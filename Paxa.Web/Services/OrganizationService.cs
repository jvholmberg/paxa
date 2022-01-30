using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paxa.Contexts;
using Paxa.Common.Entities;

namespace Paxa.Services
{
    public interface IOrganizationService
    {
        Task<Organization> Create(Organization Organization);
        Task<ICollection<Organization>> GetAll();
        Task<Organization> GetById(int id);
        Task<Organization> Update(int id, Organization Organization);
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

            return organization;
        }

        public async Task<Organization> Update(int id, Organization updates)
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
            var organization = await _context.Organizations
                .Include(x => x.Resources)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (organization.Resources.Count > 0)
            {
                throw new InvalidOperationException("Cant remove organization with resources connected to it");
            }
            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
