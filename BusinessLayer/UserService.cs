using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        #region Read
        public async Task<User> GetUserAsync(Guid UserID)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Users.FirstOrDefaultAsync(x => x.UserID == UserID);
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Users.ToListAsync();
            }
        }
        #endregion

        #region Add
        public async Task<int> CreateUserAsync(User User)
        {
            using (var db = new DonorsDBContext())
            {
                await db.Users.AddAsync(User);
                return await db.SaveChangesAsync();
            }
        }
        #endregion

        #region Update
        public async Task<int> UpdateUserAsync(User User)
        {
            using (var db = new DonorsDBContext())
            {
                var _user = await db.Users.FirstOrDefaultAsync(x => x.UserID == User.UserID);
                if (_user != null)
                {
                    db.Users.Update(User);
                    return await db.SaveChangesAsync();
                }
            }
            return 0;
        }
        #endregion

        #region Delete
        public async Task<int> DeleteUserAsync(User User)
        {
            using (var db = new DonorsDBContext())
            {
                var _user = await db.Users.Include(x=> x.Person).FirstOrDefaultAsync(x => x.UserID == User.UserID);
                if (_user != null)
                {
                    _user.Person.IsDeleted = true;
                    _user.IsActive = false;
                    _user.DateUpdated = DateTime.Now.ToUniversalTime();
                    return await db.SaveChangesAsync();
                }
            }
            return 0;
        }
        #endregion
    }
}
