using FluentValidation;
using InvestApp.DataAccess.Dtos;

namespace InvestApp.DataAccess.Validators

{
    public class RegisterValidator :AbstractValidator<CreateUserDto>
    {
        public RegisterValidator(InvestAppDbContext dbcontext)
        {
            RuleFor(x=>x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .MinimumLength(8);
            RuleFor(x => x.Email)
               .Custom((value, context) =>
               {
                   var emailInUse = dbcontext.Users.Any(u => u.Email == value);
                   if (emailInUse)
                   {
                       context.AddFailure("Email", "That email is taken");
                   }
               });
        }
    }
}
