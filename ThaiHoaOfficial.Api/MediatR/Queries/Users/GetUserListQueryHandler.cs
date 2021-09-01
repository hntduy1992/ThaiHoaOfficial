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
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserViewModel>>
    {
        private readonly AppDbContext _context;

        public GetUserListQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserViewModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Users.Include(x => x.Department).Select(x => ConvertModel.UserConvert(x)).ToListAsync<UserViewModel>();
            return result;
        }
    }
}
