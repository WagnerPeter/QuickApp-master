using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public float FixedHourlyRate { get; set; }
        public float MonthlyGrossIncome { get; set; }
        public float TakingsPercentage { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public bool IsEnabled { get; set; }        
    }
}
