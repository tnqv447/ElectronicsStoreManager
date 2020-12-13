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
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
    }
}