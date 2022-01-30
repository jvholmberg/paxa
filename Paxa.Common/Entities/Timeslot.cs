using System.ComponentModel.DataAnnotations;
using System;

namespace Paxa.Common.Entities
{
    public class Timeslot
    {
        [Key]
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public virtual Resource Resource { get; set; }
        public virtual Booking Booking { get; set; }

        public Timeslot()
        {
        }
    }
}
