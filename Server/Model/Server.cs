using Model.Base;
using Model.Base.Object;
using Model.Entity;

namespace Model
{
    public static class Server
    {
        private static Context context;

        public static Context Context
        {
            get
            {
                if (context != null)
                {
                    return context;
                }
                context = new Context();
                return context;
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
            context.Dispose();
            context = null;
            eventSystem = null;
            objectPool = null;
        }
    }
}
