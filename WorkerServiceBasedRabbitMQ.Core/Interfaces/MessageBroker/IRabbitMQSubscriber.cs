
using System;
using System.Collections.Generic;
using System.Text;
using WorkerServiceBasedRabbitMQ.Core.Models;

namespace ServiceBasedRabbit.Core.Interfaces.MessageBroker
{
    public interface IRabbitMQSubscriber 
    {
        public IEnumerable<User> Subscribe();
        //public IEnumerable<T> Subscribe<T>();

    }
}
