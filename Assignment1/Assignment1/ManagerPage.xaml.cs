using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1 {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagerPage : ContentPage {

        OrderManager om;
        public ManagerPage(OrderManager om) {
            InitializeComponent();
            this.om = om;
        }

        private async void UpdateCurrentButton_Clicked(object sender, EventArgs e) {
            //await Navigation.PushAsync(new MainPage(om));
            await Navigation.PopAsync();
        }

        private async void NewOrderButton_Clicked(object sender, EventArgs e) {
            om.StartNewOrder();
            //await Navigation.PushAsync(new MainPage(om));
            await Navigation.PopAsync();
        }

        private async void PrevButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new PreviousOrdersPage(om));
        }

        private async void CheckCurrentButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new CurrentOrderPage(om));
        }
    }
}