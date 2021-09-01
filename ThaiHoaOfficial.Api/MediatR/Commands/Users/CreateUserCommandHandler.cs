using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ThaiHoaOfficial.Api.Data;
using ThaiHoaOfficial.Shared.Enums;
using ThaiHoaOfficial.Shared.Models;

namespace ThaiHoaOfficial.Api.MediatR.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly AppDbContext _context;
        public CreateUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Guid newId = Guid.NewGuid();
            while (_context.Users.Any(x => x.Id == newId))
            {
                newId = Guid.NewGuid();
            };
            User newUser = new User
            {
                Id = newId,
                FullName = request.newUser.FullName,
                IsMale = request.newUser.IsMale,
                CreatedDate = DateTime.Now.Date,
                DateOfBirth = request.newUser.DateOfBirth,
                DepartmentId = request.newUser.DepartmentId,
                EmailAddress = request.newUser.EmailAddress,
                PhoneNumber = request.newUser.PhoneNumber,
                Status =  UserStatus.Unconfirmed,
            };
            _context.Users.Add(newUser);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
