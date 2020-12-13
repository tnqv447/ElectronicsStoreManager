using System.Collections.Generic;
using AppCore.Interfaces;
using AppCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient.Models;

namespace MvcClient.Controllers
{

    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IUnitOfWork _unitofwork;
        private IList<Item> items;
        private IList<Item> combos;
        private HomeViewModel view;
        private PaginatedList<Item> item_paging;
        private PaginatedList<Item> combo_paging;

        public ShopController(ILogger<ShopController> logger, IUnitOfWork unitofwork)
        {
            _logger = logger;
            _unitofwork = unitofwork;
            items = _unitofwork.ItemRepos.GetAllNotCombo();
            combos = _unitofwork.ItemRepos.GetAllCombo();
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Shop/Detail/{itemId:int}")]
        public IActionResult Detail(int itemId)
        {
            Item item = _unitofwork.ItemRepos.GetBy(itemId);
            view = new HomeViewModel();
            view.item = item;
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
    }
}