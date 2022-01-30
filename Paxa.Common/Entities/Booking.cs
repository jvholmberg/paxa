using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paxa.Common.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int TimeslotId { get; set; }

        public virtual Timeslot Timeslot { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }

        public Booking()
        {
        }
    }
}
