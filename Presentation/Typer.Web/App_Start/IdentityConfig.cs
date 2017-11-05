using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Typer.Database.Migrations;
using Typer.Database.Models;

namespace Typer.Web
{
    public class IdentityConfig
    {
        // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
        public class ApplicationUserManager : UserManager<DbAppUser>
        {
            public ApplicationUserManager(IUserStore<DbAppUser> store)
                : base(store)
            {

            }

            public static UserManager<DbAppUser> Create(IdentityFactoryOptions<UserManager<DbAppUser>> options, IOwinContext context)
            {
                var manager = new UserManager<DbAppUser>(new AppUserStore(context.Get<TyperContext>()));
                // Configure validation logic for usernames
                manager.UserValidator = new UserValidator<DbAppUser>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Configure user lockout defaults
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                // You can write your own provider and plug it in here.
                manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<DbAppUser>
                {
                    MessageFormat = "Your security code is {0}"
                });
                manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<DbAppUser>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is {0}"
                });
                // manager.EmailService = new EmailService();
                // manager.SmsService = new SmsService();
                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<DbAppUser>(dataProtectionProvider.Create("ASP.NET Identity"));
                }

                return manager;
            }

        }

        // Configure the application sign-in manager which is used in this application.
        public class ApplicationSignInManager : SignInManager<DbAppUser, string>
        {
            public ApplicationSignInManager(UserManager<DbAppUser> userManager, IAuthenticationManager authenticationManager)
                : base(userManager, authenticationManager)
            {
            }
            public override Task<ClaimsIdentity> CreateUserIdentityAsync(DbAppUser user)
            {
                return user.GenerateUserIdentityAsync((UserManager<DbAppUser>)UserManager);
            }
            public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
            {
                return new ApplicationSignInManager(context.GetUserManager<UserManager<DbAppUser>>(), context.Authentication);
            }
        }
    }
}
