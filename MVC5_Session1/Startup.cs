using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using MVC5_Session1.Models;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(MVC5_Session1.Startup))]
namespace MVC5_Session1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/"),
                Provider = new CookieAuthenticationProvider
                {
                    // 讓應用程式在使用者登入時驗證安全性戳記。
                    // 這是您變更密碼或將外部登入新增至帳戶時所使用的安全性功能。  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
            validateInterval: TimeSpan.FromMinutes(30),
            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
        }
    }
}
