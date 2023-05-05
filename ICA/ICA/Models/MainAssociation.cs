namespace ICA.Models
{
    public class MainAssociation
    {

        public int id { get; set; }
        public string ?FullName { get; set; }
        public string ?Photo { get; set; }
        public string ?About { get; set; }
        public string ?Email { get; set; }
        public string ?PhoneNumber { get; set; }
        public string ?FacebookLink { get; set; }
        public string ?Manger { get; set; }
        public Album ?Album { get; set; }



    }
}
