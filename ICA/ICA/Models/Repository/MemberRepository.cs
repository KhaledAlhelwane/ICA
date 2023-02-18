using ICA.Data;
using ICA.Data.Migrations;

namespace ICA.Models.Repository
{
    public class MemberRepository : ICRUD<Member>
    {
        private readonly ApplicationDbContext j;

        public MemberRepository(ApplicationDbContext db)
        {
            this.j = db;
        }
        public void Add(Member entity)
        {
            j.Members.Add(entity);
            j.SaveChanges();
        
        }

        public void Delete(int id)
        {
            var x = find(id);
            j.Members.Remove(x);
            j.SaveChanges();
        }

        public Member find(int id)
        {
            return j.Members.Find(id);
        }

        public List<Member> List()
        {
            return j.Members.ToList();
        }

        public void Update(Member entity)
        {
            j.Members.Update(entity);
            j.SaveChanges();
        }
    }
}
