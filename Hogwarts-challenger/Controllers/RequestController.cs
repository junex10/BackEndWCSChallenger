using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hogwarts_request_api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class RequestController : ControllerBase
    {

        private Requests requestsAPI = new Requests();
        private NewRequest requestInsertAPI = new NewRequest();
        private RemoveRequest requestRemoveAPI = new RemoveRequest();
        private UpdateRequestAPI requestUpdateAPI = new UpdateRequestAPI();

        /**
        *   @Request all
        **/

        [HttpGet("requests")]
        public ActionResult<RequestAPI> AllRequests()
        {

            List<RequestAPI> requests = requestsAPI.GetAllRequests();

            return Ok(requests);
        }

        /**
        *   @Request by inscription
        **/

        [HttpGet("requests/{id}")]

        public ActionResult<RequestAPI> RequestById(int id)
        {

            List<RequestAPI> request = requestsAPI.GetRequest(id);

            if (request.Count > 0)
            {
                return Ok(request);
            }
            else
            {
                List<ErrorRequestFoundUser> error = new List<ErrorRequestFoundUser>() {
                    new ErrorRequestFoundUser{
                        error = "No se encontro al usuario",
                        status = 404
                    }
                };
                return NotFound(error);
            }
        }

        /**
        *   @new Request
        **/

        [HttpPost("new_request")]

        public ActionResult newRequest(List<RequestTB> data)
        {
            List<SuccessRequest> response = requestInsertAPI.PushRequest(data);

            if (data.Count > 0)
            {
                return Ok(response);
            }
            else
            {
                List<ErrorRequestBadQuery> error = new List<ErrorRequestBadQuery>() {
                    new ErrorRequestBadQuery{
                        title = "Bad Request",
                        status = 400,
                        error = "No se pudo procesar el registro"
                    }
                };
                return BadRequest(error);
            }
        }

        /**
        *   @Remove request
        **/

        [HttpGet("disableRequest/{id}")]

        public ActionResult<RemoveRequest> RemoveRequestById(int id)
        {

            List<SuccessRequest> request = requestRemoveAPI.DisableRequest(id);

            if (request.Count > 0)
            {
                return Ok(request);
            }
            else
            {
                List<ErrorRequestFoundUser> error = new List<ErrorRequestFoundUser>() {
                    new ErrorRequestFoundUser{
                        error = "No se pudo inhabilitar el registro",
                        status = 404
                    }
                };
                return NotFound(error);
            }
        }

        /**
        *   @Update request
        **/

        [HttpPut("updateRequest/{id}")]

        public ActionResult<UpdateRequestAPI> UpdateRequest(List<RequestTB> data, int id)
        {
            List<SuccessRequest> request = requestUpdateAPI.UpdateRequest(data, id);
            
            return Ok(request);
        }
    }
}
