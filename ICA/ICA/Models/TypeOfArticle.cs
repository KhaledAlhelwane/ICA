namespace ICA.Models
{
    public class TypeOfArticle
    {
        public int Id { get; set; }
        public string ?TitleArabic { get; set; }
        public string ?TitleEnglish { get; set; }
        public int ArticleId { get; set; }
        public Article? Article { get; set; }
    }
}
