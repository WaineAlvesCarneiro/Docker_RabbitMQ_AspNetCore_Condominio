using CondominioSaaS.Application.Features.Empresas.Commands.ValidatorBase;
using CondominioSaaS.Domain.Repositories;

namespace CondominioSaaS.Application.Features.Empresas.Commands.Update;

public class UpdateCommandValidatorEmpresa : CommandValidatorBaseEmpresa<UpdateCommandEmpresa>
{
    public UpdateCommandValidatorEmpresa(IEmpresaRepository repository)
    {
        ConfigureCommonRules(repository);
    }
}