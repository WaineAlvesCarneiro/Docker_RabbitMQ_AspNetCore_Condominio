using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Mappings;
using CondominioSaaS.Domain.Common;
using CondominioSaaS.Domain.Repositories;
using MediatR;

namespace CondominioSaaS.Application.Features.Imoveis.Commands.Update;

public class UpdateCommandHandlerImovel(
    IImovelRepository repository)
        : IRequestHandler<UpdateCommandImovel, Result<ImovelDto>>
{
    public async Task<Result<ImovelDto>> Handle(UpdateCommandImovel request, CancellationToken cancellationToken)
    {
        var dadoToUpdate = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (dadoToUpdate == null) return Result<ImovelDto>.Failure("Imóvel não encontrado.");

        dadoToUpdate.UpdateFromCommand(request);
        await repository.UpdateAsync(dadoToUpdate, cancellationToken);

        return Result<ImovelDto>.Success(dadoToUpdate.ToDto(), "Imóvel atualizado com sucesso.");
    }
}