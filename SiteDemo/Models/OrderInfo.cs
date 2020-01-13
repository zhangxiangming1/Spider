using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteDemo
{
    public class OrderInfo
    {
        public string OrderID { get; set; }

        public string GoodsName { get; set; }

        public int Price { get; set; }

        public int GoodsCount { get; set; }

        public static List<OrderInfo> GetAll()
        {
            List<OrderInfo> list = new List<OrderInfo>();
            list.Add(new OrderInfo() { OrderID="1",GoodsName="口红",Price=300,GoodsCount=2});
            list.Add(new OrderInfo() { OrderID = "2", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "3", GoodsName = "肥宅", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "4", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "5", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "6", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "7", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "8", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "9", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "10", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "11", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "12", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "13", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "14", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "16", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "17", GoodsName = "肥宅", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "18", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "19", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "20", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "21", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "22", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "23", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "24", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "25", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "26", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "27", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "28", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "29", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "30", GoodsName = "肥宅", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "31", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "32", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "33", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "34", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "35", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "36", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "37", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "11", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "12", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "13", GoodsName = "香水", Price = 300, GoodsCount = 2 });

            list.Add(new OrderInfo() { OrderID = "1", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "2", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "3", GoodsName = "肥宅", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "4", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "5", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "6", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "7", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "8", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "9", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "10", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "11", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "12", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "13", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "14", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "16", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "17", GoodsName = "肥宅", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "18", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "19", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "20", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "21", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "22", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "23", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "24", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "25", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "26", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "27", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "28", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "29", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "30", GoodsName = "肥宅", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "31", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "32", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "33", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "34", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "35", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "36", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "37", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "11", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "12", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "13", GoodsName = "香水", Price = 300, GoodsCount = 2 });

            list.Add(new OrderInfo() { OrderID = "1", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "2", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "3", GoodsName = "肥宅", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "4", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "5", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "6", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "7", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "8", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "9", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "10", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "11", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "12", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "13", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "14", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "16", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "17", GoodsName = "肥宅", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "18", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "19", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "20", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "21", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "22", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "23", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "24", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "25", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "26", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "27", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "28", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "29", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "30", GoodsName = "肥宅", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "31", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "32", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "33", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "34", GoodsName = "口红", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "35", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "36", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "37", GoodsName = "洗衣粉", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "11", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "12", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            list.Add(new OrderInfo() { OrderID = "13", GoodsName = "香水", Price = 300, GoodsCount = 2 });
            return list;
        }
    }
}