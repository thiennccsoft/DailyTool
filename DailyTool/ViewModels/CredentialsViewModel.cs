
using DailyTool.ViewModels.Validations;
using FluentValidation.Attributes;

namespace DailyTool.ViewModels
{
  //login general
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
