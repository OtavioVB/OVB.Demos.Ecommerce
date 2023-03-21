using FluentValidation;
using OVB.Demos.Ecommerce.Libraries.Domain.Validators;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Microssevrices.UnitTests.Domain.ValueObjects.Validators;

public sealed class TestValueObjectNameValidator
{
    private AbstractValidator<Name> nameValidator = new NameValidator();

    [Theory]
    [InlineData("")]
    public void TestValueObjectNameCannotBeNullOrEmpty(string name)
    {
        var validation = nameValidator.Validate(new Name(name));

        Assert.False(validation.IsValid);
    }
}
