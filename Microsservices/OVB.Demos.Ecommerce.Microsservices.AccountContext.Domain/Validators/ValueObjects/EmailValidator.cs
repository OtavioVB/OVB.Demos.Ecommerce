﻿using FluentValidation;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Validators.ValueObjects;

public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
    }
}
