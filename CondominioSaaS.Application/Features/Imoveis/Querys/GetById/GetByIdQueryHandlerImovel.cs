using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Mappings;
using CondominioSaaS.Domain.Common;
using CondominioSaaS.Domain.Repositories;
using MediatR;

namespace CondominioSaaS.Application.Features.Imoveis.Queries.GetById;

public record GetByIdQueryHandlerImovel(IImovelRepository repository)
    : IRequestHandler<GetByIdQueryImovel, Result<ImovelDto>>
{
    public async Task<Result<ImovelDto>> Handle(GetByIdQueryImovel request, CancellationToken cancellationToken)
    {
        var dado = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (dado is null) return Result<ImovelDto>.Failure("Imóvel não encontrado.");

        return Result<ImovelDto>.Success(dado.ToDto());
    }
}