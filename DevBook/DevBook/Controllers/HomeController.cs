using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBook.Models;
using DevBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository repository;

        public HomeController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var name = repository.GetInfoIndexVM();
            return View(name);
        }

        [HttpGet]
        [Route("Home/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Home/Add")]
        public IActionResult Add(HomeAddVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.AddNewPerson(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
