using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomPassword.Models;

namespace RandomPassword.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("")]
      public IActionResult Index()
      {
          string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
          string passCode = "";
          var random = new Random();

          for (int i = 0; i < 14; i++)
          {
              passCode += chars[random.Next(chars.Length)];
          }
          
          ViewBag.PassCode = passCode;

          if (HttpContext.Session.GetInt32("Count") == null)
          {
            HttpContext.Session.SetInt32("Count", 0);
          }
          int? count = HttpContext.Session.GetInt32("Count");
          count++;
          ViewBag.Count = count;
          HttpContext.Session.SetInt32("Count", (int) count);
          
          return View();
      }
    }
}
