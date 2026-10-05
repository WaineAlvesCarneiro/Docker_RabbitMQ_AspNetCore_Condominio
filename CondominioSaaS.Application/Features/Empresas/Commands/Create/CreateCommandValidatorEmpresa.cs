using CondominioSaaS.Application.Features.Empresas.Commands.ValidatorBase;
using CondominioSaaS.Domain.Repositories;

namespace CondominioSaaS.Application.Features.Empresas.Commands.Create;

public class CreateCommandValidatorEmpresa : CommandValidatorBaseEmpresa<CreateCommandEmpresa>
{
    public CreateCommandValidatorEmpresa(IEmpresaRepository repository)
    {
        ConfigureCommonRules(repository);
    }
}