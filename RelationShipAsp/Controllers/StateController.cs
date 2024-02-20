using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RelationShipAsp.DatabaseContext;
using RelationShipAsp.Models;

namespace RelationShipAsp.Controllers
{

    public class StateController : Controller
    {

        private readonly ApplicationDbContext _context;

        public StateController(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Set<State>().AsNoTracking().ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> CreateOrEdit(int id)
        {
            var result= await _context.Set<Country>().Select(x=> new SelectListItem {Text=x.Name,Value=x.Id.ToString() }).ToListAsync();
            ViewData["CountryId"] = result;


            if (id == 0)
                return View(new State());
            else
            {
                var data = await _context.Set<State>().FindAsync(id);
                return View(data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(int id ,State state)
        {
            if (id == 0)
            {
                await _context.Set<State>().AddAsync(state);
               await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                 _context.Update(state);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
