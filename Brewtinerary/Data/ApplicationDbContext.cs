using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Capstone.Models.Data;
using Capstone.Models;
using System;

namespace Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<RefreshToken> RefreshToken { get; set; }

        public DbSet<Brewery> Breweries { get; set; }

        public DbSet<Beer> Beers { get; set; }

        public DbSet<Itinerary> Itineraries { get; set; }

        public DbSet<ItineraryBrewery> ItineraryBreweries { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<UserComments> UserComments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Set the default behavior of an Itinerary's date in the database to be the current date/time if none is provided by the client
            builder.Entity<Itinerary>()
                .Property(i => i.DateOfEvent)
                .HasDefaultValueSql("GETDATE()");

            //Restrict deletion of related Brewery when Beers Entry is removed
            builder.Entity<Brewery>()
                .HasMany(b => b.Beers)
                .WithOne(b => b.Brewery)
                .OnDelete(DeleteBehavior.Restrict);

            //Restrict deletion of related Itinerary when ItineraryBreweries is removed
            builder.Entity<Itinerary>()
                .HasMany(i => i.ItineraryBreweries)
                .WithOne(ib => ib.Itinerary)
                .OnDelete(DeleteBehavior.Restrict);

            //Restrict deletion of related Comment when UserComments is removed
            builder.Entity<Comment>()
                .HasMany(c => c.UserComments)
                .WithOne(uc => uc.Comment)
                .OnDelete(DeleteBehavior.Restrict);

            //Restrict deletion of related ApplicationUser when UserComments is removed
            builder.Entity<ApplicationUser>()
                .HasMany(au => au.UserComments)
                .WithOne(uc => uc.User)
                .OnDelete(DeleteBehavior.Restrict);

            ApplicationUser user1 = new ApplicationUser()
            {
                FirstName = "Andy",
                LastName = "Collins",
                Email = "andy@andy.com",
                UserName = "andy123",
                NormalizedUserName = "ANDY123",
                NormalizedEmail = "ANDY@ANDY.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                PhoneNumber = "610-123-4567"
            };
            ApplicationUser user2 = new ApplicationUser()
            {
                FirstName = "Jenny",
                LastName = "Wilkinson",
                Email = "jenny@jenny.com",
                UserName = "jenny123",
                NormalizedUserName = "JENNY123",
                NormalizedEmail = "JENNY@JENNY.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794123",
                Id = "00000000-ffff-ffff-ffff-fffffffff123",
                PhoneNumber = "610-989-4567"
            };

            var passwordHash = new PasswordHasher<ApplicationUser>();
            user1.PasswordHash = passwordHash.HashPassword(user1, "Andy8*");
            builder.Entity<ApplicationUser>().HasData(user1);

            var user2PasswordHash = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = user2PasswordHash.HashPassword(user2, "Jenny8*");
            builder.Entity<ApplicationUser>().HasData(user2);

            builder.Entity<Itinerary>().HasData(
                new Itinerary()
                {
                    Id = 1,
                    UserId = user1.Id,
                    Name = "Denver Trip",
                    City = "Denver",
                    State = "CO",
                    DateOfEvent = new DateTime(2020, 5, 19)
                },
                new Itinerary()
                {
                    Id = 4,
                    UserId = user1.Id,
                    Name = "My Birthday",
                    City = "Nashville",
                    State = "TN",
                    DateOfEvent = new DateTime(2020, 11, 11)
                },
                new Itinerary()
                {
                    Id = 2,
                    UserId = user2.Id,
                    Name = "Katie's Birthday",
                    City = "Allentown",
                    State = "PA",
                    DateOfEvent = new DateTime(2020, 7, 20)
                },
                new Itinerary()
                {
                    Id = 3,
                    UserId = user2.Id,
                    Name = "New Years Bash",
                    City = "Nashville",
                    State = "TN",
                    DateOfEvent = new DateTime(2020, 1, 1)
                }
           );
        }
    }
}
