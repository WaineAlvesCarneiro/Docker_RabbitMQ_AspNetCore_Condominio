using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Imoveis.Queries.GetById;

public record GetByIdQueryImovel(long Id) : IRequest<Result<ImovelDto>>;