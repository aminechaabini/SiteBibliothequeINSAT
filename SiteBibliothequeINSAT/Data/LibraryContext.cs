
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public class LibraryContext : DbContext
    {
        private static LibraryContext _instance;
        private LibraryContext(DbContextOptions o) : base(o)
        {

        }

        public static LibraryContext Instantiate_LibraryContext()
        {
            if (_instance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
                optionsBuilder.UseSqlite(@"Data source=D:\\Documents\INSATlibrarydb.db");
                _instance = new LibraryContext(optionsBuilder.Options);
                //using (_instance)
                //{
                //    _instance.Database.EnsureCreated(); 
                //}
            }
            return _instance;

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                        .HasOne(r => r.student)
                        .WithMany(s => s.reviews)
                        .HasForeignKey(r => r.StudentId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.book)
                .WithMany(b => b.reviews)
                .HasForeignKey(r => r.BooktId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.student)
                        .WithMany(s => s.reservations)
                        .HasForeignKey(r => r.StudentId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.book)
                .WithMany(b => b.reservations)
                .HasForeignKey(r => r.BooktId);

            modelBuilder.Entity<Loan>()
                 .HasOne(l => l.student)
                 .WithMany(s => s.loans)
                 .HasForeignKey(l => l.StudentId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.book)
                .WithMany(b => b.loans)
                .HasForeignKey(r => r.BooktId);

            modelBuilder.Entity<Book>()
                .HasOne(b=> b.genre)
                .WithMany(g=>g.books)
                .HasForeignKey(b => b.GenreId);

            modelBuilder.Entity<Book>()
               .HasOne(b => b.author)
               .WithMany(a => a.books)
               .HasForeignKey(b => b.AuthorId);

            

        }

    }
}