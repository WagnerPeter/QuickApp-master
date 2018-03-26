using DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class EmployeeDay : IJoinEntity<Employee>, IJoinEntity<Day>
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        Employee IJoinEntity<Employee>.Navigation
        {
            get => Employee;
            set => Employee = value;
        }
        public DateTime PlannedWorkFrom { get; set; }
        public DateTime PlannedWorkTo { get; set; }

        public int DayId { get; set; }
        public Day Day { get; set; }
        Day IJoinEntity<Day>.Navigation
        {
            get => Day;
            set => Day = value;
        }
    }
}
