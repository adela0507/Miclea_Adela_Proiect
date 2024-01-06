using System.ComponentModel.DataAnnotations;
namespace Miclea_Adela_Proiect.Models
{
    public class Brand

        {
 public int ID { get; set; }
        [Required]
        [Display(Name = "Brand Name")]
        [StringLength(50)]
        public string BrandName { get; set; }

        [StringLength(70)]
        public string Adress { get; set; }
        public ICollection<BrandProducer> BrandProducers  { get; set; }

    
}
}
