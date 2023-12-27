using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Miclea_Adela_Proiect.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
