using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1 {


    public class Pizza {
        public static readonly string[] AvailableToppings = { "Vegetables", "Meat balls", "Pepperoni", "Mushrooms" };
        public static readonly string[] AvailableSize = { "Large", "Medium", "Small", "Party" };


        public List<string> Toppings;
        public string Size;

       public Pizza() {
            Toppings = new List<string>();
            Size = "";
        }

        public bool AddTopping(string topping) {
            try {
                Toppings.Add(topping);
                return true;
            }
            catch {
                return false;
            }
        }

        public bool RemoveTopping(string topping) {
            try {
                Toppings.Remove(topping);
                return true;
            }
            catch {
                return false;
            }
        }

        public bool SetSize(string size) {
            try {
                Size = size;
                return true;
            }catch {
                return false;
            }
        }
    }
}
