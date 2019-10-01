using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sheet5.Models
{
    public enum SubType
    {
        TheGretaVanFleet,
        TheClash,
        TheNazerath,
        TheMarillion
    }

    public enum SubSize
    {
        Song,
        Album,
        Concert,
        Worldtour
    }

    public class Order
    {
        public SubType Type { get; set; }
        public SubSize Size { get; set; }
        public string MealDeal { get; set; }
        public double SubPrice { get; set; }
        public double MealPrice { get; set; }
        public double TotalCost { get; set; }
        public double Tax { get; set; }
        public double TotalDue { get; set; }
        public int Amount { get; set; }

        public void calCost(double typePrice, double sizePrice, double mealPrice)
        {
            if (Amount == 0)
            {
                Amount = 1;
                double price = (typePrice + sizePrice);
                SubPrice = price;
                MealPrice = mealPrice;
                double total = (price + mealPrice);
                TotalCost = total;
                double tax = total * .15;
                Tax = tax;
                TotalDue = (tax + total);
            }
            else
            {
                double price = (typePrice + sizePrice);
                SubPrice = price;
                MealPrice = mealPrice;
                double total = (price + mealPrice);
                TotalCost = total* Amount;
                double tax = total * .15;
                Tax = tax* Amount;
                TotalDue = (tax + total)* Amount;
            }
        }

    }
}