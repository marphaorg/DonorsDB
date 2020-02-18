using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class CampaignViewModel
    {
        public Campaign Campaign { get; set; }
        public User CampaignManagedBy { get; set; }
        public List<Campaign> Campaigns { get; set; }
        public List<User> CampaignManagers { get; set; }
    }
}
