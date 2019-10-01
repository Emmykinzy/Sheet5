using Sheet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Sheet5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            Order o1 = new Order();

            string type = Request.Form["SubType"];
            string size = Request.Form["SubSize"];
            string meal = Request.Form["MealDeal"];
            int amount = 0;
            if (Request.Form["Amount"] == null || Request.Form["Amount"] == "")
            {
                amount = 1;
            }
            else
            {
                amount = Int32.Parse(Request.Form["Amount"]);
            }
            

            if (type == null || size == null || meal == null)
            {
                ViewBag.message = "Please finish your order";
                return View();
            }
            else
            {

                SubType t = (SubType)Enum.Parse(typeof(SubType), type);
                SubSize s = (SubSize)Enum.Parse(typeof(SubSize), size);

                double[] sizePrice = new double[4] { 2.5, 5.5, 8.5, 10.75 };
                double[] typePrice = new double[4] { 5.99, 6.99, 7.99, 8.99 };
                double[] mealPrice = new double[3] { 0, 1.75, 2.25 };
                double sizeP;
                double typeP;
                double mealP;
                switch (t)
                {
                    case SubType.TheGretaVanFleet:
                        typeP = typePrice[0];
                        break;
                    case SubType.TheClash:
                        typeP = typePrice[1];
                        break;
                    case SubType.TheNazerath:
                        typeP = typePrice[2];
                        break;
                    case SubType.TheMarillion:
                        typeP = typePrice[3];
                        break;
                    default:
                        typeP = 0;
                        break;
                }

                switch (s)
                {
                    case SubSize.Song:
                        sizeP = sizePrice[0];
                        break;
                    case SubSize.Album:
                        sizeP = sizePrice[1];
                        break;
                    case SubSize.Concert:
                        sizeP = sizePrice[2];
                        break;
                    case SubSize.Worldtour:
                        sizeP = sizePrice[3];
                        break;
                    default:
                        sizeP = 0;
                        break;
                }

                switch (meal)
                {
                    case "None":
                        mealP = mealPrice[0];
                        break;
                    case "Drink and Chips":
                        mealP = mealPrice[1];
                        break;
                    case "Drink and Cookies":
                        mealP = mealPrice[2];
                        break;
                    default:
                        mealP = 0;
                        break;
                }


                o1.Type = t;
                o1.Size = s;
                o1.MealDeal = meal;
                o1.Amount = amount;
                o1.calCost(typeP, sizeP, mealP);

                TempData["Order"] = o1;

                if(Session["OrderList"] == null)
                {
                    List<Order> orderList = new List<Order>();
                    orderList.Add(o1);
                    Session["OrderList"] = orderList;
                }
                else
                {
                    List<Order> orderList = Session["OrderList"] as List<Order>;
                    orderList.Add(o1);
                    Session["OrderList"] = orderList;
                }

                return RedirectToAction("Receipt");
            }
        }
        public ActionResult Receipt()
        {
            return View();
        }

        public ActionResult Sales()
        {

            return View();
        }

    }
}