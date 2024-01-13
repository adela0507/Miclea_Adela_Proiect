using Microsoft.EntityFrameworkCore;
using Miclea_Adela_Proiect.Models;
using System.Net;

namespace Miclea_Adela_Proiect.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new
           ProductContext(serviceProvider.GetRequiredService
            <DbContextOptions<ProductContext>>()))
            {
                if (context.Products.Any())
                {
                    return; // BD a fost creata anterior
                }
                Producer Producer1 = new Producer
                {
                    ProducerName="L'Oreal" 
                };
                Producer Producer2 = new Producer
                {
                    ProducerName = "Mabellinn"
                };
                Producer Producer3 = new Producer
                {
                    ProducerName = "Giordani"
                };
               
                context.Producers.AddRange(Producer1, Producer2, Producer3 );

                context.Products.AddRange(
                new Product
                {
                    Name = "Fond de ten",
                    Producer = Producer1,
                    Price = Decimal.Parse("22")
                },

                 new Product
                 {
                     Name = "Rimel",
                     Producer = Producer2,
                     Price = Decimal.Parse("22")
                 },
                 new Product
                 {
                     Name = "Iluminator",
                     Producer=Producer3,
                     Price = Decimal.Parse("22")
                 },
                  new Product
                  {
                      Name = "Iluminator",
                      Producer = Producer2,
                      Price = Decimal.Parse("22")
                  }
                );


                context.Customers.AddRange(
                new Customer
                {
                    CustomerName = "Popescu Marcela",
                    Address = "Str. Plopilor, nr. 24",
                    PhoneNumber = ("0745822444"),
                },
                new Customer
                 {
                    CustomerName = "Popescu Marcela",
                    Address = "Str. Plopilor, nr. 24",
                    PhoneNumber = ("0745822444"),
                }
                );

                context.SaveChanges();
            }
        }
    }

}
