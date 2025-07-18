﻿using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library

{
    public class Context : DbContext

    {
        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "",
                Email = "admin@gmail.com",
                MobileNumber = "1234567890",
                AccountStatus = AccountStatus.ACTIVE,
                UserType = UserType.ADMIN,
                Password = "admin1999",
                CreatedOn = new DateTime(2025, 07, 01, 13, 28, 12)
            });
            modelBuilder.Entity<BookCategory>().HasData(
               new BookCategory { Id = 1, Category = "computer", SubCategory = "algorithm" },
               new BookCategory { Id = 2, Category = "computer", SubCategory = "programming languages" },
               new BookCategory { Id = 3, Category = "computer", SubCategory = "networking" },
               new BookCategory { Id = 4, Category = "computer", SubCategory = "hardware" },
               new BookCategory { Id = 5, Category = "mechanical", SubCategory = "machine" },
               new BookCategory { Id = 6, Category = "mechanical", SubCategory = "transfer of energy" },
               new BookCategory { Id = 7, Category = "mathematics", SubCategory = "calculus" },
               new BookCategory { Id = 8, Category = "mathematics", SubCategory = "algebra" });

            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, BookCategoryId = 1, Ordered = false, Price = 100, Author = "Clifford Stein", Title = "Introduction to Algorithm" },
            new Book { Id = 2, BookCategoryId = 1, Ordered = false, Price = 100, Author = "Clifford Stein", Title = "Introduction to Algorithm" },
            new Book { Id = 3, BookCategoryId = 1, Ordered = false, Price = 200, Author = "Robert Sedgewick & Kevin Wayne", Title = "Algorithms" },
            new Book { Id = 4, BookCategoryId = 1, Ordered = false, Price = 300, Author = "Steve Skiena", Title = "The Algorithm Design Manual" },
            new Book { Id = 5, BookCategoryId = 1, Ordered = false, Price = 400, Author = "Adnan Aziz", Title = "Algorithms For Interviews" },
            new Book { Id = 6, BookCategoryId = 1, Ordered = false, Price = 400, Author = "Adnan Aziz", Title = "Algorithms For Interviews" },
            new Book { Id = 7, BookCategoryId = 1, Ordered = false, Price = 600, Author = "Klienberg & Tardos", Title = "Algorithm Design" },

            new Book { Id = 8, BookCategoryId = 2, Ordered = false, Price = 700, Author = "Eric Matthes", Title = "Python Crash Course: A Hands-On, Project-Based Introduction to Programming" },
            new Book { Id = 9, BookCategoryId = 2, Ordered = false, Price = 700, Author = "Eric Matthes", Title = "Python Crash Course: A Hands-On, Project-Based Introduction to Programming" },
            new Book { Id = 10, BookCategoryId = 2, Ordered = false, Price = 700, Author = "Eric Matthes", Title = "Python Crash Course: A Hands-On, Project-Based Introduction to Programming" },
            new Book { Id = 11, BookCategoryId = 2, Ordered = false, Price = 1000, Author = "Kathy Sierra and Bert Bates", Title = "Head First Java" },
            new Book { Id = 12, BookCategoryId = 2, Ordered = false, Price = 1100, Author = "Brian W. Kernighan, Dennis M. Ritchie", Title = "C Programming Language" },
            new Book { Id = 13, BookCategoryId = 2, Ordered = false, Price = 1100, Author = "Brian W. Kernighan, Dennis M. Ritchie", Title = "C Programming Language" },
            new Book { Id = 14, BookCategoryId = 2, Ordered = false, Price = 1200, Author = "Marijn Haverbeke", Title = "Eloquent JavaScript: A Modern Introduction to Programming" },

            new Book { Id = 15, BookCategoryId = 3, Ordered = false, Price = 1400, Author = "James F Kurose and Keith W Ross", Title = "A Top-Down Approach: Computer Networking" },
            new Book { Id = 16, BookCategoryId = 3, Ordered = false, Price = 1500, Author = "Rich Seifert and James Edwards", Title = "The All-New Switch Book (2nd Edition)" },
            new Book { Id = 17, BookCategoryId = 3, Ordered = false, Price = 1700, Author = "Forouzan", Title = "Data Communications and Networking with TCP/IP Protocol Suite, 6th Edition" },
            new Book { Id = 18, BookCategoryId = 3, Ordered = false, Price = 1800, Author = "Gary Donahue", Title = "Network Warrior, 2nd Edition" },

            new Book { Id = 19, BookCategoryId = 4, Ordered = false, Price = 1900, Author = "Ramesh Gaonkar", Title = "Microprocessor Architecture, Programming, and Applications with the 8085 (4th Edition)" },
            new Book { Id = 20, BookCategoryId = 4, Ordered = false, Price = 2000, Author = "Douglas V. Hall", Title = "Microprocessors and Interfacing: Programming and Hardware (Hardcover)" },
            new Book { Id = 21, BookCategoryId = 4, Ordered = false, Price = 2100, Author = "Kenneth L. Short", Title = "Embedded Microprocessor Systems Design" },
            new Book { Id = 22, BookCategoryId = 4, Ordered = false, Price = 2200, Author = "Dr. Vibhav Kumar Sachan", Title = "Digital Electronics & Microprocessor" },
            new Book { Id = 23, BookCategoryId = 4, Ordered = false, Price = 2300, Author = "Xiaocong Fan", Title = "Real-Time Embedded Systems" },

            new Book { Id = 24, BookCategoryId = 5, Ordered = false, Price = 2500, Author = "Shigley's Mechanical Engineering Design", Title = "Richard G. Budynas and Keith J. Nisbett" },
            new Book { Id = 25, BookCategoryId = 5, Ordered = false, Price = 2600, Author = "Erik Oberg", Title = "Machinery's Handbook" },
            new Book { Id = 26, BookCategoryId = 5, Ordered = false, Price = 2800, Author = "Robert L. Norton", Title = "Machine Design" },
            new Book { Id = 27, BookCategoryId = 5, Ordered = false, Price = 2800, Author = "Robert L. Norton", Title = "Machine Design" },

            new Book { Id = 28, BookCategoryId = 6, Ordered = false, Price = 3000, Author = "Frank M. White", Title = "Fluid Mechanics" },
            new Book { Id = 29, BookCategoryId = 6, Ordered = false, Price = 3100, Author = "Claus Borgnakke and Richard E. Sonntag", Title = "Fundamentals of Thermodynamics" },
            new Book { Id = 30, BookCategoryId = 6, Ordered = false, Price = 3100, Author = "Claus Borgnakke and Richard E. Sonntag", Title = "Fundamentals of Thermodynamics" },

            new Book { Id = 31, BookCategoryId = 7, Ordered = false, Price = 3200, Author = "James Stewart", Title = "Calculus: Early Transcendentals" },
            new Book { Id = 32, BookCategoryId = 7, Ordered = false, Price = 3400, Author = "Louis Leithold", Title = "The Calculus with Analytic Geometry" },

            new Book { Id = 33, BookCategoryId = 8, Ordered = false, Price = 3600, Author = "Robert Kanigel", Title = "The Man Who Knew Infinity: A Life of the Genius Ramanujan" },
            new Book { Id = 34, BookCategoryId = 8, Ordered = false, Price = 3600, Author = "Robert Kanigel", Title = "The Man Who Knew Infinity: A Life of the Genius Ramanujan" },
            new Book { Id = 35, BookCategoryId = 8, Ordered = false, Price = 3700, Author = "Stephen Hawking", Title = "A Brief History of Time" },
            new Book { Id = 36, BookCategoryId = 8, Ordered = false, Price = 3800, Author = "Albert Einstein", Title = "Relativity: The Special and the General Theory" });



    }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<UserType>().HaveConversion<string>();
            configurationBuilder.Properties<AccountStatus>().HaveConversion<string>();
        }

     }
}
