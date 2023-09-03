using HtmlAgilityPack;
using ICA.Data;
using ICA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ICA.Controllers
{
    public class SectionsController : Controller
    {
        private readonly ApplicationDbContext context;


        public SectionsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Section(string AssosiationURL)
        {
            Assosiation model = context.Assosiation.SingleOrDefault(i => i.AssosiationURL == AssosiationURL);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(model.About);

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
            return View(model);
        }
    }
}
