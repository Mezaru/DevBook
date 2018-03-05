using System;
using System.Collections.Generic;

namespace DevBook.Models.Entities
{
    public partial class Person
    {
        public Person()
        {
            ConnTable = new HashSet<ConnTable>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

        public ICollection<ConnTable> ConnTable { get; set; }
    }
}
