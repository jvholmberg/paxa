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
        Task<Entities.Organization> Create(Entities.Organization Organization);
        Task<ICollection<Entities.Organization>> GetAll();
        Task<Entities.Organization> GetById(int id);
        Task<Entities.Organization> Update(int id, Entities.Organization Organization);
        Task<bool> Delete(int id);
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

        public async Task<Entities.Organization> Create(Entities.Organization organization)
        {
            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();

            return await GetById(organization.Id);
        }

        public async Task<ICollection<Entities.Organization>> GetAll()
        {
            var organizations = await _context.Organizations
                .Include(e => e.Location)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Resources).ThenInclude(e => e.Timeslots).ThenInclude(e => e.Booking)
                .ToListAsync();

            return organizations;
        }

        public async Task<Entities.Organization> GetById(int id)
        {
            var organization = await _context.Organizations
                .Include(e => e.Location)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Resources).ThenInclude(e => e.Timeslots).ThenInclude(e => e.Booking)
                .SingleOrDefaultAsync(e => e.Id == id);

            return organization;
        }

        public async Task<Entities.Organization> Update(int id, Entities.Organization updates)
        {
            var organization = await _context.Organizations
                .Include(e => e.Location)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Resources).ThenInclude(e => e.Timeslots).ThenInclude(e => e.Booking)
                .SingleOrDefaultAsync(e => e.Id == id);

            // Make updates
            organization.Name = updates.Name;
            organization.Description = updates.Description;
            
            _context.Organizations.Attach(organization);

            // Persist changes
            await _context.SaveChangesAsync();

            // Get updated from db
            var updatedEntity = await GetById(id);
            return updatedEntity;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var Organization = new Entities.Organization { Id = id };
                _context.Organizations.Attach(Organization);
                _context.Organizations.Remove(Organization);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
