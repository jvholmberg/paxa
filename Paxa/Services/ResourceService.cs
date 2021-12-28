﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paxa.Contexts;

namespace Paxa.Services
{
    public interface IResourceService
    {
        Task<ICollection<Entities.Resource>> GetByQuery(int? organizationId);
        Task<Entities.Resource> GetById(int id);
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

        public async Task<ICollection<Entities.Resource>> GetByQuery(
            int? organizationId
        )
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
    }
}