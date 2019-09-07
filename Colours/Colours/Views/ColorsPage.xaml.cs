using System;

using Xamarin.Forms;
using Colours.ViewModels;

namespace Colours.Views
{
    public partial class ColorsPage : ContentPage
    {
        ColorsViewModel viewModel;

        public ColorsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ColorsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Models.Color;
            if (item == null)
                return;

            await Navigation.PushAsync(new ColorDetailPage(new ColorDetailViewModel(item, viewModel)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddColor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewColorPage()));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<NewColorPage, Models.Color>(this, "AddItem");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Colors.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);

            MessagingCenter.Subscribe<NewColorPage, Models.Color>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Models.Color;
                viewModel.Colors.Add(newItem);
                await viewModel.DataStore.AddItemAsync(newItem);
            });
        }

    }
}