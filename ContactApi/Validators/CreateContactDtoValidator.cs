using ContactApi.Dtos.Contacts;
using ContactApi.Interfaces;
using FluentValidation;

namespace ContactApi.Validators
{
    public class CreateContactDtoValidator : AbstractValidator<CreateContactDto>
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IBusinessSubcategoryRepository _businessSubcategoryRepo;
        public CreateContactDtoValidator(ICategoryRepository categoryRepo, IBusinessSubcategoryRepository businessSubcategoryRepo)
        {
            _categoryRepo = categoryRepo;
            _businessSubcategoryRepo = businessSubcategoryRepo;

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
            // It can contain 7 to 15 digits and may start with a '+' sign
            RuleFor(x => x.Phone)
                .Must(BeAValidPhoneNumber).WithMessage("nieprawidłowy format numeru telefonu.")
                .When(x => !string.IsNullOrEmpty(x.Phone)); // Only validate if Phone is provided 

            // Validation for password
            // Note: Password is optional, so we check if it's not empty before validating
            // password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character
            RuleFor(x => x.Password)
                .Must(BeAValidPassword)
                .When(x => !string.IsNullOrEmpty(x.Password))
                .WithMessage("hasło musi mieć co najmniej 8 znaków, zawierać wielką literę, małą literę, cyfrę i znak specjalny.");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("kategoria jest wymagana.")
                .MustAsync(CategoryExists).WithMessage("nieprawidłowa kategoria.");

            // Conditional: If Category == Business, BusinessSubcategoryId must be set
            RuleFor(x => x.BusinessSubcategoryId)
                .NotNull().WithMessage("subkategoria biznesowa jest wymagana.")
                .MustAsync(BusinessSubcategoryExists).WithMessage("nieprawidłowa subkategoria biznesowa.")
                .When(x => x.CategoryId == 2); // Checking if Category is Business (setted in AppDbContext)
                

            // Conditional: If Category == Other, OtherSubcategory must be provided
            RuleFor(x => x.OtherSubcategory)
                .NotEmpty().WithMessage("subkategoria inna jest wymagana.")
                .When(x => x.CategoryId == 3); // Checking if Category is Other (setted in AppDbContext)
        }

        // Custom validation for phone number
        private bool BeAValidPhoneNumber(string? phone)
        {
            if (string.IsNullOrEmpty(phone)) return true;

            // Phone number must be in the format +123456789 or 123456789
            // It can contain 7 to 15 digits and may start with a '+' sign
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\+?\d{7,15}$");
        }

        // Custom validation for password
        private bool BeAValidPassword(string? password)
        {
            if (string.IsNullOrEmpty(password)) return true;

            return password.Length >= 8
                && password.Any(char.IsUpper)
                && password.Any(char.IsLower)
                && password.Any(char.IsDigit)
                && password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        // Custom validation for CategoryId
        private async Task<bool> CategoryExists(int categoryId, CancellationToken token)
        {
            return await _categoryRepo.ExistsByIdAsync(categoryId);
        }

        // Custom validation for BusinessSubcategoryId
        private async Task<bool> BusinessSubcategoryExists(int? subcategoryId, CancellationToken token)
        {
            return await _businessSubcategoryRepo.ExistsByIdAsync(subcategoryId);
        }
}
}