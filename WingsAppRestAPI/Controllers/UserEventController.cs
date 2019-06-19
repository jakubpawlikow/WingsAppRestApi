using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WingsAppBLL;
using WingsAppBLL.BusinessObjects;

namespace WingsAppRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserEventController : ControllerBase
    {
        BLLFacade facade = new BLLFacade();

        [HttpGet]
        public ActionResult<IEnumerable<UserEventBO>> Get()
        {
            return facade.UserEventService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<UserEventBO> Get(int id)
        {
            return facade.UserEventService.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] UserEventBO user_event)
        {
            facade.UserEventService.Create(user_event);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserEventBO user_event)
        {
            facade.UserEventService.Update(user_event);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.UserEventService.Delete(id);
        }
    }
}
