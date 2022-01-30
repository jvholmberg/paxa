using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Paxa.Entities
{
    public class Weekday
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TimeslotSchema> TimeslotSchemas { get; set; }

        public Weekday()
        {
        }
    }
}
