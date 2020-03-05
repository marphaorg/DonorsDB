using System;
using System.Collections.Generic;
using DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public List<User> Users { get; set; }

        public string FullAddress
        {
            get
            {
                if (Address != null)
                {
                    return string.Format("{0} {1}, {2} {3}, {4}", Address.Address1, Address.Address2, Address.State.ToUpper(), Address.ZIPCode, Address.Country.ToUpper());
                }
                return string.Empty;
            }
        }

        public IEnumerable<SelectListItem> GenderList
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem() { Text="Male", Value="1" },
                    new SelectListItem() { Text="Female", Value="2" },
                    new SelectListItem() { Text="Other", Value="3" },
                    new SelectListItem() { Text="Prefer not to say", Value="4" }
                };
            }
        }
    }
}
