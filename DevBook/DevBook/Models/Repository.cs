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
    }
}
