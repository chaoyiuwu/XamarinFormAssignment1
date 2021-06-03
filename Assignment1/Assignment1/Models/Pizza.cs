using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1 {

    public class Pizza {
        public static readonly string[] AvailableToppings = { "Vegetables", "Meat balls", "Pepperoni", "Mushrooms" };
        public static readonly string[] AvailableSize = { "Large", "Medium", "Small", "Party" };


        public string Topping { get; }
        public string Size { get; }

        public double Price { get; }

       public Pizza(string topping, string size) {
            Topping = topping;
            Size = size;
            Price = 10;
            switch (Topping) {
                case "Vegetables":
                case "Mushrooms":
                    Price += 1.5;
                    break;
                default: //** meat
                    Price += 3;
                    break;
            }
            switch (Size) {
                case "Medium":
                    Price += 1;
                    break;
                case "Large":
                    Price += 2;
                    break;
                case "Party":
                    Price += 3;
                    break;
                default:
                    break;
            }
        }
    }
}
