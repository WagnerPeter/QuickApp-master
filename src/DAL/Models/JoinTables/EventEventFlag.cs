using DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class EventEventFlag : IJoinEntity<Event>, IJoinEntity<EventFlag>
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        Event IJoinEntity<Event>.Navigation
        {
            get => Event;
            set => Event = value;
        }

        public int EventFlagId { get; set; }
        public EventFlag EventFlag { get; set; }
        EventFlag IJoinEntity<EventFlag>.Navigation
        {
            get => EventFlag;
            set => EventFlag = value;
        }
    }
}
