using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Miclea_Adela_Proiect.Models
{
    public class Product
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public int? ProducerID { get; set; }
        public Producer? Producer { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
