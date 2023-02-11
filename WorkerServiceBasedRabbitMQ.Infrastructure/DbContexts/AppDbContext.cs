using Microsoft.EntityFrameworkCore;
using WorkerServiceBasedRabbitMQ.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerServiceBasedRabbitMQ.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        
        
        public DbSet<User> User { get; set; }        
        public DbSet<Item> Item { get; set; }



       

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
