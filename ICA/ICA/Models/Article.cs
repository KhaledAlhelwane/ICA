namespace ICA.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string? ArticleUrl { get; set; }
        public string ?TypeOfArticles { get; set; }
        public  string ?TitleArabic { get; set; }
        public string ?ContentArabic { get; set; }
        public DateTime DatePuplished { get; set; }
        public bool Status { get; set; }
        public string ?ProfilePicture { get; set; }
        // English
        public string? TitleEnglish { get; set; }
        public string? ContentEnglish { get; set; }
        public  Album ?Album { get; set; }
        public ApplicationUser? ApplicationUsers { get; set; }
        public  Assosiation ?Assosiation { get; set; }
    }
}
