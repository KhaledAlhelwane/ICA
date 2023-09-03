using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICA.Data;
using ICA.Models;
using ICA.ViewModel;
using ICA.Data.Migrations;
using ICA.Services;

namespace ICA.Controllers
{
    public class AssosiationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hosting;

        public AssosiationsController(ApplicationDbContext context, IWebHostEnvironment Hosting)
        {
            _context = context;
            hosting = Hosting;
        }

        // GET: Assosiations
        public async Task<IActionResult> Index()
        {
              return _context.Assosiation != null ? 
                          View(await _context.Assosiation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Assosiation'  is null.");
        }

        // GET: Assosiations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assosiation == null)
            {
                return NotFound();
            }

            var assosiation = await _context.Assosiation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assosiation == null)
            {
                return NotFound();
            }

            return View(assosiation);
        }

        // GET: Assosiations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assosiations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssosiationsViewmodel assosiation)
        {
            if (ModelState.IsValid)
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                string filenamePhoto1 = string.Empty;
                filenamePhoto1 = Guid.NewGuid().ToString() + assosiation.PhotoFile.FileName;
                string uploads = Path.Combine(hosting.WebRootPath, "PorfilesPictures");
                string fullpathPhoto1 = Path.Combine(uploads, filenamePhoto1);
                assosiation.PhotoFile.CopyTo(new FileStream(fullpathPhoto1, FileMode.Create));
                bool compressingImage1 = await ImageCompresser.AssosiationProfileCompresser(uploads, filenamePhoto1);
                if (compressingImage1)
                {
                    filenamePhoto1 = "Resized" + filenamePhoto1;
                }
                Assosiation assosiation1 = new Assosiation()
                {
                    About = assosiation.About,
                    AboutEnglish = assosiation.AboutEnglish,
                    AssosiationURL = assosiation.AssosiationURL,
                    Email = assosiation.Email,
                    FaceBookLink = assosiation.FaceBookLink,
                    FullName = assosiation.FullName,
                    FullNameEnglish = assosiation.FullNameEnglish,
                    PhoneNumber = assosiation.PhoneNumber,
                    Manger = assosiation.Manger,
                    Photo = filenamePhoto1
                };
                _context.Add(assosiation1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assosiation);
        }

        // GET: Assosiations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assosiation == null)
            {
                return NotFound();
            }

            var assosiation = await _context.Assosiation.FindAsync(id);

            if (assosiation == null)
            {
                return NotFound();
            }

            


            AssosiationsViewmodel model = new AssosiationsViewmodel()
            {
                Photo = assosiation.Photo,
                FullName = assosiation.FullName,
                Manger = assosiation.Manger,
                PhoneNumber = assosiation.PhoneNumber
                ,FullNameEnglish = assosiation.FullNameEnglish,
                FaceBookLink = assosiation.FaceBookLink,
                Email = assosiation.Email,
                AssosiationURL = assosiation.AssosiationURL,
                About = assosiation.About  ,
                AboutEnglish = assosiation.AboutEnglish,
                Id = assosiation.Id,
 
            };
            return View(model);
        }

        // POST: Assosiations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  AssosiationsViewmodel assosiation)
        {
            if (id != assosiation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string filenamePhoto1 = assosiation.Photo;

                    if (assosiation.PhotoFile != null)
                    {
                        
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();

                          filenamePhoto1 = Guid.NewGuid().ToString() + assosiation.PhotoFile.FileName;
                        string uploads = Path.Combine(hosting.WebRootPath, "PorfilesPictures");
                        string fullpathPhoto1 = Path.Combine(uploads, filenamePhoto1);
                        assosiation.PhotoFile.CopyTo(new FileStream(fullpathPhoto1, FileMode.Create));
                        if(assosiation.Photo != null)
                        {
                            string OldFile = assosiation.Photo;
                            string fullOldpath = Path.Combine(uploads, OldFile);
                            System.IO.File.Delete(fullOldpath);
                            System.IO.File.Delete(uploads + assosiation.Photo.Substring("Resized".Length));

                        }
                        bool compressingImage1 = await ImageCompresser.AssosiationProfileCompresser(uploads, filenamePhoto1);
                        if (compressingImage1)
                        {
                            filenamePhoto1 = "Resized" + filenamePhoto1;
                        }
                        else
                        {
                            filenamePhoto1 = assosiation.Photo;
                        }
                    }



                    Assosiation model = new Assosiation()
                    {
                        Photo = filenamePhoto1,
                        FullName = assosiation.FullName,
                        Manger = assosiation.Manger,
                        PhoneNumber = assosiation.PhoneNumber
               ,
                        FullNameEnglish = assosiation.FullNameEnglish,
                        FaceBookLink = assosiation.FaceBookLink,
                        Email = assosiation.Email,
                        AssosiationURL = assosiation.AssosiationURL,
                        About = assosiation.About,
                        AboutEnglish = assosiation.AboutEnglish,
                        Id = assosiation.Id,

                    };


                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssosiationExists(assosiation.Id))
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
            return View(assosiation);
        }

        // GET: Assosiations/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Assosiation == null)
        //    {
        //        return NotFound();
        //    }

        //    var assosiation = await _context.Assosiation
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (assosiation == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(assosiation);
        //}

        //// POST: Assosiations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Assosiation == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Assosiation'  is null.");
        //    }
        //    var assosiation = await _context.Assosiation.FindAsync(id);
        //    if (assosiation != null)
        //    {
        //        _context.Assosiation.Remove(assosiation);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AssosiationExists(int id)
        {
          return (_context.Assosiation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
