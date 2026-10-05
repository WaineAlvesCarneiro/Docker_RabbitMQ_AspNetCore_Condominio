using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Auth.Commands.DefinirSenha;

public class DefinirSenhaCommand : IRequest<Result<AuthUserDto>>
{
    public string UserName { get; set; } = string.Empty;
    public string NovaSenha { get; set; } = string.Empty;
}
