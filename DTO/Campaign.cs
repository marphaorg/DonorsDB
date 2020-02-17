using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class Campaign
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CampaignID { get; set; }
        public string CampaignTitle { get; set; }
        public string Description { get; set; }

        public Guid CreatedBYID { get; set; }
        public User CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public IList<Donation> Donations { get; set; }

    }
}
