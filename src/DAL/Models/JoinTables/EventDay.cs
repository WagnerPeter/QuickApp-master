using DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class EventDay : IJoinEntity<Event>, IJoinEntity<Day>
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        Event IJoinEntity<Event>.Navigation
        {
            get => Event;
            set => Event = value;
        }

        public int DayId { get; set; }
        public Day Day { get; set; }
        Day IJoinEntity<Day>.Navigation
        {
            get => Day;
            set => Day = value;
        }
    }
}
