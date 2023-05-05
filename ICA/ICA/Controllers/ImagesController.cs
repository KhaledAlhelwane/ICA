using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICA.Data;
using ICA.Models;
using ImageMagick;
using ICA.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ICA.Controllers
{
    [Authorize(Roles = "IT,Media")]
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hosting;

        public ImagesController(ApplicationDbContext context
            , IWebHostEnvironment Hosting)
        {
            _context = context;
            hosting = Hosting;
        }

        // GET: Images
        public IActionResult Index(int id)
        {
            //return _context.Images != null ? 
            //            View(await _context.Images.ToListAsync()) :
            //            Problem("Entity set 'ApplicationDbContext.Images'  is null.");
            var lista =  _context.Images.Include(b => b.Album).Where(a => a.Album.Id == id).ToList();
            ViewData["AlbumTitle"] = _context.Albums.Find(id).AlbumTitel;
            var images = new ImageDeleteViewModel
            {
                AlbumId = id,
                AlbumObject=_context.Albums.Find(id),
                Images = lista.Select(image => new deleteimage {
                ImageUrl = image.ImageUrl,id=image.Id }).ToList()
                
            };
            if (lista.Count() == 0)
            {
                ViewBag.NotFound = "no images";
            }
            return View(images);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ImageDeleteViewModel collection)
        {
            string uploads = Path.Combine(hosting.WebRootPath, "PorfilesPictures");
           foreach (var x in collection.Images)
            {
                string fullOldpath = Path.Combine(uploads, x.ImageUrl);

                if (x.CheckedStatus == true)
                {

                    System.IO.File.Delete(fullOldpath);
                    _context.Images.Remove(_context.Images.Find(x.id));   
                }

            }
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = collection.AlbumId });
        }
       
       


        public IActionResult CreatePartial(int id)
        {
            var images = new Images
            {
                Album = _context.Albums.Find(id)
            };
            return View(images);
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePartial(int id, IFormFile[] images)
        {
            if (ModelState.IsValid)
            {
                var album = _context.Albums.Find(id);
                foreach (var x in images)
                {

                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();

                    string filename = string.Empty;
                    filename = Guid.NewGuid().ToString() + x.FileName;
                    string uploads = Path.Combine(hosting.WebRootPath, "PorfilesPictures");
                    string fullpath = Path.Combine(uploads, filename);
                    Stream Target = new FileStream(fullpath, FileMode.Create);
                    x.CopyTo(Target);
                    Target.Close();
                    await ImageResizing(uploads, filename);
                    System.IO.File.Delete(fullpath);

                    var image = new Images { ImageUrl = "Resized" + filename, Album = album };
                    _context.Add(image);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = id });
            }
            return View(images);
        }

        private bool ImagesExists(int id)
        {
          return (_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private async Task<bool> ImageResizing(string path, string filename)
        {
            var ImageUrl = Path.Combine(path, filename);
            using (var image = new MagickImage(ImageUrl))
            {
                try
                {
                    //if (image.BaseWidth >= 1000 || image.BaseHeight >= 1000)
                    //{
                        var size = new MagickGeometry(500, 500);
                        //// This will resize the image to a fixed size without maintaining the aspect ratio.
                        // Normally an image will be resized to fit inside the specified size.
                        size.IgnoreAspectRatio = false;

                        image.Resize(size);
                        image.Quality =75;
                        //   Save the result
                      await  image.WriteAsync(path + "\\Resized" + filename);
                        return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
                catch (Exception e)
                {
                    return false;
                }
            }

        }
    }
}
