using System.Collections.Generic;

namespace Paxa.Common.Views
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public ResourceTypeDto Type { get; set; }
        public string Name { get; set; }
        public ICollection<TimeslotDto> Timeslots { get; set; }

        public ResourceDto()
        {
        }
    }
}
