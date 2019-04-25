using Model.Component;
using System;
using System.Collections.Generic;

namespace Model.Object
{
    public class ObjectPool : AComponent
    {
        public string Name { get; set; }

        private readonly Dictionary<Type, ComponentQueue> dictionary = new Dictionary<Type, ComponentQueue>();

        public AComponent Fetch(Type type)
        {
            AComponent obj;
            if (!this.dictionary.TryGetValue(type, out ComponentQueue queue))
            {
                obj = (AComponent)Activator.CreateInstance(type);
            }
            else if (queue.Count == 0)
            {
                obj = (AComponent)Activator.CreateInstance(type);
            }
            else
            {
                obj = queue.Dequeue();
            }

            obj.IsFromPool = true;
            return obj;
        }

        public T Fetch<T>() where T : AComponent
        {
            T t = (T)this.Fetch(typeof(T));
            return t;
        }

        public void Recycle(AComponent obj)
        {
            obj.Parent = this;
            Type type = obj.GetType();
            ComponentQueue queue;
            if (!this.dictionary.TryGetValue(type, out queue))
            {
                queue = new ComponentQueue(type.Name);
                queue.Parent = this;
                this.dictionary.Add(type, queue);
            }
            queue.Enqueue(obj);
        }

        public void Clear()
        {
            foreach (var kv in this.dictionary)
            {
                kv.Value.IsFromPool = false;
                kv.Value.Dispose();
            }
            this.dictionary.Clear();
        }
    }
}
