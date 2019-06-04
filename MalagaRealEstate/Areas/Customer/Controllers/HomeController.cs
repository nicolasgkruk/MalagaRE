using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MalagaRealEstate.Models;
using MalagaRealEstate.Data;
using Microsoft.EntityFrameworkCore;

namespace MalagaRealEstate.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Properties.ToListAsync());
        }

        public async Task<IActionResult> Filtro(string criterio)
        {
            switch (criterio)
            {
                case "filtroPrecio":
                    return PartialView("_FiltrosPartial", await _context.Properties.OrderBy(x => x.OwnerPrice).ToListAsync());

                case "filtroFecha":
                    return PartialView("_FiltrosPartial", await _context.Properties.OrderByDescending(x => x.Updated).ToListAsync());

                case "filtroGaraje":
                    return PartialView("_FiltrosPartial", await _context.Properties.Where(z => z.Garaje == true).ToListAsync());

                case "filtroPisos":
                    return PartialView("_FiltrosPartial", await _context.Properties.Where(z => z.PropType == "piso").ToListAsync());

                case "filtroCasas":
                    return PartialView("_FiltrosPartial", await _context.Properties.Where(z => z.PropType == "casaOChalet").ToListAsync());
                default:
                    return PartialView("_FiltrosPartial", await _context.Properties.ToListAsync());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var propertyFromDb = await _context.Properties
                .Where(m => m.Id == id).FirstOrDefaultAsync();

            return View(propertyFromDb);
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
