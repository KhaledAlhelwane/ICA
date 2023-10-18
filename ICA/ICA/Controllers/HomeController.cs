﻿using HtmlAgilityPack;
using ICA.Data;
using ICA.Models;
using ICA.Services;
using ICA.ViewModel;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Globalization;
using System.Net.Http;

namespace ICA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;
        private readonly IMailingService mailingService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMailingService mailingService)
        {
            _logger = logger;
            this.context = context;
            this.mailingService = mailingService;
        }

        public IActionResult Index()
        {
            VisitorsCounter.Increment();
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
            ViewData["newslist"] = context.Articles.Include(a=>a.ApplicationUsers).Include(a2=>a2.Assosiation).OrderByDescending(b=>b.DatePuplished).Where(z=>z.Status==true&&z.TypeOfArticles=="خبر").Take(3).ToList();
            ViewData["Eventslist"] = context.Articles.Include(a=>a.ApplicationUsers).Include(a2 => a2.Assosiation).OrderByDescending(b=>b.DatePuplished).Where(z=>z.Status==true&&z.TypeOfArticles=="حدث").Take(3).ToList();
            return View();
        }
       
        public async Task<IActionResult> News(int page = 1, int pageSize = 9)
        {
            if (page < 1) // Check if page is less than 1
            {
                page = 1; // Set page to 1 to prevent negative navigation
            }
            var data = await context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).Where(t => t.TypeOfArticles == "خبر" &&t.Status==true).OrderByDescending(o=>o.DatePuplished).ToListAsync();
            var totalCount = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var currentPageData = data.Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(currentPageData);
        }

        public IActionResult Article(string title) 
        {
            Article articel = context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).SingleOrDefault(i => i.ArticleUrl== title);

            //Article articel = context.News.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).SingleOrDefault(i => i.Id == id);
            if (articel == null|| articel.Status==false)
            {
                ViewBag.Notfound = "not found";
            }
            //this code is intended to clean the content varible from the html elment to make the meta descritpoin tag more efficiant 
            HtmlDocument document = new HtmlDocument();
             if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
            {
                document.LoadHtml(articel.ContentArabic);

            }
            else
            {
                document.LoadHtml(articel.ContentEnglish);

            }
            // Extract the plain text from the HTML content
            string content = document.DocumentNode.InnerText;
            if (content.Length > 125)
            {
                ViewBag.description = content.Substring(0, 125) + "....";
            }
            else
            {
                ViewBag.description = content;
            }
            if (articel.TypeOfArticles == "مقال للمدونة") {
                ViewData["News"] = context.Articles
                    .Where(x=>x.TypeOfArticles== "مقال للمدونة" && x.Id!=articel.Id && x.Status==true)
                    .OrderBy(r => r.DatePuplished)
                    .Take(4)
                    .ToList();
            }
            //
            articel.visitCounter +=1 ;
            context.Articles.Update(articel);
            context.SaveChanges();
            return View(articel);
                                
        }
      
        public async Task<IActionResult> Events(int page = 1, int pageSize = 9)
        {
            if (page < 1) // Check if page is less than 1
            {
                page = 1; // Set page to 1 to prevent negative navigation
            }
            var data = await context.Articles.Include(x => x.ApplicationUsers).Include(A=>A.Assosiation).Include(a => a.Album).ThenInclude(b => b.Images).Where(t => t.TypeOfArticles == "حدث"&& t.Status==true).OrderByDescending(o => o.DatePuplished).ToListAsync();
            var totalCount = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var currentPageData = data.Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(currentPageData);
           
        }
        [Route("about-islamic-charity-association")]
        public IActionResult about()
        {
            return View();
        }
        [Route("contact-us")]
        public IActionResult contact()
        {
            var contact = new ContatctViewModel();
            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> contact(ContatctViewModel massage)
        {
            if (ModelState.IsValid) { 
            string themassage = "the name is:" + massage.Name + "<br>the email: " + massage.Email + "<br> the massage: " + massage.Message;
        bool result= await mailingService.SendEmailAsync("IT@icangoh.org", massage.Subject,themassage);
            if (result) {
                ViewBag.successed = "successed";
                    ModelState.Clear();
            }
            else if (!result)
            {
                ViewBag.Notsuccessed = "Notsuccessed";
            }
            }

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
        [Route("previous-projects")]

        public IActionResult Projects()
        {
            return View();
        }
        [Route("human-resources")]
        public IActionResult HR()
        {
            return View();
        }
        [Route("donation")]
        public IActionResult Donation()
        {
            return View();
        }
        [Route("association-structure")]
        public IActionResult structure()
        {
            return View();
        }
       
        public async Task<IActionResult> BlogAsync(int page = 1, int pageSize = 3)
        {
            if (page < 1) // Check if page is less than 1
            {
                page = 1; // Set page to 1 to prevent negative navigation
            }
            var data = await context.Articles.Include(x => x.ApplicationUsers).Include(a => a.Album).ThenInclude(b => b.Images).Where(t => t.TypeOfArticles == "مقال للمدونة").OrderByDescending(o => o.DatePuplished).ToListAsync();
            var totalCount = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var currentPageData = data.Skip((page - 1) * pageSize).Take(pageSize);
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;

            return View(currentPageData);
        
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}