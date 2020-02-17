using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PersonID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public short? Gender { get; set; }
        public DateTime? DOB { get; set; }

        public IList<Contact> Contacts { get; set; }

        public IList<Address> Addresses { get; set; }

        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User User { get; set; }
    }
}
