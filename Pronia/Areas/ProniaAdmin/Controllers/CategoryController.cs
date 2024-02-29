using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;

namespace Pronia.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class CategoryController : Controller
    {
        private readonly ProniaDbContext _context;

        public CategoryController(ProniaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories.AsEnumerable();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult Creates(Category newCategory)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name","You cannot duplicate category name");
                return View();
            }
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            Console.WriteLine("Hello World");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            if (id == 0) return NotFound();
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null) return NotFound();
            return View(category);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null) return NotFound();
            return View();
        }


        [HttpPost]
        public IActionResult Delete(int id,Category delete)
        {
            if (id != delete.Id) return BadRequest();
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null) return NotFound();
            delete=_context.Categories.FirstOrDefault(_c => _c.Id == id); 
            if (delete is null) return NotFound();
            _context.Categories.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
