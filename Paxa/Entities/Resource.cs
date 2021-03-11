using System.Collections.Generic;

namespace Paxa.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }

        public virtual ResourceType Type { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Timeslot> Timeslots { get; set; }

        public Resource()
        {
        }
    }
}
