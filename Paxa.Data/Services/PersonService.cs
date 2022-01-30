using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paxa.Contexts;
using Paxa.Common.Entities;
using Paxa.Common.Views;

namespace Paxa.Services
{
    public interface IPersonService
    {
        Task<PersonDto> Create(PersonDto person);
        Task<ICollection<Person>> GetAll();
        Task<PersonDto> GetById(int id);
        Task<PersonDto> Update(int id, PersonDto person);
        Task<ConfirmationDto> Delete(int id);
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

        public async Task<PersonDto> Create(PersonDto person)
        {
            // Create entity
            var entity = _mapper.Map<Person>(person);
            await _context.Persons
                .AddAsync(entity);
            await _context.SaveChangesAsync();

            // Get entity
            var persistedEntity = await GetById(entity.Id);
            var view = _mapper.Map<PersonDto>(persistedEntity);

            return view;
        }

        public async Task<ICollection<Person>> GetAll()
        {
            var entities = await _context.Persons
                .Include(e => e.Bookings)
                .Include(e => e.Address)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .ToListAsync();

            return entities;
        }

        public async Task<PersonDto> GetById(int id)
        {
            var entity = await _context.Persons
                .Include(e => e.Bookings)
                .Include(e => e.Address)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            var view = _mapper.Map<PersonDto>(entity);

            return view;
        }

        public async Task<PersonDto> Update(int id, PersonDto person)
        {
            // Get from db
            var entity = await _context.Persons
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            // Persist changes
            await _context.SaveChangesAsync();

            // Get updated from db
            var view = await GetById(id);

            return view;
        }

        public async Task<ConfirmationDto> Delete(int id)
        {
            var person = new Person { Id = id };
            _context.Persons.Attach(person);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            var view = new ConfirmationDto();
            return view;
        }
    }
}
