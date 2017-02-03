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

        private INoteService _service;

        public HomeController(INoteService service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var model = new TestViewModel
            {
                Notes = await _service.GetNotesAsync(),
                Categories = await _service.GetCategoriesAsync()
            };

            return View(model);
        } 
    }
}