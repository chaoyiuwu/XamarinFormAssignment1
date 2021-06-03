using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Assignment1.Models {

    public class OrderItem {
        public int ID { get; set; }
        public int Quantity { get; }
        public Pizza Pizza { get; }

        public OrderItem(int quantity, Pizza pizza) {
            Quantity = quantity;
            Pizza = pizza;
        }
    }

    public class Order {
        public string PlacedTime { get; private set; }
        public ObservableCollection<OrderItem> Pizzas { get; set; }

        public double TotalPrice { get; private set; }

        public Order() {
            Pizzas = new ObservableCollection<OrderItem>();
        }

        public void AddPizzas(int quantity, Pizza pizza) {
            var item = new OrderItem(quantity, pizza) {
                ID = Pizzas.Count == 0 ? 1 : Pizzas.Last().ID + 1
            };
            Pizzas.Add(item);
            UpdateTotal();
        }

        public double UpdateTotal() {
            TotalPrice = Pizzas.Sum(i => i.Quantity * i.Pizza.Price);
            return TotalPrice;
        }
        public void UpdateTime() {
            PlacedTime = DateTime.Now.ToString("yyyy/MM/dd : hh:mm");
        }
    }

}
