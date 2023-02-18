namespace ICA.Models
{
    public class MainInterface
    {
        public int Id { get; set; }
        public int ?served_over { get; set; }
        public string ?facebook_link { get; set; }
        public string ?Emial_link { get; set; }
        public string ?phone { get; set; }
        public string ?location { get; set; }
        public Album ?Album { get; set; }


    }
}
