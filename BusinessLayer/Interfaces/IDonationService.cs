using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;

namespace BusinessLayer.Interfaces
{
    public interface IDonationService
    {
        Task<Donation> GetDonationAsync(Guid DonationID);
        Task<List<Donation>> GetDonationListAsync();
        Task<List<Donation>> GetDonationListAsync(Guid DonorID);
        Task<List<Donation>> GetDonationListAsync(DonationType DonationType);
        Task<List<Donation>> GetDonationListAsync(DonationMethod DonationMethod);
        Task<List<Donation>> GetDonationsReviewedAsync(bool IsReviewed);
        Task<List<Donation>> GetDonationsVerifiedAsync(bool IsVerified);

        Task<int> AddDonationAsync(Donation Donation);

        Task<int> UpdateDonationAsync(Donation Donation);

        Task<int> DeleteDonationAsync(Guid DonationID);
    }
}
