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
                    .ForMember(
                        destination => destination.Ratings,
                        options => options.MapFrom(
                            source => source.Ratings.ToList()
                        )
                    )
                    .ReverseMap()
                    .ForMember(destination => destination.Resources, options => options.Ignore())
                    .ForMember(destination => destination.Ratings, options => options.Ignore());
                
                cfg.CreateMap<CreateOrganizationRequest, Organization>();
                
                cfg.CreateMap<UpdateOrganizationRequest, Organization>();

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

                cfg.CreateMap<CreateResourceRequest, Resource>();

                cfg.CreateMap<UpdateResourceRequest, Resource>();

                // Person
                cfg.CreateMap<Person, PersonDto>()
                    .ForMember(
                        destination => destination.BookingIds,
                        options => options.MapFrom(
                            source => source.Bookings.Select(booking => booking.Id).ToList()
                        )
                    )
                    .ForMember(
                        destination => destination.Address,
                        options => options.MapFrom(
                            source => source.Address
                        )
                    )
                    .ForMember(
                        destination => destination.Ratings,
                        options => options.MapFrom(
                            source => source.Ratings.ToList()
                        )
                    )
                    .ReverseMap()
                    .ForMember(
                        destination => destination.Bookings,
                        options => options.Ignore()
                    )
                    .ForMember(
                        destination => destination.Ratings,
                        options => options.Ignore()
                    );

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
                    .ForMember(
                        destination => destination.Type,
                        options => options.Ignore()
                    );

                // RefreshToken
                cfg.CreateMap<RefreshToken, RefreshTokenDto>()
                    .ReverseMap();

                // User
                cfg.CreateMap<User, UserDto>()
                    .ReverseMap();

                cfg.CreateMap<User, AuthenticateResponse>();

            });

            return config;
        }
    }
}
