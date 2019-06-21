using System;
using System.Collections.Generic;
using System.Text;


namespace WingsAppDAL.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }

        public List<UserEvent> Event{ get; set; }
    }
}
