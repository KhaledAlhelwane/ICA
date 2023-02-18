using ICA.Data;

namespace ICA.Models.Repository
{
    public class ItRequistRepository : ICRUD<ITRequist>
    {
        private readonly ApplicationDbContext db;

        public ItRequistRepository(ApplicationDbContext Db)
        {
            db = Db;
        }
        public void Add(ITRequist entity)
        {
            db.ITRequists.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            db.ITRequists.Remove(entity);
            db.SaveChanges();
        }

        public ITRequist find(int id)
        {
            return db.ITRequists.Find(id);
        }

        public List<ITRequist> List()
        {
            return db.ITRequists.ToList();
        }

        public void Update(ITRequist entity)
        {
            db.ITRequists.Update(entity);
            db.SaveChanges();
        }
    }
}
