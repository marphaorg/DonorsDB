using System;
using System.Collections.Generic;
using DTO;

namespace UI.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public List<User> Users { get; set; }
    }
}
