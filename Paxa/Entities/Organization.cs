using System.Collections.Generic;

namespace Paxa.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }

        public Organization()
        {
        }
    }
}
