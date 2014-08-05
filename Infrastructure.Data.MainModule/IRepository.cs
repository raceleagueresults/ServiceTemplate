using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MainModule
{
    public interface IRepository<T>
    {
        List<T> GetManyBy(Func<T, bool> predicate);

        T GetBy(Func<T, bool> predicate);

        T Add(T item);

        T Update(T item);

        T Delete(int id);
    }
}
