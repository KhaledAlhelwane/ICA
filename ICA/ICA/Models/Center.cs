namespace ICA.Models
{
    public class Center
    {
        public int Id { get; set; }
        public string ?location_name { get; set; }
        public string ?map { get; set; }
        public string ?contac_us { get; set; }
        public string ?center_manger { get; set; }
        public  projects ?Projects { get; set; }
        public ComplintDep ?ComplintDep { get; set; }
        public int MemberId { get; set; }
        public Member ?Member { get; set; }


    }
}
