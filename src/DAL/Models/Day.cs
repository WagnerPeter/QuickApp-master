using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Day: AuditableEntity
    {
        public Day()
        {
            Employees = new JoinCollectionFacade<Employee, Day, EmployeeDay>(this, EmployeeDays);
            Events = new JoinCollectionFacade<Event, Day, EventDay>(this, EventDays);
        }

        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public double AmountHandedOver { get; set; }
        public double AmountReceipt { get; set; }
        public double AmountTip { get; set; }
        public string StockMissing { get; set; }
        public string StockRunningLow { get; set; }
        public string StuffBroken { get; set; }

        public ICollection<DayEvaluation> DayEvaluations { get; set; }

        private ICollection<EmployeeDay> EmployeeDays { get; } = new List<EmployeeDay>();
        private ICollection<EventDay> EventDays { get; } = new List<EventDay>();


        [NotMapped]
        public ICollection<Employee> Employees { get; set; }
        [NotMapped]
        public ICollection<Event> Events { get; set; }

    }
}
