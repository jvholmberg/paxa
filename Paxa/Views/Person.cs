using System.Collections.Generic;

namespace Paxa.Views
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public ICollection<int> FollowerIds { get; set; } = new List<int>();
        public ICollection<int> FollowingIds { get; set; } = new List<int>();
        public ICollection<int> BookingIds { get; set; } = new List<int>();

        public Person()
        {
        }
    }
}
