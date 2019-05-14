using Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Base.Component
{
    public static class ComponentFactory
    {
        public static AComponent CreateWithParent(Type type, AComponent parent, bool fromPool = true)
        {
            AComponent component;
            //if (fromPool)
            //{
            //    component = Game.ObjectPool.Fetch(type);
            //}
            //else
            {
                component = (AComponent)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            component.Parent = parent;
            if (component is AComponentWithId componentWithId)
            {
                componentWithId.Id = component.InstanceId;
            }
            SystemContext.EventSystem.Awake(component);
            return component;
        }

        public static T CreateWithParent<T>(AComponent parent, bool fromPool = true) where T : AComponent
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            component.Parent = parent;
            if (component is AComponentWithId componentWithId)
            {
                componentWithId.Id = component.InstanceId;
            }
            SystemContext.EventSystem.Awake(component);
            return component;
        }

        public static T CreateWithParent<T, A>(AComponent parent, A a, bool fromPool = true) where T : AComponent
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            component.Parent = parent;
            if (component is AComponentWithId componentWithId)
            {
                componentWithId.Id = component.InstanceId;
            }
            SystemContext.EventSystem.Awake(component, a);
            return component;
        }

        public static T CreateWithParent<T, A, B>(AComponent parent, A a, B b, bool fromPool = true) where T : AComponent
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            component.Parent = parent;
            if (component is AComponentWithId componentWithId)
            {
                componentWithId.Id = component.InstanceId;
            }
            SystemContext.EventSystem.Awake(component, a, b);
            return component;
        }

        public static T CreateWithParent<T, A, B, C>(AComponent parent, A a, B b, C c, bool fromPool = true) where T : AComponent
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            component.Parent = parent;
            if (component is AComponentWithId componentWithId)
            {
                componentWithId.Id = component.InstanceId;
            }
            SystemContext.EventSystem.Awake(component, a, b, c);
            return component;
        }

        public static T Create<T>(bool fromPool = true) where T : AComponent
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            if (component is AComponentWithId componentWithId)
            {
                componentWithId.Id = component.InstanceId;
            }
            SystemContext.EventSystem.Awake(component);
            return component;
        }

        public static T Create<T, A>(A a, bool fromPool = true) where T : AComponent
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            if (component is AComponentWithId componentWithId)
            {
                componentWithId.Id = component.InstanceId;
            }
            SystemContext.EventSystem.Awake(component, a);
            return component;
        }

        public static T Create<T, A, B>(A a, B b, bool fromPool = true) where T : AComponent
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            if (component is AComponentWithId componentWithId)
            {
                componentWithId.Id = component.InstanceId;
            }
            SystemContext.EventSystem.Awake(component, a, b);
            return component;
        }

        public static T Create<T, A, B, C>(A a, B b, C c, bool fromPool = true) where T : AComponent
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            if (component is AComponentWithId componentWithId)
            {
                componentWithId.Id = component.InstanceId;
            }
            SystemContext.EventSystem.Awake(component, a, b, c);
            return component;
        }

        public static T CreateWithId<T>(long id, bool fromPool = true) where T : AComponentWithId
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            component.Id = id;
            SystemContext.EventSystem.Awake(component);
            return component;
        }

        public static T CreateWithId<T, A>(long id, A a, bool fromPool = true) where T : AComponentWithId
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            component.Id = id;
            SystemContext.EventSystem.Awake(component, a);
            return component;
        }

        public static T CreateWithId<T, A, B>(long id, A a, B b, bool fromPool = true) where T : AComponentWithId
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            component.Id = id;
            SystemContext.EventSystem.Awake(component, a, b);
            return component;
        }

        public static T CreateWithId<T, A, B, C>(long id, A a, B b, C c, bool fromPool = true) where T : AComponentWithId
        {
            Type type = typeof(T);

            T component;
            if (fromPool)
            {
                component = (T)SystemContext.ObjectPool.Fetch(type);
            }
            else
            {
                component = (T)Activator.CreateInstance(type);
            }

            SystemContext.EventSystem.Add(component);

            component.Id = id;
            SystemContext.EventSystem.Awake(component, a, b, c);
            return component;
        }
    }
}
