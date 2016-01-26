using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(object Id);

        void Insert(T model);

        void Update(T model);

        void Delete(object id);

        void Save();
    }
}
