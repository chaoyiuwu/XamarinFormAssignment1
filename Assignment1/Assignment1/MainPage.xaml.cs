using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment1 {
    public partial class MainPage : ContentPage {

        int quantity;
        public int Quantity {
            set {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
            get {
                return quantity;
            }
        }
        string selectedTopping;
        public string SelectedTopping {
            set {
                if(selectedTopping != value) {
                    selectedTopping = value;
                    OnPropertyChanged(nameof(SelectedTopping));
                } 
            }
            get {
                return selectedTopping;
            }
        }
        string selectedSize;
        public string SelectedSize {
            set {
                if (selectedSize != value) {
                    selectedSize = value;
                    OnPropertyChanged(nameof(SelectedSize));
                }
                
            }
            get {
                return selectedSize;
            }
        }

        OrderManager om;
        public MainPage(OrderManager om)
        {
            InitializeComponent();
            BindingContext = this;
            ToppingListView.ItemsSource = Pizza.AvailableToppings;
            SizeListView.ItemsSource = Pizza.AvailableSize;

            this.om = om;
            Quantity = 0;
            SelectedTopping = "";
            SelectedSize = "";
        }


        #region listview click
        private void Toppings_OnTap(object sender, ItemTappedEventArgs e) {
            SelectedTopping = e.Item.ToString();
        }
        private void Size_OnTap(object sender, ItemTappedEventArgs e) {
            SelectedSize = e.Item.ToString();
        }
        #endregion

        #region button click
        private void Button1_Clicked(object sender, EventArgs e) {
            Quantity = 1;
        }
        private void Button2_Clicked(object sender, EventArgs e) {
            Quantity = 2;
        }

        private void Button3_Clicked(object sender, EventArgs e) {
            Quantity = 3;
        }

        private void Button4_Clicked(object sender, EventArgs e) {
            Quantity = 4;
        }

        private void Button5_Clicked(object sender, EventArgs e) {
            Quantity = 5;
        }

        private void Button6_Clicked(object sender, EventArgs e) {
            Quantity = 6;
        }

        private void Reset_Clicked(object sender, EventArgs e) {
            Quantity = 0;
            SelectedTopping = "";
            SelectedSize = "";
            ToppingListView.SelectedItem = null;
            SizeListView.SelectedItem = null;
        }

        private void Add_Clicked(object sender, EventArgs e) {
            string selectionIncomplete = "Selection Incomplete";
            if (Quantity == 0) {
                DisplayAlert(selectionIncomplete, "Quantity is still 0", "OK");
                return;
            }
            if (SelectedTopping == "") {
                DisplayAlert(selectionIncomplete, "No topping selected", "OK");
                return;
            }
            if(SelectedSize == "") {
                DisplayAlert(selectionIncomplete, "No size selected", "OK");
                return;
            }
            om.CurrentOrder.AddPizzas(Quantity, new Pizza(SelectedTopping, SelectedSize));

            DisplayAlert("Success", string.Format("{0} {1}-size pizza with {2} has been added to your order.\n" +
                "Your order now has {3} pizza(s).", Quantity, SelectedSize, SelectedTopping, om.CurrentOrder.Pizzas.Sum(p => p.Quantity)), "OK");
        }

        private async void Manager_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new ManagerPage(om));
        }
        #endregion
    }
}
