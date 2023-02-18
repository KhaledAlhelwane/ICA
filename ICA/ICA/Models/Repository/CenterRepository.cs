using ICA.Data;

namespace ICA.Models.Repository
{
    public class CenterRepository : ICRUD<Center>
    {
        private readonly ApplicationDbContext db;

        public CenterRepository(ApplicationDbContext Db)
        {
            db = Db;
        }
        public void Add(Center entity)
        {
            db.Centers.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            db.Centers.Remove(entity);
            db.SaveChanges();
        }

        public Center find(int id)
        {
            return db.Centers.Find(id);
        }

        public List<Center> List()
        {
            return db.Centers.ToList();
        }

        public void Update(Center entity)
        {
            db.Centers.Update(entity);
            db.SaveChanges();
        }
    }
}
