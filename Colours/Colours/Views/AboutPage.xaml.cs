using Colours.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colours.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutViewModel viewModel;
        public AboutPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AboutViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //viewModel.CalculateAverage();
        }
    }
}