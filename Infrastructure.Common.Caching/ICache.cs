using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Caching
{
    public interface ICache<T>
    {
        void Add(T obj, string id);

        void Add(List<T> obj, string id);

        T Get(string id);

        List<T> GetAll(string id);

        void Remove(string id);

        void Update(T obj, string id);
    }
}
