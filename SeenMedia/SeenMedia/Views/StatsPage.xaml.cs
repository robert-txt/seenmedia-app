using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SeenMedia.Data;
using Xamarin.Forms.Xaml;

namespace SeenMedia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        public StatsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            var Counter = await App.Database.CountItemAsync("Książka");
            BooksLabel.Text = Counter.ToString();

            var Counter2 = await App.Database.CountItemAsync("Film");
            MoviesLabel.Text = Counter2.ToString();

            var Counter3 = await App.Database.CountItemAsync("Koncert");
            ConcertsLabel.Text = Counter3.ToString();

            var Counter4 = await App.Database.CountItemAsync("Sztuka");
            SpectaclesLabel.Text = Counter4.ToString();

            var Counter5 = await App.Database.CountItemAsync("Muzeum");
            MuseumsLabel.Text = Counter5.ToString();

            var Counter6 = await App.Database.CountItemAsync("Gra");
            GamesLabel.Text = Counter6.ToString();

            var Counter7 = await App.Database.CountItemAsync("Serial");
            SeriesLabel.Text = Counter7.ToString();
        }
    }
}
