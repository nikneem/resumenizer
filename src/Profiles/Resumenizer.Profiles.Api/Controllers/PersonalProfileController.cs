using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resumenizer.Core.Abstractions.Cqrs;
using Resumenizer.Core.Abstractions.DataTransferObjects;
using Resumenizer.Core.Features;
using Resumenizer.Profiles.Abstractions.DataTransferObjects;
using Resumenizer.Profiles.Features.CreatePersonalProfile;
using Resumenizer.Profiles.Features.GetPersonalProfilesList;

namespace Resumenizer.Profiles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalProfileController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] GetPersonalProfilesListQuery requestData,
            [FromServices] IQueryHandler<GetPersonalProfilesListQuery, ResumenizerListResponse<GetPersonalProfilesListItemResponse>> handler)
        {
            var response = await handler.HandleAsync(requestData, HttpContext.RequestAborted);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] CreatePersonalProfileCommand requestData, 
            [FromServices] ICommandHandler<CreatePersonalProfileCommand, PersonalProfileDetailsResponse> handler)
        {
            var response = await handler.HandleAsync(requestData, HttpContext.RequestAborted);
            return Ok(response);
        }
    }
}
