using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerServiceBasedRabbitMQ.Core.Models
{
    public class User
    {
      

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
      

        public ICollection<Item> Items { get; set; }




    }
}
