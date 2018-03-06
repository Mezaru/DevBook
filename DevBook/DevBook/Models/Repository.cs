using DevBook.Models.Entities;
using DevBook.Models.ViewModels;
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
                FirstName = model.person.FirstName,
                LastName = model.person.LastName,
                Email = model.person.Email,
                PhoneNumber = model.person.PhoneNumber,
                Description = model.person.Description,
            });
         
            context.SaveChanges();
        }

        public HomeAddVM GetAllSkills()
        {
            HomeAddVM List = new HomeAddVM()
            {
                skills = context.Skill.ToArray(),
            };

            return List;
        }
    }
}
