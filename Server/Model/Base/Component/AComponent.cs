using Model.Base.Helper;
using Model.Base.Object;
using System;
using System.Diagnostics;

namespace Model.Base.Component
{
    public abstract class AComponent : AObject, IDisposable
    {
        public long InstanceId { get; private set; }

        private bool isFromPool;

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

        public bool IsDisposed
        {
            get
            {
                return this.InstanceId == 0;
            }
        }

        private AComponent parent;

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
            Server.EventSystem.Destroy(this);

            Server.EventSystem.Remove(this.InstanceId);

            this.InstanceId = 0;

            if (this.IsFromPool)
            {
                Server.ObjectPool.Recycle(this);
            }
            else
            {
            }
        }

        public override void EndInit()
        {
            Server.EventSystem.Deserialize(this);
        }

        public override string ToString()
        {
            return MongoHelper.ToJson(this);
        }
    }
}
