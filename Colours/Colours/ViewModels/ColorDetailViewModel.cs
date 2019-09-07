using System;
using System.Windows.Input;
using Colours.Models;
using Xamarin.Forms;
using Color = Colours.Models.Color;

namespace Colours.ViewModels
{
    public class ColorDetailViewModel : BaseViewModel
    {
        public Color Color { get; set; }
        private ColorsViewModel _colorsViewModel;
        public ColorDetailViewModel(Color color = null, ColorsViewModel colorsViewModel = null)
        {
            Title = color?.ColorName;
            Color = color;

            _colorsViewModel = colorsViewModel;
        }

        public void RemoveColor()
        {
            DataStore.DeleteItemAsync(Color.Id);
            _colorsViewModel?.LoadItemsCommand.Execute(null);
        }
    }
}
