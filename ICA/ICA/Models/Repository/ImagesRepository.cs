using ICA.Data;

namespace ICA.Models.Repository
{
    public class ImagesRepository : ICRUD<Images>
    {
        private readonly ApplicationDbContext db;

        public ImagesRepository(ApplicationDbContext Db)
        {
            db = Db;
        }
        public void Add(Images entity)
        {
            db.Images.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            db.Images.Remove(entity);
            db.SaveChanges();
        }

        public Images find(int id)
        {
            return db.Images.Find(id);
        }

        public List<Images> List()
        {
            return db.Images.ToList();
        }

        public void Update(Images entity)
        {
            db.Images.Update(entity);
            db.SaveChanges();
        }
    }
}
