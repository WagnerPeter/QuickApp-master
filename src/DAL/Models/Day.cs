using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Day: AuditableEntity
    {
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

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
