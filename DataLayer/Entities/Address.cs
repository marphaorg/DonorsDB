using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddressID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public short ZIPCode { get; set; }

        public Guid PersonID { get; set; }
        public Person Person { get; set; }

        public bool IsPrimary { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
