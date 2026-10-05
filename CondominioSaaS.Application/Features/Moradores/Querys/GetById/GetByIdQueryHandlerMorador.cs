using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Mappings;
using CondominioSaaS.Domain.Common;
using CondominioSaaS.Domain.Repositories;
using MediatR;

namespace CondominioSaaS.Application.Features.Moradores.Queries.GetById;

public class GetByIdQueryHandlerMorador(IMoradorRepository repository)
    : IRequestHandler<GetByIdQueryMorador, Result<MoradorDto>>
{
    public async Task<Result<MoradorDto>> Handle(GetByIdQueryMorador request, CancellationToken cancellationToken)
    {
        var dado = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (dado is null) return Result<MoradorDto>.Failure("Morador não encontrado.");

        return Result<MoradorDto>.Success(dado.ToDto());
    }
}
