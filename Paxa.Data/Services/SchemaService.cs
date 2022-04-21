using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paxa.Data.Contexts;
using Paxa.Common.Entities;

namespace Paxa.Data.Services
{
    public interface ISchemaService
    {
        Task<Schema> Create(Schema schema);
        Task<ICollection<Schema>> GetAll();
        Task<ICollection<Schema>> GetByQuery(int? organizationId);
        Task<Schema> GetById(int id);
        Task<Schema> Update(int id, Schema schema);
        void Delete(int id);
        Task<bool> GenerateTimeslots(Schema schema, int year, int month, int day);
    }

    public class SchemaService : ISchemaService
    {
        private readonly PaxaContext _context;

        public SchemaService(PaxaContext context)
        {
            _context = context;
        }

        private IQueryable<Schema> AllData() {
            return _context.Schemas
                .Include(x => x.Organization)
                .Include(x => x.Resources)
                .Include(x => x.SchemaEntries).ThenInclude(x => x.Weekday) as IQueryable<Schema>;
        }

        private IQueryable<Schema> SlimData() {
            return _context.Schemas
                .Include(x => x.Organization)
                .Include(x => x.Resources) as IQueryable<Schema>;
        }

        public async Task<Schema> Create(Schema schema)
        {
            await _context.Schemas.AddAsync(schema);
            await _context.SaveChangesAsync();
            return await GetById(schema.Id);
        }

        public async Task<ICollection<Schema>> GetAll()
        {
            return await AllData().ToListAsync();
        }

        public async Task<ICollection<Schema>> GetByQuery(int? organizationId)
        {
            var query = AllData();
            if (organizationId != null)
            {
                query = query.Where(x => x.OrganizationId == organizationId);
            }
            return await query.ToListAsync();;
        }

        public async Task<Schema> GetById(int id)
        {
            var schema = await AllData().SingleOrDefaultAsync(e => e.Id == id);
            if (schema == null)
            {
                throw new KeyNotFoundException("Could not find requested schema");
            }
            return schema;
        }

        public async Task<Schema> Update(int id, Schema updates)
        {
            var schema = await GetById(id);

            if (schema == null)
            {
                throw new KeyNotFoundException("Could not find requested resource");
            }

            // Make updates
            schema.Name = updates.Name;
            
            _context.Schemas.Attach(schema);

            // Persist changes
            await _context.SaveChangesAsync();

            // Get updated from db
            var updatedEntity = await GetById(id);
            return updatedEntity;
        }

        public void Delete(int id)
        {
            var schema = _context.Schemas
                .Include(x => x.SchemaEntries)
                .SingleOrDefault(e => e.Id == id);

            if (schema == null)
            {
                throw new KeyNotFoundException("Could not find requested schema");
            }
            if (schema.SchemaEntries.Count > 0)
            {
                throw new InvalidOperationException("Cant remove schema with schema-entries connected to it");
            }
            _context.Schemas.Remove(schema);
            _context.SaveChanges();
        }

        public async Task<bool> GenerateTimeslots(Schema schema, int year, int month, int day) {
            try {
                // Get entries for supplied date
                var date = new DateTime(year, month, day);
                var weekday = (int)date.DayOfWeek;
                var entries = schema.SchemaEntries.Where(x => x.Weekday.Number == weekday);

                // Iterate over resources connected to schema
                foreach(Resource resource in schema.Resources) {

                    // Iterate over entries in schema
                    foreach(SchemaEntry schemaEntry in entries) {

                        var from = new DateTime(year, month, day, schemaEntry.StartHour, schemaEntry.StartMinute, schemaEntry.StartSecond);
                        var to = new DateTime(year, month, day, schemaEntry.EndHour, schemaEntry.EndMinute, schemaEntry.EndSecond);

                        // Create Timeslot
                        var timeslot = new Timeslot {
                            ResourceId = resource.Id,
                            From = from.ToUniversalTime(),
                            To = to.ToUniversalTime(),
                        };

                        // Add timeslot
                        await _context.AddAsync(timeslot);
                    }
                }

                // Save timeslots
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}
