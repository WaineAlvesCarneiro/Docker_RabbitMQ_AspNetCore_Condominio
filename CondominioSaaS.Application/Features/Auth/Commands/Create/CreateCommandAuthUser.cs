using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Features.Auth.Commands.ValidatorBase;
using CondominioSaaS.Domain.Common;
using CondominioSaaS.Domain.Enums;
using MediatR;

namespace CondominioSaaS.Application.Features.Auth.Commands.Create;

public class CreateCommandAuthUser : IRequest<Result<AuthUserDto>>, ICommandBaseAuthUser
{
    public int Id { get; set; }
    public TipoUserAtivo Ativo { get; set; }
    public TipoEmpresaAtivo EmpresaAtiva { get; set; }
    public long? EmpresaId { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public TipoRole Role { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime? DataAlteracao { get; set; }
}