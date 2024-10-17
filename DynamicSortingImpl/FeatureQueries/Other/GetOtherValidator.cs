using FluentValidation;

namespace DynamicSortingImpl.FeatureQueries.Other;

public class GetOtherValidator : AbstractValidator<GetOtherQuery>
{
    public GetOtherValidator()
    {
        RuleFor(x => x).NotNull();
    }
}