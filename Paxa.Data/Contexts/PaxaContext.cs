using System;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;
using Paxa.Common.Entities;

namespace Paxa.Contexts
{
    public class PaxaContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<MembershipRole> MembershipRoles { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<RatingType> RatingTypes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceSchema> ResourceSchemas { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<TimeslotSchema> TimeslotSchemas { get; set; }
        public DbSet<Timestamp> Timestamps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<FriendshipType> FriendshipTypes { get; set; }
        public DbSet<Weekday> Weekdays { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ParticipantType> ParticipantTypes { get; set; }


        public PaxaContext(DbContextOptions<PaxaContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelConfiguration.Setup(modelBuilder);
            ModelData.Setup(modelBuilder);
            ModelData.SetupDevelopment(modelBuilder);

        }
    }
}
