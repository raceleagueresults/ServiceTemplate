using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Mappings
{
    public interface IMapper<T, U>
    {
        T Map(U obj);

        U Map(T obj);

        List<T> Map(List<U> objs);

        List<U> Map(List<T> objs);
    }
}
