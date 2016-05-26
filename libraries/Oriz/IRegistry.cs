using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oriz
{
    public interface IRegistry<T>
        where T: class, IEntity
    {
        void Register(T entity);
        T Get(string key);
    }
}
