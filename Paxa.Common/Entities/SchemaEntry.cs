using System.ComponentModel.DataAnnotations;
using System;

namespace Paxa.Common.Entities
{
    public class SchemaEntry
    {
        [Key]
        public int Id { get; set; }
        public int SchemaId { get; set; }
        public int WeekdayId { get; set; }
        public string FromTimestamp { get; set; }
        public string ToTimestamp { get; set; }

        public virtual Schema Schema { get; set; }
        public virtual Weekday Weekday { get; set; }

        public SchemaEntry()
        {
        }
    }
}
