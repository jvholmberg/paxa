using System.Collections.Generic;

namespace Paxa.Views
{
    public class Booking
    {
        public int Id { get; set; }
        public int TimeslotId { get; set; }
        public int HostId { get; set; }
        public ICollection<int> ParticipantIds { get; set; }

        public Booking()
        {
        }
    }
}
