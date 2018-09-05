using System;

namespace BuildStudio.Core.Patterns
{
    public static class Singleton<T> where T : class, new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = Activator.CreateInstance<T>();

                return instance;
            }
        }
    }
}
