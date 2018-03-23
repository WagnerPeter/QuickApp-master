using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class EventFlag : AuditableEntity
    {
        public EventFlag() => Events = new JoinCollectionFacade<Event, EventFlag, EventEventFlag>(this, EventEventFlags);

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        private ICollection<EventEventFlag> EventEventFlags { get; } = new List<EventEventFlag>();

        [NotMapped]
        public ICollection<Event> Events { get; set; }

    }
}
