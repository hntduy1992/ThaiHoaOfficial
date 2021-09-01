﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.CommandModels;

namespace ThaiHoaOfficial.Api.MediatR.Commands.Users
{
    public record UpdateUserCommand(CreateOrUpdateUserModel UpdateUser):IRequest<bool>;
}
