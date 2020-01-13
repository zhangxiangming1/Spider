using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteDemo
{
    public class ProductInfo
    {
        public string Id { get; set; }

        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public string Color { get; set; }

        public static List<ProductInfo> GetAll()
        {
            List<ProductInfo> list = new List<ProductInfo>();
            list.Add(new ProductInfo() { Id = "1", ProductName = "阿玛尼", ProductType = "化妆品", Color = "红色" });
            list.Add(new ProductInfo() { Id = "2", ProductName = "香奈儿", ProductType = "化妆品", Color = "白色" });
            list.Add(new ProductInfo() { Id = "3", ProductName = "圣罗兰", ProductType = "化妆品", Color = "紫色" });
            list.Add(new ProductInfo() { Id = "4", ProductName = "沃尔沃", ProductType = "车", Color = "黑色" });
            list.Add(new ProductInfo() { Id = "5", ProductName = "奥迪", ProductType = "车", Color = "黑色" });
            list.Add(new ProductInfo() { Id = "6", ProductName = "大众", ProductType = "车", Color = "白色" });
            return list;
        }
    }
}