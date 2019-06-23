using System;
using System.Collections.Generic;
using System.Text;
using WingsAppBLL.BusinessObjects;
using WingsAppDAL.Entities;

namespace WingsAppBLL.Converters
{
    class UserProfileConverter
    {

        internal UserProfile Convert(UserProfileBO userProfile)
        {
            if (userProfile == null) { return null; }
            return new UserProfile()
            {
                Id = userProfile.Id,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                JoinDate = userProfile.JoinDate,
                
            };
        }

        internal UserProfileBO Convert(UserProfile userProfile)
        {
            if (userProfile == null) { return null; }
            return new UserProfileBO()
            {
                Id = userProfile.Id,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                JoinDate = userProfile.JoinDate
            };
        }
    }
}