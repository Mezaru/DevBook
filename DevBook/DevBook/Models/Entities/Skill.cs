using System;
using System.Collections.Generic;

namespace DevBook.Models.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            ConnTable = new HashSet<ConnTable>();
        }

        public int Id { get; set; }
        public string Skill1 { get; set; }

        public ICollection<ConnTable> ConnTable { get; set; }
    }
}
