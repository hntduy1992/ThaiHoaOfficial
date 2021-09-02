using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ThaiHoaOfficial.Api.Data;
using ThaiHoaOfficial.Shared.Modules;
using ThaiHoaOfficial.Shared.ViewModels;

namespace ThaiHoaOfficial.Api.MediatR.Queries.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly AppDbContext _context;

        public GetUserByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return ConvertModel.UserConvert(await _context.Users.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == request.Id));

        }
    }
}
