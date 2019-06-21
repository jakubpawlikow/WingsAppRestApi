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
            if (user_event == null) { return null; }

            return new UserEvent()
            {
                ID = user_event.ID,
                Title = user_event.Title,
                Description = user_event.Description,
                Reporter = new UserProfileConverter().Convert(user_event.Reporter)
            };
        }

        internal UserEventBO Convert(UserEvent user_event)
        {
            if (user_event == null) { return null; }
            return new UserEventBO()
            {
                ID = user_event.ID,
                Title = user_event.Title,
                Description = user_event.Description,
                Reporter = new UserProfileConverter().Convert(user_event.Reporter)
            };
        }
    }
}