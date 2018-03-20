using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{ 
    public class DayEvaluation : AuditableEntity
    {
        public DayEvaluation() => Ratings = new JoinCollectionFacade<Rating, DayEvaluation, DayEvaluationRating>(this, DayEvaluationRatings);

        [Key]
        public int Id { get; set; } 
        public Day Day { get; set; }
        public Employee Employee { get; set; }

        public DateTime WorkingFrom { get; set; }
        public DateTime WorkingTo { get; set; }

        public double AmountConsumed { get; set; }

        private ICollection<DayEvaluationRating> DayEvaluationRatings { get; } = new List<DayEvaluationRating>();

        [NotMapped]
        public ICollection<Rating> Ratings { get; set; }
        [NotMapped]
        public ICollection<EventEvaluation> EventEvaluations { get; set; }


    }
}
