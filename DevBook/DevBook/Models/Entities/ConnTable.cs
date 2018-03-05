using System;
using System.Collections.Generic;

namespace DevBook.Models.Entities
{
    public partial class ConnTable
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int SkillId { get; set; }

        public Person Person { get; set; }
        public Skill Skill { get; set; }
    }
}
