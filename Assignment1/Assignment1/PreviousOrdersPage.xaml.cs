using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1 {
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class PreviousOrdersPage : ContentPage {

        private ObservableCollection<Order> placedOrders;
        public ObservableCollection<Order> PlacedOrders {
            get { return placedOrders ?? new ObservableCollection<Order>(); }
            set {
                if (placedOrders != value) {
                    placedOrders = value;
                    OnPropertyChanged(nameof(PlacedOrders));
                }
            }
        }

        public PreviousOrdersPage(OrderManager om) {
            InitializeComponent();
            BindingContext = this;
            PlacedOrders = om.PlacedOrders;
        }
    }
}