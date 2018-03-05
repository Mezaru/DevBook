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
    }
}
