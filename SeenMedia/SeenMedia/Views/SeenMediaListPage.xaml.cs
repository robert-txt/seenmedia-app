using SeenMedia.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeenMedia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeenMediaListPage : ContentPage
    {
        public SeenMediaListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtSeenMediaEntryId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeenMediaEntryPage
            {
                BindingContext = new SeenMediaEntry()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtSeenMediaEntryId = (e.SelectedItem as SeenMediaEntry).ID;

            await Navigation.PushAsync(new SeenMediaEntryPage
            {
                BindingContext = e.SelectedItem as SeenMediaEntry
            });
        }

        async void OnStatsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatsPage
            {
                BindingContext = new StatsPage()
            });
        }
    }
}
