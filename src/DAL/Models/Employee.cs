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
        public bool IsStudent { get; set; }
        public DateTime RegisteredFrom { get; set; }
        public DateTime RegisteredTo { get; set; }

        public ApplicationUser User { get; set; }

        private ICollection<EmployeeDay> EmployeeDays { get; } = new List<EmployeeDay>();
        private ICollection<EventEmployee> EventEmployees { get; } = new List<EventEmployee>();

        [NotMapped]
        public ICollection<Day> Days { get; set; }
        [NotMapped]
        public ICollection<Event> Events { get; set; }

        public ICollection<EmployeeSalary> Salaries { get; set; }

    }
}
