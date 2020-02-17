using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(Guid DonorID);
        Task<List<User>> GetUsersAsync();

        Task<int> CreateUserAsync(User User);

        Task<int> UpdateUserAsync(User User);

        Task<int> DeleteUserAsync(Guid UserID);
    }
}
