﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paxa.Contexts;

namespace Paxa.Services
{
    public interface IResourceService
    {
        Task<Entities.Resource> Create(Entities.Resource resource);
        Task<ICollection<Entities.Resource>> GetByQuery(int? organizationId);
        Task<Entities.Resource> GetById(int id);
        Task<ICollection<Entities.ResourceType>> GetTypes();
        Task<Entities.Resource> Update(int id, Entities.Resource resource);
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

        public async Task<Entities.Resource> Create(Entities.Resource resource)
        {
            await _context.Resources.AddAsync(resource);
            await _context.SaveChangesAsync();

            return await GetById(resource.Id);
        }

        public async Task<ICollection<Entities.Resource>> GetByQuery(int? organizationId)
        {
            var query = _context.Resources.Include(e => e.Type) as IQueryable<Entities.Resource>;

            if (organizationId != null) {
                query = query.Where(x => x.OrganizationId == organizationId);
            }

            return await query.ToListAsync();;
        }

        public async Task<Entities.Resource> GetById(int id)
        {
            var resource = await _context.Resources
                .Include(e => e.Type)
                .Include(e => e.Timeslots)
                .Include(e => e.Organization)
                .SingleOrDefaultAsync(e => e.Id == id);

            return resource;
        }

        public async Task<ICollection<Entities.ResourceType>> GetTypes()
        {
            var types = await _context.ResourceTypes.ToListAsync();

            return types;
        }

        public async Task<Entities.Resource> Update(int id, Entities.Resource updates)
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