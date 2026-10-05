using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Auth.Commands.Delete;

public record DeleteCommandAuthUser(Guid Id) : IRequest<Result>;