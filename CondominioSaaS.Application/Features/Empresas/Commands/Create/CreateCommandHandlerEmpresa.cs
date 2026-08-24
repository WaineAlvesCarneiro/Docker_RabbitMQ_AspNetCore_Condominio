using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Application.Mappings;
using CondominioSaaS.Domain.Common;
using CondominioSaaS.Domain.Entities;
using CondominioSaaS.Domain.Interfaces;
using CondominioSaaS.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CondominioSaaS.Application.Features.Empresas.Commands.Create;

public record CreateCommandHandlerEmpresa(
    IEmpresaRepository repository,
    IMensageriaService mensageriaService,
    IEmailTemplateService emailTemplateService,
    ILogger<CreateCommandHandlerEmpresa> logger)
        : IRequestHandler<CreateCommandEmpresa, Result<EmpresaDto>>
{
    public async Task<Result<EmpresaDto>> Handle(CreateCommandEmpresa request, CancellationToken cancellationToken)
    {
        Empresa dado = request.ToEntity();
        await repository.CreateAsync(dado, cancellationToken);

        await EnviarEmailBoasVindasAsync(dado);

        return Result<EmpresaDto>.Success(dado.ToDto(), "Empresa criada com sucesso.");
    }

    private async Task EnviarEmailBoasVindasAsync(Empresa dado)
    {
        try
        {
            var corpoEmail = emailTemplateService.GerarBoasVindasEmpresa(dado.RazaoSocial);
            var emailRequest = new EnvioEmailRequest(
                dado.Email,
                "Bem-vindo ao Sistema",
                corpoEmail,
                dado.Id
            );

            await mensageriaService.PublicarMensagemAsync(emailRequest);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "[Create Empresa] Falha ao enfileirar e-mail para {Email}", dado.Email);
        }
    }
}