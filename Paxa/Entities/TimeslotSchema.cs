using System.ComponentModel.DataAnnotations;
using System;

namespace Paxa.Entities
{
    public class TimeslotSchema
    {
        [Key]
        public int Id { get; set; }
        public int FromTimestampId { get; set; }
        public int ToTimestampId { get; set; }
        public int WeekdayId { get; set; }
        public int ResourceSchemaId { get; set; }

        public virtual Timestamp FromTimestamp { get; set; }
        public virtual Timestamp ToTimestamp { get; set; }
        public virtual Weekday Weekday { get; set; }
        public virtual ResourceSchema ResourceSchema { get; set; }

        public TimeslotSchema()
        {
        }
    }
}
