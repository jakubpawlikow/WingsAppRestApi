using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WingsAppBLL;
using WingsAppBLL.BusinessObjects;

namespace WingsAppRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
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
        public ActionResult Post([FromBody] UserEventBO userEvent)
        {
            return Ok(facade.UserEventService.Create(userEvent));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserEventBO userEvent)
        {
            if (id != userEvent.Id)
            {
                return StatusCode(405, "Path id not matching with json id");
            }
            try
            {
                var editedEvent = facade.UserEventService.Update(userEvent);
                return Ok(editedEvent);
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
