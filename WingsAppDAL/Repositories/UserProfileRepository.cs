using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WingsAppDAL.Context;
using WingsAppDAL.Entities;

namespace WingsAppDAL.Repositories
{
    class UserProfileRepository : IUserProfileRepository
    {
        WingsAppContext  _context;

        public UserProfileRepository(WingsAppContext context)
        {
            _context = context;
        }
        //Create
        public UserProfile Create(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            return userProfile;
        }

        //Read
        public List<UserProfile> GetAll()
        {
            return _context.UserProfiles.ToList();
        }
        public UserProfile Get(int Id)
        {
            return _context.UserProfiles.FirstOrDefault(obj => obj.Id == Id);
        }

        //Delete
        public UserProfile Delete(int Id)
        {
            var userProfile = Get(Id);
            _context.UserProfiles.Remove(userProfile);
            return userProfile;
        }
    }
}
