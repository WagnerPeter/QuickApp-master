using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Employee : AuditableEntity
    {
        public Employee()
        {
            Days = new JoinCollectionFacade<Day, Employee, EmployeeDay>(this, EmployeeDays);
            Events = new JoinCollectionFacade<Event, Employee, EventEmployee>(this, EventEmployees);
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsEnabled { get; set; }

        public float Salary { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ApplicationUser User { get; set; }

        private ICollection<EmployeeDay> EmployeeDays { get; } = new List<EmployeeDay>();
        private ICollection<EventEmployee> EventEmployees { get; } = new List<EventEmployee>();

        [NotMapped]
        public ICollection<Day> Days { get; set; }
        [NotMapped]
        public ICollection<Event> Events { get; set; }

    }
}
