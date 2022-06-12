using Api.Contracts.UserProfile.Requests;
using Api.Contracts.UserProfile.Responses;
using Application.UserProfiles.Commands;
using Application.UserProfiles.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route(ApiRoutes.BaseRoute)]
    public class UserProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserProfilesController(IMediator mediator,
                                      IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var query = new GetAllUserProfiles();
            var response = await _mediator.Send(query);
            var userProfiles = _mapper.Map<List<UserProfileResponse>>(response);
            
            return Ok(userProfiles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateUpdate profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            var response = await _mediator.Send(command);
            var userProfile = _mapper.Map<UserProfileResponse>(response);

            return CreatedAtAction(nameof(GetUserProfileById), new {id = response.UserProfileId}, userProfile);
        }

        [HttpGet]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileById { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(query);
            var userProfile = _mapper.Map<UserProfileResponse>(response);
            
            return Ok(userProfile);
        }

        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdate updatedProfile)
        {
            var command = _mapper.Map<UpdateUserProfileBasicInfoCommand>(updatedProfile);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserProfileCommand() { UserProfileId = Guid.Parse(id)};
            var response = await _mediator.Send(command);

            return NoContent();
        }
    }
}
