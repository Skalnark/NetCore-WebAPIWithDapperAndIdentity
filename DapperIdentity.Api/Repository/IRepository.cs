using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DapperIdentity.Api.Repository
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);

        Task<int> Add(T entity);
        Task<int> Update(T entity);
        void Delete(int id);
    }
}
