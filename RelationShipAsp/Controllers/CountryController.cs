using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelationShipAsp.DatabaseContext;
using RelationShipAsp.Models;

namespace RelationShipAsp.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CountryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
       
        public async Task< IActionResult> Index()
        {
            var data = await context.Set<Country>().AsNoTracking().ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if(id == 0)
            {
                return View(new Country());
            }
            else
            {
                return View(await context.Set<Country>().FindAsync(id));
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(int id,Country country)
        {
            if (id==0)
            {
                if (ModelState.IsValid)
                {
                  await  context.Set<Country>().AddAsync(country);
                   await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                    
                }


            }
            else
            {
                context.Set<Country>().Update(country);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(country);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await context.Set<Country>().FindAsync(id);
            if (data != null)
            {
                context.Set<Country>().Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


    }
}
