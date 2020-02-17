using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ContactID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsPrimary { get; set; }

        public Guid PersonID { get; set; }
        public Person Person { get; set; }

        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
