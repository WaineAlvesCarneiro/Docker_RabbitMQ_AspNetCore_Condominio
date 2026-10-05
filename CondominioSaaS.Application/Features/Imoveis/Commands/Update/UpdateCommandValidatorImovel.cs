using CondominioSaaS.Application.Features.Imoveis.Commands.ValidatorBase;

namespace CondominioSaaS.Application.Features.Imoveis.Commands.Update;

public class UpdateCommandValidatorImovel : CommandValidatorBaseImovel<UpdateCommandImovel>
{
    public UpdateCommandValidatorImovel()
    {
        ConfigureCommonRules();
    }
}