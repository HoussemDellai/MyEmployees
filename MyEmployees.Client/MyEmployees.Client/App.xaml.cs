using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEmployees.Client.Views;
using Xamarin.Forms;

namespace MyEmployees.Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TabbedPage
            {
                Children =
                {
                    new AllPage(),
                    new AddPage()
                }
            };
            //MainPage = new AddPage();
            //MainPage = new AllPage();
            //MainPage = new MyEmployees.Client.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
