using System.Collections.Generic;

namespace Paxa.Views
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public Person Person { get; set; }
        public Organization Organization { get; set; }
        public ICollection<int> BookingIds { get; set; }

        public User()
        {
        }
    }
}
