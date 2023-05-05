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
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using ImageMagick;
using System.IO;
using System.Collections;
using Microsoft.AspNetCore.Authorization;

namespace ICA.Controllers
{
    [Authorize(Roles = "IT,Media")]
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> usermanger;
        private readonly IWebHostEnvironment hosting;

        public ArticlesController(ApplicationDbContext context,
            UserManager<ApplicationUser> Usermanger
            , IWebHostEnvironment Hosting)
        {
            _context = context;
            usermanger = Usermanger;
            hosting = Hosting;
        }

        // GET: Articles
        public async Task<IActionResult> Index(string ?search)
        
        {
            if (search == null)
            {
                return _context.Articles != null ?
                            View(await _context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).OrderByDescending(d => d.Id).ToListAsync()) :
                            Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
            }
            else
            {
                ViewBag.searchword = search;
                var lista = _context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).OrderByDescending(d => d.Id).ToList().Where(a => a.TitleArabic.Contains(search));
                if (lista.Count() == 0)
                {
                    ViewBag.faild = "no items";
                    return _context.Articles != null ?
                                             View(await _context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).OrderByDescending(d => d.Id).ToListAsync()) :
                                             Problem("Entity set 'ApplicationDbContext.Articles'  is null.");

                }
                return View(lista) ;
            }
            }

        
        public IActionResult ChangeStatus(int Id)
        {
            var id = ViewData["id"];
            var article = _context.Articles.Find(Id);

            if (article.Status)
            {
                article.Status = false;
            }
            else
            {
                article.Status = true;
            }
            _context.Articles.Update(article);
            _context.SaveChanges();
           return RedirectToAction(nameof(Index));
        }
        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.Include(c=>c.Assosiation).Include(a=>a.Album).ThenInclude(b=>b.Images)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            var listofassociation = _context.Assosiation.ToList();
            var articl = new ArticleViewModel { AssosiationList = listofassociation };
            return View(articl);
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleViewModel articleviewmodel)
        {
            if (ModelState.IsValid)
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
              
                string filename = string.Empty;
                filename = Guid.NewGuid().ToString() + articleviewmodel.ProfilePictureFile.FileName;
                string uploads = Path.Combine(hosting.WebRootPath, "PorfilesPictures");
                string fullpath = Path.Combine(uploads, filename);
                articleviewmodel.ProfilePictureFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                ImageResizing(uploads, filename);
                var album = new Album { AlbumTitel = articleviewmodel.TitleArabic };

                var article = new Article
                {
                    ApplicationUsers = usermanger.FindByNameAsync(User.Identity.Name).Result,
                    Assosiation = _context.Assosiation.Find(articleviewmodel.thenameassoc),
                    ContentArabic = articleviewmodel.ContentArabic,
                    ContentEnglish = articleviewmodel.ContentEnglish,
                    DatePuplished = DateTime.Now,
                    ProfilePicture = filename,
                    TitleArabic = articleviewmodel.TitleArabic,
                    TitleEnglish = articleviewmodel.TitleEnglish,
                    TypeOfArticles = articleviewmodel.TypeOfArticles,
                    Status=true,
                    Album= album
                };
                _context.Add(article);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articleviewmodel);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.Include(a=>a.Assosiation).SingleOrDefaultAsync(b=>b.Id==id);
            if (article == null)
            {
                return NotFound();
            }

            var articleVM = new ArticleViewModel
            {
                id = article.Id,
                TypeOfArticles = article.TypeOfArticles,
                TitleEnglish = article.TitleEnglish,
                Status = article.Status,
                ContentArabic = article.ContentArabic,
                ContentEnglish = article.ContentEnglish,
                DatePuplished = article.DatePuplished,
                ProfilePicture = article.ProfilePicture,
                TitleArabic = article.TitleArabic,
                AssosiationList = _context.Assosiation.ToList(),
                thenameassoc = article.Assosiation.Id,
                
            };
            return View(articleVM);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleViewModel article)
        {
            if (id != article.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (article.ProfilePictureFile != null)
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();

                        string filename = string.Empty;
                        filename = Guid.NewGuid().ToString() + article.ProfilePictureFile.FileName;
                        string uploads = Path.Combine(hosting.WebRootPath, "PorfilesPictures");
                        string fullpath = Path.Combine(uploads, filename);
                        article.ProfilePictureFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                        ImageResizing(uploads, filename);
                        string OldFile = article.ProfilePicture;
                        string fullOldpath = Path.Combine(uploads, OldFile);
                        System.IO.File.Delete(fullOldpath);
                        System.IO.File.Delete(uploads + "Resized" + article.ProfilePicture);
                        article.ProfilePicture = filename;
                    }
                    var newarticle = _context.Articles.Find(id);
                    newarticle.ProfilePicture = article.ProfilePicture;
                    newarticle.TitleArabic = article.TitleArabic;
                    newarticle.TitleEnglish = article.TitleEnglish;
                    newarticle.TypeOfArticles = article.TypeOfArticles;
                    newarticle.ContentArabic = article.ContentArabic;
                    newarticle.ContentEnglish = article.ContentEnglish;
                    newarticle.DatePuplished = article.DatePuplished;
                    newarticle.Assosiation = _context.Assosiation.Find(article.thenameassoc);

                    _context.Articles.Update(newarticle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.id))
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
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.Include(c=>c.Assosiation).Include(a => a.Album).ThenInclude(b => b.Images)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
            }
            var article = await _context.Articles.Include(a => a.Album).ThenInclude(b => b.Images).SingleAsync(c=>c.Id==id);
            string uploads = Path.Combine(hosting.WebRootPath, "PorfilesPictures");

            if (article != null)
            {
                var AllImages = article.Album.Images.ToList();
                 try {
                    string fullOldpath = Path.Combine(uploads, article.ProfilePicture);
                    string fullOldpathResized = Path.Combine(uploads,"Resized"+article.ProfilePicture);
                    System.IO.File.Delete(fullOldpath );
                    System.IO.File.Delete(fullOldpathResized);
                }
                catch (Exception e)
                {
                    

                }
                string fullOldpathAlbum =string.Empty;

                if (AllImages.Count()!=0)
                foreach (var x in AllImages)
                {
                        fullOldpathAlbum= Path.Combine(uploads, x.ImageUrl);
                        System.IO.File.Delete(fullOldpathAlbum);
                }
                _context.Articles.Remove(article);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
          return (_context.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        //for compressing images 
        private bool ImageResizing(string path, string filename)
        {
            var ImageUrl = Path.Combine(path, filename);
            using (var image = new MagickImage(ImageUrl))
            {
                try
                {
                    //if (image.BaseWidth >= 1000 || image.BaseHeight >= 1000)
                    //{
                       var size = new MagickGeometry(740, 780);
                        //// This will resize the image to a fixed size without maintaining the aspect ratio.
                        // Normally an image will be resized to fit inside the specified size.
                        size.IgnoreAspectRatio = false;
                        image.Resize(size);
                        image.Quality = 65;
                        //   Save the result
                        image.Write(path + "\\Resized" + filename);
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
