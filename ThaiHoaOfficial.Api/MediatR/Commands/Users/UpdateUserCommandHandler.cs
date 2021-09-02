using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ThaiHoaOfficial.Api.Data;
using ThaiHoaOfficial.Shared.Models;

namespace ThaiHoaOfficial.Api.MediatR.Commands.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _context.Users.FindAsync(request.UpdateUser.Id);
            if (user == null) return false;
            user.FullName = request.UpdateUser.FullName;
            user.DateOfBirth = request.UpdateUser.DateOfBirth;
            user.EmailAddress = request.UpdateUser.EmailAddress;
            user.IsMale = request.UpdateUser.IsMale;
            user.PhoneNumber = request.UpdateUser.PhoneNumber;
            user.DepartmentId = request.UpdateUser.DepartmentId;
            
            _context.Users.Update(user);
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
