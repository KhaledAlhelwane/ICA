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
using Microsoft.AspNetCore.Authorization;
using ImageMagick;
using ICA.Services;

namespace ICA.Controllers
{
    [Authorize(Roles ="Driver")]
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
                          View(await _context.Bus.OrderByDescending(a=>a.Id).ToListAsync()) :
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
                bool compressingImage1=   await ImageCompresser.BusImageCompresser(uploads, filenamePhoto1);
              
                bool compressingImage2=   await ImageCompresser.BusImageCompresser(uploads, filenamePhoto2);
                if (compressingImage1)
                {
                    filenamePhoto1 = "Resized" + filenamePhoto1;
                }

                if (compressingImage2)
                {
                    filenamePhoto2 = "Resized" + filenamePhoto2;
                }

               
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
            var EditMession = new EditDriverViewModel
            {
                Id = bus.Id,
                FullName = bus.FullName,
                Photo1 = bus.Photo1,
                DigitSurce = bus.DigitSurce,
                Photo2 = bus.Photo2,
                DigitDes = bus.DigitDes,
                Source = bus.Source,
                Des = bus.Des,
                TIME = bus.TIME,

            };
            return View(EditMession);
        }

        // POST: Driver/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditDriverViewModel EditMession)
        {
            if (id != EditMession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var NewMission = await _context.Bus.FindAsync(id);
                try
                {
                     string uploads = Path.Combine(hosting.WebRootPath, "BusKilometer");
                      
                    if (EditMession.Photo1File != null)
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        //شو نعمل شلون بدنا نحكيي (:
                        string filename1 = string.Empty;
                        filename1 = Guid.NewGuid().ToString() + EditMession.Photo1File.FileName;
                         string fullpath = Path.Combine(uploads, filename1);
                        //Delete Old Picture

                        string OldFile1 = EditMession.Photo1;
                        string fullOldpath1 = Path.Combine(uploads, OldFile1);
                        string fullOldResizedpath1 = Path.Combine(uploads,"Resized"+OldFile1);
                        System.IO.File.Delete(fullOldpath1);
                        if (System.IO.File.Exists(fullOldResizedpath1))
                        {
                            System.IO.File.Delete(fullOldResizedpath1);
                        }
                        EditMession.Photo1File.CopyTo(new FileStream(fullpath, FileMode.Create));

                        bool compressingImage1 = await ImageCompresser.BusImageCompresser(uploads, filename1);

                        if (compressingImage1)
                        {

                            NewMission.Photo1 = "Resized" + filename1;
                        }

                    
                    }

                    if (EditMession.Photo2File != null)
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        //شو نعمل شلون بدنا نحكيي (:
                        string filename2 = string.Empty;
                        filename2 = Guid.NewGuid().ToString() + EditMession.Photo2File.FileName;
                        string fullpath = Path.Combine(uploads, filename2);
                        //Delete Old Picture

                        string OldFile2 = EditMession.Photo2;
                        string fullOldpath2 = Path.Combine(uploads, OldFile2);
                        string fullOldResizedpath2 = Path.Combine(uploads, "Resized"+OldFile2);
                        System.IO.File.Delete(fullOldpath2);
                        if (System.IO.File.Exists(fullOldResizedpath2))
                        {
                            System.IO.File.Delete(fullOldResizedpath2);
                        }
                        EditMession.Photo2File.CopyTo(new FileStream(fullpath, FileMode.Create));

                        bool compressingImage2 = await ImageCompresser.BusImageCompresser(uploads, filename2);
                  
                        if (compressingImage2)
                        {
                            NewMission.Photo2 = "Resized" + filename2;
                        }




                       
                    }




                    NewMission.Source = EditMession.Source;
                    NewMission.Des = EditMession.Des;
                    NewMission.DigitDes = EditMession.DigitDes;
                    NewMission.DigitSurce = EditMession.DigitSurce;
                    NewMission.TIME = EditMession.TIME;

                   _context.Update(NewMission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusExists(EditMession.Id))
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
            return View(EditMession);
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
