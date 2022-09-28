using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TatakPinoy.Data;
using TatakPinoy.Models;
using TatakPinoy.Services;

namespace TatakPinoy.Controllers
{
    public class AccountController : Controller
    {
        public List<UserModel> users = null;
        private readonly IUserService _userService;
        private readonly TatakPinoyContext _context;
        public AccountController()
        {
            users = new List<UserModel>();
            users.Add(new UserModel()
            {
                UserId = 1,
                Username = "Ivonne",
                Password = "123",
                Role = "Admin"
            });

        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            ViewBag.layout = "_Layout";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserModel fmisUser)
        {
            fmisUser.Password = _userService.HashPassword(fmisUser, fmisUser.Password);
            _context.Add(fmisUser);
            _context.SaveChanges();
            ViewBag.layout = "_Layout";
            return View("~/Views/Account/CreateUser.cshtml");
        }

        public IActionResult Login(string ReturnUrl = "/")
        {
            LoginModel objLoginModel = new LoginModel();
            objLoginModel.ReturnUrl = ReturnUrl;
            return View(objLoginModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                var user = users.Where(x => x.Username == objLoginModel.UserName && x.Password == objLoginModel.Password).FirstOrDefault();
                if (user == null)
                {
                    //Add logic here to display some message to user    
                    ViewBag.Message = "Invalid Credential";
                    return View(objLoginModel);
                }
                else
                {
                    //A claim is a statement about a subject by an issuer and    
                    //represent attributes of the subject that are useful in the context of authentication and authorization operations.    
                    var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId)),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim("FavoriteDrink", "Tea")
                };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = objLoginModel.RememberLogin
                    });
                    return View("~/Views/Shipments/Create.cshtml");
                }
            }
            return View(objLoginModel);
        }
        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return LocalRedirect("/");
        }
    }
}
