using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Empresas.Queries.GetById;

public record GetByIdQueryEmpresa(long Id) : IRequest<Result<EmpresaDto>>;