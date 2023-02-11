using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerServiceBasedRabbitMQ.Core.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }

        public int IsDeleted { get; set; }

        public ICollection<ItemDto> Items { get; set; }




    }
}
