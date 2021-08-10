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
        private readonly PaxaContext _context;
        private readonly IMapper _mapper;

        public OrganizationService(PaxaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Views.Organization> Create(Views.Organization Organization)
        {
            // Create entity
            var entity = _mapper.Map<Entities.Organization>(Organization);
            await _context.Organizations
                .AddAsync(entity);
            await _context.SaveChangesAsync();

            // Get entity
            var persistedEntity = await GetById(entity.Id);
            var view = _mapper.Map<Views.Organization>(persistedEntity);

            return view;
        }

        public async Task<ICollection<Views.Organization>> GetAll()
        {
            var entities = await _context.Organizations
                .Include(e => e.Location)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Resources).ThenInclude(e => e.Timeslots).ThenInclude(e => e.Booking)
                .ToListAsync();

            var view = _mapper.Map<Views.Organization[]>(entities);

            return view;
        }

        public async Task<Views.Organization> GetById(int id)
        {
            var entity = await _context.Organizations
                .Include(e => e.Location)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Resources).ThenInclude(e => e.Timeslots).ThenInclude(e => e.Booking)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            var view = _mapper.Map<Views.Organization>(entity);

            return view;
        }

        public async Task<Views.Organization> Update(int id, Views.Organization organization)
        {
            
            var updates = _mapper.Map<Entities.Organization>(organization);
            updates.Id = id;

            // Make updates
            _context.Organizations.Attach(updates);

            // Persist changes
            await _context.SaveChangesAsync();

            // Get updated from db
            var view = await GetById(id);

            return view;
        }

        public async Task<Views.Confirmation> Delete(int id)
        {
            var Organization = new Entities.Organization { Id = id };
            _context.Organizations.Attach(Organization);
            _context.Organizations.Remove(Organization);
            await _context.SaveChangesAsync();

            var view = new Views.Confirmation();
            return view;
        }
    }
}
