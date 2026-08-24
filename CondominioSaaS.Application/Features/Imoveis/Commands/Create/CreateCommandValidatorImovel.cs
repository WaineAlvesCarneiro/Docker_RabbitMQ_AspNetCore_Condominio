using CondominioSaaS.Application.Features.Imoveis.Commands.ValidatorBase;

namespace CondominioSaaS.Application.Features.Imoveis.Commands.Create;

public class CreateCommandValidatorImovel : CommandValidatorBaseImovel<CreateCommandImovel>
{
    public CreateCommandValidatorImovel()
    {
        ConfigureCommonRules();
    }
}