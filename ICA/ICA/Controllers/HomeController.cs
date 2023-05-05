using ICA.Data;
using ICA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ICA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;
            string x = remoteIpAddress.ToString();
            TempData["IP"] = x;
            var lista =context.Rating.ToList();
            foreach(var counter in lista)
            {
                if (counter.IP == x.ToString())
                {
                    TempData["IP"] = "IPSubmited";
                    break;

                }

            }
            ViewData["newslist"] = context.Articles.Include(a=>a.ApplicationUsers).Include(a2=>a2.Assosiation).OrderByDescending(b=>b.Id).Where(z=>z.Status==true&&z.TypeOfArticles=="خبر").Take(6).ToList();
            ViewData["Eventslist"] = context.Articles.Include(a=>a.ApplicationUsers).Include(a2 => a2.Assosiation).OrderByDescending(b=>b.Id).Where(z=>z.Status==true&&z.TypeOfArticles=="حدث").Take(3).ToList();
            return View();
        }
        public async Task<IActionResult> Articles(int page = 1, int pageSize = 9)
        {
            //    return context.Articles != null ?
            //                  View(await context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).ToListAsync()) :
            //                  Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
            //
            var data = await context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).Where(t => t.TypeOfArticles == "خبر").OrderByDescending(o=>o.Id).ToListAsync();
            var totalCount = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var currentPageData = data.Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(currentPageData);
        }

        public IActionResult Article(int id) 
        {
            Article articel = context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).SingleOrDefault(i => i.Id == id);
            if (articel == null)
            {
                ViewBag.Notfound = "not found";
            }
            return View(articel);
            return context.Articles != null ?
                                    View( context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).SingleOrDefault(i=>i.Id==id) ):
                                    Problem("Entity set 'ApplicationDbContext.Articles'  is null.");
        }

        public async Task<IActionResult> Events(int page = 1, int pageSize = 9)
        {
            //return context.Articles != null ?
            //          View(await context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).Where(t=>t.TypeOfArticles=="حدث").ToListAsync()) :
            //          Problem("Entity set 'ApplicationDbContext.Articles'  is null.");

            var data = await context.Articles.Include(x => x.ApplicationUsers).Include(A=>A.Assosiation).Include(a => a.Album).ThenInclude(b => b.Images).Where(t => t.TypeOfArticles == "حدث").OrderByDescending(o => o.Id).ToListAsync();
            var totalCount = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var currentPageData = data.Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(currentPageData);
           
        }
        public IActionResult about()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult OurStory()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }
        public IActionResult HR()
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