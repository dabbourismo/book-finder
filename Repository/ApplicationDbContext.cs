using Repository.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=local")
        {
            //Database.Log = e => Debug.WriteLine(e);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Manuscript> Manuscripts { get; set; }

        public DbSet<BookOne> BookOnes { get; set; }
        public DbSet<BookTwo> BookTwos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Manuscript>().ToTable("Manuscripts");

            modelBuilder.Entity<BookOne>().ToTable("BookOnes");
            modelBuilder.Entity<BookTwo>().ToTable("BookTwos");
        }
    }
}
