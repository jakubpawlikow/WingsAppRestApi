using System;
using System.Collections.Generic;
using System.Text;
using WingsAppBLL.BusinessObjects;

namespace WingsAppBLL
{
    public interface IUserEventService
    {
        //Create
        UserEventBO Create(UserEventBO user_event);

        //Read
        List<UserEventBO> GetAll();
        UserEventBO Get(int Id);

        //Update
        UserEventBO Update(UserEventBO user_event);

        //Delete
        UserEventBO Delete(int Id);
    }
}
