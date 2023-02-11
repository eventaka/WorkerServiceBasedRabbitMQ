using Microsoft.EntityFrameworkCore;
using WorkerServiceBasedRabbitMQ.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerServiceBasedRabbitMQ.Infrastructure.DbContexts
{
    public interface IAppDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Item> Item { get; set; }

        Task<int> SaveChanges();
    }
}
