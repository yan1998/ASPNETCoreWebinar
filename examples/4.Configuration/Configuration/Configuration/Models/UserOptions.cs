using System;
using System.Collections.Generic;

namespace Configuration.Models
{
    public class UserOptions
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public Address Address { get; set; }

        public List<string> Hobbies { get; set; }
    }

    public class Address
    {
        public string Country { get; set; }

        public string City { get; set; }
    }
}
