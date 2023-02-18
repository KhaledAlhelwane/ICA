using ICA.Data;

namespace ICA.Models.Repository
{
    public class TypeOfArticlesRepository : ICRUD<TypeOfArticle>
    {
        private readonly ApplicationDbContext db;

        public TypeOfArticlesRepository(ApplicationDbContext Db) 
        {
            db = Db;
        }
        public void Add(TypeOfArticle entity)
        {
           db.TypeOfArticles.Add(entity);   
            db.SaveChanges();   
        }

        public void Delete(int id)
        {
            var entity = find(id);
            db.TypeOfArticles.Remove(entity);   
            db.SaveChanges();
        }

        public TypeOfArticle find(int id)
        {
            return db.TypeOfArticles.Find(id);  

        }

        public List<TypeOfArticle> List()
        {
           return db.TypeOfArticles.ToList();   
        }

        public void Update(TypeOfArticle entity)
        {
            db.TypeOfArticles.Update(entity);
            db.SaveChanges();
        }
    }
}
