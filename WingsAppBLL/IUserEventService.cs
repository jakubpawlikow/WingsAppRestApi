using System;
using System.Collections.Generic;
using System.Text;
using WingsAppBLL.BusinessObjects;

namespace WingsAppBLL
{
    public interface IUserEventService
    {
        //Create
        UserEventBO Create(UserEventBO userEvent);

        //Read
        List<UserEventBO> GetAll();
        UserEventBO Get(int Id);

        //Update
        UserEventBO Update(UserEventBO userEvent);

        //Delete
        UserEventBO Delete(int Id);
    }
}
