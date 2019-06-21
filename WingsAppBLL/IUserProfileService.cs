using System;
using System.Collections.Generic;
using System.Text;
using WingsAppBLL.BusinessObjects;

namespace WingsAppBLL
{
    public interface IUserProfileService
    {
        //Create
        UserProfileBO Create(UserProfileBO user_profile);

        //Read
        List<UserProfileBO> GetAll();
        UserProfileBO Get(int Id);

        //Update
        UserProfileBO Update(UserProfileBO user_profile);

        //Delete
        UserProfileBO Delete(int Id);
    }
}
