using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MVC_OT.Controllers;

public class CreateOTController : BaseController
{
    private readonly INotyfService _notyf;
    public CreateOTController(INotyfService notyf)
    {
        _notyf = notyf;
    }
    public IActionResult Index()
    {
        return View();
    }
}