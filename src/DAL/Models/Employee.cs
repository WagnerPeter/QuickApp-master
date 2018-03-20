using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Employee : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public float Salary { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Day> Days { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
