using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Mappings;
using CondominioSaaS.Domain.Common;
using CondominioSaaS.Domain.Repositories.Auth;
using MediatR;

namespace CondominioSaaS.Application.Features.Auth.Queries.GetAll;

public class GetAllQueryHandlerAuthUser(IAuthUserRepository repository)
    : IRequestHandler<GetAllQueryAuthUser, Result<IEnumerable<AuthUserDto>>>
{
    public async Task<Result<IEnumerable<AuthUserDto>>> Handle(GetAllQueryAuthUser request, CancellationToken cancellationToken)
    {
        var dados = await repository.GetAllAsync(empresaId: request.IdEmpresa, cancellationToken);

        var dtos = dados.Select(dado => dado.ToDto()).ToList();

        return Result<IEnumerable<AuthUserDto>>.Success(dtos);
    }
}
