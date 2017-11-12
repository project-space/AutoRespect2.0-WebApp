using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRespect.AuthorizationServer.Api;
using AutoRespect.AuthorizationServer.DataTransfer.Request;
using AutoRespect.Infrastructure.Errors.Design;
using AutoRespect.Infrastructure.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AutoRespect.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountApi accountApi;

        public AccountController(IAccountApi accountApi)
        {
            this.accountApi = accountApi;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(string login, string password)
        {
            //TODO: [REFACTORING] EXTRACT LOGIC TO SOME BUSINESS ENTITY

            var signInRequest = new SignInRequest { Login = login, Password = password };
            var response = await accountApi.SignIn(signInRequest);
            if (response.IsSuccess)
            {
                HttpContext.SignIn(response.Value.AccessToken);
                return Redirect("/");
            }
            else
            {
                return View(response.Failures);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(string login, string password, string confirmPassword)
        {
            //TODO: [REFACTORING] EXTRACT LOGIC TO SOME BUSINESS ENTITY

            if (password.Equals(confirmPassword))
            {
                var request = new RegisterRequest { Login = login, Password = password };
                var response = await accountApi.SignUp(request);
                if (response.IsSuccess)
                {
                    HttpContext.SignIn(response.Value.AccessToken);
                    return Redirect("/");
                }
                else
                {
                    return View(response.Failures);
                }
            }
            else
            {
                return View(new List<E> { new PasswordAndRetryPasswordNotEquals() });
            }

        }

        //TODO: [REFACTORING] MOVE FROM HERE
        public class PasswordAndRetryPasswordNotEquals : E
        {
            public PasswordAndRetryPasswordNotEquals() : base("E7280A7C-FFCC-4A57-A3EB-8C64780DE438", "Confirm password not equals to password")
            {
            }
        }


        [HttpGet]
        [Authorize]
        public IActionResult SignOut()
        {
            HttpContext.SignOut();
            return Redirect("/");
        }
    }
}
