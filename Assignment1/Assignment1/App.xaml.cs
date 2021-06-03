using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Assignment1.Models;

namespace Assignment1 {
    public partial class App : Application {
        public App()
        {
            InitializeComponent();
            OrderManager orderManager = new OrderManager();
            MainPage = new NavigationPage(new MainPage(orderManager));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
