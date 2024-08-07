﻿using FluentValidation;
using KartowkaMarkowkaHub.Web.Models;

namespace KartowkaMarkowkaHub.Web.Validators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Name is required")
                                .MaximumLength(50).WithMessage("Name length can't be more than 50.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                                 .EmailAddress().WithMessage("Invalid email address");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                                    .Length(6, 100).WithMessage("Password length should be between 6 and 100.");
        }
    }
}