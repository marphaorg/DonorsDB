using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DTO;

namespace BusinessLayer
{
    public class DonationService
    {
        DonorsDBContext _db = null;
        public DonationService()
        {
            _db = new DonorsDBContext();
        }

        public List<Donation> GetDonationList()
        {
            var list = new List<Donation>();
            

            return list;
        }
    }
}
