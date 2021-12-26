using System;
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
        Task<ICollection<Entities.Resource>> GetAll();
        Task<ICollection<Entities.Resource>> GetByOrganizationId(int organizationId);
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

        public async Task<ICollection<Entities.Resource>> GetAll()
        {
            var resources = await _context.Resources
                .Include(e => e.Type)
                .ToListAsync();

            return resources;
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

        public async Task<ICollection<Entities.Resource>> GetByOrganizationId(int organizationId)
        {
            var resources = await _context.Resources
                .Include(e => e.Type)
                .Include(e => e.Timeslots)
                .Where(e => e.OrganizationId == organizationId)
                .ToListAsync();

            return resources;
        }
    }
}
