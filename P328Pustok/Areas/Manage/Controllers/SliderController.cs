using Microsoft.AspNetCore.Mvc;
using P328Pustok.DAL;
using P328Pustok.Models;
using P328Pustok.ViewModels;

namespace P328Pustok.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController:Controller
    {
        private readonly PustokContext _context;

        public SliderController(PustokContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search = null)
        {
            var query = _context.Sliders.AsQueryable();

            if (search != null)
                query = query.Where(x => x.Name.Contains(search));

            ViewBag.Search = search;

            return View(query.ToList());
        }
    }
}
