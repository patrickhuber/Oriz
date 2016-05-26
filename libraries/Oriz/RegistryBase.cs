using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz
{
    public abstract class RegistryBase<T> : IRegistry<T>
        where T : class, IEntity
    {
        private IDictionary<string, T> _dictionary;

        public T Get(string key)
        {
            T value = null;
            if (_dictionary.TryGetValue(key, out value))
                return value;
            return null;
        }

        public void Register(T entity)
        {
            _dictionary[entity.Id] = entity;
        }
    }
}
