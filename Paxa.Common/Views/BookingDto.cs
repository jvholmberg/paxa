using System.Collections.Generic;

namespace Paxa.Common.Views
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int TimeslotId { get; set; }
        public ICollection<int> ParticipantIds { get; set; }

        public BookingDto()
        {
        }
    }
}
