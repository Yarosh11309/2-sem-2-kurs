using Microsoft.AspNetCore.Mvc;
using sem_2_k_2.Models;

namespace sem_2_k_2.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;
        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.Items.ToList();
            return View(items);
        }
    }
}
