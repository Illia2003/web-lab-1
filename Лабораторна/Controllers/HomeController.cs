using Microsoft.AspNetCore.Mvc;
using Лабораторна.Models;

namespace Лабораторна.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db = new ProductContext();

        // GET: /Home/
        public IActionResult Index()
        {
            IEnumerable<Product> products = db.Products;
            ViewBag.Products = products;
            return View();
        }

        // GET: /Home/Buy/{id}
        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Buy(Order order) {
            order.Date = DateTime.Now;

            db.Orders.Add(order);
            db.SaveChanges();

            return RedirectToAction("Confirm", "Home", new { Person = order.Person });
        }

        public IActionResult Confirm(string Person)
        {
			ViewBag.Person = Person;
			return View();
		}
	}
}
