using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Colours.Models;
using Colours.Views;
using System.Windows.Input;
using System.Linq;

namespace Colours.ViewModels
{
    public class ColorsViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Color> Colors { get; set; }
        public Command LoadItemsCommand { get; set; }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                // If empty, unfilters the list
                if (value == string.Empty) LoadItemsCommand.Execute(null);
                _searchText = value;
            }
        }

        public ColorsViewModel()
        {
            Title = "Colors";
            Colors = new ObservableCollection<Models.Color>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            SearchCommand = new Command(() => Search());
        }

        public ICommand SearchCommand { get; }

        void Search()
        {
            var filteredColors = Colors.Where(c => c.ColorName.ToLower().StartsWith(SearchText.ToLower())).ToList();
            Colors.Clear();
            foreach(var filteredColor in filteredColors)
            {
                Colors.Add(filteredColor);
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Colors.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Colors.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}