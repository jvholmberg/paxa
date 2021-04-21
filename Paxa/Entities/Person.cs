using System.Collections.Generic;

namespace Paxa.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Person> Followers { get; set; }
        public virtual ICollection<Person> Following { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        public Person()
        {
        }
    }
}
