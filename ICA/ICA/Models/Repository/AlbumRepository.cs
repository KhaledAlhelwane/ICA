using ICA.Data;

namespace ICA.Models.Repository
{
    public class AlbumRepository : ICRUD<Album>
    {
        private readonly ApplicationDbContext db;

        public AlbumRepository(ApplicationDbContext Db)
        {
            db = Db;
        }
        public void Add(Album entity)
        {
            db.Albums.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            db.Albums.Remove(entity);
            db.SaveChanges();
        }

        public Album find(int id)
        {
            return db.Albums.Find(id);
        }

        public List<Album> List()
        {
            return db.Albums.ToList();
        }

        public void Update(Album entity)
        {
            db.Albums.Update(entity);
            db.SaveChanges();
        }
    }
}
