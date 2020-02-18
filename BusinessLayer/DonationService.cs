using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer;
using DTO;
using DTO.Enum;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class DonationService : IDonationService
    {
        #region Read
        public async Task<Donation> GetDonationAsync(Guid DonationID)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Donations.FirstOrDefaultAsync(x => x.DonationID == DonationID);
            }
        }

        public async Task<List<Donation>> GetDonationListAsync()
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Donations.ToListAsync();
            }
        }

        public async Task<List<Donation>> GetDonationListAsync(Guid DonorID)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Donations.Where(x=> x.DonorID == DonorID).ToListAsync();
            }
        }

        public async Task<List<Donation>> GetDonationListAsync(DonationType DonationType)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Donations.Where(x => x.DonationType == (short)DonationType).ToListAsync();
            }
        }

        public async Task<List<Donation>> GetDonationListAsync(DonationMethod DonationMethod)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Donations.Where(x => x.DonationMethod == (short)DonationMethod).ToListAsync();
            }
        }

        public async Task<List<Donation>> GetDonationsReviewedAsync(bool IsReviewed)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Donations.Where(x => x.IsReviewed == IsReviewed).ToListAsync();
            }
        }

        public async Task<List<Donation>> GetDonationsVerifiedAsync(bool IsVerified)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Donations.Where(x => x.IsVerified == IsVerified).ToListAsync();
            }
        }
        #endregion

        #region Create
        public async Task<int> AddDonationAsync(Donation Donation)
        {
            using (var db = new DonorsDBContext())
            {
                await db.Donations.AddAsync(Donation);
                return await db.SaveChangesAsync();
            }
        }
        #endregion

        #region Update
        public async Task<int> UpdateDonationAsync(Donation Donation)
        {
            using (var db = new DonorsDBContext())
            {
                var _donation = db.Donations.FirstOrDefaultAsync(x => x.DonationID == Donation.DonationID);
                if (_donation != null)
                {
                    db.Donations.Update(Donation);
                    return await db.SaveChangesAsync();
                }
            }
            return 0;
        }
        #endregion

        #region Delete
        public async Task<int> DeleteDonationAsync(Guid DonationID)
        {
            using (var db = new DonorsDBContext())
            {
                var _donation = await db.Donations.FirstOrDefaultAsync(x => x.DonationID == DonationID);
                if (_donation != null)
                {
                    db.Donations.Remove(_donation);
                    return await db.SaveChangesAsync();
                }
            }
            return 0;
        }
        #endregion
    }
}
