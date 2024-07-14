using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Trips.Register;
public class RegisterTripValidate : AbstractValidator<RequestRegisterTripJson>
{
    public RegisterTripValidate()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.NOME_VAZIO);

        RuleFor(request => request.StartDate.Date)
            .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
            .WithMessage(ResourceErrorMessages.DATA_PASSADA);

        RuleFor(request => request)
            .Must(request => request.EndDate.Date >= request.StartDate.Date)
            .WithMessage(ResourceErrorMessages.DATA_FINAL_DEVE_TERMINAR_APOS_DATA_INICIO);
    }
}