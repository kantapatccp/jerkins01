using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_OT.Helper;
using MVC_OT.Models;

namespace MVC_OT.Controllers;
[Authorize]
public class HomeController : BaseController
{
    private readonly INotyfService _notyf;
    public HomeController(INotyfService notyf)
    {
        _notyf = notyf;
    }

    public IActionResult Index()
    {
        if(User.Identity.IsAuthenticated)
        {
            _notyf.Success("ยินดีต้อนรับคุณ " + User.Identity.Name);
            
        }
       
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
