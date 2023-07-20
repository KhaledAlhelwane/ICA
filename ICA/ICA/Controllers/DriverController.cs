using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICA.Data;
using ICA.Models;
using ICA.Data.Migrations;
using ICA.ViewModel;

namespace ICA.Controllers
{
    public class DriverController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hosting;

        public DriverController(ApplicationDbContext context, IWebHostEnvironment Hosting)
        {
            _context = context;
            hosting = Hosting;
        }

        // GET: Driver
        public async Task<IActionResult> Index()
        {
              return _context.Bus != null ? 
                          View(await _context.Bus.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Bus'  is null.");
        }

        // GET: Driver/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bus == null)
            {
                return NotFound();
            }

            var bus = await _context.Bus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bus == null)
            {
                return NotFound();
            }
            
            return View(bus);
        }

        // GET: Driver/Create
        public IActionResult Create()
        {



            return View();
        }

        // POST: Driver/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( DriverViewModel bus)
        {
            if (ModelState.IsValid)
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                //شو نعمل شلون بدنا نحكيي (:
                string filenamePhoto1 = string.Empty;
                string filenamePhoto2 = string.Empty;
                filenamePhoto1 = Guid.NewGuid().ToString() + bus.Photo1File.FileName;
                filenamePhoto2 = Guid.NewGuid().ToString() + bus.Photo2File.FileName;
                string uploads = Path.Combine(hosting.WebRootPath, "BusKilometer");
                string fullpathPhoto1 = Path.Combine(uploads, filenamePhoto1);
                string fullpathPhoto2 = Path.Combine(uploads, filenamePhoto2);
             bus.Photo1File.CopyTo(new FileStream(fullpathPhoto1  , FileMode.Create));
             bus.Photo2File.CopyTo(new FileStream(fullpathPhoto2, FileMode.Create));
                Bus BusMession = new Bus
                {
                    Check = false,
                    Des = bus.Des,
                    DigitDes = bus.DigitDes,
                    DigitSurce = bus.DigitSurce,
                    FullName = bus.FullName,
                    Source = bus.Source,
                    TIME = bus.TIME,
                    Photo1=filenamePhoto1,
                    Photo2=filenamePhoto2
                   ,
                    RealTIME = DateTime.Now
                };
                _context.Add(BusMession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bus);
        }

        // GET: Driver/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bus == null)
            {
                return NotFound();
            }

            var bus = await _context.Bus.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }
            return View(bus);
        }

        // POST: Driver/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Photo1,DigitSurce,Photo2,DigitDes,Source,Des,TIME,Check")] Bus bus)
        {
            if (id != bus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusExists(bus.Id))
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
            return View(bus);
        }

        // GET: Driver/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bus == null)
            {
                return NotFound();
            }

            var bus = await _context.Bus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // POST: Driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bus'  is null.");
            }
            var bus = await _context.Bus.FindAsync(id);
            if (bus != null)
            {
                _context.Bus.Remove(bus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusExists(int id)
        {
          return (_context.Bus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
