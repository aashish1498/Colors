using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Colours.Models;
using Colours.ViewModels;

namespace Colours.Views
{
    public partial class ColorDetailPage : ContentPage
    {
        ColorDetailViewModel viewModel;

        public ColorDetailPage(ColorDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ColorDetailPage()
        {
            InitializeComponent();

            var color = new Models.Color
            {
                ColorName = "Color Name",
                ColorCodeString = "#008080"
            };

            viewModel = new ColorDetailViewModel(color);
            BindingContext = viewModel;
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            viewModel.RemoveColor();
            Navigation.PopAsync();
        }
    }
}