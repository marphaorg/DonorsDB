using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;

namespace BusinessLayer.Interfaces
{
    public interface ICampaignService
    {
        Task<Campaign> GetCampaignProfileAsync(Guid CampaignID);
        Task<List<Campaign>> GetCampaignsAsync();

        Task<int> CreateCampaignProfileAsync(Campaign Campaign);

        Task<int> UpdateCampaignProfileAsync(Campaign Campaign);

        Task<int> DeleteCampaignProfileAsync(Guid CampaignID);
    }
}
