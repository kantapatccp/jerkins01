using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MVC_OT.Helper;
using MVC_OT.Models;

namespace MVC_OT.Controllers;

public class ReportController : BaseController
{
    private readonly INotyfService _notyf;
    public ReportController(INotyfService notyf) 
    {
      _notyf = notyf;
    }
    //[MultiplePolicysAuthorize("SystemAll;Admin")]
   public IActionResult Index()
   {
        return View();  
   }
   [HttpGet]
   public IActionResult GetData()
   {
      
         return View();
   }

   public IActionResult PrintDoc()
   {
    return View();
   }
   public IActionResult Print()
   {
    return View();
   }
}
