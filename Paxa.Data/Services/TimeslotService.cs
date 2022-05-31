using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paxa.Data.Contexts;
using Paxa.Common.Entities;

namespace Paxa.Data.Services
{
    public interface ITimeslotService
    {
        Task<Timeslot> Create(Timeslot timeslot);
        Task<ICollection<Timeslot>> GetByQuery(int? resourceId);
        Task<Timeslot> GetById(int id);
        Task<Timeslot> Update(int id, Timeslot timeslot);
        void Delete(int id);
    }

    public class TimeslotService : ITimeslotService
    {
        private readonly PaxaContext _context;

        public TimeslotService(PaxaContext context)
        {
            _context = context;
        }

        public async Task<Timeslot> Create(Timeslot timeslot)
        {
            await _context.Timeslots.AddAsync(timeslot);
            await _context.SaveChangesAsync();

            return await GetById(timeslot.Id);
        }

        public async Task<ICollection<Timeslot>> GetByQuery(int? resourceId)
        {
            var query = _context.Timeslots
                .Include(e => e.Booking).ThenInclude(e => e.Participants).ThenInclude(e => e.Person)
                .Include(e => e.Booking).ThenInclude(e => e.Participants).ThenInclude(e => e.Type) as IQueryable<Timeslot>;

            if (resourceId != null)
            {
                query = query.Where(x => x.ResourceId == resourceId);
            }

            return await query.ToListAsync();
        }

        public async Task<Timeslot> GetById(int id)
        {
            var timeslot = await _context.Timeslots
                .Include(e => e.Booking).ThenInclude(e => e.Participants).ThenInclude(e => e.Person)
                .Include(e => e.Booking).ThenInclude(e => e.Participants).ThenInclude(e => e.Type)
                .SingleOrDefaultAsync(e => e.Id == id);
            
            if (timeslot == null)
            {
                throw new KeyNotFoundException("Could not find requested timeslot");
            }

            return timeslot;
        }

        public async Task<Timeslot> Update(int id, Timeslot updates)
        {
            var timeslot = await _context.Timeslots
                .SingleOrDefaultAsync(e => e.Id == id);

            if (timeslot == null)
            {
                throw new KeyNotFoundException("Could not find requested timeslot");
            }

            // Make updates
            timeslot.From = updates.From;
            timeslot.To = updates.To;
            
            _context.Timeslots.Attach(timeslot);

            // Persist changes
            await _context.SaveChangesAsync();

            // Get updated from db
            var updatedEntity = await GetById(id);
            return updatedEntity;
        }

        public void Delete(int id)
        {
            var timeslot = _context.Timeslots
                .Include(e => e.Booking).ThenInclude(e => e.Participants).ThenInclude(e => e.Booking)
                .SingleOrDefault(e => e.Id == id);

            if (timeslot == null)
            {
                throw new KeyNotFoundException("Could not find requested timeslot");
            }
            _context.Timeslots.Remove(timeslot);
            _context.SaveChanges();
        }
    }
}
