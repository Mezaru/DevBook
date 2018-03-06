using DevBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBook.Models.ViewModels
{
    public class HomeIndexVM
    {
        public Person[] Person { get; set; }
        public Skill[] Skill { get; set; }
        public ConnTable[] ConnTable { get; set; }
    }
}
