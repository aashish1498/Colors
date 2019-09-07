using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Colours.Services;
using Colours.Views;
using Colours.ViewModels;

namespace Colours
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //MessagingCenter.Subscribe<NewColorPage, Models.Color>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Models.Color;
            //    var vm = new ColorsViewModel();
            //    await vm.DataStore.AddItemAsync(newItem);
            //});
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
