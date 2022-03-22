using Core.Interface;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbConext _context;

        public BaseRepository(AppDbConext context)
        {
            _context = context;
        }

        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public T Find(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public List<T> ListByFilter(Func<T, bool> Lamda)
        {
            return _context.Set<T>().Where(Lamda).ToList();
        }

        public void Add(T Add)
        {
            _context.Set<T>().Add(Add);
            _context.SaveChanges();
        }
    }
}