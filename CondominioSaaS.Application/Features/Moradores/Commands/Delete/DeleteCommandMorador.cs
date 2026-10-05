using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Moradores.Commands.Delete;

public record DeleteCommandMorador(long Id) : IRequest<Result>;