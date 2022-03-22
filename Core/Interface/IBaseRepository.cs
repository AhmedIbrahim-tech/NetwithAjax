using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> List();

        void Add(T Add);

        T Find(int Id);

        List<T> ListByFilter(Func<T, bool> lamda);
    }
}