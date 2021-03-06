﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBook.Models;
using DevBook.Models.Entities;
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
            var viewModel = repository.GetAllSkills();

            return View(viewModel);
        }

        [HttpPost]
        [Route("Home/Add")]
        public IActionResult Add(HomeAddVM model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = repository.GetAllSkills();

                viewModel.Person.SelectedSkills = model.Person.SelectedSkills;

                return View(viewModel);
            }

            repository.AddNewPerson(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetData(int id)
        {
            var data = repository.GetDataFromId(id);
            return PartialView("_GetData", data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = repository.GetPersonById(id);
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(HomeEditVM model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = repository.GetAllSkills();

                viewModel.Person.SelectedSkills = model.SelectedSkills;

                return View(viewModel);
            }
            repository.UpdatePerson(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Home/Remove{id}")]
        public IActionResult Remove(HomeEditVM person)
        {
            repository.RemovePerson(person);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult FilterPersons(int id)
        {
            HomeFilterDataVM data;
            if (id == 0)
            {
                data = repository.GetAllPersons();
            }
            else
            {
                data = repository.GetFilterFromId(id);
            }
            return PartialView("_FilterPersons", data);
        }
    }
}
