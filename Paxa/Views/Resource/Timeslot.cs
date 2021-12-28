using System;

namespace Paxa.Views
{
    public class Timeslot
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Timeslot()
        {
        }
    }
}
