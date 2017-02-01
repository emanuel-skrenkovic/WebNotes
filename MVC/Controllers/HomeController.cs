using Model.Common;
using MVC.Models;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public async Task<ActionResult> Index()
        {
            var model = new NotesViewModel
            {
                Notes = await noteService.GetAllAsync(),
            };
            return View(model);
        }
    }
}