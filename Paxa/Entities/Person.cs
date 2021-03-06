﻿using System.Collections.Generic;

namespace Paxa.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Person> Followers { get; set; }
        public virtual ICollection<Person> Following { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        public Person()
        {
        }
    }
}
