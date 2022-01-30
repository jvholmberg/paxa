using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paxa.Common.Entities
{
    public class ResourceType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public ResourceType()
        {
        }
    }
}
