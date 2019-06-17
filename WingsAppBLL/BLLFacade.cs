using System;
using System.Collections.Generic;
using System.Text;
using WingsAppBLL.Services;
using WingsAppDAL;

namespace WingsAppBLL
{
    public class BLLFacade
    {
        public IUserEventService UserEventService
        {
            get {return new UserEventService(new DALFacade()); }
        }
    }
}
