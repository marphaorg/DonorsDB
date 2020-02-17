using System;
using System.Collections.Generic;

namespace DTO
{
    public class Donor
    {
        public Guid DonorID { get; set; }

        public Guid PersonID { get; set; }
        public Person Person { get; set; }
        public IList<Donation> Donations { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
