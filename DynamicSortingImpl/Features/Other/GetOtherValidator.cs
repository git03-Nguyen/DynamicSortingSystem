using FluentValidation;

namespace DynamicSortingImpl.Features.Other;

public class GetOtherValidator : AbstractValidator<GetOtherQuery>
{
    public GetOtherValidator()
    {
        RuleFor(x => x).NotNull();
    }
}