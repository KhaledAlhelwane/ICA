using ICA.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ICA.ViewModel
{
    public class ArticleViewModel
    {
        public int id { get; set; }
        public string? ArticleUrl { get; set; }
        public string? TypeOfArticles { get; set; }
        [Required(ErrorMessage = "Please fill this field")]
        public string? TitleArabic { get; set; }
        [Required(ErrorMessage = "Please fill this field")]
        public string? ContentArabic { get; set; }
        [Required(ErrorMessage = "Please fill this field")]
        public DateTime DatePuplished { get; set; }
        public bool Status { get; set; }
        // English
        [Required(ErrorMessage = "Please fill this field")]
        public string? TitleEnglish { get; set; }
        [Required(ErrorMessage = "Please fill this field")]
        public string? ContentEnglish { get; set; }
        public List<Assosiation>? AssosiationList { get; set; }
        [Required(ErrorMessage = "Please fill this field")]
        public int thenameassoc { get; set; }
        //main picture
        public IFormFile? ProfilePictureFile { get; set; }
        public string? ProfilePicture { get; set; }

    }
}
