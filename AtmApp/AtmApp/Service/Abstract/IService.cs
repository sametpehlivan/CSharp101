using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AtmApp.Entities;

namespace AtmApp.Service.Abstract
{
    public interface IService<T> where T : BaseEntitiy
    {
        List<T> GetList(Func<T, bool> filter = null);
        T Get(Func<T, bool> filter = null);
        bool Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        int GenerateId();
    }
}
