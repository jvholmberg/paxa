using System.Collections.Generic;

namespace Paxa.Views
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<int> FollowerIds { get; set; } = new List<int>();
        public IList<int> FollowingIds { get; set; } = new List<int>();
        public IList<int> BookingIds { get; set; } = new List<int>();

        public Person()
        {
        }
    }
}
