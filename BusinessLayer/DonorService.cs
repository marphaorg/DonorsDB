using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class DonorService : IDonorService
    {
        #region Read
        public async Task<Donor> GetDonorAsync(Guid DonorID)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Donors.FirstOrDefaultAsync(x => x.DonorID == DonorID);
            }
        }

        public async Task<List<Donor>> GetDonorsAsync()
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Donors.ToListAsync();
            }
        }
        #endregion

        #region Add
        public async Task<int> CreateDonorProfileAsync(Donor Donor)
        {
            using (var db = new DonorsDBContext())
            {
                await db.Donors.AddAsync(Donor);
                return await db.SaveChangesAsync();
            }
        }
        #endregion

        #region Update
        public async Task<int> UpdateDonorProfileAsync(Donor Donor)
        {
            using (var db = new DonorsDBContext())
            {
                var _donor = db.Donors.FirstOrDefaultAsync(x => x.DonorID == Donor.DonorID);
                if (_donor != null)
                {
                    db.Donors.Update(Donor);
                    return await db.SaveChangesAsync();
                }
            }
            return 0;
        }
        #endregion

        #region Delete
        public async Task<int> DeleteDonorProfileAsync(Donor Donor)
        {
            using (var db = new DonorsDBContext())
            {
                var _donor = await db.Donors.Include(x=> x.Person).FirstOrDefaultAsync(x => x.DonorID == Donor.DonorID);
                if (_donor != null)
                {
                    _donor.Person.IsDeleted = true;
                    return await db.SaveChangesAsync();
                }
            }
            return 0;
        }
        #endregion

    }
}
