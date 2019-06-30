using System;
using System.Collections.Generic;
using System.Text;
using WingsAppDAL.Entities;

namespace WingsAppDAL
{
    public interface IUserProfileRepository
    {
        //Create
        UserProfile Create(UserProfile userProfile);

        //Read
        List<UserProfile> GetAll();
        UserProfile Get(int Id);

        IEnumerable<UserProfile> GetAllById(List<int> ids);

        //Delete
        UserProfile Delete(int Id);
    }
}
