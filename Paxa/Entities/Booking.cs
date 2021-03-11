using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paxa.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int TimeslotId { get; set; }
        public int HostId { get; set; }

        public virtual Timeslot Timeslot { get; set; }
        public virtual User Host { get; set; }
        public virtual ICollection<Person> Participants { get; set; }

        public Booking()
        {
        }
    }
}
