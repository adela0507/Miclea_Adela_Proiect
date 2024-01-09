using System.ComponentModel.DataAnnotations;

namespace Miclea_Adela_Proiect.Models.ProductViewModels
{
    public class OrderGroup
    {
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public int ProductCount { get; set; }
    }
}
