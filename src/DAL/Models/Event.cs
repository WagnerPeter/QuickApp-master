using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Event : AuditableEntity
    {
        public Event()
        {
            EventFlags = new JoinCollectionFacade<EventFlag, Event, EventEventFlag>(this, EventEventFlags);
            EventTasks = new JoinCollectionFacade<EventTask, Event, EventEventTask>(this, EventEventTasks);
            Employees = new JoinCollectionFacade<Employee, Event, EventEmployee>(this, EventEmployees);
            Days = new JoinCollectionFacade<Day, Event, EventDay>(this, EventDays);
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        private ICollection<EventEventFlag> EventEventFlags { get; } = new List<EventEventFlag>();
        private ICollection<EventEventTask> EventEventTasks { get; } = new List<EventEventTask>();
        private ICollection<EventEmployee> EventEmployees { get; } = new List<EventEmployee>();
        private ICollection<EventDay> EventDays { get; } = new List<EventDay>();

        [NotMapped]
        public ICollection<EventFlag> EventFlags { get; set; }
        [NotMapped]
        public ICollection<EventTask> EventTasks { get; set; }
        [NotMapped]
        public ICollection<Employee> Employees { get; set; }
        [NotMapped]
        public ICollection<Day> Days { get; set; }
    }
}
