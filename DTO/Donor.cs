using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class Donor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DonorID { get; set; }
        public string DonorCode { get; set; }
        public Guid PersonID { get; set; }
        public Person Person { get; set; }
        public IList<Donation> Donations { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
