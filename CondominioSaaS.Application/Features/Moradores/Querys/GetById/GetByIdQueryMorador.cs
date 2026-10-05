using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Moradores.Queries.GetById;

public record GetByIdQueryMorador(long Id) : IRequest<Result<MoradorDto>>;