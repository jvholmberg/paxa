﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Paxa.Contexts;

namespace Paxa.Migrations
{
    [DbContext(typeof(PaxaContext))]
    [Migration("20210810204146_RemoveBookingsOnUser")]
    partial class RemoveBookingsOnUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BookingPerson", b =>
                {
                    b.Property<int>("BookingsId")
                        .HasColumnType("integer");

                    b.Property<int>("ParticipantsId")
                        .HasColumnType("integer");

                    b.HasKey("BookingsId", "ParticipantsId");

                    b.HasIndex("ParticipantsId");

                    b.ToTable("BookingPerson");
                });

            modelBuilder.Entity("Paxa.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Älmhult",
                            Country = "Sweden",
                            PostalCode = "34391",
                            Street = "Femlingehult 2384"
                        },
                        new
                        {
                            Id = 2,
                            City = "Älmhult",
                            Country = "Sweden",
                            PostalCode = "34391",
                            Street = "Femlingehult 2384"
                        });
                });

            modelBuilder.Entity("Paxa.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("HostId")
                        .HasColumnType("integer");

                    b.Property<int>("TimeslotId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HostId");

                    b.HasIndex("TimeslotId")
                        .IsUnique();

                    b.ToTable("booking");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HostId = 1,
                            TimeslotId = 1
                        },
                        new
                        {
                            Id = 2,
                            HostId = 2,
                            TimeslotId = 2
                        },
                        new
                        {
                            Id = 3,
                            HostId = 1,
                            TimeslotId = 3
                        });
                });

            modelBuilder.Entity("Paxa.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Latitude")
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("location");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Latitude = "0",
                            Longitude = "0"
                        },
                        new
                        {
                            Id = 2,
                            Latitude = "99",
                            Longitude = "99"
                        });
                });

            modelBuilder.Entity("Paxa.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("organization");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description 1",
                            LocationId = 1,
                            Name = "House of Padel"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description 2",
                            LocationId = 2,
                            Name = "Sankt Jörgens"
                        });
                });

            modelBuilder.Entity("Paxa.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            FirstName = "Johan",
                            LastName = "Holmberg"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            FirstName = "Joel",
                            LastName = "Holmberg"
                        });
                });

            modelBuilder.Entity("Paxa.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("integer");

                    b.Property<int?>("PersonId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TypeId");

                    b.ToTable("rating");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PersonId = 2,
                            TypeId = 1,
                            Value = 5
                        });
                });

            modelBuilder.Entity("Paxa.Entities.RatingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("rating_type");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "General"
                        });
                });

            modelBuilder.Entity("Paxa.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("TypeId");

                    b.ToTable("resource");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bana #1",
                            OrganizationId = 1,
                            TypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bana #2",
                            OrganizationId = 1,
                            TypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bana #3",
                            OrganizationId = 1,
                            TypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bana #4",
                            OrganizationId = 1,
                            TypeId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Utomhus 1",
                            OrganizationId = 2,
                            TypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "Utomhus 2",
                            OrganizationId = 2,
                            TypeId = 1
                        });
                });

            modelBuilder.Entity("Paxa.Entities.ResourceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("resource_type");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            Name = "Padel"
                        });
                });

            modelBuilder.Entity("Paxa.Entities.Timeslot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ResourceId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("timeslot");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            From = new DateTime(2021, 8, 10, 22, 41, 44, 592, DateTimeKind.Local).AddTicks(9850),
                            To = new DateTime(2021, 8, 10, 23, 41, 44, 608, DateTimeKind.Local).AddTicks(1630)
                        },
                        new
                        {
                            Id = 2,
                            From = new DateTime(2021, 8, 10, 23, 41, 44, 608, DateTimeKind.Local).AddTicks(2440),
                            To = new DateTime(2021, 8, 11, 0, 41, 44, 608, DateTimeKind.Local).AddTicks(2450)
                        },
                        new
                        {
                            Id = 3,
                            From = new DateTime(2021, 8, 11, 0, 41, 44, 608, DateTimeKind.Local).AddTicks(2460),
                            To = new DateTime(2021, 8, 11, 1, 41, 44, 608, DateTimeKind.Local).AddTicks(2470)
                        },
                        new
                        {
                            Id = 4,
                            From = new DateTime(2021, 8, 11, 1, 41, 44, 608, DateTimeKind.Local).AddTicks(2470),
                            To = new DateTime(2021, 8, 11, 2, 41, 44, 608, DateTimeKind.Local).AddTicks(2480)
                        },
                        new
                        {
                            Id = 5,
                            From = new DateTime(2021, 8, 11, 2, 41, 44, 608, DateTimeKind.Local).AddTicks(2480),
                            To = new DateTime(2021, 8, 11, 3, 41, 44, 608, DateTimeKind.Local).AddTicks(2480)
                        },
                        new
                        {
                            Id = 6,
                            From = new DateTime(2021, 8, 11, 3, 41, 44, 608, DateTimeKind.Local).AddTicks(2490),
                            To = new DateTime(2021, 8, 11, 4, 41, 44, 608, DateTimeKind.Local).AddTicks(2490)
                        },
                        new
                        {
                            Id = 7,
                            From = new DateTime(2021, 8, 11, 4, 41, 44, 608, DateTimeKind.Local).AddTicks(2500),
                            To = new DateTime(2021, 8, 11, 5, 41, 44, 608, DateTimeKind.Local).AddTicks(2500)
                        },
                        new
                        {
                            Id = 8,
                            From = new DateTime(2021, 8, 11, 5, 41, 44, 608, DateTimeKind.Local).AddTicks(2510),
                            To = new DateTime(2021, 8, 11, 6, 41, 44, 608, DateTimeKind.Local).AddTicks(2510)
                        },
                        new
                        {
                            Id = 9,
                            From = new DateTime(2021, 8, 11, 6, 41, 44, 608, DateTimeKind.Local).AddTicks(2510),
                            To = new DateTime(2021, 8, 11, 7, 41, 44, 608, DateTimeKind.Local).AddTicks(2520)
                        });
                });

            modelBuilder.Entity("Paxa.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("integer");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<int?>("PersonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PersonId");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "johan.holmberg@domain.se",
                            PasswordHash = "$2a$11$MWLhRydXZU9c/GBQodUAYeM/WbMcweq9ydGAQaUhMU4KPGsgQuYcG",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "joel.holmberg@domain.se",
                            PasswordHash = "$2a$11$HZHLFaoAvW7gGTKj8jRuUO4DWyk/xaDsdeTfx0TZ8Cr6q5AwwQSD6",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "owner@houseofpadel.se",
                            OrganizationId = 1,
                            PasswordHash = "$2a$11$7U6D7YJms.JGSFY.cHVj0eqQvvsH84RGAJzIa9.ITiYlcPzSh08vW"
                        },
                        new
                        {
                            Id = 4,
                            Email = "owner@sanktgorans.se",
                            OrganizationId = 2,
                            PasswordHash = "$2a$11$6aCtspFG1YjEJTuVSgGS.uPGHRIRN96zzKOLml69w5Ui1e5GYOb2C"
                        });
                });

            modelBuilder.Entity("PersonPerson", b =>
                {
                    b.Property<int>("FollowersId")
                        .HasColumnType("integer");

                    b.Property<int>("FollowingId")
                        .HasColumnType("integer");

                    b.HasKey("FollowersId", "FollowingId");

                    b.HasIndex("FollowingId");

                    b.ToTable("PersonPerson");
                });

            modelBuilder.Entity("BookingPerson", b =>
                {
                    b.HasOne("Paxa.Entities.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paxa.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paxa.Entities.Booking", b =>
                {
                    b.HasOne("Paxa.Entities.User", "Host")
                        .WithMany()
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paxa.Entities.Timeslot", "Timeslot")
                        .WithOne("Booking")
                        .HasForeignKey("Paxa.Entities.Booking", "TimeslotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Host");

                    b.Navigation("Timeslot");
                });

            modelBuilder.Entity("Paxa.Entities.Organization", b =>
                {
                    b.HasOne("Paxa.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Paxa.Entities.Person", b =>
                {
                    b.HasOne("Paxa.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Paxa.Entities.Rating", b =>
                {
                    b.HasOne("Paxa.Entities.Organization", "Organization")
                        .WithMany("Ratings")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("Paxa.Entities.Person", "Person")
                        .WithMany("Ratings")
                        .HasForeignKey("PersonId");

                    b.HasOne("Paxa.Entities.RatingType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Person");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Paxa.Entities.Resource", b =>
                {
                    b.HasOne("Paxa.Entities.Organization", "Organization")
                        .WithMany("Resources")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paxa.Entities.ResourceType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Paxa.Entities.Timeslot", b =>
                {
                    b.HasOne("Paxa.Entities.Resource", null)
                        .WithMany("Timeslots")
                        .HasForeignKey("ResourceId");
                });

            modelBuilder.Entity("Paxa.Entities.User", b =>
                {
                    b.HasOne("Paxa.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("Paxa.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.OwnsMany("Paxa.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<DateTime>("Created")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("text");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<string>("ReasonRevoked")
                                .HasColumnType("text");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("text");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("text");

                            b1.Property<string>("Token")
                                .HasColumnType("text");

                            b1.Property<int>("UserId")
                                .HasColumnType("integer");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Organization");

                    b.Navigation("Person");

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("PersonPerson", b =>
                {
                    b.HasOne("Paxa.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paxa.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paxa.Entities.Organization", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Paxa.Entities.Person", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Paxa.Entities.Resource", b =>
                {
                    b.Navigation("Timeslots");
                });

            modelBuilder.Entity("Paxa.Entities.Timeslot", b =>
                {
                    b.Navigation("Booking");
                });
#pragma warning restore 612, 618
        }
    }
}
