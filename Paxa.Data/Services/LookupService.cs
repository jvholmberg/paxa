using Microsoft.EntityFrameworkCore;
using Paxa.Data.Contexts;
using Paxa.Common.Entities;

namespace Paxa.Data.Services
{
    public interface ILookupService
    {
        Task<ICollection<Weekday>> GetWeekdays();
    }

    public class LookupService : ILookupService
    {
        private readonly PaxaContext _context;

        public LookupService(PaxaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Weekday>> GetWeekdays()
        {
            return await _context.Weekdays.ToListAsync();
        }
    }
}
