using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceBasedRabbitMQ.Core.Dto;
using WorkerServiceBasedRabbitMQ.Core.Interfaces;
using WorkerServiceBasedRabbitMQ.Core.Models;
using WorkerServiceBasedRabbitMQ.Infrastructure.DbContexts;

namespace WorkerServiceBasedRabbitMQ.Infrastructure.Repositories
{
    public class CreateUserRepository : ICreateUserRepository
    {
        private readonly IAppDbContext _appDbContext;
        public CreateUserRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       


        public async Task<int> CreateUserAsync(User user)
        {
            _appDbContext.User.Add(user);
            await _appDbContext.SaveChanges();
            return user.UserId;


        }
    }
}
