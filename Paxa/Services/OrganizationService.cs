using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paxa.Contexts;

namespace Paxa.Services
{
    public interface IOrganizationService
    {
        Task<Views.Organization> Create(Views.Organization Organization);
        Task<ICollection<Views.Organization>> GetAll();
        Task<Views.Organization> GetById(int id);
        Task<Views.Organization> Update(int id, Views.Organization Organization);
        Task<Views.Confirmation> Delete(int id);
    }

    public class OrganizationService : IOrganizationService
    {
        private readonly PaxaContext _Context;
        private readonly IMapper _Mapper;

        public OrganizationService(PaxaContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<Views.Organization> Create(Views.Organization Organization)
        {
            // Create entity
            var entity = _Mapper.Map<Entities.Organization>(Organization);
            await _Context.Organization
                .AddAsync(entity);
            await _Context.SaveChangesAsync();

            // Get entity
            var persistedEntity = await GetById(entity.Id);
            var view = _Mapper.Map<Views.Organization>(persistedEntity);

            return view;
        }

        public async Task<ICollection<Views.Organization>> GetAll()
        {
            var entities = await _Context.Organization
                .Include(e => e.Location)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Resources).ThenInclude(e => e.Timeslots).ThenInclude(e => e.Booking)
                .ToListAsync();

            var view = _Mapper.Map<Views.Organization[]>(entities);

            return view;
        }

        public async Task<Views.Organization> GetById(int id)
        {
            var entity = await _Context.Organization
                .Include(e => e.Location)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Resources).ThenInclude(e => e.Timeslots).ThenInclude(e => e.Booking)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            var view = _Mapper.Map<Views.Organization>(entity);

            return view;
        }

        public async Task<Views.Organization> Update(int id, Views.Organization organization)
        {
            
            var updates = _Mapper.Map<Entities.Organization>(organization);
            updates.Id = id;

            // Make updates
            _Context.Organization.Attach(updates);

            // Persist changes
            await _Context.SaveChangesAsync();

            // Get updated from db
            var view = await GetById(id);

            return view;
        }

        public async Task<Views.Confirmation> Delete(int id)
        {
            var Organization = new Entities.Organization { Id = id };
            _Context.Organization.Attach(Organization);
            _Context.Organization.Remove(Organization);
            await _Context.SaveChangesAsync();

            var view = new Views.Confirmation();
            return view;
        }
    }
}
