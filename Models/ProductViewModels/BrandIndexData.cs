using System.Security.Policy;

namespace Miclea_Adela_Proiect.Models.ProductViewModels
{
    public class BrandIndexData
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Product> Products{ get; set; }
        public IEnumerable<Order> Orders { get; set; }

    }
}
