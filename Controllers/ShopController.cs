using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sem_2_k_2.Models;

namespace sem_2_k_2.Controllers
{
    public class ShopController : Controller
    {
        private readonly ProductService _service;

        public ShopController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(string name, decimal price)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                _service.Add(new Product { Name = name, Price = price });
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
