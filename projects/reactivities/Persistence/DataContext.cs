using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext 
    {
        /* must pass `options` to base for migrations to work   */
        public DataContext(DbContextOptions options): base(options)
        {
            
        }

        /* this will be used to generate the table name  */
        public DbSet<Value> Values { get; set;}
    }
}
