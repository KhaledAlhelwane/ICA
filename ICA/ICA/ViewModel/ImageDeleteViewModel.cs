using ICA.Models;

namespace ICA.ViewModel
{
    public class ImageDeleteViewModel
    {
        public int AlbumId { get; set; }
        public Album ?AlbumObject { get; set; }
        public List<deleteimage> ?Images { get; set; }
    }

    public class deleteimage
    {
        public int id { get; set; }
        public string ?ImageUrl { get; set; }
        public bool CheckedStatus { get; set; }
    }
}
