using System.Collections.Generic;

namespace Paxa.Views
{
    public class Resource
    {
        public int Id { get; set; }
        public ResourceType Type { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public ICollection<Timeslot> Timeslots { get; set; }

        public Resource()
        {
        }
    }
}
