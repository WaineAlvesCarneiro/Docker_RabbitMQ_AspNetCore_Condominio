using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Empresas.Queries.GetAll;

public record GetAllQueryEmpresa(
    long? EmpresaId = null)
        : IRequest<Result<IEnumerable<EmpresaDto>>>
{
    public long? IdEmpresa => EmpresaId;
}