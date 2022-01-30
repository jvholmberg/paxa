using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Paxa.Common.Entities
{
    public class ResourceSchema
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int OrganizationId { get; set; }
        
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<TimeslotSchema> TimeslotSchemas { get; set; }

        public ResourceSchema()
        {
        }
    }
}
