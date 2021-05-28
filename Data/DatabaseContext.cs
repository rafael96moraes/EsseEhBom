using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Linq;
using System.Threading.Tasks;
using EsseEhBom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EsseEhBom.Data
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<MainCastMovie> MainCastMovies { get; set; }
        public DbSet<MainCastSerie> MainCastSeries { get; set; }
        public DbSet<ReviewMovie> CommentsMovie { get; set; }
        public DbSet<ReviewSerie> CommentsSerie { get; set; }
        public DbSet<ReviewBook> CommentsBook { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<ApplicationUser> AplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LateName { get; set; }
        public DateTime Birth { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}