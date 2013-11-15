using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextApp.Components.Repository.Abstract
{
    public interface IGenericRepository<T>
    {
        T Create(T entity);
        void Delete(int id);
        System.Collections.Generic.List<T> Read();
        T Read(int id);
        System.Collections.Generic.List<T> Read(int page, int pageSize);
        T Update(T entity);
    }
}
