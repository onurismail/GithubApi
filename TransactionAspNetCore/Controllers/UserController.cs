using Microsoft.AspNetCore.Mvc;
using TransactionAspNetCore.Models;
using Newtonsoft.Json.Linq;
using TransactionAspNetCore.Services;

namespace TransactionAspNetCore.Controllers
{
    // [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private IUserRepository _repository;
        public TransactionsController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = nameof(SearchUsers))]
        public ActionResult SearchUsers([FromQuery] QueryParameters queryParameters)
        {

            if (string.IsNullOrEmpty(queryParameters.location))
                return BadRequest("Location parameter is mandatory(e.g : Barcelona)");

            string contributorsEndPoint = _repository
                .GetGithubSearchUsersEndpoint(queryParameters.location,
                                               queryParameters.sort,
                                               queryParameters.order);
            var result = JObject.Parse(_repository.GetMostContributedUsers(contributorsEndPoint));
            return Ok(result);
        }
    }
}
