using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unit1Labs.Models;

namespace Unit1Labs.Controllers
{
    public class HomeController : Controller
    {
        private readonly string[] balloons = { "Green", "Orange", "Purple", "Blue" };
        private readonly List<Products> Products = new List<Products>()
        {
            new Products {Id = "100", Name = "Video Game", Price = 59.99},
            new Products {Id = "101", Name = "Computer", Price = 600.00},
            new Products {Id = "102", Name = "Keyboard", Price = 40.00}
        };

        public ActionResult DisplayProducts()
        {
            return View(Products);
        }

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        
        [HttpPost]
        public ActionResult Birthday(FormCollection form)
        {
            string[] balloons = { "Green", "Orange", "Purple", "Blue" };
            ViewBag.balloons = balloons;
            List<string> list = new List<string>();
            ViewBag.name = form["name"];
            ViewBag.birthday = form["birthday"];
            foreach (var balloon in balloons)
            {
                var val = form[balloon].Split(',')[0];
                
                list.Add(balloon);

            }
            return View("Results");
        }
        [HttpPost]
        public ActionResult ProcessOrder(FormCollection form)
        {
            List<Order> orders = new List<Order>();
            foreach (Products p in Products)
            {
                int qty = Convert.ToInt32(form[p.Id]);
                if(qty > 0)
                {
                    orders.Add(new Order { Prod = p, Qty = qty });
                }
                
            }
            ViewBag.Orders = orders;
            return View();
        }

    }
}