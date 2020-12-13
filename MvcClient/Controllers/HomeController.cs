using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient.Models;
using AppCore.Interfaces;
using AppCore.Models;
using Microsoft.AspNetCore.Http;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitofwork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitofwork)
        {
            _logger = logger;
            _unitofwork = unitofwork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            string user = model.Username;
            string pass = model.Password;
            Dictionary<string, string> temp = new Dictionary<string, string>();
            if (this._unitofwork.CustomerRepos.IsUserNameExists(user))
            {
                Customer account = this._unitofwork.CustomerRepos.GetByAccount(user, pass);
                if (account == null)
                {
                    model.Message = "Either Username or Password is incorrect.";
                    temp.Add("Message", model.Message);
                    return new JsonResult(temp);
                }
                else
                {
                    if (account.Status == CUSTOMER_STATUS.ACTIVE)
                    {
                        HttpContext.Session.SetInt32("id", account.Id);
                        HttpContext.Session.SetString("name", account.Name);
                        return PartialView("_Account");
                    }
                    else
                    {
                        model.Message = "This username is blocked.";
                        temp.Add("Message", model.Message);
                        return new JsonResult(temp);
                    }
                }
            }
            else
            {
                model.Message = "Username doesn't exist.";
                temp.Add("Message", model.Message);
                return new JsonResult(temp);
            }


        }
        public IActionResult Register()
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
