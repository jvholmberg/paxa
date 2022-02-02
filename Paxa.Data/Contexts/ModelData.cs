using System;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using Paxa.Common.Entities;

namespace Paxa.Data.Contexts
{
    public sealed class ModelData
    {

        public static void Setup(ModelBuilder modelBuilder)
        {
            // Weekday
            modelBuilder
                .Entity<Weekday>()
                .HasData(
                    new Weekday { Id = 1, Number = 0, Name = "Sunday" },
                    new Weekday { Id = 2, Number = 1, Name = "Monday" },
                    new Weekday { Id = 3, Number = 2, Name = "Tuesday" },
                    new Weekday { Id = 4, Number = 3, Name = "Wednesday" },
                    new Weekday { Id = 5, Number = 4, Name = "Thursday" },
                    new Weekday { Id = 6, Number = 5, Name = "Friday" },
                    new Weekday { Id = 7, Number = 6, Name = "Saturday" }
                );

            // MembershipRole
            modelBuilder
                .Entity<MembershipRole>()
                .HasData(
                    new MembershipRole { Id = 1, Code = "OWNER", Name = "Owner", Description = "Description for owner-role" },
                    new MembershipRole { Id = 2, Code = "ADMIN", Name = "Admin", Description = "Description for admin-role" },
                    new MembershipRole { Id = 3, Code = "MEMBER", Name = "Member", Description = "Description for member-role" },
                    new MembershipRole { Id = 4, Code = "TRIAL", Name = "Trial", Description = "Description for trial-role" }
                ); 

            // RatingType
            modelBuilder
                .Entity<RatingType>()
                .HasData(
                    new RatingType { Id = 1, Name = "General" },
                    new RatingType { Id = 2, Name = "Personnel" },
                    new RatingType { Id = 3, Name = "Washrooms" },
                    new RatingType { Id = 4, Name = "Building" }
                );

            // ResourceType
            modelBuilder
                .Entity<ResourceType>()
                .HasData(
                    new ResourceType { Id = 1, Name = "Padel", Description = "Description" },
                    new ResourceType { Id = 2, Name = "Tennis", Description = "Description" },
                    new ResourceType { Id = 3, Name = "Badminton", Description = "Description" },
                    new ResourceType { Id = 4, Name = "Table tennis", Description = "Description" },
                    new ResourceType { Id = 5, Name = "Riding", Description = "Description" }
                );  

        }

        public static void SetupDevelopment(ModelBuilder modelBuilder)
        {
            // Address
            modelBuilder
                .Entity<Address>()
                .HasData(
                    new Address { Id = 1, Street = "Cool road 1", City = "Test city", PostalCode = "73574", Country = "Sweden" },
                    new Address { Id = 2, Street = "Not so cool road 4", City = "Test city", PostalCode = "73574", Country = "Sweden" },
                    new Address { Id = 3, Street = "Regular road 21", City = "Some city", PostalCode = "43715", Country = "Sweden" },
                    new Address { Id = 4, Street = "Unregular road 2", City = "Some city", PostalCode = "43715", Country = "Sweden" }
                );

            // Booking
            modelBuilder
                .Entity<Booking>()
                .HasData(
                    new Booking { Id = 1, TimeslotId = 1 },
                    new Booking { Id = 2, TimeslotId = 2 },
                    new Booking { Id = 3, TimeslotId = 3 }
                );
            
            // Location
            modelBuilder
                .Entity<Location>()
                .HasData(
                    new Location { Id = 1, Latitude = "0", Longitude = "0" },
                    new Location { Id = 2, Latitude = "99", Longitude = "99" }
                );

            // Organization
            modelBuilder
                .Entity<Organization>()
                .HasData(
                    new Organization { Id = 1, Name = "Valid Inc", Description = "Description 1", LocationId = 1 },
                    new Organization { Id = 2, Name = "Correct Inc", Description = "Description 2", LocationId = 2 },
                    new Organization { Id = 3, Name = "Hard to find", Description = "Description 2" }
                );

            // Person
            modelBuilder
                .Entity<Person>()
                .HasData(
                    new Person { Id = 1, FirstName = "Johan", LastName = "Holmberg", AddressId = 1 },
                    new Person { Id = 2, FirstName = "Joel", LastName = "Holmberg", AddressId = 2 },
                    new Person { Id = 3, FirstName = "Sam", LastName = "Samson", AddressId = 3 },
                    new Person { Id = 4, FirstName = "John", LastName = "Doe", AddressId = 4 }
                );

            // Rating
            modelBuilder
                .Entity<Rating>()
                .HasData(
                    new Rating { Id = 1, TypeId = 1, Value = 5, PersonId = 2 }
                );
            
            // Resource
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

            // Timeslot
            var now = DateTime.UtcNow;
            modelBuilder
                .Entity<Timeslot>()
                .HasData(
                    new Timeslot { Id = 1, ResourceId = 1, From = now, To = now.AddHours(1) },
                    new Timeslot { Id = 2, ResourceId = 1, From = now.AddHours(1), To = now.AddHours(2) },
                    new Timeslot { Id = 3, ResourceId = 1, From = now.AddHours(2), To = now.AddHours(3) },
                    new Timeslot { Id = 4, ResourceId = 1, From = now.AddHours(3), To = now.AddHours(4) },
                    new Timeslot { Id = 5, ResourceId = 1, From = now.AddHours(4), To = now.AddHours(5) },
                    new Timeslot { Id = 6, ResourceId = 1, From = now.AddHours(5), To = now.AddHours(6) },
                    new Timeslot { Id = 7, ResourceId = 1, From = now.AddHours(6), To = now.AddHours(7) },
                    new Timeslot { Id = 8, ResourceId = 1, From = now.AddHours(7), To = now.AddHours(8) },
                    new Timeslot { Id = 9, ResourceId = 1, From = now.AddHours(8), To = now.AddHours(9) }
                );
            
            // User
            modelBuilder
                .Entity<User>()
                .HasData(
                    new User { Id = 1, Email = "johan.holmberg@domain.se", PasswordHash = BCryptNet.HashPassword("johan"), PersonId = 1 },
                    new User { Id = 2, Email = "joel.holmberg@domain.se", PasswordHash = BCryptNet.HashPassword("joel"), PersonId = 2 },
                    new User { Id = 3, Email = "owner@houseofpadel.se", PasswordHash = BCryptNet.HashPassword("houseofpadel"), PersonId = 3 },
                    new User { Id = 4, Email = "owner@sanktgorans.se", PasswordHash = BCryptNet.HashPassword("sanktgorans"), PersonId = 4 }
                );

            // Memberships
            modelBuilder
                .Entity<Membership>()
                .HasData(
                    new Membership { Id = 1, RoleId = 1, OrganizationId = 1, UserId = 3 },
                    new Membership { Id = 2, RoleId = 1, OrganizationId = 2, UserId = 4 },
                    new Membership { Id = 3, RoleId = 2, OrganizationId = 2, UserId = 1 }
                );

            // ResourceSchema
            modelBuilder
                .Entity<ResourceSchema>()
                .HasData(
                    new ResourceSchema { Id = 1, Active = true, Name = "Default Schema", OrganizationId = 1 }
                );

            // Time
            modelBuilder
                .Entity<Timestamp>()
                .HasData(
                    new Timestamp { Id = 1, Hours = 10, Minutes = 0, Seconds = 0 },
                    new Timestamp { Id = 2, Hours = 11, Minutes = 0, Seconds = 0 },
                    new Timestamp { Id = 3, Hours = 11, Minutes = 0, Seconds = 0 },
                    new Timestamp { Id = 4, Hours = 12, Minutes = 0, Seconds = 0 },
                    new Timestamp { Id = 5, Hours = 10, Minutes = 0, Seconds = 0 },
                    new Timestamp { Id = 6, Hours = 11, Minutes = 0, Seconds = 0 },
                    new Timestamp { Id = 7, Hours = 11, Minutes = 0, Seconds = 0 },
                    new Timestamp { Id = 8, Hours = 12, Minutes = 0, Seconds = 0 }
                );

            // TimeslotSchema
            modelBuilder
                .Entity<TimeslotSchema>()
                .HasData(
                    new TimeslotSchema { Id = 1, FromTimestampId = 1, ToTimestampId = 2, ResourceSchemaId = 1, WeekdayId = 1 },
                    new TimeslotSchema { Id = 2, FromTimestampId = 3, ToTimestampId = 4, ResourceSchemaId = 1, WeekdayId = 1 },
                    new TimeslotSchema { Id = 3, FromTimestampId = 5, ToTimestampId = 6, ResourceSchemaId = 1, WeekdayId = 7 },
                    new TimeslotSchema { Id = 4, FromTimestampId = 7, ToTimestampId = 8, ResourceSchemaId = 1, WeekdayId = 7 }
                );
        }
    }
}
