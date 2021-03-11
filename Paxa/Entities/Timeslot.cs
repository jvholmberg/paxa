using System;

namespace Paxa.Entities
{
    public class Timeslot
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public virtual Booking Booking { get; set; }

        public Timeslot()
        {
        }
    }
}
