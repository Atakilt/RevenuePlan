using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RevenuTypesController : Controller
    {
        private readonly AppDbContext _context;

        public RevenuTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RevenuTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RevenuTypes.ToListAsync());
        }

        // GET: RevenuTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revenuType = await _context.RevenuTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revenuType == null)
            {
                return NotFound();
            }

            return View(revenuType);
        }
        // GET: RevenuTypes/Revenue
        public IActionResult Revenue()
        {
            var revenue = _context.RevenuTypes.ToList();

            var lstRevenueTypes = new RevenueViewModel
            {
                RevenuTypesList = revenue
            };

            return View(lstRevenueTypes);
        }

        [HttpPost]
        public IActionResult Revenue(RevenueViewModel revenueViewModel)
        {
            return View();
        }
        // GET: RevenuTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RevenuType revenuType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(revenuType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(revenuType);
        }

        // GET: RevenuTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revenuType = await _context.RevenuTypes.FindAsync(id);
            if (revenuType == null)
            {
                return NotFound();
            }
            return View(revenuType);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RevenuType revenuType)
        {
            if (id != revenuType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revenuType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevenuTypeExists(revenuType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(revenuType);
        }

        // GET: RevenuTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revenuType = await _context.RevenuTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revenuType == null)
            {
                return NotFound();
            }

            return View(revenuType);
        }

        // POST: RevenuTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var revenuType = await _context.RevenuTypes.FindAsync(id);
            _context.RevenuTypes.Remove(revenuType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevenuTypeExists(int id)
        {
            return _context.RevenuTypes.Any(e => e.Id == id);
        }
    }
}
