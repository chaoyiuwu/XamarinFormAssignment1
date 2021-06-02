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
                OnPropertyChanged("Quantity");
            }
            get {
                return quantity;
            }
        }

        public List<Order> Orders;
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            Quantity = 0;
            Orders = new List<Order>();
        }

        private void Button1_Clicked(object sender, EventArgs e) {
            Quantity = 1;
        }

        #region button click
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
        #endregion
    }
}
