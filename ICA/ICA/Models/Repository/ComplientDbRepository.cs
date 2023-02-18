using ICA.Data;

namespace ICA.Models.Repository
{
    public class ComplientDbRepository : ICRUD<ComplintDep>
    {
        private readonly ApplicationDbContext db;

        public ComplientDbRepository(ApplicationDbContext Db)
        {
            db = Db;
        }
        public void Add(ComplintDep entity)
        {
            db.ComplintDep.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            db.ComplintDep.Remove(entity);
            db.SaveChanges();
        }

        public ComplintDep find(int id)
        {
            return db.ComplintDep.Find(id);
        }

        public List<ComplintDep> List()
        {
            return db.ComplintDep.ToList();
        }

        public void Update(ComplintDep entity)
        {
            db.ComplintDep.Update(entity);
            db.SaveChanges();
        }
    }
}
