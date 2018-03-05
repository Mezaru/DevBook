using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBook.Models;
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


        public IActionResult Index()
        {
            var name = repository.GetAllPersons();
            return View(name);
        }
    }
}
