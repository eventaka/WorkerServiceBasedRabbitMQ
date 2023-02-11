using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerServiceBasedRabbitMQ.Core.Models
{
    public class Item
    {
       

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }
        public string Description { get; set; }
        public int IsDeleted { get; set; }

     

    }
}
