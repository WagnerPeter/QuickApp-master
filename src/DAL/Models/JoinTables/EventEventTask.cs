using DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class EventEventTask : IJoinEntity<Event>, IJoinEntity<EventTask>
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        Event IJoinEntity<Event>.Navigation
        {
            get => Event;
            set => Event = value;
        }

        public int EventTaskId { get; set; }
        public EventTask EventTask { get; set; }
        EventTask IJoinEntity<EventTask>.Navigation
        {
            get => EventTask;
            set => EventTask = value;
        }
    }
}
