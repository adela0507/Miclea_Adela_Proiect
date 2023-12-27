namespace Miclea_Adela_Proiect.Models
{
    public class Producer
    {
        public string ProducerID { get; set; }
        public string? ProducerName { get; set; }
        public string ProducerCountry { get; set; }
        public ICollection<Product>? Products { get; set; }
        public Producer()
        {
            Products = new List<Product>(); 
        }
    }
}
