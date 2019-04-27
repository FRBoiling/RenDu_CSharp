using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Base.System
{
    public abstract class AUpdateSystem<T> : IUpdateSystem
    {
        public void Run(object o)
        {
            this.Update((T)o);
        }

        public Type Type()
        {
            return typeof(T);
        }

        public abstract void Update(T self);
    }
}
