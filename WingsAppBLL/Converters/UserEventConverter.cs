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
        private UserProfileConverter userProfileConverter;
        public UserEventConverter()
        {
            userProfileConverter = new UserProfileConverter();
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
                Assigners = userEvent.AssignersIds?.Select(aId => new UserEventUserProfile() {
                    UserProfileId = aId,
                    UserEventId = userEvent.Id
                }).ToList()              
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
                AssignersIds = userEvent.Assigners?.Select(a => a.UserProfileId).ToList()
            };
        }
    }
}