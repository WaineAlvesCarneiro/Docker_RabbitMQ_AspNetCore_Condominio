using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Imoveis.Commands.Delete;

public record DeleteCommandImovel(long Id) : IRequest<Result>;