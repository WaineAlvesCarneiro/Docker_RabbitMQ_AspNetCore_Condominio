using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Auth.Queries.GetAll;

public record GetAllQueryAuthUser(
    long? EmpresaId = null)
        : IRequest<Result<IEnumerable<AuthUserDto>>>
{
    public long? IdEmpresa => EmpresaId;
}