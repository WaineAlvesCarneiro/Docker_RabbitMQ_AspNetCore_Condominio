using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Auth.Queries.GetById;

public record GetByIdQueryAuthUser(Guid Id) : IRequest<Result<AuthUserDto>>;