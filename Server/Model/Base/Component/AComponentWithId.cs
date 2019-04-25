using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Component
{
    public abstract class AComponentWithId : AComponent
    {
        public long Id { get; set; }

        protected AComponentWithId()
        {
            this.Id = this.InstanceId;
        }

        protected AComponentWithId(long id)
        {
            this.Id = id;
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();
        }
    }
}
