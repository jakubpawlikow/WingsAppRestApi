using System;
using System.Collections.Generic;
using System.Text;
using WingsAppBLL.BusinessObjects;
using WingsAppDAL.Entities;

namespace WingsAppBLL.Converters
{
    class EventTypeConverter
    {

        internal EventType Convert(EventTypeBO eventType)
        {
            if (eventType == null) { return null; }
            return new EventType()
            {
                Id = eventType.Id,
                Name = eventType.Name
            };
        }

        internal EventTypeBO Convert(EventType eventType)
        {
            if (eventType == null) { return null; }
            return new EventTypeBO()
            {
                Id = eventType.Id,
                Name = eventType.Name
            };
        }
    }
}