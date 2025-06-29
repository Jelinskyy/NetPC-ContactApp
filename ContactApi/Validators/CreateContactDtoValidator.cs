using System.ComponentModel.DataAnnotations;
using ContactApi.Dtos.Contacts;
using FluentValidation;

namespace ContactApi.Validators
{
    public class CreateContactDtoValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("imie jest wymagane.")
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("nazwisko jest wymagane.")
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("nieprawidłowy format emaila.")
                .When(x => !string.IsNullOrEmpty(x.Email)); // Only validate if Email is provided

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Today).WithMessage("data urodzenia musi być wcześniejsza niż dzisiaj.")
                .When(x => x.DateOfBirth.HasValue); // Only validate if DateOfBirth is provided

            // Validation for phone number
            // Phone number must be in the format +123456789 or 123456789
            // It can contain 7 to 15 digits
            RuleFor(x => x.Phone)
                .Must(x => new PhoneAttribute().IsValid(x))
                .WithMessage("Nieprawidłowy numer telefonu.")
                .When(x => !string.IsNullOrEmpty(x.Phone)); // Only validate if Phone is provided 

            // Validation for password
            // Note: Password is optional, so we check if it's not empty before validating
            // password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character
            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
                .When(x => !string.IsNullOrEmpty(x.Password))
                .WithMessage("hasło musi mieć co najmniej 8 znaków, zawierać wielką literę, małą literę, cyfrę i znak specjalny.");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("kategoria jest wymagana.");

            // Conditional: If Category == Business, BusinessSubcategoryId must be set
            RuleFor(x => x.BusinessSubcategoryId)
                .NotNull().WithMessage("subkategoria biznesowa jest wymagana.")
                .When(x => x.CategoryId == 2); // Checking if Category is Business (setted in AppDbContext)


            // Conditional: If Category == Other, OtherSubcategory must be provided
            RuleFor(x => x.OtherSubcategory)
                .NotEmpty().WithMessage("subkategoria inna jest wymagana.")
                .When(x => x.CategoryId == 3); // Checking if Category is Other (setted in AppDbContext)
        }
    }
}