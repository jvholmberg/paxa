using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paxa.Contexts;
using Paxa.Common.Entities;

namespace Paxa.Services
{
    public interface IPersonService
    {
        Task<Person> Create(Person person);
        Task<ICollection<Person>> GetAll();
        Task<Person> GetById(int id);
        Task<Person> Update(int id, Person person);
        void Delete(int id);
    }

    public class PersonService : IPersonService
    {
        private readonly PaxaContext _context;

        public PersonService(PaxaContext context)
        {
            _context = context;
        }

        public async Task<Person> Create(Person person)
        {
            // Create entity
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            var persistedPerson = await GetById(person.Id);
            return persistedPerson;
        }

        public async Task<ICollection<Person>> GetAll()
        {
            var persons = await _context.Persons
                .Include(e => e.Bookings)
                .Include(e => e.Address)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .ToListAsync();

            return persons;
        }

        public async Task<Person> GetById(int id)
        {
            var person = await _context.Persons
                .Include(e => e.Bookings)
                .Include(e => e.Address)
                .Include(e => e.Ratings).ThenInclude(e => e.Type)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            if (person == null)
            {
                throw new InvalidOperationException("Could not find requested person");
            }

            return person;
        }

        public async Task<Person> Update(int id, Person updates)
        {
            var person = await _context.Persons
                .SingleOrDefaultAsync(e => e.Id.Equals(id));
            
            if (person == null)
            {
                throw new InvalidOperationException("Could not find requested person");
            }

            await _context.SaveChangesAsync();
            var updatedPerson = await GetById(id);
            return updatedPerson;
        }

        public void Delete(int id)
        {
            var person = _context.Persons
                .SingleOrDefault(e => e.Id == id);

            if (person == null)
            {
                throw new InvalidOperationException("Could not find requested person");
            }
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
