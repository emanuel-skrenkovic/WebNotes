using MVC.Models;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {

        private INoteService noteService { get; set; }

        public HomeController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Test()
        {
            var notes = await noteService.GetAllAsync();
            var model = new TestViewModel
            {
                Notes = notes,
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}