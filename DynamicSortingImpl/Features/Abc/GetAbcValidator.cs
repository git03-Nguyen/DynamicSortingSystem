using FluentValidation;

namespace DynamicSortingImpl.Features.Abc;

public class GetAbcValidator : AbstractValidator<GetAbcQuery>
{
    public GetAbcValidator()
    {
        RuleFor(x => x.Payload).NotNull();
    }
}