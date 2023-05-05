using System.Reflection.Metadata.Ecma335;

namespace ICA.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string? AlbumTitel { get; set; }
        public ICollection<Images>? Images { get; set; }
        public int ?ArticleId { get; set; }
        public Article ?Article { get; set; }
        public int ?MainAssociationId { get; set; }
        public MainAssociation? MainAssociation { get; set; }
        public int ?projectsId { get; set; }
        public projects? projects { get; set; }
        public int ?MainInterfaceId { get; set; }
        public MainInterface? MainInterface { get; set; }

    }
}
