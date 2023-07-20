namespace ICA.Models
{
    public class Rating
    {
        public int id { get; set; }
        public string ?IP { get; set; }
        public string ?RatingLevel { get; set; }
        public string ?Comment { get; set; }
        public DateTime ?RatingTime { get; set; }
    }
}
