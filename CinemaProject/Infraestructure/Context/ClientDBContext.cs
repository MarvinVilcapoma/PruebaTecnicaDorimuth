using Common.AspNetCore;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Context
{
    public class ClientDBContext : DbContext
    {
        public ClientDBContext() : base() { }

        public ClientDBContext(DbContextOptions<ClientDBContext> options) : base(options) { }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaRoom> CinemaRooms { get; set; }
        public DbSet<CinemaRoomDetail> CinemaRoomDetails { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);           

            IConfigurationRoot configuration = ConfigManager.GetConfig();
            var connectionString = configuration.GetConnectionString("myconn");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(180));
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(120);
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<QuestionAnswer>().HasKey(qa => qa.QuestionAsnwerID);
            // otras configuraciones
        }
    }
}
