using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Paxa.Entities
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int OrganizationId { get; set; }
        public int? ResourceSchemaId { get; set; }

        public virtual ResourceType Type { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ResourceSchema ResourceSchema { get; set; }
        public virtual ICollection<Timeslot> Timeslots { get; set; }

        public Resource()
        {
        }
    }
}
