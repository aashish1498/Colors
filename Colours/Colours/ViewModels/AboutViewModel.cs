using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Colours.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Color AverageColour { get; set; }

        public string RGBString { get; set; }

        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.reddit.com/r/aww/")));

            CalculateAverage();
        }

        public async void CalculateAverage()
        {
            var colors = await DataStore.GetItemsAsync(true);
            double totalR = 0;
            double totalG = 0;
            double totalB = 0;
            int count = 0;
            foreach (var color in colors)
            {
                count++;
                totalR += color.ColorCode.R;
                totalG += color.ColorCode.G;
                totalB += color.ColorCode.B;
            }
            if (count == 0)
            {
                AverageColour = Color.Teal;
                return;
            }

            double averageR = totalR / count;
            double averageG = totalG / count;
            double averageB = totalB / count;
            RGBString = $"Red: {Math.Round(averageR * 255)}     Green: {Math.Round(averageG * 255)}     Blue: {Math.Round(averageB * 255)}";
            AverageColour = Xamarin.Forms.Color.FromRgb(averageR, averageG, averageB);
        }

        public ICommand OpenWebCommand { get; }
    }
}