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
        public UserProfile Create(UserProfile user_profile)
        {
            _context.UserProfiles.Add(user_profile);
            return user_profile;
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
            var user_profile = Get(Id);
            _context.UserProfiles.Remove(user_profile);
            return user_profile;
        }
    }
}
