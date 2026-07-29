namespace Identity.Controllers
{
    using Identity.Data;
    using Identity.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Storage;

    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var registerUser = new User
            {
                Email = user.Email,
                UserName = user.Email,
                FullName = user.FullName
            };

            var result = await this.userManager.CreateAsync(registerUser, user.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel user)
        {
            var loggedUser = await this.userManager.FindByEmailAsync(user.Email);

            if (loggedUser == null)
            {
                InvalidCredentials(user);
            }

            var passwordIsValid = await this.userManager.CheckPasswordAsync(loggedUser, user.Password);

            if (!passwordIsValid)
            {
                InvalidCredentials(user);
            }

            await this.signInManager.SignInAsync(loggedUser, true);
            return RedirectToAction("Index", "Home");
        }

        private IActionResult InvalidCredentials(LoginFormModel user)
        {
            const string invalidCredentialsMessage = "Credentials Invalid!";
            ModelState.AddModelError(string.Empty, invalidCredentialsMessage);

            return View(user);
        }
    }
}
