using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SeenMedia.Model;

namespace SeenMedia.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeenMediaEntryPage : ContentPage
    {
        public SeenMediaEntryPage()
        {
            InitializeComponent();
            BindingContext = new SeenMediaEntry();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var SeenMediaEntry = (SeenMediaEntry)BindingContext;
            await App.Database.SaveItemAsync(SeenMediaEntry);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var SeenMediaEntry = (SeenMediaEntry)BindingContext;
            await App.Database.DeleteItemAsync(SeenMediaEntry);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        class Notify : INotifyPropertyChanged
        {

            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
