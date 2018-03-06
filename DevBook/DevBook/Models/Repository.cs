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
        public HomeIndexVM GetAllPersons()
        {
            return new HomeIndexVM()
            {
                FirstName = context.Person.First().FirstName
            };
        }

        internal void AddNewPerson(HomeAddVM model)
        {
            context.Person.Add(new Person
            {
                FirstName = model.person.FirstName,
                LastName = model.person.LastName,
                Email = model.person.Email,
                PhoneNumber = model.person.PhoneNumber,
                Description = model.person.Description
            });
            context.SaveChanges();

        }
    }
}
