namespace ICA.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public Album ?Album { get; set; }
    }
}
