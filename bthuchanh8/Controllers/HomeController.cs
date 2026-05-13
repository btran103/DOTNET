using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using bthuchanh8.Models;

namespace bthuchanh8.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlbhContext _context;

        public HomeController(QlbhContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int? categoryId)
        {
            var products = _context.Products
                .Include(p => p.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            if (categoryId != null)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }

            ViewBag.Categories = _context.Categories.ToList();

            return View(await products.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}