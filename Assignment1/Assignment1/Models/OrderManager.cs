using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Assignment1.Models {
    public class OrderManager {

        public ObservableCollection<Order> PlacedOrders { get; private set; }
        Order currentOrder;
        public Order CurrentOrder {
            get {
                if (currentOrder == null) currentOrder = new Order();
                return currentOrder;
            }
            set {
                if (currentOrder != value) {
                    currentOrder = value;
                }
            }
        }

        public void PlaceCurrentOrder() {
            if (PlacedOrders == null) {
                PlacedOrders = new ObservableCollection<Order>();
            }
            CurrentOrder.UpdateTotal();
            CurrentOrder.UpdateTime();
            PlacedOrders.Add(CurrentOrder);
            StartNewOrder();
        }

        public void StartNewOrder() {
            CurrentOrder = null;
        }

    }
}
