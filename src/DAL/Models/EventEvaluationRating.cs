using DAL.Models.Interfaces;

namespace DAL.Models
{
    public class EventEvaluationRating : IJoinEntity<EventEvaluation>, IJoinEntity<Rating>
    {
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
        Rating IJoinEntity<Rating>.Navigation
        {
            get => Rating;
            set => Rating = value;
        }

        public int EventEvaluationId { get; set; }
        public EventEvaluation EventEvaluation { get; set; }
        EventEvaluation IJoinEntity<EventEvaluation>.Navigation
        {
            get => EventEvaluation;
            set => EventEvaluation = value;
        }

    }
}
