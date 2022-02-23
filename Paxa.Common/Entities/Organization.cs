using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Paxa.Common.Entities
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<Schema> Schemas { get; set; }

        public Organization()
        {
        }
    }
}
