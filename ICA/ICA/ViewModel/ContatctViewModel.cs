using System.ComponentModel.DataAnnotations;

namespace ICA.ViewModel
{
    public class ContatctViewModel
    {
        [Required]
        [StringLength(maximumLength:15)]
        public string ?Name { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string ?Subject { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string ?Email { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string ?Message { get; set; }

    }
}
