
using System.Diagnostics;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVC_OT.Models;
using MVC_OT.Services;

namespace MVC_OT.Controllers;

public class AccountController : Controller
{
    private readonly INotyfService _notyf;
    public AccountController(INotyfService notyf)
    {
        _notyf = notyf;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ErrorForbidden()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel data)
    {
        if(ModelState.IsValid)
        {
             bool IsAuth = false;
            ClaimsIdentity claim = null;
            var result = await NetworkService.StdLogin(data.UserName, data.Password);
            if (result != null)
            {
                if (result.autoID != 0)
                {
                    // var us = await (from u in _db.Authorizes
                    //                 where (u.AuthorizeStatus == "Active")
                    //                 && (u.AuthorizeId == result.autoID)
                    //                 select u).FirstOrDefaultAsync();
                    // if (us == null)
                    // {
                    //     _notyfService.Warning(result.name + " คุณยังไม่มีสิทธิ์เข้าถึงการใช้งาน<br /> หากไม่ทราบกรุณาติดต่อ Administrator ระบบ");
                    //     return View(data);
                    // }
                    // else
                    // {
                    //     claim = new ClaimsIdentity(new[] {
                    // new Claim(ClaimTypes.Name, result.name + " " + result.surname),
                    // new Claim(ClaimTypes.Role, "Admin"),
                    // }, CookieAuthenticationDefaults.AuthenticationScheme);
                    //     IsAuth = true;
                    // }

                    claim = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, result.name + " " + result.surname),
                        new Claim(ClaimTypes.Role, "Admin"),
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    IsAuth = true;
                }
            }
            else
            {
                _notyf.Error("ระบบ API Login ผิดพลาดกรุณาตรวจติดต่อ IT Support");
            }
             if (IsAuth)
            {
                var principal = new ClaimsPrincipal(claim);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _notyf.Error("ไม่สามารถเข้าใช้งานได้ กรุณาตรวจสอบ User,Password ว่าถูกต้องหรือไม่");
            }
        }
        _notyf.Error("ไม่ได้กรอก");
        return View(data);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(Index));
    }
}