using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class EventTask: AuditableEntity
    {
        public EventTask() => Events = new JoinCollectionFacade<Event, EventTask, EventEventTask>(this, EventEventTasks);

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private ICollection<EventEventTask> EventEventTasks { get; } = new List<EventEventTask>();

        [NotMapped]
        public ICollection<Event> Events { get; set; }
    }
}
