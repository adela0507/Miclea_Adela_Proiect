using Microsoft.EntityFrameworkCore;
using Miclea_Adela_Proiect.Models;
using System.Net;
using System.Security.Policy;
using static System.Reflection.Metadata.BlobBuilder;

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
                    return;
                }
                Producer Producer1 = new Producer
                {
                    ProducerName = "L'Oreal"
                };
                Producer Producer2 = new Producer
                {
                    ProducerName = "Mabellinn"
                };
                Producer Producer3 = new Producer
                {
                    ProducerName = "Giordani"
                };
                Producer Producer4 = new()
                {
                    ProducerName = "Gucci"
                };
                Producer Producer5 = new Producer
                {
                    ProducerName = "NYX"

                };
                context.Producers.AddRange(Producer1, Producer2, Producer3, Producer4, Producer5);

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
                     Producer = Producer3,
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

                var orders = new Order[]
                {
                     new Order{ProductID=1,CustomerID=1050,OrderDate=DateTime.Parse("2021-02-25")},
                     new Order{ProductID=2,CustomerID=1045,OrderDate=DateTime.Parse("2021-09-25")},
                     new Order{ProductID=3,CustomerID=1050,OrderDate=DateTime.Parse("2021-12-25")},
                     new Order{ProductID=4,CustomerID=1045,OrderDate=DateTime.Parse("2021-03-25")},
                     new Order{ProductID=1,CustomerID=1045,OrderDate=DateTime.Parse("2021-02-25")},

                 };

                foreach (Order e in orders)
                {
                    context.Orders.Add(e);
                }
                context.SaveChanges();
                var brands = new Brand[]
 {

 new Brand{BrandName="Donna Karan",Adress="Str. Aviatorilor, nr. 40,Bucuresti"},
 new Brand{BrandName= "La Mer", Adress="Str. Aviatorilor, nr. 50,Bucuresti"},
 new Brand{BrandName= "MAC Cosmetics", Adress="Str. Aviatorilor, nr. 60,Bucuresti"},
 new Brand{BrandName="Aveda",Adress="Str. Aviatorilor, nr. 70,Bucuresti"}, };
                foreach (Brand p in brands)
                {
                    context.Brands.Add(p);
                }
                context.SaveChanges();

                var product = context.Products;
                var brandproducers = new BrandProducer[]
                {
                    new BrandProducer
                    {
                        ProductID = product.Single(c => c.Name == "Fond de ten" ).ID,
                        BrandID = brands.Single(i => i.BrandName =="Donna Karan").ID
                    },
                    new BrandProducer
                    {
                        ProductID = product.Single(c => c.Name == "Rimel" ).ID,
                        BrandID = brands.Single(i => i.BrandName =="Donna Karan").ID
                    },
                   new BrandProducer
                    {
                        ProductID = product.Single(c => c.Name == "Rimel" ).ID,
                        BrandID = brands.Single(i => i.BrandName =="Donna Karan").ID
                    },

                    };
                foreach (BrandProducer pb in brandproducers)
                {
                    context.BrandProducers.Add(pb);
                }
                context.SaveChanges();

            }
        }
    }

}
