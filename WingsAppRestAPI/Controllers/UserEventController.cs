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
        public ActionResult Post([FromBody] UserEventBO user_event)
        {
            return Ok(facade.UserEventService.Create(user_event));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserEventBO user_event)
        {
            if (id != user_event.ID)
            {
                return StatusCode(405, "Path id not matching with json id");
            }
            try
            {
                var edited_event = facade.UserEventService.Update(user_event);
                return Ok(edited_event);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.UserEventService.Delete(id);
        }
    }
}
