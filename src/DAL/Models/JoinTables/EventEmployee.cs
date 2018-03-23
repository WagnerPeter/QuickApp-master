using DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class EventEmployee : IJoinEntity<Event>, IJoinEntity<Employee>
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        Event IJoinEntity<Event>.Navigation
        {
            get => Event;
            set => Event = value;
        }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        Employee IJoinEntity<Employee>.Navigation
        {
            get => Employee;
            set => Employee = value;
        }
    }
}
