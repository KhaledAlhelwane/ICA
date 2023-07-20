using ICA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ICA.ViewModel;

namespace ICA.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rating>().ToTable("Rating");
            modelBuilder.Entity<Assosiation>().HasData(new Assosiation {Id=1,FullName="عون" });
            modelBuilder.Entity<Assosiation>().HasData(new Assosiation {Id=2,FullName="الميتم" });
            modelBuilder.Entity<Assosiation>().HasData(new Assosiation {Id=3,FullName="صالة زنوبية" });
            modelBuilder.Entity<Assosiation>().HasData(new Assosiation {Id=4,FullName="المدارس الخيرية النموذجية" });
           

        }
        //Tables name to invoce them in the repositories
        public DbSet<Article> Articles { get; set; }
     
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
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Bus> Bus { get; set; }
        




    }
}