using DevBook.Models.Entities;
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
                Person = context.Person.OrderBy(p => p.FirstName).ToArray(),
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

        public void UpdatePerson(HomeEditVM model)
        {
            var personToUpdate = context.Person.Find(model.Id);
            personToUpdate.FirstName = model.FirstName;
            personToUpdate.LastName = model.LastName;
            personToUpdate.Email = model.Email;
            personToUpdate.PhoneNumber = model.PhoneNumber;
            personToUpdate.Description = model.Description;
            context.SaveChanges();
        }

        internal HomeFilterDataVM GetAllPersons()
        {
            var person = new HomeFilterDataVM()
            {
                Person = context.Person.OrderBy(p => p.FirstName).ToArray()
            };

            return person;
        }

        public void RemovePerson(HomeEditVM person)
        {

           var model = context.ConnTable
                .Where(p => p.PersonId == person.Id);

            foreach (var item in model)
            {
            context.ConnTable.Remove(item);
            }


            var personToRemove = context.Person
                .Single(p => p.Id == person.Id);

            context.Person.Remove(personToRemove);
                
            context.SaveChanges();
        }

        internal HomeEditVM GetPersonById(int id)
        {
            var person = context.Person.Find(id);

            return new HomeEditVM {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                Description = person.Description
            };
        }

        internal HomeFilterDataVM GetFilterFromId(int id)
        {
            var person = new HomeFilterDataVM()
            {
                Person = context.ConnTable.Where(p => p.SkillId == id).Select(p => p.Person).OrderBy(p => p.FirstName).ToArray()
            };

            return person;
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
