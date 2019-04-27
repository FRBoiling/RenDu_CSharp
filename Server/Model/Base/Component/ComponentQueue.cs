using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Base.Component
{
    public class ComponentQueue : AComponent
    {
        public string TypeName { get; }

        private readonly Queue<AComponent> queue = new Queue<AComponent>();

        public ComponentQueue(string typeName)
        {
            this.TypeName = typeName;
        }

        public void Enqueue(AComponent component)
        {
            component.Parent = this;
            this.queue.Enqueue(component);
        }

        public AComponent Dequeue()
        {
            return this.queue.Dequeue();
        }

        public AComponent Peek()
        {
            return this.queue.Peek();
        }

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            base.Dispose();

            while (this.queue.Count > 0)
            {
                AComponent component = this.queue.Dequeue();
                component.IsFromPool = false;
                component.Dispose();
            }
        }
    }
}
