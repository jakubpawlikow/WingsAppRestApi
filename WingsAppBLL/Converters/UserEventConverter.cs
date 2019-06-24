using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WingsAppBLL.BusinessObjects;
using WingsAppDAL.Entities;

namespace WingsAppBLL.Converters
{
    class UserEventConverter
    {
        private EventTypeConverter eventTypeConverter;
        public UserEventConverter()
        {
            eventTypeConverter = new EventTypeConverter();
        }
        internal UserEvent Convert(UserEventBO userEvent)
        {
            if (userEvent == null) { return null; }

            return new UserEvent()
            {
                Id = userEvent.Id,
                Title = userEvent.Title,
                Description = userEvent.Description,
                ReporterId = userEvent.ReporterId,
                Types = userEvent.Types.Select(eventTypeConverter.Convert).ToList()
            };
        }

        internal UserEventBO Convert(UserEvent userEvent)
        {
            if (userEvent == null) { return null; }
            return new UserEventBO()
            {
                Id = userEvent.Id,
                Title = userEvent.Title,
                Description = userEvent.Description,
                Reporter = new UserProfileConverter().Convert(userEvent.Reporter),
                ReporterId = userEvent.ReporterId,
                Types = userEvent.Types.Select(eventTypeConverter.Convert).ToList()
            };
        }
    }
}