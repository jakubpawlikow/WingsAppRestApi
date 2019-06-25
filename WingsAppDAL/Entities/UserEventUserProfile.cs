using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace WingsAppDAL.Entities
{
    public class UserEventUserProfile
    {
        public int UserEventId { get; set; }
        public UserEvent UserEvent { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

    }
}
