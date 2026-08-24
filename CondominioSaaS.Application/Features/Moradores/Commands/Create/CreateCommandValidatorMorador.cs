using CondominioSaaS.Application.Features.Moradores.Commands.ValidatorBase;

namespace CondominioSaaS.Application.Features.Moradores.Commands.Create;

public class CreateCommandValidatorMorador : CommandValidatorBaseMorador<CreateCommandMorador>
{
    public CreateCommandValidatorMorador()
    {
        ConfigureCommonRules();
    }
}