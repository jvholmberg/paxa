using System.ComponentModel.DataAnnotations;

namespace Paxa.Common.Entities
{
    public class Timestamp
    {
        [Key]
        public int Id { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public virtual TimeslotSchema FromTimeslotSchema { get; set; }
        public virtual TimeslotSchema ToTimeslotSchema { get; set; }

        public Timestamp()
        {
        }
    }
}
