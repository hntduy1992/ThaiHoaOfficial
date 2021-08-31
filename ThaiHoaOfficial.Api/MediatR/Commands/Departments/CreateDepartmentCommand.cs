using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.CommandModels;
using ThaiHoaOfficial.Shared.Models;

namespace ThaiHoaOfficial.Api.MediatR.Commands.Departments
{
    public record CreateDepartmentCommand(CreateOrUpdateDepartmentModel NewDepartment) : IRequest<bool>;    
}
