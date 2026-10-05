using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Mappings;
using CondominioSaaS.Domain.Common;
using CondominioSaaS.Domain.Entities;
using CondominioSaaS.Domain.Repositories;
using MediatR;

namespace CondominioSaaS.Application.Features.Imoveis.Commands.Create;

public class CreateCommandHandlerImovel(
    IImovelRepository repository)
        : IRequestHandler<CreateCommandImovel, Result<ImovelDto>>
{
    public async Task<Result<ImovelDto>> Handle(CreateCommandImovel request, CancellationToken cancellationToken)
    {
        Imovel dado = request.ToEntity();
        await repository.CreateAsync(dado, cancellationToken);

        return Result<ImovelDto>.Success(dado.ToDto(), "Imóvel criado com sucesso.");
    }
}