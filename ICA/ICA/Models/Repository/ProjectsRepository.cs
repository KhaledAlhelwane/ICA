using ICA.Data;
namespace ICA.Models.Repository
   
{
    public class ProjectsRepository : ICRUD<projects>
    {
    private readonly ApplicationDbContext db;

    public ProjectsRepository(ApplicationDbContext Db)
        {
        db = Db;
    }
        public void Add(projects entity)
        {
            db.projects.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entiy = find(id);
            db.projects.Remove(entiy);
            db.SaveChanges();
        }

        public projects find(int id)
        {
            return db.projects.Find(id);    
        }

        public List<projects> List()
        {
            return db.projects.ToList();
        }

        public void Update(projects entity)
        {
            db.projects.Update(entity);
            db.SaveChanges();
        }
    }
}
