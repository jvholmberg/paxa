using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paxa.Entities
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int BookingId { get; set; }
        public int PersonId { get; set; }

        public virtual ParticipantType Type { get; set; }
        public virtual Booking Booking { get; set; }
        public virtual Person Person { get; set; }

        public Participant()
        {
        }
    }
}
