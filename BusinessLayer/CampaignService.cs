using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class CampaignService: ICampaignService
    {
        #region Read
        public async Task<Campaign> GetCampaignProfileAsync(Guid CampaignID)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Campaigns.FirstOrDefaultAsync(x => x.CampaignID == CampaignID);
            }
        }

        public async Task<List<Campaign>> GetCampaignsAsync()
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Campaigns.ToListAsync();
            }
        }
        #endregion

        #region Add
        public async Task<int> CreateCampaignProfileAsync(Campaign Campaign)
        {
            using (var db = new DonorsDBContext())
            {
                await db.Campaigns.AddAsync(Campaign);
                return await db.SaveChangesAsync();
            }
        }
        #endregion

        #region Update
        public async Task<int> UpdateCampaignProfileAsync(Campaign Campaign)
        {
            using (var db = new DonorsDBContext())
            {
                var _campaign = await db.Campaigns.FirstOrDefaultAsync(x => x.CampaignID == Campaign.CampaignID);
                if (_campaign != null)
                {
                    db.Campaigns.Update(Campaign);
                    return await db.SaveChangesAsync();
                }
            }
            return 0;
        }
        #endregion

        #region Delete
        public async Task<int> DeleteCampaignProfileAsync(Guid CampaignID)
        {
            using (var db = new DonorsDBContext())
            {
                var _campaign = await db.Campaigns.FirstOrDefaultAsync(x => x.CampaignID == CampaignID);
                if (_campaign != null)
                {
                    db.Campaigns.Remove(_campaign);
                    return await db.SaveChangesAsync();
                }
            }
            return 0;
        }
        #endregion
    }
}
