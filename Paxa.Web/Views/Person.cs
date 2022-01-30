﻿using System.Collections.Generic;

namespace Paxa.Views
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<int> BookingIds { get; set; } = new List<int>();

        public Person()
        {
        }
    }
}