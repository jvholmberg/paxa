using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paxa.Contexts;
using Paxa.Common.Entities;

namespace Paxa.Data.Services
{
    public interface IOrganizationService
    {
        Task<Organization> Create(Organization Organization);
        Task<ICollection<Organization>> GetAll();
        Task<Organization> GetById(int id);
        Task<Organization> Update(int id, Organization Organization);
        void Delete(int id);
    }

    public class OrganizationService : IOrganizationService
    {
        private readonly PaxaContext _context;

        public OrganizationService(PaxaContext context)
        {
            _context = context;
        }

        public async Task<Organization> Create(Organization organization)
        {
            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();

            return await GetById(organization.Id);
        }

        public async Task<ICollection<Organization>> GetAll()
        {
            var organizations = await _context.Organizations
                .Include(e => e.Location)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Resources).ThenInclude(e => e.Timeslots).ThenInclude(e => e.Booking)
                .ToListAsync();

            return organizations;
        }

        public async Task<Organization> GetById(int id)
        {
            var organization = await _context.Organizations
                .Include(e => e.Location)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Resources).ThenInclude(e => e.Timeslots).ThenInclude(e => e.Booking)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (organization == null)
            {
                throw new KeyNotFoundException("Could not find requested organization");
            }
            
            return organization;
        }

        public async Task<Organization> Update(int id, Organization updates)
        {
            var organization = await _context.Organizations
                .Include(e => e.Location)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Resources).ThenInclude(e => e.Timeslots).ThenInclude(e => e.Booking)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (organization == null)
            {
                throw new KeyNotFoundException("Could not find requested organization");
            }

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

        public void Delete(int id)
        {
            var organization = _context.Organizations
                .Include(x => x.Resources)
                .SingleOrDefault(e => e.Id == id);

            if (organization == null)
            {
                throw new KeyNotFoundException("Could not find requested organization");
            }
            if (organization.Resources.Count > 0)
            {
                throw new InvalidOperationException("Cant remove organization with resources connected to it");
            }

            _context.Organizations.Remove(organization);
            _context.SaveChanges();

        }
    }
}
