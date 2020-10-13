using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperIdentity.Api.Entities;

namespace DapperIdentity.Api.Context
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        public DbSet<DapperIdentity.Api.Entities.Product> Product { get; set; }

        public DbSet<DapperIdentity.Api.Entities.Category> Category { get; set; }
    }
}
