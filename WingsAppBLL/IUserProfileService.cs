using System;
using System.Collections.Generic;
using System.Text;
using WingsAppBLL.BusinessObjects;

namespace WingsAppBLL
{
    public interface IUserProfileService
    {
        //Create
        UserProfileBO Create(UserProfileBO userProfile);

        //Read
        List<UserProfileBO> GetAll();
        UserProfileBO Get(int Id);

        //Update
        UserProfileBO Update(UserProfileBO userProfile);

        //Delete
        UserProfileBO Delete(int Id);
    }
}
