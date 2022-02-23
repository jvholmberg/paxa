using System.Collections.Generic;

namespace Paxa.Common.Views
{
    public class OrganizationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public LocationDto? Location { get; set; }
        public ICollection<int> ResourceIds { get; set; } = new List<int>();
        public ICollection<RatingDto> Ratings { get; set; } = new List<RatingDto>();

        public OrganizationDto()
        {
        }
    }
}
