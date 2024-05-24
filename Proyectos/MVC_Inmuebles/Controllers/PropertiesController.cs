using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_devhive.Data;

namespace MVC_devhive.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly RealEstateContext _context;

        public PropertiesController(RealEstateContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Properties.ToListAsync());
        }

        public async Task<IActionResult> Table()
        {
            return View(await _context.Properties.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Properties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

    }
}
