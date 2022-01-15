using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Paxa.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }

        public virtual User User { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Participant> Participating { get; set; }
        public virtual ICollection<Friendship> FromFriendships { get; set; }
        public virtual ICollection<Friendship> ToFriendships { get; set; }

        public Person()
        {
        }
    }
}
