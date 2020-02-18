using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Guid PersonID { get; set; }
        public Person Person { get; set; }
        public short UserRole { get; set; }

        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual IList<Donation> DonationsRecognized { get; set; }
        public virtual IList<Donation> DonationsReviewed { get; set; }

        public virtual IList<Campaign> CampaignsManaged { get; set; }

        public DateTime DateLastActive { get; set; }
    }
}
