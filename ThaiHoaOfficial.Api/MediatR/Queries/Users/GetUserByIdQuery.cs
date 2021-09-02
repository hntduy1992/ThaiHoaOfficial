using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.ViewModels;

namespace ThaiHoaOfficial.Api.MediatR.Queries.Users
{
    public record GetUserByIdQuery(Guid Id) : IRequest<UserViewModel>;
   
}
