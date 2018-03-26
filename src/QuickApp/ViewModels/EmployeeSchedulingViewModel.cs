using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonAdmin.ViewModels
{
    public class EmployeeSchedulingViewModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public ICollection<Day> Days { get; set; }
    }
}
