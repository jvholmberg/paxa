using System;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using Paxa.Common.Entities;

namespace Paxa.Data.Contexts
{
    public sealed class ModelConfiguration
    {

        public static void Setup(ModelBuilder modelBuilder)
        {

            // Participant
            modelBuilder.Entity<Participant>()
                .HasOne(participant => participant.Person)
                .WithMany(person => person.Participating)
                .HasForeignKey(participant => participant.BookingId);
            modelBuilder.Entity<Participant>()
                .HasOne(participant => participant.Type)
                .WithMany(participantType => participantType.Participants)
                .HasForeignKey(participant => participant.TypeId);

            // Booking
            modelBuilder.Entity<Booking>()
                .HasMany(bok => bok.Participants)
                .WithOne(par => par.Booking)
                .HasForeignKey(par => par.BookingId);

            // Timeslot
            modelBuilder.Entity<Timeslot>()
                .HasOne(timeslot => timeslot.Booking)
                .WithOne(booking => booking.Timeslot)
                .HasForeignKey<Booking>(booking => booking.TimeslotId)
                .IsRequired(false);

            // Resource
            modelBuilder.Entity<Resource>()
                .HasOne(resource => resource.Type)
                .WithMany(resourceType => resourceType.Resources)
                .HasForeignKey(resource => resource.TypeId);
            modelBuilder.Entity<Resource>()
                .HasMany(res => res.Timeslots)
                .WithOne(timeslot => timeslot.Resource)
                .HasForeignKey(timeslot => timeslot.ResourceId)
                .IsRequired(false);

            // SchemaEntry
            modelBuilder.Entity<SchemaEntry>()
                .HasOne(schemaEntry => schemaEntry.Weekday)
                .WithMany(weekday => weekday.SchemaEntries)
                .HasForeignKey(schemaEntry => schemaEntry.WeekdayId);

            // Schema
            modelBuilder.Entity<Schema>()
                .HasOne(schema => schema.Organization)
                .WithMany(organization => organization.Schemas)
                .HasForeignKey(schema => schema.OrganizationId);
            modelBuilder.Entity<Schema>()
                .HasMany(schema => schema.Resources)
                .WithOne(resource => resource.Schema)
                .HasForeignKey(resource => resource.SchemaId)
                .IsRequired(false);
            modelBuilder.Entity<Schema>()
                .HasMany(schema => schema.SchemaEntries)
                .WithOne(schemaEntry => schemaEntry.Schema)
                .HasForeignKey(schemaEntry => schemaEntry.SchemaId)
                .IsRequired(false);

            // Rating
            modelBuilder.Entity<Rating>()
                .HasOne(rating => rating.Type)
                .WithMany(ratingType => ratingType.Ratings)
                .HasForeignKey(rating => rating.TypeId);

            // Organization
            modelBuilder.Entity<Organization>()
                .HasOne(organization => organization.Location)
                .WithOne(location => location.Organization)
                .HasForeignKey<Organization>(organization => organization.LocationId)
                .IsRequired(false);
            modelBuilder.Entity<Organization>()
                .HasMany(organization => organization.Ratings)
                .WithOne(rating => rating.Organization)
                .HasForeignKey(rating => rating.OrganizationId)
                .IsRequired(false);
            modelBuilder.Entity<Organization>()
                .HasMany(organization => organization.Resources)
                .WithOne(resource => resource.Organization)
                .HasForeignKey(resource => resource.OrganizationId)
                .IsRequired(false);

            // Membership
            modelBuilder.Entity<Membership>()
                .HasOne(membership => membership.Organization)
                .WithMany(organization => organization.Memberships)
                .HasForeignKey(membership => membership.OrganizationId);
            modelBuilder.Entity<Membership>()
                .HasOne(membership => membership.User)
                .WithMany(user => user.Memberships)
                .HasForeignKey(membership => membership.UserId);
            modelBuilder.Entity<Membership>()
                .HasOne(membership => membership.Role)
                .WithMany(role => role.Memberships)
                .HasForeignKey(membership => membership.RoleId);

            // Person
            modelBuilder.Entity<Person>()
                .HasOne(person => person.Address)
                .WithOne(address => address.Person)
                .HasForeignKey<Person>(person => person.AddressId)
                .IsRequired(false);
            modelBuilder.Entity<Person>()
                .HasMany(person => person.Ratings)
                .WithOne(rating => rating.Person)
                .HasForeignKey(rating => rating.PersonId)
                .IsRequired(false);
            modelBuilder.Entity<Person>()
                .HasMany(person => person.Participating)
                .WithOne(par => par.Person)
                .HasForeignKey(par => par.PersonId)
                .IsRequired(false);

            // Friendship
            modelBuilder.Entity<Friendship>()
                .HasOne(friendship => friendship.FromPerson)
                .WithMany(person => person.FromFriendships)
                .HasForeignKey(friendship => friendship.FromPersonId);
            modelBuilder.Entity<Friendship>()
                .HasOne(friendship => friendship.ToPerson)
                .WithMany(person => person.ToFriendships)
                .HasForeignKey(friendship => friendship.ToPersonId);
            modelBuilder.Entity<Friendship>()
                .HasOne(friendship => friendship.Type)
                .WithMany(friendshipType => friendshipType.Friendships)
                .HasForeignKey(friendship => friendship.TypeId);

            // User
            modelBuilder.Entity<User>()
                .HasOne(user => user.Person)
                .WithOne(person => person.User)
                .HasForeignKey<User>(user => user.PersonId);
            modelBuilder.Entity<User>()
                .OwnsMany(user => user.RefreshTokens)
                .WithOwner(refreshToken => refreshToken.User)
                .HasForeignKey(refreshToken => refreshToken.UserId);

        }
    }
}
