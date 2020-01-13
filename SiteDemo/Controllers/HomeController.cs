using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace SiteDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult LoginResult(string userID,string password)
        {
            System.Web.Security.FormsAuthentication.SetAuthCookie(userID, true);
            return Redirect("/Home/Index");
        }

        public ActionResult Products(string productType,string color)
        {
            ViewBag.ProductType = productType;
            ViewBag.Color = color;
            List<ProductInfo> list = ProductInfo.GetAll();
            IEnumerable<ProductInfo> result = list.Where(
                m => 
                (string.IsNullOrEmpty(productType) || m.ProductType.IndexOf(productType) >= 0) 
                && (string.IsNullOrEmpty(color) || m.Color.IndexOf(color) >= 0));
            return View(result);
        }

        public ActionResult Orders(string goodsName,int pageIndex=1,int pageSize=5)
        {
            Response.SetCookie(new HttpCookie("aaa", "aaa"));
            List<OrderInfo> list = OrderInfo.GetAll();
            List<OrderInfo> result = list.Where(m => string.IsNullOrEmpty(goodsName) || m.GoodsName.IndexOf(goodsName) >= 0).ToList();
            ViewBag.GoodsName = goodsName;
            ViewBag.PageIndex = pageIndex;
            ViewBag.RecordCount = result.Count;
            List<OrderInfo> pageList = new List<OrderInfo>();
            for(int i= (pageIndex-1) * pageSize;i< pageIndex * pageSize&&i<result.Count; i++)
            {
                pageList.Add(result[i]);
            }
            return View(pageList);
        }
    }
}