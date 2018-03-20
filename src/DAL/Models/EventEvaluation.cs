using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class EventEvaluation : AuditableEntity
    {
        public EventEvaluation() => Ratings = new JoinCollectionFacade<Rating, EventEvaluation, EventEvaluationRating>(this, EventEvaluationRatings);

        [Key]
        public int Id { get; set; }
        public Event Event { get; set; }

        private ICollection<EventEvaluationRating> EventEvaluationRatings { get; } = new List<EventEvaluationRating>();

        [NotMapped]
        public ICollection<Rating> Ratings { get; set; }
    }
}
