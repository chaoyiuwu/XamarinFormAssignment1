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
    public partial class CurrentOrderPage : ContentPage {

        private ObservableCollection<OrderItem> currentPizzas;
        public ObservableCollection<OrderItem> CurrentPizzas {
            get { return currentPizzas ?? new ObservableCollection<OrderItem>(); }
            set {
                if (currentPizzas != value) {
                    currentPizzas = value;           
                    OnPropertyChanged(nameof(CurrentPizzas));
                    UpdateTotal();
                }
            }
        }

        private double totalPrice;
        public double TotalPrice {
            get { return totalPrice; }
            set {
                if (totalPrice != value) {
                    totalPrice = value;
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        OrderManager om;

        public CurrentOrderPage(OrderManager om) {
            InitializeComponent();
            BindingContext = this;

            this.om = om;
            CurrentPizzas = om.CurrentOrder.Pizzas;
        }

        private async void PlaceOrderButton_Clicked(object sender, EventArgs e) {
            if (CurrentPizzas.Count == 0) {
                await DisplayAlert("Error", "No pizzas in cart", "OK");
                return;
            }
            om.PlaceCurrentOrder();

            await Navigation.PushAsync(new MainPage(om));
        }

        private void DeleteItemButton_Clicked(object sender, EventArgs e) {
            var item = (Xamarin.Forms.Button)sender;
            OrderItem listItem = (from itm in CurrentPizzas
                                  where itm.ID.ToString() == item.CommandParameter.ToString()
                                  select itm)
                   .FirstOrDefault();
            CurrentPizzas.Remove(listItem);
            UpdateTotal();
        }

        private void UpdateTotal() {
            TotalPrice = om.CurrentOrder.UpdateTotal();
        }
    }
}