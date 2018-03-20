using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Event : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public ICollection<EventFlag> EventFlags { get; set; }
        public ICollection<EventTask> EventTasks { get; set; }

        public ICollection<Employee> EventManagers { get; set; }
    }
}
