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
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int StartSecond { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public int EndSecond { get; set; }

        public virtual Schema Schema { get; set; }
        public virtual Weekday Weekday { get; set; }

        public SchemaEntry()
        {
        }
    }
}
