using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThaiHoaOfficial.Api.MediatR.Commands.Departments;
using ThaiHoaOfficial.Api.MediatR.Queries.Departments;
using ThaiHoaOfficial.Shared.CommandModels;
using ThaiHoaOfficial.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThaiHoaOfficial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        // GET: api/<DepartmentsController>

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("get-department-list")]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _mediator.Send(new GetDepartmentListQuery());
        }

        

        // POST api/<DepartmentsController>
        [HttpPost]
        [Route("create-department")]
        public async Task<bool> CreateDepartment([FromBody] CreateOrUpdateDepartmentModel newDepartment)
        {
            return await _mediator.Send(new CreateDepartmentCommand(newDepartment));
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut]
        [Route("update-department")]
        public async Task<bool> UpdateDepartment([FromBody] CreateOrUpdateDepartmentModel updateDepartment)
        {
            return await _mediator.Send(new UpdateDepartmentCommand(updateDepartment));
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete]
        [Route("delete-department/{id}")]
        public async Task<bool> DeleteDepartment([FromRoute]Guid id) 
        {
            return await _mediator.Send(new DeleteDepartmentCommand(id));
        }
    }
}
