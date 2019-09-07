using System;
using System.Drawing;

namespace Colours.Models
{
    public class Color
    {
        public string Id { get; set; }
        public string ColorName { get; set; }
        public string ColorCodeString { get; set; }
        public Xamarin.Forms.Color ColorCode => Xamarin.Forms.Color.FromHex(ColorCodeString);
    }
}