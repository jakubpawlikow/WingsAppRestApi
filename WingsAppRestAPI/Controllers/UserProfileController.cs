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
    public class UserProfileController : ControllerBase
    {
        BLLFacade facade = new BLLFacade();

        [HttpGet]
        public ActionResult<IEnumerable<UserProfileBO>> Get()
        {
            return facade.UserProfileService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<UserProfileBO> Get(int id)
        {
            return facade.UserProfileService.Get(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserProfileBO userProfile)
        {
            return Ok(facade.UserProfileService.Create(userProfile));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserProfileBO userProfile)
        {
            if (id != userProfile.Id)
            {
                return StatusCode(405, "Path id not matching with json id");
            }
            try
            {
                var editedProfile = facade.UserProfileService.Update(userProfile);
                return Ok(editedProfile);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.UserProfileService.Delete(id);
        }
    }
}
