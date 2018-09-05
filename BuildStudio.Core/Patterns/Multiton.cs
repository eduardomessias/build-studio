using System;
using System.Collections.Generic;

namespace BuildStudio.Core.Patterns
{
    public class Multiton<T> where T : class, new()
    {
        private static readonly Dictionary<string, T> instances = Activator.CreateInstance<Dictionary<string, T>>();
        private static T instance;

        public static T Instance(string key)
        {
            lock(instances)
            {
                if(!instances.TryGetValue(key, out instance))
                {
                    instance = Activator.CreateInstance<T>();

                    if(!instances.TryAdd(key, instance))
                    {
                        throw new ApplicationException($"It was not possible to add an instance of the object {typeof(T).Name}," +
                            $" by the key {key}, into our multiton dictionary. Please review your code and try again.");
                    }
                }
            }

            return instance;
        }
    }
}
