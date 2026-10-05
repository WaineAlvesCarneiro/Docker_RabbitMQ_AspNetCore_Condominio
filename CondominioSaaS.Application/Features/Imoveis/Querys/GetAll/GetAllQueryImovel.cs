using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Imoveis.Queries.GetAll;

public record GetAllQueryImovel(
    long? EmpresaId = null)
        : IRequest<Result<IEnumerable<ImovelDto>>>
{
    public long? IdEmpresa => EmpresaId;
}