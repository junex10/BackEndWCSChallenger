using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hogwarts_users_api.Controllers
{
    [ApiController]
    [Route("api/users/")]

    public class UserController : ControllerBase
    {
        private User usersAPI = new User();
        private NewUser newUserAPI = new NewUser();
        private RemoveUser removeUserAPI = new RemoveUser();
        private UpdateUser updateUserAPI = new UpdateUser();

        /**
        * @Users all
        **/

        [HttpGet]

        public ActionResult<User> GetAllUsers()
        {
            List<UserAPI> users = usersAPI.GetAll();
            return Ok(users);
        }

        /**
        * @Users BY ID
        **/

        [HttpGet("{id}")]

        public ActionResult<User> GetUser(int id)
        {
            List<UserAPI> user = usersAPI.GetById(id);
            return Ok(user);
        }

        /**
        *   @new User
        **/

        [HttpPost("new_user")]

        public ActionResult newUser(List<UsersTB> data)
        {
            List<Hogwarts_request_api.SuccessRequest> response = newUserAPI.PushUser(data);

            if (data.Count > 0)
            {
                return Ok(response);
            }
            else
            {
                List<Hogwarts_request_api.ErrorRequestBadQuery> error = new List<Hogwarts_request_api.ErrorRequestBadQuery>() {
                    new Hogwarts_request_api.ErrorRequestBadQuery{
                        title = "Bad Request",
                        status = 400,
                        error = "No se pudo procesar el registro"
                    }
                };
                return BadRequest(error);
            }
        }

        /**
        *   @Remove user
        **/

        [HttpGet("disableUser/{id}")]

        public ActionResult<RemoveUser> RemoveUserById(int id)
        {

            List<Hogwarts_request_api.SuccessRequest> request = removeUserAPI.DisableUser(id);

            if (request.Count > 0)
            {
                return Ok(request);
            }
            else
            {
                List<Hogwarts_request_api.ErrorRequestFoundUser> error = new List<Hogwarts_request_api.ErrorRequestFoundUser>() {
                    new Hogwarts_request_api.ErrorRequestFoundUser{
                        error = "No se pudo inhabilitar el usuario",
                        status = 404
                    }
                };
                return NotFound(error);
            }
        }

        /**
        *   @Update user
        **/

        [HttpPut("updateUser/{id}")]

        public ActionResult<UpdateUser> UpdateUser(List<UsersTB> data, int id)
        {
            List<Hogwarts_request_api.SuccessRequest> request = updateUserAPI.UpdUser(data, id);
            
            return Ok(request);
        }
    }
}