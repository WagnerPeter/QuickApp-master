using DAL.Models.Interfaces;

namespace DAL.Models
{
    public class DayEvaluationRating : IJoinEntity<DayEvaluation>, IJoinEntity<Rating>
    {
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
        Rating IJoinEntity<Rating>.Navigation
        {
            get => Rating;
            set => Rating = value;
        }

        public int DayEvaluationId { get; set; }
        public DayEvaluation DayEvaluation { get; set; }
        DayEvaluation IJoinEntity<DayEvaluation>.Navigation
        {
            get => DayEvaluation;
            set => DayEvaluation = value;
        }

    }
}
