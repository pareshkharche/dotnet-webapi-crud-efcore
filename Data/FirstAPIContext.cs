using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data
{
    public class FirstAPIContext: DbContext
    {
        public FirstAPIContext(DbContextOptions<FirstAPIContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                        new Book
                        {
                            Id = 1,
                            Title = "Clean Code",
                            Author = "Robert C. Martin",
                            YearPublished = 2008
                        },
                    new Book
                    {
                        Id = 2,
                        Title = "The Pragmatic Programmer",
                        Author = "Andrew Hunt",
                        YearPublished = 1999
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Design Patterns",
                        Author = "Erich Gamma",
                        YearPublished = 1994
                    },
                    new Book
                    {
                        Id = 4,
                        Title = "Refactoring",
                        Author = "Martin Fowler",
                        YearPublished = 1999
                    },
                    new Book
                    {
                        Id = 5,
                        Title = "Introduction to Algorithms",
                        Author = "Thomas H. Cormen",
                        YearPublished = 2009
                    },
                    new Book
                    {
                        Id = 6,
                        Title = "Head First Design Patterns",
                        Author = "Eric Freeman",
                        YearPublished = 2004
                    },
                    new Book
                    {
                        Id = 7,
                        Title = "You Don’t Know JS",
                        Author = "Kyle Simpson",
                        YearPublished = 2015
                    },
                    new Book
                    {
                        Id = 8,
                        Title = "Effective Java",
                        Author = "Joshua Bloch",
                        YearPublished = 2001
                    },
                    new Book
                    {
                        Id = 9,
                        Title = "C# in Depth",
                        Author = "Jon Skeet",
                        YearPublished = 2019
                    },
                    new Book
                    {
                        Id = 10,
                        Title = "System Design Interview",
                        Author = "Alex Xu",
                        YearPublished = 2020
                    }

                );
        }
        public DbSet<Book> Books {get; set;}
    }
}
