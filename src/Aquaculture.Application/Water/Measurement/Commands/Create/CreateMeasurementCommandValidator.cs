using FluentValidation;

namespace Aquaculture.Application.Water.Measurement.Commands.Create;

public class CreateMeasurementCommandValidator : AbstractValidator<CreateMeasurementCommand>
{
    public CreateMeasurementCommandValidator()
    {
        RuleFor(x => x.TimeStamp);
        RuleFor(x => x.FishTankId);
    }
}
