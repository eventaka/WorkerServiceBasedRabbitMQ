using WorkerServiceBasedRabbitMQ.Core.Dto;
using WorkerServiceBasedRabbitMQ.Core.Models;
using System;
using System.Threading.Tasks;

namespace WorkerServiceBasedRabbitMQ.Core.Interfaces
{
    public interface ICreateUserRepository
    {
        public Task<int> CreateUserAsync(User user);
        
    }
}
