using System;
using System.Linq;
using AutoMapper;

namespace Paxa
{
    public class MapperConfig {

        public MapperConfig()
        {
        }

        public MapperConfiguration CreateConfigutation()
        {
            var config = new MapperConfiguration(cfg =>
            {

                // Booking
                cfg.CreateMap<Entities.Booking, Views.Booking>()
                    .ForMember(
                        destination => destination.HostId,
                        options => options.MapFrom(source => source.Host.Id)
                    )
                    .ForMember(
                        destination => destination.ParticipantIds,
                        options => options.MapFrom(
                            source => source.Participants.Select(participant => participant.Id).ToList()
                        )
                    )
                    .ReverseMap()
                    .ForMember(
                        destination => destination.HostId,
                        options => options.Ignore()
                    )
                    .ForMember(
                        destination => destination.Participants,
                        options => options.Ignore()
                    );

                // Location
                cfg.CreateMap<Entities.Location, Views.Location>()
                    .ReverseMap();

                // Address
                cfg.CreateMap<Entities.Address, Views.Address>()
                    .ReverseMap();

                // User
                cfg.CreateMap<Entities.User, Views.User>()
                    .ForMember(
                        destination => destination.BookingIds,
                        options => options.MapFrom(
                            source => source.Bookings.Select(booking => booking.Id).ToList()
                        )
                    )
                    .ReverseMap()
                    .ForMember(
                        destination => destination.Bookings,
                        options => options.Ignore()
                    );

                // Organization
                cfg.CreateMap<Entities.Organization, Views.Organization>()
                    .ForMember(
                        destination => destination.ResourceIds,
                        options => options.MapFrom(
                            source => source.Resources.Select(resource => resource.Id).ToList()
                        )
                    )
                    .ReverseMap()
                    .ForMember(
                        destination => destination.Resources,
                        options => options.Ignore()
                    );

                // Person
                cfg.CreateMap<Entities.Person, Views.Person>()
                    .ForMember(
                        destination => destination.BookingIds,
                        options => options.MapFrom(
                            source => source.Bookings.Select(person => person.Id).ToList()
                        )
                    )
                    .ForMember(
                        destination => destination.FollowerIds,
                        options => options.MapFrom(
                            source => source.Followers.Select(follower => follower.Id).ToList()
                        )
                    )
                    .ForMember(
                        destination => destination.FollowingIds,
                        options => options.MapFrom(
                            source => source.Following.Select(following => following.Id).ToList()
                        )
                    )
                    .ForMember(
                        destination => destination.Address,
                        options => options.MapFrom(
                            source => source.Address
                        )
                    )
                    .ReverseMap()
                    .ForMember(
                        destination => destination.Bookings,
                        options => options.Ignore()
                    )
                    .ForMember(
                        destination => destination.Followers,
                        options => options.Ignore()
                    )
                    .ForMember(
                        destination => destination.Following,
                        options => options.Ignore()
                    );

            });

            return config;
        }
    }
}
