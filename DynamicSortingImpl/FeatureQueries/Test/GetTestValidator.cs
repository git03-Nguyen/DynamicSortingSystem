using FluentValidation;

namespace DynamicSortingImpl.FeatureQueries.Test;

public class GetTestValidator : AbstractValidator<GetTestQuery>
{
    public GetTestValidator()
    {
        RuleFor(x => x.Payload).NotNull();
    }
}