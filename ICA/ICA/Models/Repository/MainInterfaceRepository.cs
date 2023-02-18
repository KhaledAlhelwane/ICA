using ICA.Data;

namespace ICA.Models.Repository
{
    public class MainInterfaceRepository : ICRUD<MainInterface>
    {
        private readonly ApplicationDbContext db;

        public MainInterfaceRepository(ApplicationDbContext Db)
        {
            db = Db;
        }
        public void Add(MainInterface entity)
        {
            db.MainInterface.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            db.MainInterface.Remove(entity);
            db.SaveChanges();
        }

        public MainInterface find(int id)
        {
         return   db.MainInterface.Find(id);
        }

        public List<MainInterface> List()
        {
            return db.MainInterface.ToList();
        }

        public void Update(MainInterface entity)
        {
            db.MainInterface.Update(entity);
            db.SaveChanges();
        }
    }
}
