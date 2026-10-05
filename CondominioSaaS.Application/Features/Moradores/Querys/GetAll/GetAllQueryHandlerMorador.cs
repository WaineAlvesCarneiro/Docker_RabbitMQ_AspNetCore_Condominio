using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Mappings;
using CondominioSaaS.Domain.Common;
using CondominioSaaS.Domain.Repositories;
using MediatR;

namespace CondominioSaaS.Application.Features.Moradores.Queries.GetAll;

public class GetAllQueryHandlerMorador(IMoradorRepository repository)
    : IRequestHandler<GetAllQueryMorador, Result<IEnumerable<MoradorDto>>>
{
    public async Task<Result<IEnumerable<MoradorDto>>> Handle(GetAllQueryMorador request, CancellationToken cancellationToken)
    {
        var dados = await repository.GetAllAsync(empresaId: request.IdEmpresa, cancellationToken);

        var dtos = dados.Select(dado => dado.ToDto()).ToList();

        return Result<IEnumerable<MoradorDto>>.Success(dtos);
    }
}