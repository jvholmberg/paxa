using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paxa.Contexts;

namespace Paxa.Services
{
    public interface IPersonService
    {
        Task<Views.Person> Create(Views.Person person);
        Task<ICollection<Entities.Person>> GetAll();
        Task<Views.Person> GetById(int id);
        Task<Views.Person> Update(int id, Views.Person person);
        Task<Views.Confirmation> Delete(int id);
    }

    public class PersonService : IPersonService
    {
        private readonly PaxaContext _context;
        private readonly IMapper _mapper;

        public PersonService(PaxaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Views.Person> Create(Views.Person person)
        {
            // Create entity
            var entity = _mapper.Map<Entities.Person>(person);
            await _context.Persons
                .AddAsync(entity);
            await _context.SaveChangesAsync();

            // Get entity
            var persistedEntity = await GetById(entity.Id);
            var view = _mapper.Map<Views.Person>(persistedEntity);

            return view;
        }

        public async Task<ICollection<Entities.Person>> GetAll()
        {
            var entities = await _context.Persons
                .Include(e => e.Bookings)
                .Include(e => e.Followers)
                .Include(e => e.Following)
                .Include(e => e.Address)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .ToListAsync();

            return entities;
        }

        public async Task<Views.Person> GetById(int id)
        {
            var entity = await _context.Persons
                .Include(e => e.Bookings)
                .Include(e => e.Followers)
                .Include(e => e.Following)
                .Include(e => e.Address)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            var view = _mapper.Map<Views.Person>(entity);

            return view;
        }

        public async Task<Views.Person> Update(int id, Views.Person person)
        {
            // Get from db
            var entity = await _context.Persons
                .Include(e => e.Following)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            // Make updates
            entity.Following = await _context.Persons
                .Where(e => person.FollowingIds.Contains(e.Id))
                .ToListAsync();

            // Persist changes
            await _context.SaveChangesAsync();

            // Get updated from db
            var view = await GetById(id);

            return view;
        }

        public async Task<Views.Confirmation> Delete(int id)
        {
            var person = new Entities.Person { Id = id };
            _context.Persons.Attach(person);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            var view = new Views.Confirmation();
            return view;
        }
    }
}
