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
    public class UserService : IUserService
    {
        #region Read
        public async Task<User> GetUserAsync(Guid UserID)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Users.Include(x => x.Person).Include(x => x.Person.Contacts).Include(x => x.Person.Addresses).FirstOrDefaultAsync(x => x.UserID == UserID);
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Users.Include(x => x.Person).Where(x => x.IsActive).ToListAsync();
            }
        }

        public async Task<List<User>> GetUsersAsync(UserRole UserRole)
        {
            using (var db = new DonorsDBContext())
            {
                return await db.Users.Include(x => x.Person).Where(x => x.IsActive && x.UserRole == (short)UserRole).ToListAsync();
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
                var _user = await db.Users.Include(x => x.Person).Include(x => x.Person.Contacts).Include(x => x.Person.Addresses).FirstOrDefaultAsync(x => x.UserID == User.UserID);
                if (_user != null)
                {
                    _user.UserName = User.UserName;
                    _user.Person.FirstName = User.Person.FirstName;
                    _user.Person.MiddleName = User.Person.MiddleName;
                    _user.Person.Gender = User.Person.Gender;
                    _user.Person.DOB = User.Person.DOB;
                    _user.Person.DisplayName = User.Person.DisplayName;

                    db.Users.Update(_user);

                    var _cont = await db.Contacts.FirstOrDefaultAsync(x => x.PersonID == User.PersonID);
                    if (_cont != null)
                    {
                        var __cont = User.Person.Contacts.FirstOrDefault();
                        _cont.Phone = __cont.Phone;
                        _cont.Email = __cont.Email;
                        db.Contacts.Update(_cont);
                    }
                    var _addr = await db.Addresses.FirstOrDefaultAsync(x => x.PersonID == User.PersonID);
                    if (_addr != null)
                    {
                        var __addr = User.Person.Addresses.FirstOrDefault();
                        _addr.Address1 = __addr.Address1;
                        _addr.Address2 = __addr.Address2;
                        _addr.City = __addr.City;
                        _addr.State = __addr.State;
                        _addr.ZIPCode = __addr.ZIPCode;
                        db.Addresses.Update(_addr);
                    }
                    return await db.SaveChangesAsync();
                }
            }
            return 0;
        }
        #endregion

        #region Delete
        public async Task<int> DeleteUserAsync(Guid UserID)
        {
            using (var db = new DonorsDBContext())
            {
                var _user = await db.Users.Include(x => x.Person).FirstOrDefaultAsync(x => x.UserID == UserID);
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
