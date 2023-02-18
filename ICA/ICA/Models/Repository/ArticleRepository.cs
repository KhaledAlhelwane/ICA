using ICA.Data;
using Microsoft.EntityFrameworkCore;

namespace ICA.Models.Repository
{
    public class ArticleRepository : ICRUD<Article>
    {
        private readonly ApplicationDbContext dB;

        public ArticleRepository(ApplicationDbContext DB)
        {
            dB = DB;
        }
        public void Add(Article entity)
        {
            dB.Articles.Add(entity);
            dB.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = find(id);
            dB.Articles.Remove(entity);
            dB.SaveChanges();
        }

        public Article find(int id)
        { 
            return dB.Articles.Find(id);
        }

        public List<Article> List()
        {
            return dB.Articles.Include(a=>a.Album).ThenInclude(b=>b.Images).Include(c=>c.Assosiation).ToList();
        }

        public void Update(Article entity)
        {
            dB.Articles.Update(entity);
            dB.SaveChanges();

        }
    }
}
