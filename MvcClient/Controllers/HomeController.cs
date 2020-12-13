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
using AppCore.Services;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitofwork;
        private readonly ISearchSortService _service;
        private IList<Item> items;
        private IList<Item> combos;
        private HomeViewModel view;
        private PaginatedList<Item> item_paging;
        private PaginatedList<Item> combo_paging;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitofwork, ISearchSortService service)
        {
            _logger = logger;
            _unitofwork = unitofwork;
            _service = service;
            items = _unitofwork.ItemRepos.GetAllNotCombo();
            combos = _unitofwork.ItemRepos.GetAllCombo();

        }

        public IActionResult Index(int pageNumber = 1, string searchString = null)
        {
            view = GetViewModel();

            return View(view);
        }
        public HomeViewModel GetViewModel(int pageNumber = 1, string searchString = null)
        {
            var pageSize = 3;

            if (searchString == null || searchString == "")
            {
                item_paging = PaginatedList<Item>.Create(items, pageNumber, pageSize);
                combo_paging = PaginatedList<Item>.Create(combos, pageNumber, pageSize);
            }
            else
            {
                // var item_search = _service.
            }
            var result = new HomeViewModel();
            result.items = item_paging;
            result.combos = combo_paging;
            return result;
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
            Console.WriteLine(user + " mk " + pass);
            Dictionary<string, string> temp = new Dictionary<string, string>();
            if (this._unitofwork.CustomerRepos.IsUserNameExists(user))
            {
                Customer account = this._unitofwork.CustomerRepos.GetByAccount(user, pass);
                if (account == null)
                {
                    model.Message = "Tài khoản hoặc mật khẩu bị sai.";
                    temp.Add("Message", model.Message);
                    return new JsonResult(temp);
                }
                else
                {
                    if (account.Status == CUSTOMER_STATUS.ACTIVE)
                    {
                        model.Message = "Đăng nhập thành công.";
                        HttpContext.Session.SetInt32("id", account.Id);
                        HttpContext.Session.SetString("name", account.Name);
                        return PartialView("_Account");
                        // session
                    }
                    else
                    {
                        model.Message = "Tài khoản này đã bị khóa.";
                        temp.Add("Message", model.Message);
                        return new JsonResult(temp);
                    }
                }
            }
            else
            {
                model.Message = "Tài khoản này không tồn tại.";
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
