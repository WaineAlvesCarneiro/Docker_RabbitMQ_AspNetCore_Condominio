using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Mappings;
using CondominioSaaS.Domain.Common;
using CondominioSaaS.Domain.Entities.Auth;
using CondominioSaaS.Domain.Interfaces;
using CondominioSaaS.Domain.Repositories.Auth;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CondominioSaaS.Application.Features.Auth.Commands.Update;

public record UpdateCommandHandlerAuthUser(
    IAuthUserRepository repository,
    IMensageriaService mensageriaService,
    IEmailTemplateService emailTemplateService,
    ILogger<UpdateCommandHandlerAuthUser> logger)
        : IRequestHandler<UpdateCommandAuthUser, Result<AuthUserDto>>
{
    public async Task<Result<AuthUserDto>> Handle(UpdateCommandAuthUser request, CancellationToken cancellationToken)
    {
        var dadoToUpdate = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (dadoToUpdate == null) return Result<AuthUserDto>.Failure("Usuário não encontrado.");

        dadoToUpdate.UpdateFromCommand(request);
        await repository.UpdateAsync(dadoToUpdate, cancellationToken);
        await EnviarEmailAlteracoesAsync(dadoToUpdate);

        return Result<AuthUserDto>.Success(dadoToUpdate.ToDto(), "Usuário atualizado com sucesso.");
    }

    private async Task EnviarEmailAlteracoesAsync(AuthUser dadoToUpdate)
    {
        try
        {
            var corpoEmail = emailTemplateService.GerarUsuarioAlterado(dadoToUpdate.UserName);
            var emailRequest = new EnvioEmailRequest(
                dadoToUpdate.Email,
                "Usuário alteração de Dados Cadastrais",
                corpoEmail,
                dadoToUpdate.EmpresaId.GetValueOrDefault()
            );

            await mensageriaService.PublicarMensagemAsync(emailRequest);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "[Update Empresa] Falha ao enfileirar e-mail para {Email}", dadoToUpdate.Email);
        }
    }
}