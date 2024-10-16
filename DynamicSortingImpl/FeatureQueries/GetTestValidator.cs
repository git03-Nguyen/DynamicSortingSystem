using FluentValidation;

namespace DynamicSortingImpl.FeatureQueries;

public class GetTestValidator : AbstractValidator<GetTestQuery>
{
    public GetTestValidator()
    {
        RuleFor(x => x.Payload).NotNull();
    }
}