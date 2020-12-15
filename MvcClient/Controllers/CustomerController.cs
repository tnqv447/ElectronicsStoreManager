using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient.Models;
using Infrastructure;
using AppCore.Interfaces;
using Microsoft.AspNetCore.Http;
using AppCore.Models;

namespace MvcClient.Controllers
{

    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IUnitOfWork _unitofwork;

        public CustomerController(ILogger<CustomerController> logger, IUnitOfWork unitofwork)
        {
            _logger = logger;
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            var model = new CustomerModel();
            if (HttpContext.Session.GetInt32("id") == null)
            {
                model.Customer = new Customer();
                Forbid();
            }
            else
            {
                int uid = HttpContext.Session.GetInt32("id").GetValueOrDefault();
                model.Customer = this._unitofwork.CustomerRepos.GetBy(uid);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CustomerModel model)
        {
            Customer user = model.Customer;
            if (ModelState.IsValid)
            {
                this._unitofwork.CustomerRepos.Update(model.Customer);
                HttpContext.Session.SetString("name", model.Customer.Name);
                // ViewBag.Message = "Cập nhật thông tin nhân viên " + oldUser.Name + " thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Orders()
        {
            var model = new CustomerModel();
            if (HttpContext.Session.GetInt32("id") == null)
            {
                model.Customer = new Customer();
                Forbid();
            }
            else
            {
                int uid = HttpContext.Session.GetInt32("id").GetValueOrDefault();
                model.Customer = this._unitofwork.CustomerRepos.GetBy(uid);
            }
            return View(model);
        }
    }
}