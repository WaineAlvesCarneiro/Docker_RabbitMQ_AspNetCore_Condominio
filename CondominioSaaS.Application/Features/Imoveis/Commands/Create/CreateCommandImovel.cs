using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Features.Imoveis.Commands.ValidatorBase;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Imoveis.Commands.Create;

public record CreateCommandImovel : IRequest<Result<ImovelDto>>, ICommandBaseImovel
{
    public long Id { get; set; }
    public required string Bloco { get; set; }
    public required string Apartamento { get; set; }
    public required string BoxGaragem { get; set; }
    public long EmpresaId { get; set; }
}