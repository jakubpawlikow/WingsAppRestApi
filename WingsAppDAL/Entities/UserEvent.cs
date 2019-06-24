using System;
using System.Collections.Generic;
using System.Text;


namespace WingsAppDAL.Entities
{
    public class UserEvent
    {
        public int Id { get; set; }

        // [MaxLength(50)]
        // [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        // public int UserID { get; set; }
        // public DateTime AddDate { get; private set; } = DateTime.UtcNow;
        //[Required]
        // public DateTime StartDate { get; private set; }
        // public DateTime EndDate { get; private set; }
        // public IList<UserEventTag> UserEventTags { get; set; } = new List<UserEventTag>();
        public int ReporterId { get; set; }
        public UserProfile Reporter { get; set; }
        public List<EventType> Types { get; set; }
    }
}
