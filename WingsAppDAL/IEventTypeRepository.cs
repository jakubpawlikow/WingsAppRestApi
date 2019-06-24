using System;
using System.Collections.Generic;
using System.Text;
using WingsAppDAL.Entities;

namespace WingsAppDAL
{
    public interface IEventTypeRepository
    {
        //Create
        EventType Create(EventType eventType);

        //Read
        List<EventType> GetAll();
        EventType Get(int Id);

        //Delete
        EventType Delete(int Id);
    }
}
