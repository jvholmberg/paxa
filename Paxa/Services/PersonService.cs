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
        Task<ICollection<Views.Person>> GetAll();
        Task<Views.Person> GetById(int id);
        Task<Views.Person> Update(int id, Views.Person person);
        Task<Views.Confirmation> Delete(int id);
    }

    public class PersonService : IPersonService
    {
        private readonly PaxaContext _Context;
        private readonly IMapper _Mapper;

        public PersonService(PaxaContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<Views.Person> Create(Views.Person person)
        {
            // Create entity
            var entity = _Mapper.Map<Entities.Person>(person);
            await _Context.Person
                .AddAsync(entity);
            await _Context.SaveChangesAsync();

            // Get entity
            var persistedEntity = await GetById(entity.Id);
            var view = _Mapper.Map<Views.Person>(persistedEntity);

            return view;
        }

        public async Task<ICollection<Views.Person>> GetAll()
        {
            var entities = await _Context.Person
                .Include(e => e.Bookings)
                .Include(e => e.Followers)
                .Include(e => e.Following)
                .Include(e => e.Address)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .ToListAsync();

            var view = _Mapper.Map<Views.Person[]>(entities);

            return view;
        }

        public async Task<Views.Person> GetById(int id)
        {
            var entity = await _Context.Person
                .Include(e => e.Bookings)
                .Include(e => e.Followers)
                .Include(e => e.Following)
                .Include(e => e.Address)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            var view = _Mapper.Map<Views.Person>(entity);

            return view;
        }

        public async Task<Views.Person> Update(int id, Views.Person person)
        {
            // Get from db
            var entity = await _Context.Person
                .Include(e => e.Following)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            // Make updates
            entity.Following = await _Context.Person
                .Where(e => person.FollowingIds.Contains(e.Id))
                .ToListAsync();

            // Persist changes
            await _Context.SaveChangesAsync();

            // Get updated from db
            var view = await GetById(id);

            return view;
        }

        public async Task<Views.Confirmation> Delete(int id)
        {
            var person = new Entities.Person { Id = id };
            _Context.Person.Attach(person);
            _Context.Person.Remove(person);
            await _Context.SaveChangesAsync();

            var view = new Views.Confirmation();
            return view;
        }
    }
}
