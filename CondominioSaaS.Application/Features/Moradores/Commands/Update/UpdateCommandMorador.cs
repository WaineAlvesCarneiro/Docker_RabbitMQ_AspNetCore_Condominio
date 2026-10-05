using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Features.Moradores.Commands.ValidatorBase;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Moradores.Commands.Update;

public record UpdateCommandMorador : IRequest<Result<MoradorDto>>, ICommandBaseMorador
{
    public long Id { get; set; }
    public required string Nome { get; set; }
    public required string Celular { get; set; }
    public required string Email { get; set; }
    public bool IsProprietario { get; set; }
    public DateOnly DataEntrada { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateOnly? DataSaida { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public long ImovelId { get; set; }
    public long EmpresaId { get; set; }
}