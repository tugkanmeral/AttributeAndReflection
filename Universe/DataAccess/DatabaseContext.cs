using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Universe.Entity;

namespace Universe.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserTest> UserTests { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) 
        { 
        }

        public override TEntity Find<TEntity>(params object[] keyValues)
        {

            return base.Find<TEntity>(keyValues);
        }
    }
}
