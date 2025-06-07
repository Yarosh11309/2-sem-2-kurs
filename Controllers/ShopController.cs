using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sem_2_k_2.Models;
using sem_2_k_2.Services;

namespace sem_2_k_2.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _service;

        public ShopController(IProductService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(string name, decimal price)
        {
            _service.Add(new Product { Name = name, Price = price });
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
