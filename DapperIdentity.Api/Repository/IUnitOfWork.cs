using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperIdentity.Api.Repository
{
    public interface IUnitOfWork
    {
        IRepositoryProduct Products { get; }
        IRepositoryCategory Categories { get; }
        Task Commit();
        void Dispose();
    }
}
