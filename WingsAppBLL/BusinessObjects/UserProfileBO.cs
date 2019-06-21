using System;
using System.Collections.Generic;
using System.Text;


namespace WingsAppBLL.BusinessObjects
{
    public class UserProfileBO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
