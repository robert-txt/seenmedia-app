using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using SeenMedia.Data;
using SeenMedia.Views;

namespace SeenMedia
{
    public partial class App : Application
    {
        static SeenMediaDatabase database;

        public App()
        {
            InitializeComponent();

            //MainPage = new SeenMedia.MainPage();

            Resources = new ResourceDictionary();
            Resources.Add("DarkNavy", Color.FromHex("0b2938"));
            Resources.Add("Navy", Color.FromHex("2f6581"));

            var nav = new NavigationPage(new SeenMediaListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["Navy"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static SeenMediaDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SeenMediaDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("SeenMediaSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtSeenMediaEntryId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
