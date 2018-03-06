﻿using DevBook.Models.Entities;
using DevBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DevBook.Models
{
    public class Repository
    {
        private readonly DevBookContext context;

        public Repository(DevBookContext context)
        {
            this.context = context;
        }

        public HomeIndexVM GetInfoIndexVM()
        {
            HomeIndexVM List = new HomeIndexVM()
            {
                Person = context.Person.ToArray(),
                Skill = context.Skill.ToArray(),
                ConnTable = context.ConnTable.ToArray()
            };

            return List;
        }

        public void AddNewPerson(HomeAddVM model)
        {
            context.Person.Add(new Person
            {
                FirstName = model.Person.FirstName,
                LastName = model.Person.LastName,
                Email = model.Person.Email,
                PhoneNumber = model.Person.PhoneNumber,
                Description = model.Person.Description
            });

            context.SaveChanges();

            var person = context.Person.Last();

            foreach (var item in model.Person.SelectedSkills)
            {
                context.ConnTable.Add(new ConnTable
                {
                    SkillId = item,
                    PersonId = person.Id,
                });
            }
            context.SaveChanges();
        }

        public HomeAddVM GetAllSkills()
        {
            HomeAddVM List = new HomeAddVM()
            {
                Person = new HomeAddVM.PersonVM
                {
                    Skills = context.Skill
                        .Select(o => new SelectListItem
                        {
                            Text = o.Skill1,
                            Value = o.Id.ToString()
                        })
                        .ToArray()
                }
            };
            return List;
        }

        internal HomeGetDataVM GetDataFromId(int id)
        {
            var Person = new HomeGetDataVM()
            {
                Person = context.Person.Find(id)
            };

            return Person;
        }
    }
}
