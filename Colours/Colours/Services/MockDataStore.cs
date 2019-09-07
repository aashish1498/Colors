using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Colours.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Color = Colours.Models.Color;

namespace Colours.Services
{
    public class MockDataStore : IDataStore<Color>
    {
        List<Color> colors;

        public MockDataStore()
        {
            colors = new List<Color>();
            var mockColors = new List<Color>
            {
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Malachite", ColorCodeString="#0bda51" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Bittersweet", ColorCodeString="#fe6f5e" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Ball Blue", ColorCodeString="#21abcd" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Bubbles", ColorCodeString="#e7feff" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Bondi Blue", ColorCodeString="#0095b6" },

                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Bright Ube", ColorCodeString="#d19fe8" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Rich Maroon", ColorCodeString="#b03060" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Mountain Meadow", ColorCodeString="#30ba8f" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Bulgarian Rose", ColorCodeString="#480607" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Manatee", ColorCodeString="#979aaa" },

                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Ochre", ColorCodeString="#cc7722" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Blue (Pigment)", ColorCodeString="#333399" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Medium Aquamarine", ColorCodeString="#66ddaa" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Blue Violet", ColorCodeString="#8a2be2" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Medium Spring Bud", ColorCodeString="#c9dc87" },

                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Midnight Blue", ColorCodeString="#191970" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Battleship Grey", ColorCodeString="#979aaa" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Wild Strawberry", ColorCodeString="#ff43a4" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Rubine Red", ColorCodeString="#d10056" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Emerald", ColorCodeString="#50c878" },

                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Cornflower Blue", ColorCodeString="#6495ed" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Periwinkle", ColorCodeString="#c3cde6" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Sepia", ColorCodeString="#704214" },

                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Pine Green", ColorCodeString="#01796f" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Teal Blue <3", ColorCodeString="#367588" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Mulberry", ColorCodeString="#c54b8c" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Steel Blue", ColorCodeString="#4682b4" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Viridian", ColorCodeString="#40826d" },

                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Antique Fuchsia", ColorCodeString="#915c83" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Asparagus", ColorCodeString="#87a96b" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Aurometalsaurus", ColorCodeString="#6e7f80" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Charcoal", ColorCodeString="#36454f" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Apple Green", ColorCodeString="#8db600" },

                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Awesome", ColorCodeString="#ff2052" },
                new Color { Id = Guid.NewGuid().ToString(), ColorName = "Cerise", ColorCodeString="#ec3b83" },
                
            };

            foreach (var color in mockColors)
            {
                colors.Add(color);
            }
            LoadColorsFromProperties();
        }

        public async Task<bool> AddItemAsync(Color item)
        {
            colors.Add(item);
            SaveColor(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Color item)
        {
            var oldItem = colors.Where((Color arg) => arg.Id == item.Id).FirstOrDefault();
            colors.Remove(oldItem);
            colors.Add(item);
            
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = colors.Where((Color arg) => arg.Id == id).FirstOrDefault();
            colors.Remove(oldItem);
            RemoveColor(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<Color> GetItemAsync(string id)
        {
            return await Task.FromResult(colors.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Color>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(colors);
        }

        public void SaveColor(Color color)
        {
            var json = JsonConvert.SerializeObject(color);
            try
            {
                //Application.Current.Properties.Clear();
                Application.Current.Properties.Add(color.Id, json);
            }
            catch
            {
            }

            Application.Current.SavePropertiesAsync();
        }

        public void RemoveColor(Color color)
        {
            if (Application.Current.Properties.ContainsKey(color.Id))
            {
                Application.Current.Properties.Remove(color.Id);
                Application.Current.SavePropertiesAsync();
            }
        }

        private void LoadColorsFromProperties()
        {
            try
            {
                foreach (var kvp in Application.Current.Properties)
                {
                    var jsonString = kvp.Value as string;
                    var newColor = JsonConvert.DeserializeObject<Color>(jsonString);
                    colors.Add(newColor);
                }
            }
            catch
            {
            }
        }
    }
}