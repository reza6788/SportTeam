using Microsoft.AspNetCore.Mvc;
using SP.Services.Person.Implementation;
using SP.Services.Person.Messaging;
using SP.Services.Person.ViewModel;

namespace SP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("GetPerson")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var response = await _personService.GetPersonInfo(new GetPersonInfoRequest
            {
                Entity = new GetPersonInfoRequestVm{PersonalId = id}
            });
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        [Route("GetPersonContactInfo")]
        public async Task<IActionResult> GetPersonContactInfo(int id)
        {
            var response = await _personService.GetPersonContactInfo(new GetPersonContactInfoRequest
            {
                Entity = new GetPersonContactInfoRequestVm{PersonalId = id}
            });
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        [Route("GetPersonContribution")]
        public async Task<IActionResult> GetPersonContribution(int id)
        {
            var response = await _personService.GetPersonContribution(new GetPersonContributionsRequest
            {
                Entity = new GetPersonContributionRequestVm{PersonalId = id}
            });
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
