using Model.Base.Helper;
using Model.Base.Object;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Diagnostics;

namespace Model.Base.Component
{
    [BsonIgnoreExtraElements]
    public abstract class AComponent : AObject, IDisposable
    {
		[BsonIgnore]
        public long InstanceId { get; private set; }

		[BsonIgnore]
        private bool isFromPool;

		[BsonIgnore]
        public bool IsFromPool
        {
            get
            {
                return this.isFromPool;
            }
            set
            {
                this.isFromPool = value;

                if (!this.isFromPool)
                {
                    return;
                }

                if (this.InstanceId == 0)
                {
                    this.InstanceId = IdGeneraterHelper.GenerateInstanceId();
                }
            }
        }

		[BsonIgnore]
        public bool IsDisposed
        {
            get
            {
                return this.InstanceId == 0;
            }
        }

        private AComponent parent;

		[BsonIgnore]
        public AComponent Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
            }
        }

        public T GetParent<T>() where T : AComponent
        {
            return this.Parent as T;
        }

		[BsonIgnore]
        public BaseEntity Entity
        {
            get
            {
                return this.Parent as BaseEntity;
            }
        }

        protected AComponent()
        {
            this.InstanceId = IdGeneraterHelper.GenerateInstanceId();
        }


        public virtual void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            // 触发Destroy事件
            SystemContext.EventSystem.Destroy(this);

            SystemContext.EventSystem.Remove(this.InstanceId);

            this.InstanceId = 0;

            if (this.IsFromPool)
            {
                SystemContext.ObjectPool.Recycle(this);
            }
            else
            {
            }
        }

        public override void EndInit()
        {
            SystemContext.EventSystem.Deserialize(this);
        }

        public override string ToString()
        {
            return MongoHelper.ToJson(this);
        }
    }
}
