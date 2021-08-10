using System;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using Paxa.Entities;

namespace Paxa.Contexts
{
    public class PaxaContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<User> Users { get; set; }

        public PaxaContext(DbContextOptions<PaxaContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Address
            modelBuilder
                .Entity<Address>()
                .ToTable("Address");
            modelBuilder
                .Entity<Address>()
                .HasData(
                    new Address { Id = 1, Street = "Femlingehult 2384", City = "Älmhult", PostalCode = "34391", Country = "Sweden" },
                    new Address { Id = 2, Street = "Femlingehult 2384", City = "Älmhult", PostalCode = "34391", Country = "Sweden" }
                );
                
            // Booking
            modelBuilder
                .Entity<Booking>()
                .ToTable("booking");
            modelBuilder
                .Entity<Booking>()
                .HasOne(bok => bok.Host);
            modelBuilder
                .Entity<Booking>()
                .HasMany(bok => bok.Participants);
            modelBuilder
                .Entity<Booking>()
                .HasData(
                    new Booking { Id = 1, TimeslotId = 1, HostId = 1 },
                    new Booking { Id = 2, TimeslotId = 2, HostId = 2 },
                    new Booking { Id = 3, TimeslotId = 3, HostId = 1 }
                );

            // Location
            modelBuilder
                .Entity<Location>()
                .ToTable("location");
            modelBuilder
                .Entity<Location>()
                .HasData(
                    new Location { Id = 1, Latitude = "0", Longitude = "0" },
                    new Location { Id = 2, Latitude = "99", Longitude = "99" }
                );

            // Organization
            modelBuilder
                .Entity<Organization>()
                .ToTable("organization");
            modelBuilder
                .Entity<Organization>()
                .HasOne(org => org.Location);
            modelBuilder
                .Entity<Organization>()
                .HasMany(org => org.Resources);
            modelBuilder
                .Entity<Organization>()
                .HasData(
                    new Organization { Id = 1, Name = "House of Padel", Description = "Description 1", LocationId = 1 },
                    new Organization { Id = 2, Name = "Sankt Jörgens", Description = "Description 2", LocationId = 2 }
                );

            // Person
            modelBuilder
                .Entity<Person>()
                .ToTable("person");
            modelBuilder
                .Entity<Person>()
                .HasMany(per => per.Followers)
                .WithMany(per => per.Following);
            modelBuilder
                .Entity<Person>()
                .HasOne(per => per.Address);
            modelBuilder
                .Entity<Person>()
                .HasData(
                    new Person { Id = 1, FirstName = "Johan", LastName = "Holmberg", AddressId = 1 },
                    new Person { Id = 2, FirstName = "Joel", LastName = "Holmberg", AddressId = 2 }
                );

            // Rating
            modelBuilder
                .Entity<Rating>()
                .ToTable("rating");
            modelBuilder
                .Entity<Rating>()
                .HasOne(res => res.Type);
            modelBuilder
                .Entity<Rating>()
                .HasOne(res => res.Person);
            modelBuilder
                .Entity<Rating>()
                .HasOne(res => res.Organization);
            modelBuilder
                .Entity<Rating>()
                .HasData(
                    new Rating { Id = 1, TypeId = 1, Value = 5, PersonId = 2 }
                );

            // RatingType
            modelBuilder
                .Entity<RatingType>()
                .ToTable("rating_type");
            modelBuilder
                .Entity<RatingType>()
                .HasData(
                    new RatingType { Id = 1, Name = "General" }
                );

            // Resource
            modelBuilder
                .Entity<Resource>()
                .ToTable("resource");
            modelBuilder
                .Entity<Resource>()
                .HasOne(res => res.Type);
            modelBuilder
                .Entity<Resource>()
                .HasOne(res => res.Organization);
            modelBuilder
                .Entity<Resource>()
                .HasMany(res => res.Timeslots);
            modelBuilder
                .Entity<Resource>()
                .HasData(
                    new Resource { Id = 1, Name = "Bana #1", TypeId = 1, OrganizationId = 1 },
                    new Resource { Id = 2, Name = "Bana #2", TypeId = 1, OrganizationId = 1 },
                    new Resource { Id = 3, Name = "Bana #3", TypeId = 1, OrganizationId = 1 },
                    new Resource { Id = 4, Name = "Bana #4", TypeId = 1, OrganizationId = 1 },
                    new Resource { Id = 5, Name = "Utomhus 1", TypeId = 1, OrganizationId = 2 },
                    new Resource { Id = 6, Name = "Utomhus 2", TypeId = 1, OrganizationId = 2 }
                );

            // ResourceType
            modelBuilder
                .Entity<ResourceType>()
                .ToTable("resource_type");
            modelBuilder
                .Entity<ResourceType>()
                .HasData(
                    new ResourceType { Id = 1, Name = "Padel", Description = "Description" }
                );

            // Timeslot
            modelBuilder
                .Entity<Timeslot>()
                .ToTable("timeslot");
            modelBuilder
                .Entity<Timeslot>()
                .HasOne(tms => tms.Booking);
            modelBuilder
                .Entity<Timeslot>()
                .HasData(
                    new Timeslot { Id = 1, From = DateTime.Now, To = DateTime.Now.AddHours(1) },
                    new Timeslot { Id = 2, From = DateTime.Now.AddHours(1), To = DateTime.Now.AddHours(2) },
                    new Timeslot { Id = 3, From = DateTime.Now.AddHours(2), To = DateTime.Now.AddHours(3) },
                    new Timeslot { Id = 4, From = DateTime.Now.AddHours(3), To = DateTime.Now.AddHours(4) },
                    new Timeslot { Id = 5, From = DateTime.Now.AddHours(4), To = DateTime.Now.AddHours(5) },
                    new Timeslot { Id = 6, From = DateTime.Now.AddHours(5), To = DateTime.Now.AddHours(6) },
                    new Timeslot { Id = 7, From = DateTime.Now.AddHours(6), To = DateTime.Now.AddHours(7) },
                    new Timeslot { Id = 8, From = DateTime.Now.AddHours(7), To = DateTime.Now.AddHours(8) },
                    new Timeslot { Id = 9, From = DateTime.Now.AddHours(8), To = DateTime.Now.AddHours(9) }
                );

            // User
            modelBuilder
                .Entity<User>()
                .ToTable("user");
            modelBuilder
                .Entity<User>()
                .HasOne(usr => usr.Person);
            modelBuilder
                .Entity<User>()
                .HasOne(usr => usr.Organization);
            modelBuilder
                .Entity<User>()
                .OwnsMany(usr => usr.RefreshTokens);
            modelBuilder
                .Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Email = "johan.holmberg@domain.se",
                        PasswordHash = BCryptNet.HashPassword("johan"),
                        PersonId = 1,
                    },
                    new User
                    {
                        Id = 2,
                        Email = "joel.holmberg@domain.se",
                        PasswordHash = BCryptNet.HashPassword("joel"),
                        PersonId = 2,
                    },
                    new User
                    {
                        Id = 3,
                        Email = "owner@houseofpadel.se",
                        PasswordHash = BCryptNet.HashPassword("houseofpadel"),
                        OrganizationId = 1,
                    },
                    new User
                    {
                        Id = 4,
                        Email = "owner@sanktgorans.se",
                        PasswordHash = BCryptNet.HashPassword("sanktgorans"),
                        OrganizationId = 2,
                    }
                );
        }
    }
}
