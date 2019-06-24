using System;
using System.Collections.Generic;
using System.Text;
using WingsAppBLL.BusinessObjects;

namespace WingsAppBLL
{
    public interface IEventTypeService
    {
        //Create
        EventTypeBO Create(EventTypeBO eventType);

        //Read
        List<EventTypeBO> GetAll();
        EventTypeBO Get(int Id);

        //Update
        EventTypeBO Update(EventTypeBO eventType);

        //Delete
        EventTypeBO Delete(int Id);
    }
}
