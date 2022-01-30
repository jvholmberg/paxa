using System;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using Paxa.Common.Entities;

namespace Paxa.Contexts
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
                .HasForeignKey<Booking>(booking => booking.TimeslotId);

            // Resource
            modelBuilder.Entity<Resource>()
                .HasOne(resource => resource.Type)
                .WithMany(resourceType => resourceType.Resources)
                .HasForeignKey(resource => resource.TypeId);
            modelBuilder.Entity<Resource>()
                .HasMany(res => res.Timeslots)
                .WithOne(timeslot => timeslot.Resource)
                .HasForeignKey(timeslot => timeslot.ResourceId);

            // TimeslotSchema
            modelBuilder.Entity<TimeslotSchema>()
                .HasOne(timeslotSchema => timeslotSchema.FromTimestamp)
                .WithOne(timestamp => timestamp.FromTimeslotSchema)
                .HasForeignKey<TimeslotSchema>(timeslotSchema => timeslotSchema.FromTimestampId);
            modelBuilder.Entity<TimeslotSchema>()
                .HasOne(timeslotSchema => timeslotSchema.ToTimestamp)
                .WithOne(timestamp => timestamp.ToTimeslotSchema)
                .HasForeignKey<TimeslotSchema>(timeslotSchema => timeslotSchema.ToTimestampId);
            modelBuilder.Entity<TimeslotSchema>()
                .HasOne(timeslotSchema => timeslotSchema.Weekday)
                .WithMany(weekday => weekday.TimeslotSchemas)
                .HasForeignKey(timeslotSchema => timeslotSchema.WeekdayId);

            // ResourceSchema
            modelBuilder.Entity<ResourceSchema>()
                .HasOne(resourceSchema => resourceSchema.Organization)
                .WithMany(organization => organization.ResourceSchemas)
                .HasForeignKey(resourceSchema => resourceSchema.OrganizationId);
            modelBuilder.Entity<ResourceSchema>()
                .HasMany(resourceSchema => resourceSchema.Resources)
                .WithOne(resource => resource.ResourceSchema)
                .HasForeignKey(resource => resource.ResourceSchemaId);
            modelBuilder.Entity<ResourceSchema>()
                .HasMany(resourceSchema => resourceSchema.TimeslotSchemas)
                .WithOne(timeslotSchema => timeslotSchema.ResourceSchema)
                .HasForeignKey(resourceSchema => resourceSchema.ResourceSchemaId);

            // Rating
            modelBuilder.Entity<Rating>()
                .HasOne(rating => rating.Type)
                .WithMany(ratingType => ratingType.Ratings)
                .HasForeignKey(rating => rating.TypeId);

            // Organization
            modelBuilder.Entity<Organization>()
                .HasOne(organization => organization.Location)
                .WithOne(location => location.Organization)
                .HasForeignKey<Organization>(organization => organization.LocationId);
            modelBuilder.Entity<Organization>()
                .HasMany(organization => organization.Ratings)
                .WithOne(rating => rating.Organization)
                .HasForeignKey(rating => rating.OrganizationId);
            modelBuilder.Entity<Organization>()
                .HasMany(organization => organization.Resources)
                .WithOne(resource => resource.Organization)
                .HasForeignKey(resource => resource.OrganizationId);

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
                .HasForeignKey<Person>(person => person.AddressId);
            modelBuilder.Entity<Person>()
                .HasMany(person => person.Ratings)
                .WithOne(rating => rating.Person)
                .HasForeignKey(rating => rating.PersonId);
            modelBuilder.Entity<Person>()
                .HasMany(person => person.Participating)
                .WithOne(par => par.Person)
                .HasForeignKey(par => par.PersonId);

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
