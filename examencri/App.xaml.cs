using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace examencri
{
    public partial class App : Application
    {

        static controler.localizacioncontroler database;
        public static controler.localizacioncontroler Database
        {

            get
            {
                if (database == null)
                {
                    var pathdatabase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dbname = "Programacion 4.db3";
                    var fullpath = Path.Combine(pathdatabase, dbname);
                    database = new controler.localizacioncontroler(fullpath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new views.Pagelocalizacion());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
