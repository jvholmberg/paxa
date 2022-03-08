using System.Linq;
using AutoMapper;
using Paxa.Common.Entities;
using Paxa.Common.Views;

namespace Paxa.Web
{
    public class MapperConfig {

        public MapperConfig()
        {
        }

        public MapperConfiguration CreateConfigutation()
        {
            var config = new MapperConfiguration(cfg =>
            {

                // Address
                cfg.CreateMap<Address, AddressDto>()
                    .ReverseMap();

                // Booking
                cfg.CreateMap<Booking, BookingDto>()
                    .ForMember(
                        destination => destination.ParticipantIds,
                        options => options.MapFrom(
                            source => source.Participants.Select(participant => participant.Id).ToList()
                        )
                    )
                    .ReverseMap();

                // Location
                cfg.CreateMap<Location, LocationDto>()
                    .ReverseMap();

                // Organization
                cfg.CreateMap<Organization, OrganizationDto>()
                    .ForMember(
                        destination => destination.ResourceIds,
                        options => options.MapFrom(
                            source => source.Resources.Select(resource => resource.Id).ToList()
                        )
                    )
                    .ReverseMap()
                    .ForMember(destination => destination.Resources, options => options.Ignore())
                    .ForMember(destination => destination.Ratings, options => options.Ignore());
                
                cfg.CreateMap<CreateOrganizationRequest, Organization>()
                    .ForMember(destination => destination.Id, options => options.Ignore())
                    .ForMember(destination => destination.LocationId, options => options.Ignore())
                    .ForMember(destination => destination.Location, options => options.Ignore())
                    .ForMember(destination => destination.Ratings, options => options.Ignore())
                    .ForMember(destination => destination.Resources, options => options.Ignore())
                    .ForMember(destination => destination.Memberships, options => options.Ignore())
                    .ForMember(destination => destination.Schemas,options => options.Ignore());

                
                cfg.CreateMap<UpdateOrganizationRequest, Organization>()
                    .ForMember(destination => destination.Id, options => options.Ignore())
                    .ForMember(destination => destination.LocationId, options => options.Ignore())
                    .ForMember(destination => destination.Location, options => options.Ignore())
                    .ForMember(destination => destination.Ratings, options => options.Ignore())
                    .ForMember(destination => destination.Resources, options => options.Ignore())
                    .ForMember(destination => destination.Memberships, options => options.Ignore())
                    .ForMember(destination => destination.Schemas,options => options.Ignore());

                // Membership
                cfg.CreateMap<Membership, MembershipDto>()
                    .ReverseMap();

                // MembershipRole
                cfg.CreateMap<MembershipRole, MembershipRoleDto>()
                    .ReverseMap();

                // Resource
                cfg.CreateMap<Resource, ResourceDto>()
                    .ReverseMap();

                cfg.CreateMap<ResourceType, ResourceTypeDto>()
                    .ReverseMap();

                cfg.CreateMap<CreateResourceRequest, Resource>()
                    .ForMember(destination => destination.Id, options => options.Ignore())
                    .ForMember(destination => destination.SchemaId, options => options.Ignore())
                    .ForMember(destination => destination.Type, options => options.Ignore())
                    .ForMember(destination => destination.Organization, options => options.Ignore())
                    .ForMember(destination => destination.Schema, options => options.Ignore())
                    .ForMember(destination => destination.Timeslots, options => options.Ignore());

                cfg.CreateMap<UpdateResourceRequest, Resource>()
                    .ForMember(destination => destination.Id, options => options.Ignore())
                    .ForMember(destination => destination.OrganizationId, options => options.Ignore())
                    .ForMember(destination => destination.SchemaId, options => options.Ignore())
                    .ForMember(destination => destination.Type, options => options.Ignore())
                    .ForMember(destination => destination.Organization, options => options.Ignore())
                    .ForMember(destination => destination.Schema, options => options.Ignore())
                    .ForMember(destination => destination.Timeslots, options => options.Ignore());;

                // Person
                cfg.CreateMap<Person, PersonDto>()
                    .ForMember(
                        destination => destination.BookingIds,
                        options => options.MapFrom(
                            source => source.Bookings.Select(booking => booking.Id).ToList()
                        )
                    )
                    .ReverseMap()
                    .ForMember(destination => destination.Bookings, options => options.Ignore())
                    .ForMember(destination => destination.Ratings, options => options.Ignore());

                // Rating
                cfg.CreateMap<Rating, RatingDto>()
                    .ForMember(
                        destination => destination.TypeId,
                        options => options.MapFrom(
                            source => source.Type.Id
                        )
                    )
                    .ForMember(
                        destination => destination.Name,
                        options => options.MapFrom(
                            source => source.Type.Name
                        )
                    )
                    .ReverseMap()
                    .ForMember(destination => destination.Type, options => options.Ignore());

                // RefreshToken
                cfg.CreateMap<RefreshToken, RefreshTokenDto>()
                    .ReverseMap();

                // User
                cfg.CreateMap<User, UserDto>()
                    .ReverseMap();

                cfg.CreateMap<User, AuthenticateResponse>()
                    .ForMember(
                        destination => destination.UserId,
                        options => options.MapFrom(
                            source => source.Id
                        )
                    )
                    .ForMember(destination => destination.JwtToken, options => options.Ignore());

                // Schema
                cfg.CreateMap<Schema, SchemaDto>()
                    .ForMember(
                        destination => destination.ResourceIds,
                        options => options.MapFrom(
                            source => source.Resources.Select(resource => resource.Id).ToList()
                        )
                    )
                    .ReverseMap();

                // SchemaEntry
                cfg.CreateMap<SchemaEntry, SchemaEntryDto>()
                    .ReverseMap();

                // Timeslot
                cfg.CreateMap<Timeslot, TimeslotDto>()
                    .ReverseMap();

                // Weekday
                cfg.CreateMap<Weekday, WeekdayDto>()
                    .ReverseMap();

                // Timestamp
                cfg.CreateMap<Timestamp, TimestampDto>()
                    .ReverseMap();

            });

            // Make sure mapping is valid
            config.AssertConfigurationIsValid();

            return config;
        }
    }
}
