using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paxa.Contexts;
using Paxa.Common.Entities;

namespace Paxa.Services
{
    public interface IResourceService
    {
        Task<Resource> Create(Resource resource);
        Task<ICollection<Resource>> GetByQuery(int? organizationId);
        Task<Resource> GetById(int id);
        Task<ICollection<ResourceType>> GetTypes();
        Task<Resource> Update(int id, Resource resource);
        Task<bool> Delete(int id);
    }

    public class ResourceService : IResourceService
    {
        private readonly PaxaContext _context;
        private readonly IMapper _mapper;

        public ResourceService(PaxaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Resource> Create(Resource resource)
        {
            await _context.Resources.AddAsync(resource);
            await _context.SaveChangesAsync();

            return await GetById(resource.Id);
        }

        public async Task<ICollection<Resource>> GetByQuery(int? organizationId)
        {
            var query = _context.Resources.Include(e => e.Type) as IQueryable<Resource>;

            if (organizationId != null) {
                query = query.Where(x => x.OrganizationId == organizationId);
            }

            return await query.ToListAsync();;
        }

        public async Task<Resource> GetById(int id)
        {
            var resource = await _context.Resources
                .Include(e => e.Type)
                .Include(e => e.Timeslots)
                .Include(e => e.Organization)
                .SingleOrDefaultAsync(e => e.Id == id);

            return resource;
        }

        public async Task<ICollection<ResourceType>> GetTypes()
        {
            var types = await _context.ResourceTypes.ToListAsync();

            return types;
        }

        public async Task<Resource> Update(int id, Resource updates)
        {
            var resource = await _context.Resources
                .SingleOrDefaultAsync(e => e.Id == id);

            // Make updates
            resource.Name = updates.Name;
            resource.TypeId = updates.TypeId;
            
            _context.Resources.Attach(resource);

            // Persist changes
            await _context.SaveChangesAsync();

            // Get updated from db
            var updatedEntity = await GetById(id);
            return updatedEntity;
        }

        public async Task<bool> Delete(int id)
        {
            var resource = await _context.Resources
                .Include(x => x.Timeslots)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (resource.Timeslots.Count > 0)
            {
                throw new InvalidOperationException("Cant remove resource with timesplots connected to it");
            }
            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
