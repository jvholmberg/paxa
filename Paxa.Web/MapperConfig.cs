﻿using System;
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

                // Address
                cfg.CreateMap<Entities.Address, Views.Address>()
                    .ReverseMap();

                // Booking
                cfg.CreateMap<Entities.Booking, Views.Booking>()
                    .ForMember(
                        destination => destination.ParticipantIds,
                        options => options.MapFrom(
                            source => source.Participants.Select(participant => participant.Id).ToList()
                        )
                    )
                    .ReverseMap();

                // Location
                cfg.CreateMap<Entities.Location, Views.Location>()
                    .ReverseMap();

                // Organization
                cfg.CreateMap<Entities.Organization, Views.Organization>()
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
                
                cfg.CreateMap<Views.CreateOrganizationRequest, Entities.Organization>();
                
                cfg.CreateMap<Views.UpdateOrganizationRequest, Entities.Organization>();

                // Membership
                cfg.CreateMap<Entities.Membership, Views.Membership>()
                    .ReverseMap();

                // MembershipRole
                cfg.CreateMap<Entities.MembershipRole, Views.MembershipRole>()
                    .ReverseMap();

                // Resource
                cfg.CreateMap<Entities.Resource, Views.Resource>()
                    .ReverseMap();

                cfg.CreateMap<Entities.ResourceType, Views.ResourceType>()
                    .ReverseMap();

                cfg.CreateMap<Views.CreateResourceRequest, Entities.Resource>();

                cfg.CreateMap<Views.UpdateResourceRequest, Entities.Resource>();

                // Person
                cfg.CreateMap<Entities.Person, Views.Person>()
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
                cfg.CreateMap<Entities.Rating, Views.Rating>()
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
                cfg.CreateMap<Entities.RefreshToken, Views.RefreshToken>()
                    .ReverseMap();

                // User
                cfg.CreateMap<Entities.User, Views.User>()
                    .ReverseMap();

                cfg.CreateMap<Entities.User, Views.AuthenticateResponse>();

            });

            return config;
        }
    }
}