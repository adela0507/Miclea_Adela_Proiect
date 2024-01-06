using Microsoft.EntityFrameworkCore;
using Miclea_Adela_Proiect.Data;
using Miclea_Adela_Proiect.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Miclea_Adela_Proiect.ProductViewModels;

namespace Miclea_Adela_Proiect.Controllers
{
    public class HomeController : Controller

    {
        private readonly ProductContext _context;
        public HomeController(ProductContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data =
            from order in _context.Orders
            group order by order.OrderDate into dateGroup
            select new OrderGroup()
            {
                OrderDate = dateGroup.Key,
                ProductCount = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }

       // private readonly ILogger<HomeController> _logger;

      /*  public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
      */
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}