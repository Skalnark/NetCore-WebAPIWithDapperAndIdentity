using DapperIdentity.Api.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperIdentity.Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _context;
        private RepositoryProduct _product;
        private RepositoryCategory _category;

        public UnitOfWork(IConfiguration configuration, DatabaseContext context)
        {
            _context = context;
            _configuration = configuration;
        }

        public IRepositoryProduct Products
        => _product ??= new RepositoryProduct(_configuration);

        public IRepositoryCategory Categories => _category ??= new RepositoryCategory(_configuration);

        public async Task Commit() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
