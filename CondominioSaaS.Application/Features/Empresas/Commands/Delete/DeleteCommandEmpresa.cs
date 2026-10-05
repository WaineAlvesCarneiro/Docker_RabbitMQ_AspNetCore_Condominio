using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Empresas.Commands.Delete;

public record DeleteCommandEmpresa(long Id) : IRequest<Result>;