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
    [Migration("20210303233433_Booking2")]
    partial class Booking2
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

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Johan",
                            LastName = "Holmberg"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Joel",
                            LastName = "Holmberg"
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
                            From = new DateTime(2021, 3, 4, 0, 34, 32, 788, DateTimeKind.Local).AddTicks(4220),
                            To = new DateTime(2021, 3, 4, 1, 34, 32, 797, DateTimeKind.Local).AddTicks(8050)
                        },
                        new
                        {
                            Id = 2,
                            From = new DateTime(2021, 3, 4, 1, 34, 32, 797, DateTimeKind.Local).AddTicks(8600),
                            To = new DateTime(2021, 3, 4, 2, 34, 32, 797, DateTimeKind.Local).AddTicks(8600)
                        },
                        new
                        {
                            Id = 3,
                            From = new DateTime(2021, 3, 4, 2, 34, 32, 797, DateTimeKind.Local).AddTicks(8610),
                            To = new DateTime(2021, 3, 4, 3, 34, 32, 797, DateTimeKind.Local).AddTicks(8610)
                        },
                        new
                        {
                            Id = 4,
                            From = new DateTime(2021, 3, 4, 3, 34, 32, 797, DateTimeKind.Local).AddTicks(8610),
                            To = new DateTime(2021, 3, 4, 4, 34, 32, 797, DateTimeKind.Local).AddTicks(8610)
                        },
                        new
                        {
                            Id = 5,
                            From = new DateTime(2021, 3, 4, 4, 34, 32, 797, DateTimeKind.Local).AddTicks(8610),
                            To = new DateTime(2021, 3, 4, 5, 34, 32, 797, DateTimeKind.Local).AddTicks(8610)
                        },
                        new
                        {
                            Id = 6,
                            From = new DateTime(2021, 3, 4, 5, 34, 32, 797, DateTimeKind.Local).AddTicks(8620),
                            To = new DateTime(2021, 3, 4, 6, 34, 32, 797, DateTimeKind.Local).AddTicks(8620)
                        },
                        new
                        {
                            Id = 7,
                            From = new DateTime(2021, 3, 4, 6, 34, 32, 797, DateTimeKind.Local).AddTicks(8620),
                            To = new DateTime(2021, 3, 4, 7, 34, 32, 797, DateTimeKind.Local).AddTicks(8620)
                        },
                        new
                        {
                            Id = 8,
                            From = new DateTime(2021, 3, 4, 7, 34, 32, 797, DateTimeKind.Local).AddTicks(8620),
                            To = new DateTime(2021, 3, 4, 8, 34, 32, 797, DateTimeKind.Local).AddTicks(8620)
                        },
                        new
                        {
                            Id = 9,
                            From = new DateTime(2021, 3, 4, 8, 34, 32, 797, DateTimeKind.Local).AddTicks(8620),
                            To = new DateTime(2021, 3, 4, 9, 34, 32, 797, DateTimeKind.Local).AddTicks(8630)
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

                    b.Property<int?>("PersonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId")
                        .IsUnique();

                    b.HasIndex("PersonId");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "johan.holmberg@domain.se",
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "joel.holmberg@domain.se",
                            PersonId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "owner@houseofpadel.se",
                            OrganizationId = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "owner@sanktgorans.se",
                            OrganizationId = 2
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
                        .WithMany("Bookings")
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
                        .WithOne("User")
                        .HasForeignKey("Paxa.Entities.User", "OrganizationId");

                    b.HasOne("Paxa.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Organization");

                    b.Navigation("Person");
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
                    b.Navigation("Resources");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Paxa.Entities.Resource", b =>
                {
                    b.Navigation("Timeslots");
                });

            modelBuilder.Entity("Paxa.Entities.Timeslot", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Paxa.Entities.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
