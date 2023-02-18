using ICA.Data;
using Microsoft.Build.FileSystem;

namespace ICA.Models.Repository
{
    public class AssociationRepository : ICRUD<Assosiation>
    {
        private readonly ApplicationDbContext db;

        public AssociationRepository(ApplicationDbContext Db)
        {
            db = Db;
        }
        public void Add(Assosiation entity)
        {
            db.Assosiation.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            db.Assosiation.Remove(entity);
            db.SaveChanges();
        }

        public Assosiation find(int id)
        {
            return db.Assosiation.Find(id);
        }

        public List<Assosiation> List()
        {
            return db.Assosiation.ToList();
        }

        public void Update(Assosiation entity)
        {
            db.Assosiation.Update(entity);
            db.SaveChanges();
        }
    }
}
