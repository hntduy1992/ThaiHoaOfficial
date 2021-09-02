using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThaiHoaOfficial.Api.MediatR.Commands.Users
{
    public record DeleteUserCommand(Guid Id ) : IRequest<bool>;
    
}
