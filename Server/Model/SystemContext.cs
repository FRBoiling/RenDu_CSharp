using Model.Base;
using Model.Base.Object;
using Model.Entity;

namespace Model
{
    public static class SystemContext
    {
        private static SystemEntity systemEntity;

        public static SystemEntity SystemEntity
        {
            get
            {
                if (systemEntity != null)
                {
                    return systemEntity;
                }
                systemEntity = new SystemEntity();
                return systemEntity;
            }
        }

        private static EventSystem eventSystem;

        public static EventSystem EventSystem
        {
            get
            {
                return eventSystem ?? (eventSystem = new EventSystem());
            }
        }

        private static ObjectPool objectPool;

        public static ObjectPool ObjectPool
        {
            get
            {
                return objectPool ?? (objectPool = new ObjectPool());
            }
        }

        public static void Close()
        {
            systemEntity.Dispose();
            systemEntity = null;
            objectPool = null;
            eventSystem = null;
        }
    }
}
