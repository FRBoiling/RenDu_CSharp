using Model.Base;
using Model.Helper;
using Model.Object;
using System;

namespace Model.Component
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
                    this.InstanceId = IdGenerater.GenerateInstanceId();
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

        public Entity Entity
        {
            get
            {
                return this.Parent as Entity;
            }
        }

        protected AComponent()
        {
            this.InstanceId = IdGenerater.GenerateInstanceId();
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
            return "TODO:BOIL help mongohelpoer to json";
            //return MongoHelper.ToJson(this);
        }
    }
}
