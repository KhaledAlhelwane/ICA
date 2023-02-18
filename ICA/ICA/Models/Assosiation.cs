namespace ICA.Models
{
    public class Assosiation
    {
        public int Id { get; set; }
        public string ?FullName { get; set; }
        public string  ?Photo{ get; set; }
        public string  ?About{ get; set; }
        public string  ?Email{ get; set; }
        public string  ?PhoneNumber{ get; set; }
        public string  ?FaceBookLink{ get; set; }
        public string Manger { get; set; }
        public ICollection<projects>? Projects { get; set; }
        public ICollection<Member> ?Members{ get; set; }
        public ICollection<Article>? Articles { get; set; }
      

    }
}
