using ICA.Data;

namespace ICA.Models.Repository
{
    public class MainAssosiationRepository : ICRUD<MainAssociation>
    {
        private readonly ApplicationDbContext db;

        public MainAssosiationRepository(ApplicationDbContext Db)
        {
            db = Db;
        }
        public void Add(MainAssociation entity)
        {
            db.MainAssociations.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            db.MainAssociations.Remove(entity);
            db.SaveChanges();
        }

        public MainAssociation find(int id)
        {
            return db.MainAssociations.Find(id);

        }

        public List<MainAssociation> List()
        {
            return db.MainAssociations.ToList();
        }

        public void Update(MainAssociation entity)
        {
            db.MainAssociations.Update(entity);
            db.SaveChanges();
        }
    }
}
