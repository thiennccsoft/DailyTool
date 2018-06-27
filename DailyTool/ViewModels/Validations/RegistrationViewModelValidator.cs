
using FluentValidation;
 

namespace DailyTool.ViewModels.Validations
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
    //error when type in form register
        public RegistrationViewModelValidator()
        {
            RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(vm => vm.UserName).NotEmpty().WithMessage("FirstName cannot be empty");
            //RuleFor(vm => vm.CreateAt).NotEmpty().WithMessage("LastName cannot be empty");
        }
    }
}
