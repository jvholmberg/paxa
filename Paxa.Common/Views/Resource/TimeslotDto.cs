using System;

namespace Paxa.Common.Views
{
    public class TimeslotDto
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public TimeslotDto()
        {
        }
    }
}
