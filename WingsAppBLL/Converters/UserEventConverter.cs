using System;
using System.Collections.Generic;
using System.Text;
using WingsAppBLL.BusinessObjects;
using WingsAppDAL.Entities;

namespace WingsAppBLL.Converters
{
    class UserEventConverter
    {

        internal UserEvent Convert(UserEventBO user_event)
        {
            return new UserEvent()
            {
                ID = user_event.ID,
                Title = user_event.Title,
                Description = user_event.Description
            };
        }

        internal UserEventBO Convert(UserEvent user_event)
        {
            return new UserEventBO()
            {
                ID = user_event.ID,
                Title = user_event.Title,
                Description = user_event.Description
            };
        }
    }
}