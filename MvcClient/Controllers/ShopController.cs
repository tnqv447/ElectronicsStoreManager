using AppCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MvcClient.Controllers
{

    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IUnitOfWork _unitofwork;

        public ShopController(ILogger<ShopController> logger, IUnitOfWork unitofwork)
        {
            _logger = logger;
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}