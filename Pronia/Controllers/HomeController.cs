using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;

namespace Pronia.Controllers
{
    public class HomeController : Controller
    {
        readonly ProniaDbContext _context;

        public HomeController(ProniaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> slider = _context.Sliders.OrderBy(s => s.Order).ToList();
            ViewBag.RelatedPlant = _context.Plants.ToList();
            return View(slider);
        }
    }
}