using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Moradores.Queries.GetAll;

public record GetAllQueryMorador(
    long? EmpresaId = null)
        : IRequest<Result<IEnumerable<MoradorDto>>>
{
    public long? IdEmpresa => EmpresaId;
}