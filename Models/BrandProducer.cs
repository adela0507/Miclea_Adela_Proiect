using System.Security.Policy;

namespace Miclea_Adela_Proiect.Models
{
    public class BrandProducer
    {
        public int BrandID { get; set; }
        public int ProductID { get; set; }
        public int ProducerID { get; set; }

        public Brand Brand{ get; set; }
        public Product Product { get; set; }
        public Producer Producer { get; set; }

    }
}
