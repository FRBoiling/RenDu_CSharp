using Model.Base.Logger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Base.Component
{
    public class BaseEntity : AComponentWithId
    {
        private Dictionary<Type, AComponent> componentDict = new Dictionary<Type, AComponent>();
        private HashSet<AComponent> components = new HashSet<AComponent>();


        public BaseEntity()
        {
        }

        protected BaseEntity(long id) : base(id)
        {
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();

            foreach (AComponent component in this.componentDict.Values)
            {
                try
                {
                    component.Dispose();
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }

            this.components.Clear();
            this.componentDict.Clear();
        }

        public virtual AComponent AddComponent(AComponent component)
        {
            Type type = component.GetType();
            if (this.componentDict.ContainsKey(type))
            {
                throw new Exception($"AddComponent, component already exist, id: {this.Id}, component: {type.Name}");
            }

            component.Parent = this;

            this.componentDict.Add(type, component);

            if (component is ISerializeToEntity)
            {
                this.components.Add(component);
            }

            return component;
        }

        public virtual AComponent AddComponent(Type type)
        {
            if (this.componentDict.ContainsKey(type))
            {
                throw new Exception($"AddComponent, component already exist, id: {this.Id}, component: {type.Name}");
            }

            AComponent component = ComponentFactory.CreateWithParent(type, this, this.IsFromPool);

            this.componentDict.Add(type, component);

            if (component is ISerializeToEntity)
            {
                this.components.Add(component);
            }

            return component;
        }

        public virtual K AddComponent<K>() where K : AComponent, new()
        {
            Type type = typeof(K);
            if (this.componentDict.ContainsKey(type))
            {
                throw new Exception($"AddComponent, component already exist, id: {this.Id}, component: {typeof(K).Name}");
            }

            K component = ComponentFactory.CreateWithParent<K>(this, this.IsFromPool);

            this.componentDict.Add(type, component);

            if (component is ISerializeToEntity)
            {
                this.components.Add(component);
            }

            return component;
        }

        public virtual K AddComponent<K, P1>(P1 p1) where K : AComponent, new()
        {
            Type type = typeof(K);
            if (this.componentDict.ContainsKey(type))
            {
                throw new Exception($"AddComponent, component already exist, id: {this.Id}, component: {typeof(K).Name}");
            }

            K component = ComponentFactory.CreateWithParent<K, P1>(this, p1, this.IsFromPool);

            this.componentDict.Add(type, component);

            if (component is ISerializeToEntity)
            {
                this.components.Add(component);
            }

            return component;
        }

        public virtual K AddComponent<K, P1, P2>(P1 p1, P2 p2) where K : AComponent, new()
        {
            Type type = typeof(K);
            if (this.componentDict.ContainsKey(type))
            {
                throw new Exception($"AddComponent, component already exist, id: {this.Id}, component: {typeof(K).Name}");
            }

            K component = ComponentFactory.CreateWithParent<K, P1, P2>(this, p1, p2, this.IsFromPool);

            this.componentDict.Add(type, component);

            if (component is ISerializeToEntity)
            {
                this.components.Add(component);
            }

            return component;
        }

        public virtual K AddComponent<K, P1, P2, P3>(P1 p1, P2 p2, P3 p3) where K : AComponent, new()
        {
            Type type = typeof(K);
            if (this.componentDict.ContainsKey(type))
            {
                throw new Exception($"AddComponent, component already exist, id: {this.Id}, component: {typeof(K).Name}");
            }

            K component = ComponentFactory.CreateWithParent<K, P1, P2, P3>(this, p1, p2, p3, this.IsFromPool);

            this.componentDict.Add(type, component);

            if (component is ISerializeToEntity)
            {
                this.components.Add(component);
            }

            return component;
        }

        public virtual void RemoveComponent<K>() where K : AComponent
        {
            if (this.IsDisposed)
            {
                return;
            }
            Type type = typeof(K);
            AComponent component;
            if (!this.componentDict.TryGetValue(type, out component))
            {
                return;
            }

            this.componentDict.Remove(type);
            this.components.Remove(component);

            component.Dispose();
        }

        public virtual void RemoveComponent(Type type)
        {
            if (this.IsDisposed)
            {
                return;
            }
            AComponent component;
            if (!this.componentDict.TryGetValue(type, out component))
            {
                return;
            }

            this.componentDict.Remove(type);
            this.components.Remove(component);

            component.Dispose();
        }

        public K GetComponent<K>() where K : AComponent
        {
            AComponent component;
            if (!this.componentDict.TryGetValue(typeof(K), out component))
            {
                return default(K);
            }
            return (K)component;
        }

        public AComponent GetComponent(Type type)
        {
            AComponent component;
            if (!this.componentDict.TryGetValue(type, out component))
            {
                return null;
            }
            return component;
        }

        public AComponent[] GetComponents()
        {
            return this.componentDict.Values.ToArray();
        }

        public override void EndInit()
        {
            try
            {
                base.EndInit();

                this.componentDict.Clear();

                if (this.components != null)
                {
                    foreach (AComponent component in this.components)
                    {
                        component.Parent = this;
                        this.componentDict.Add(component.GetType(), component);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
