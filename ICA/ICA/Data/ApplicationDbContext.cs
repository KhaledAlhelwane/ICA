using ICA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ICA.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Tables name to invoce them in the repositories
        public DbSet<Article> Articles { get; set; }
        public DbSet<TypeOfArticle> TypeOfArticles { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<ITRequist> ITRequists { get; set; }
        public DbSet<projects> projects { get; set; }
        public DbSet<ComplintDep> ComplintDep { get; set; }
        public DbSet<Assosiation> Assosiation { get; set; }
        public DbSet<MainInterface> MainInterface { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MainAssociation> MainAssociations { get; set; }
        public DbSet<Center> Centers { get; set; }





    }
}