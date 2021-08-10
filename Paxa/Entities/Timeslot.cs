using System.ComponentModel.DataAnnotations;
using System;

namespace Paxa.Entities
{
    public class Timeslot
    {
        [Key]
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public virtual Booking Booking { get; set; }

        public Timeslot()
        {
        }
    }
}
