using System.Collections.Generic;
using AppCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient.Helpers;
using MvcClient.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using AppCore.Models;
using System;

namespace MvcClient.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly IUnitOfWork _unitofwork;
        private CartViewModel view;
        private IList<CartItem> cart;
        private int TotalItem;

        public CartController(ILogger<CartController> logger, IUnitOfWork unitofwork)
        {
            _logger = logger;
            _unitofwork = unitofwork;
            view = new CartViewModel();
            TotalItem = 0;
        }
        public IActionResult Index()
        {

            if (SessionHelper.GetObjectFromJson<IList<CartItem>>(HttpContext.Session, "cart") == null)
            {
                return View(view);
            }
            else
            {
                view.Cart = SessionHelper.GetObjectFromJson<IList<CartItem>>(HttpContext.Session, "cart");
                return View(view);
            }

        }
        [HttpPost]
        public IActionResult AddToCart(Product item, int Quantity = 1)
        {
            if (SessionHelper.GetObjectFromJson<IList<CartItem>>(HttpContext.Session, "cart") == null)
            {
                cart = new List<CartItem>();
                var cartItem = new CartItem(item, Quantity);

                cart.Add(cartItem);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);


            }
            else
            {
                cart = SessionHelper.GetObjectFromJson<IList<CartItem>>(HttpContext.Session, "cart");
                var itemFound = cart.Where(m => m.Item.Id.Equals(item.Id)).FirstOrDefault();
                if (itemFound == null)
                {
                    cart.Add(new CartItem(item, Quantity));
                }
                else
                {
                    itemFound.Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }
            view.Cart = cart;
            foreach (var t in cart)
            {
                view.TotalPrice += t.Item.Price * t.Quantity;
                TotalItem += t.Quantity;
            }
            HttpContext.Session.SetString("TotalPrice", view.TotalPrice.ToString("N2"));
            HttpContext.Session.SetInt32("TotalItem", TotalItem);
            Dictionary<string, object> temp = new Dictionary<string, object>();
            temp.Add("TotalPrice", view.TotalPrice.ToString("N2"));
            temp.Add("TotalItem", TotalItem);
            return new JsonResult(temp);
        }

        [HttpPost]
        public IActionResult UpdateCart(string Action, int ItemId)
        {
            cart = SessionHelper.GetObjectFromJson<IList<CartItem>>(HttpContext.Session, "cart");
            var item = cart.FirstOrDefault(m => m.Item.Id.Equals(ItemId));
            var TotalPrice = HttpContext.Session.GetString("TotalPrice");
            decimal d = decimal.Parse(TotalPrice);
            switch (Action)
            {
                case "minus":
                    if (item.Quantity > 1)
                    {
                        item.Quantity -= 1;
                        item.TotalPrice -= item.Item.Price;
                        d = d - item.TotalPrice;
                    }

                    break;
                case "plus_":
                    item.Quantity += 1;
                    item.TotalPrice += item.Item.Price;
                    d = d + item.TotalPrice;
                    break;
                case "remov":
                    d = d - item.TotalPrice;
                    item.TotalPrice -= item.Item.Price;
                    cart.Remove(item);

                    break;
            }
            if (cart.Count.Equals(0))
            {
                HttpContext.Session.Remove("cart");
            }
            else
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                HttpContext.Session.SetString("TotalPrice", d.ToString("N2"));

                view.Cart = cart;
            }

            return PartialView("_Cart", view);
        }
        [HttpGet]
        public IActionResult GetInfor()
        {
            var cusID = HttpContext.Session.GetInt32("id").GetValueOrDefault();
            var cus = _unitofwork.CustomerRepos.GetBy(cusID);
            cart = SessionHelper.GetObjectFromJson<IList<CartItem>>(HttpContext.Session, "cart");
            view.Cus = cus;
            view.Cart = cart;
            view.GetInfo = true;
            return PartialView("_Cart", view);
        }
        [HttpPost]
        public IActionResult CheckOut(int CusPhone, string CusName, string CusAddress)
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var CusId = HttpContext.Session.GetInt32("id").GetValueOrDefault();
                var order = _unitofwork.OrderRepos.Add(new Order(CusId, DateTime.Now));
                cart = SessionHelper.GetObjectFromJson<IList<CartItem>>(HttpContext.Session, "cart");
                foreach (var item in cart)
                {
                    Console.WriteLine(item.Item.Id);
                    var temp = new OrderDetail(order.Id, item.Item.Id, item.Quantity, item.Item.Name, item.Item.Price);
                    _unitofwork.OrderRepos.OrderDetailRepos.Add(temp);
                }
            }
            return View();
        }
    }
}