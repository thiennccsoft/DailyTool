using DailyTool.ViewModels;
using FluentValidation;

namespace DailyTool.ViewModels.Validations
{
    public class CredentialsViewModelValidator : AbstractValidator<CredentialsViewModel>
    {
    //error when type in form login
        public CredentialsViewModelValidator()
        {
      //RuleFor: luật cho các trường nhập vào 
            RuleFor(vm => vm.UserName).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(vm => vm.Password).Length(6, 12).WithMessage("Password must be between 6 and 12 characters");
        }
    }
}
