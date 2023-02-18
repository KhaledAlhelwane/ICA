namespace ICA.Models
{
    public class projects
    {
        public int Id { get; set; }
        public string ?project_title { get; set; }
        public string ?Logo_picture { get; set; }
        public string ?status { get; set; }
        public string ?Center { get; set; }
        public Album? Album { get; set; }
        public ICollection<Center> ?centers { get; set; }
        public ICollection<ComplintDep> ? ComplintDeps { get; set; }
        public Member ?Member { get; set; }
        public Assosiation ?Assosiation { get; set; }

    }
}
