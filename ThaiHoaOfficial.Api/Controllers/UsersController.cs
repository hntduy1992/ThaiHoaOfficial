using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThaiHoaOfficial.Api.MediatR.Commands.Users;
using ThaiHoaOfficial.Api.MediatR.Queries.Users;
using ThaiHoaOfficial.Shared.CommandModels;
using ThaiHoaOfficial.Shared.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThaiHoaOfficial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Route("get-user-list")]
        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            return await _mediator.Send(new GetUserListQuery());
        }

        // GET api/<UsersController>/5
        [HttpGet]
        [Route("get-user/{id}")]
        public async Task<UserViewModel> GetUserAsync([FromRoute] Guid id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        // POST api/<UsersController>
        [HttpPost]
        [Route("create-user")]
        public async Task<bool> CreateUser([FromBody] CreateOrUpdateUserModel newUser)
        {
            return await _mediator.Send(new CreateUserCommand(newUser));
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        [Route("update-user")]
        public async Task<bool> UpdateUser([FromBody] CreateOrUpdateUserModel updateUser)
        {
            return await _mediator.Send(new UpdateUserCommand(updateUser));
        }

        // DELETE api/<UsersController>/5
        [HttpDelete]
        [Route("delete-user/{id}")]
        public async Task<bool> Delete([FromRoute] Guid id)
        {
            return await _mediator.Send(new DeleteUserCommand(id));
        }
    }
}
