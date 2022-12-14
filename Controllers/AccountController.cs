using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Metro.Models;
using DataLayer;
using System.Web.Security;
using DataLayer.ViewModels;

namespace Metro.Controllers
{
    //[Authorize]
    //public class AccountController : Controller
    //{
    //    private ApplicationSignInManager _signInManager;
    //    private ApplicationUserManager _userManager;

    //    public AccountController()
    //    {
    //    }

    //    public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
    //    {
    //        UserManager = userManager;
    //        SignInManager = signInManager;
    //    }

    //    public ApplicationSignInManager SignInManager
    //    {
    //        get
    //        {
    //            return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
    //        }
    //        private set 
    //        { 
    //            _signInManager = value; 
    //        }
    //    }

    //    public ApplicationUserManager UserManager
    //    {
    //        get
    //        {
    //            return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //        }
    //        private set
    //        {
    //            _userManager = value;
    //        }
    //    }

    //    //
    //    // GET: /Account/Login
    //    [AllowAnonymous]
    //    public ActionResult Login(string returnUrl)
    //    {
    //        ViewBag.ReturnUrl = returnUrl;
    //        return View();
    //    }
        
    //    // POST: /Account/Login
    //    // ممونم وقتتون رو به من اختصاص دادین اوایل کار که اومدین پایین حدودا یک ساعت باهم صحبت کردیم و اصن همون یک ساعت بود که نشون 
    //    // داد چقدر ارزش قائل هستین و چقدر من باید قدر بچه ها رو بدونم بهم راه درست نشون دادین
    //    // اونجا بهم گفتید که هر دغدغه ای داری به خودم و مهندس پیونده بگو
    //    // برای این دوتا مشکل  دارم  که میخواستم ازتون کمک بگیرم راه درست انتخاب کنم

    //    // از کجا شروع کنم اااا یادتون یه نرم افزاری بود ساعت کار کردنم تو خونه رو میزدم که از 5 صبح پامیشم و تا 12 باز 12 تا 13 میخوابم 
    //    // اون الان این جوری شده که از اینجا که میرم خونه ساعت 6 میرسم به حاج خانم گفتم شام برای من همونجا آماده کنه
    //    // تا ساعت 7 میخورم تا 7:30 میخوابم از اون طرف 3 3:30 بیدار میشم تا تاحدود 6 برای کنکور درس میخونم 6:30 هم که راه میوفتم به سمت شرکت
    //    // نکته ای که هست اینکه راهی هست نمیخوام هم که به اذیت بیوفتید ولی راهی هست که این مشکل سربازی  حل بشه یا نه

    //    // دغدغه اول اینکه خوب هفته پیش بود که مهندس پیونده بهم گفتن پروژه تغییر کرده اون طیب رو تا جایی که پیشرفتی داکیومنت کن به همو
    //    // شکلی که شما گفته بودین از ذکر جزئیات و فیلم از جزئیات کارکردش  اون ثبت کردم فرستادم
    //    // این پروژه جدید که یک هفته ای هست روش کارمیکنم دیگه خودتون میدونید دیگه فاز اولش یک صفحه برای اینکه کاربر ناوبری کنه بین 
    //    //  براش
    //    // سامانه ها نکته اینکه این پروژه تغییر کرد خب این الان بسم هستش خب آخر ما چند چند هستید بامن من چکار کنم برای معیار های شما
        
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        // This doesn't count login failures towards account lockout
    //        // To enable password failures to trigger account lockout, change to shouldLockout: true
    //        var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
    //        switch (result)
    //        {
    //            case SignInStatus.Success:
    //                return RedirectToLocal(returnUrl);
    //            case SignInStatus.LockedOut:
    //                return View("Lockout");
    //            case SignInStatus.RequiresVerification:
    //                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
    //            case SignInStatus.Failure:
    //            default:
    //                ModelState.AddModelError("", "Invalid login attempt.");
    //                return View(model);
    //        }
    //    }

    //    //
    //    // GET: /Account/VerifyCode
    //    [AllowAnonymous]
    //    public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
    //    {
    //        // Require that the user has already logged in via username/password or external login
    //        if (!await SignInManager.HasBeenVerifiedAsync())
    //        {
    //            return View("Error");
    //        }
    //        return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
    //    }

    //    //
    //    // POST: /Account/VerifyCode
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        // The following code protects for brute force attacks against the two factor codes. 
    //        // If a user enters incorrect codes for a specified amount of time then the user account 
    //        // will be locked out for a specified amount of time. 
    //        // You can configure the account lockout settings in IdentityConfig
    //        var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
    //        switch (result)
    //        {
    //            case SignInStatus.Success:
    //                return RedirectToLocal(model.ReturnUrl);
    //            case SignInStatus.LockedOut:
    //                return View("Lockout");
    //            case SignInStatus.Failure:
    //            default:
    //                ModelState.AddModelError("", "Invalid code.");
    //                return View(model);
    //        }
    //    }

    //    //
    //    // GET: /Account/Register
    //    [AllowAnonymous]
    //    public ActionResult Register()
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Account/Register
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> Register(RegisterViewModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    //            var result = await UserManager.CreateAsync(user, model.Password);
    //            if (result.Succeeded)
    //            {
    //                await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    
    //                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
    //                // Send an email with this link
    //                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
    //                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
    //                // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

    //                return RedirectToAction("Index", "Home");
    //            }
    //            AddErrors(result);
    //        }

    //        // If we got this far, something failed, redisplay form
    //        return View(model);
    //    }

    //    //
    //    // GET: /Account/ConfirmEmail
    //    [AllowAnonymous]
    //    public async Task<ActionResult> ConfirmEmail(string userId, string code)
    //    {
    //        if (userId == null || code == null)
    //        {
    //            return View("Error");
    //        }
    //        var result = await UserManager.ConfirmEmailAsync(userId, code);
    //        return View(result.Succeeded ? "ConfirmEmail" : "Error");
    //    }

    //    //
    //    // GET: /Account/ForgotPassword
    //    [AllowAnonymous]
    //    public ActionResult ForgotPassword()
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Account/ForgotPassword
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var user = await UserManager.FindByNameAsync(model.Email);
    //            if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
    //            {
    //                // Don't reveal that the user does not exist or is not confirmed
    //                return View("ForgotPasswordConfirmation");
    //            }

    //            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
    //            // Send an email with this link
    //            // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
    //            // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
    //            // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
    //            // return RedirectToAction("ForgotPasswordConfirmation", "Account");
    //        }

    //        // If we got this far, something failed, redisplay form
    //        return View(model);
    //    }

    //    //
    //    // GET: /Account/ForgotPasswordConfirmation
    //    [AllowAnonymous]
    //    public ActionResult ForgotPasswordConfirmation()
    //    {
    //        return View();
    //    }

    //    //
    //    // GET: /Account/ResetPassword
    //    [AllowAnonymous]
    //    public ActionResult ResetPassword(string code)
    //    {
    //        return code == null ? View("Error") : View();
    //    }

    //    //
    //    // POST: /Account/ResetPassword
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }
    //        var user = await UserManager.FindByNameAsync(model.Email);
    //        if (user == null)
    //        {
    //            // Don't reveal that the user does not exist
    //            return RedirectToAction("ResetPasswordConfirmation", "Account");
    //        }
    //        var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
    //        if (result.Succeeded)
    //        {
    //            return RedirectToAction("ResetPasswordConfirmation", "Account");
    //        }
    //        AddErrors(result);
    //        return View();
    //    }

    //    //
    //    // GET: /Account/ResetPasswordConfirmation
    //    [AllowAnonymous]
    //    public ActionResult ResetPasswordConfirmation()
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Account/ExternalLogin
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult ExternalLogin(string provider, string returnUrl)
    //    {
    //        // Request a redirect to the external login provider
    //        return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
    //    }

    //    //
    //    // GET: /Account/SendCode
    //    [AllowAnonymous]
    //    public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
    //    {
    //        var userId = await SignInManager.GetVerifiedUserIdAsync();
    //        if (userId == null)
    //        {
    //            return View("Error");
    //        }
    //        var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
    //        var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
    //        return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
    //    }

    //    //
    //    // POST: /Account/SendCode
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> SendCode(SendCodeViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View();
    //        }

    //        // Generate the token and send it
    //        if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
    //        {
    //            return View("Error");
    //        }
    //        return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
    //    }

    //    //
    //    // GET: /Account/ExternalLoginCallback
    //    [AllowAnonymous]
    //    public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
    //    {
    //        var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
    //        if (loginInfo == null)
    //        {
    //            return RedirectToAction("Login");
    //        }

    //        // Sign in the user with this external login provider if the user already has a login
    //        var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
    //        switch (result)
    //        {
    //            case SignInStatus.Success:
    //                return RedirectToLocal(returnUrl);
    //            case SignInStatus.LockedOut:
    //                return View("Lockout");
    //            case SignInStatus.RequiresVerification:
    //                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
    //            case SignInStatus.Failure:
    //            default:
    //                // If the user does not have an account, then prompt the user to create an account
    //                ViewBag.ReturnUrl = returnUrl;
    //                ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
    //                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
    //        }
    //    }

    //    //
    //    // POST: /Account/ExternalLoginConfirmation
    //    [HttpPost]
    //    [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
    //    {
    //        if (User.Identity.IsAuthenticated)
    //        {
    //            return RedirectToAction("Index", "Manage");
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            // Get the information about the user from the external login provider
    //            var info = await AuthenticationManager.GetExternalLoginInfoAsync();
    //            if (info == null)
    //            {
    //                return View("ExternalLoginFailure");
    //            }
    //            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
    //            var result = await UserManager.CreateAsync(user);
    //            if (result.Succeeded)
    //            {
    //                result = await UserManager.AddLoginAsync(user.Id, info.Login);
    //                if (result.Succeeded)
    //                {
    //                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
    //                    return RedirectToLocal(returnUrl);
    //                }
    //            }
    //            AddErrors(result);
    //        }

    //        ViewBag.ReturnUrl = returnUrl;
    //        return View(model);
    //    }

    //    //
    //    // POST: /Account/LogOff
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult LogOff()
    //    {
    //        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
    //        return RedirectToAction("Index", "Home");
    //    }

    //    //
    //    // GET: /Account/ExternalLoginFailure
    //    [AllowAnonymous]
    //    public ActionResult ExternalLoginFailure()
    //    {
    //        return View();
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            if (_userManager != null)
    //            {
    //                _userManager.Dispose();
    //                _userManager = null;
    //            }

    //            if (_signInManager != null)
    //            {
    //                _signInManager.Dispose();
    //                _signInManager = null;
    //            }
    //        }

    //        base.Dispose(disposing);
    //    }

    //    #region Helpers
    //    // Used for XSRF protection when adding external logins
    //    private const string XsrfKey = "XsrfId";

    //    private IAuthenticationManager AuthenticationManager
    //    {
    //        get
    //        {
    //            return HttpContext.GetOwinContext().Authentication;
    //        }
    //    }

    //    private void AddErrors(IdentityResult result)
    //    {
    //        foreach (var error in result.Errors)
    //        {
    //            ModelState.AddModelError("", error);
    //        }
    //    }

    //    private ActionResult RedirectToLocal(string returnUrl)
    //    {
    //        if (Url.IsLocalUrl(returnUrl))
    //        {
    //            return Redirect(returnUrl);
    //        }
    //        return RedirectToAction("Index", "Home");
    //    }

    //    internal class ChallengeResult : HttpUnauthorizedResult
    //    {
    //        public ChallengeResult(string provider, string redirectUri)
    //            : this(provider, redirectUri, null)
    //        {
    //        }

    //        public ChallengeResult(string provider, string redirectUri, string userId)
    //        {
    //            LoginProvider = provider;
    //            RedirectUri = redirectUri;
    //            UserId = userId;
    //        }

    //        public string LoginProvider { get; set; }
    //        public string RedirectUri { get; set; }
    //        public string UserId { get; set; }

    //        public override void ExecuteResult(ControllerContext context)
    //        {
    //            var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
    //            if (UserId != null)
    //            {
    //                properties.Dictionary[XsrfKey] = UserId;
    //            }
    //            context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
    //        }
    //    }
    //    #endregion
    //}

    public class AccountController : Controller
    {
        myMetro_DBEntities db = new myMetro_DBEntities();

        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");

                var user = db.Users.SingleOrDefault(u => u.Email == login.Email && u.Password == hashPassword);

                if (user != null)
                {
                    if (user.IsActive==true)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);                       
                        return Redirect("/");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "حساب کاربری فعال نشده");
                    }

                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری با اطلاعات یافت شده پیدا نشد");
                }
            }
            return View(login);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (!db.Users.Any(u => u.Email == register.Email.Trim().ToLower()))
                {
                    Users user = new Users()
                    {
                        Email = register.Email.Trim().ToLower(),
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5"),
                        ActiveCode = Guid.NewGuid().ToString(),
                        IsActive = false,
                        RegisterDate = DateTime.Now,
                        RoleID = 1,
                        UserName = register.UserName
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    return View("SuccessRegister",user);
                }
                else
                {
                    ModelState.AddModelError("Email", "ایمیل وارد شده تکراری است");
                }
            }
            return View(register);
        }        
    }
}