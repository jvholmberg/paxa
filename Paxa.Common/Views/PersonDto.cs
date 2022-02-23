using System.Collections.Generic;

namespace Paxa.Common.Views
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDto Address { get; set; }

        public ICollection<RatingDto> Ratings { get; set; } = new List<RatingDto>();
        public ICollection<int> BookingIds { get; set; } = new List<int>();

        public PersonDto()
        {
        }
    }
}
