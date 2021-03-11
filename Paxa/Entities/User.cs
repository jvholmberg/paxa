using System;
using System.Collections.Generic;

namespace Paxa.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? PersonId { get; set; }
        public int? OrganizationId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        public User()
        {
        }
    }
}
