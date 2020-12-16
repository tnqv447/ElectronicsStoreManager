using System.Collections.Generic;
using AppCore.Interfaces;
using AppCore.Models;
using AppCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient.Models;
using System.Linq;
namespace MvcClient.Controllers
{

    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IUnitOfWork _unitofwork;
        private readonly ISearchSortService _service;
        private IList<Item> items;
        private IList<Item> combos;
        private HomeViewModel view;
        private PaginatedList<Item> item_paging;
        private PaginatedList<Item> combo_paging;

        public ShopController(ILogger<ShopController> logger, IUnitOfWork unitofwork, ISearchSortService service)
        {
            _logger = logger;
            _unitofwork = unitofwork;
            _service = service;
            items = _unitofwork.ItemRepos.GetAllNotCombo();
            combos = _unitofwork.ItemRepos.GetAllCombo();
        }
        public IActionResult Index(IList<EnumCheckBox> CheckBoxValues, int pageNumber = 1, string searchString = null)
        {
            ViewData["Title"] = "All";
            view = GetViewModel(CheckBoxValues, pageNumber, searchString);

            return View(view);
        }
        [Route("Shop/Detail/{itemId:int}")]
        public IActionResult Detail(int itemId)
        {
            Item item = _unitofwork.ItemRepos.GetBy(itemId);
            view = new HomeViewModel();
            view.item = item;
            return View(view);
        }

        public HomeViewModel GetViewModel(IList<EnumCheckBox> CheckBoxValues, int pageNumber = 1, string searchString = null)
        {
            var pageSize = 100;
            var itemSearch = items;
            var comboSearch = combos;
            var listTypes = CheckBoxValues.Where(m => m.IsSelected.Equals(true)).Select(m => m.types).ToList();
            if (listTypes != null && listTypes.Count() > 0)
            {
                itemSearch = _service.Search(items, null, listTypes);
                comboSearch = _service.Search(combos, null, listTypes);
                ViewData["Title"] = "";
                foreach (var type in listTypes)
                {
                    if (!type.Equals(ITEM_TYPE.COMBO))
                    {
                        if (listTypes.IndexOf(type).Equals(listTypes.Count() - 1))
                        {
                            ViewData["Title"] += EnumConverter.Convert(type);
                        }
                        else
                        {
                            ViewData["Title"] += EnumConverter.Convert(type) + "/ ";
                        }
                    }
                }
            }
            if (searchString != null)
            {
                itemSearch = _service.Search(itemSearch, searchString);
                comboSearch = _service.Search(comboSearch, searchString);

            }
            item_paging = PaginatedList<Item>.Create(itemSearch, pageNumber, pageSize);
            combo_paging = PaginatedList<Item>.Create(comboSearch, pageNumber, pageSize);
            var result = new HomeViewModel();
            result.items = item_paging;
            result.combos = combo_paging;
            result.CheckBoxValues = CheckBoxValues;
            return result;
        }
    }
}