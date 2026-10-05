using CondominioSaaS.Application.Features.Auth.Commands.ValidatorBase;

namespace CondominioSaaS.Application.Features.Auth.Commands.Update;

public class UpdateCommandValidatorAuthUser : CommandValidatorBaseAuthUser<UpdateCommandAuthUser>
{
    public UpdateCommandValidatorAuthUser()
    {
        ConfigureCommonRules();
    }
}