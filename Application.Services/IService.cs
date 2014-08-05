using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IService<T>
    {
        List<T> GetManyBy(Func<T, bool> predicate);

        T GetBy(Func<T, bool> predicate);

        T Add(T item);

        T Update(T item);

        T Delete(int id);
    }
}
