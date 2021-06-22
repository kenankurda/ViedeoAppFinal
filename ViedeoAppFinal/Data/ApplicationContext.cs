using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViedeoAppFinal.Models;

namespace ViedeoAppFinal.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = 1, Name="Action"},
                new Genre() { GenreId = 2, Name="Comedy"},
                new Genre() { GenreId = 3, Name="Action-Comedy"},
                new Genre() { GenreId = 4, Name="Romance"});


            modelBuilder.Entity<Actor>().HasData(
                new Actor() { ActorId=1, FirstName="Kenan", LastName="Kurda", DayOfBirth = new DateTime(1970, 05,29)},
                new Actor() { ActorId=2, FirstName="Harrison", LastName="Ford", DayOfBirth = new DateTime(1956, 02,18)},               
                new Actor() { ActorId=3, FirstName="Antony", LastName="Hopkins", DayOfBirth = new DateTime(1945, 06, 30) },
                new Actor() { ActorId=4, FirstName="Johny", LastName="Dep", DayOfBirth = new DateTime(1980, 03,30)});


            modelBuilder.Entity<Video>().HasData(
                new Video() { VideoId = 1, Name = "Indiana Johnes", GenreId = 1 },
                new Video() { VideoId = 2, Name = "Call of wild", GenreId = 1 },
                new Video() { VideoId = 3, Name = "Pirates of the Caribean", GenreId = 3 });     
        }


        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
