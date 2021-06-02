using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1.Models {
    public class Order {
        public int ID;
        public List<Pizza> Pizzas;

        public Order(int id) {
            this.ID = id;
            Pizzas = new List<Pizza>();
        }

        public void AddPizza(Pizza p) {
            Pizzas.Add(p);
        }
    }


}
