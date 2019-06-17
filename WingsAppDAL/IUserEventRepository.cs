using System;
using System.Collections.Generic;
using System.Text;
using WingsAppDAL.Entities;

namespace WingsAppDAL
{
    public interface IUserEventRepository
    {
        //Create
        UserEvent Create(UserEvent user_event);

        //Read
        List<UserEvent> GetAll();
        UserEvent Get(int Id);

        //Delete
        UserEvent Delete(int Id);
    }
}
