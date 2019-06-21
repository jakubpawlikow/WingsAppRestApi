using System;
using System.Collections.Generic;
using System.Text;
using WingsAppBLL.BusinessObjects;
using WingsAppDAL.Entities;

namespace WingsAppBLL.Converters
{
    class UserProfileConverter
    {

        internal UserProfile Convert(UserProfileBO user_profile)
        {
            if (user_profile == null) { return null; }
            return new UserProfile()
            {
                Id = user_profile.Id,
                FirstName = user_profile.FirstName,
                LastName = user_profile.LastName,
                JoinDate = user_profile.JoinDate,
                
            };
        }

        internal UserProfileBO Convert(UserProfile user_profile)
        {
            if (user_profile == null) { return null; }
            return new UserProfileBO()
            {
                Id = user_profile.Id,
                FirstName = user_profile.FirstName,
                LastName = user_profile.LastName,
                JoinDate = user_profile.JoinDate
            };
        }
    }
}