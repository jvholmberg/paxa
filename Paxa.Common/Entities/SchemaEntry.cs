using System.ComponentModel.DataAnnotations;
using System;

namespace Paxa.Common.Entities
{
    public class SchemaEntry
    {
        [Key]
        public int Id { get; set; }
        public int FromTimestampId { get; set; }
        public int ToTimestampId { get; set; }
        public int WeekdayId { get; set; }
        public int SchemaId { get; set; }

        public virtual Timestamp FromTimestamp { get; set; }
        public virtual Timestamp ToTimestamp { get; set; }
        public virtual Weekday Weekday { get; set; }
        public virtual Schema Schema { get; set; }

        public SchemaEntry()
        {
        }
    }
}
