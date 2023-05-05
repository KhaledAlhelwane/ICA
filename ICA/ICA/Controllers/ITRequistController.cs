using ICA.Models;
using ICA.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ICA.Controllers
{
    [Authorize(Roles = "IT,Media")]
    public class ITRequistController : Controller
    {
        private readonly ICRUD<ITRequist> iTREQUISTREPO;
        private readonly UserManager<ApplicationUser> usermanger;

        public ITRequistController(ICRUD<ITRequist>ITREQUISTREPO, UserManager<ApplicationUser> Usermanger)
        {
            iTREQUISTREPO = ITREQUISTREPO;
            usermanger = Usermanger;
        }
        // GET: ITRequistController
        public ActionResult Index()
        {
            var list = iTREQUISTREPO.List();
            return View(list);
        }
       
        // GET: ITRequistController/Details/5
        public ActionResult Details(int id)
        {
           var requist= iTREQUISTREPO.find(id);
            return View(requist);
        }

        // GET: ITRequistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ITRequistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ITRequist collection)
        {
            try
            {
                collection.ApplicationUsers = usermanger.FindByNameAsync(User.Identity.Name).Result;
                iTREQUISTREPO.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ITRequistController/Edit/5
        public ActionResult Edit(int id)
        {
            var requist = iTREQUISTREPO.find(id);
            return View(requist);
        }

        // POST: ITRequistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ITRequist collection)
        {
            try
            {
                var request = new ITRequist
                {
                    Id = collection.Id,
                    ApplicationUsers = collection.ApplicationUsers,
                    MaintenanceNote = collection.MaintenanceNote,
                    RequistStatus = collection.RequistStatus,
                    RequistTitle = collection.RequistTitle,
                    TechnicalNotes = collection.TechnicalNotes,
                    TypeOfRequist = collection.TypeOfRequist
                };
                iTREQUISTREPO.Update(request);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ITRequistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ITRequistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
