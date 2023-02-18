namespace ICA.Models
{
    public class ITRequist
    {
        public int Id { get; set; }
        public string ?RequistTitle { get; set; }
        public string ?TypeOfRequist { get; set; }
        public string ?TechnicalNotes { get; set; }
        public string ?MaintenanceNote { get; set; }
        public bool RequistStatus { get; set; }
        public ApplicationUser ?ApplicationUsers { get; set; }
    }
}
