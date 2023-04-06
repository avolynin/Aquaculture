﻿using Aquaculture.Application.Services.Users.Common;
using Aquaculture.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Aquaculture.Application.Users.Commands.Update;

public record UpdateUserCommand(
    Guid Id,
    string? FullName,
    string? Role,
    string? Email,
    string? Password) : IRequest<ErrorOr<User>>;