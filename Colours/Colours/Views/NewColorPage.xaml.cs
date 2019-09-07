using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Colours.Models;
using Color = Colours.Models.Color;

namespace Colours.Views
{
    public partial class NewColorPage : ContentPage
    {
        public Color Color { get; set; }

        public NewColorPage()
        {
            InitializeComponent();

            Color = new Models.Color
            {
                ColorName = "Color name",
                ColorCodeString = "#008080"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Color.Id = Guid.NewGuid().ToString();
            MessagingCenter.Send(this, "AddItem", (Models.Color)Color);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}