using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;

namespace BusinessLayer.Interfaces
{
    public interface IDonorService
    {
        Task<Donor> GetDonorAsync(Guid DonorID);
        Task<List<Donor>> GetDonorsAsync();

        Task<int> CreateDonorProfileAsync(Donor Donor);

        Task<int> UpdateDonorProfileAsync(Donor Donor);

        Task<int> DeleteDonorProfileAsync(Donor Donor);
    }
}
