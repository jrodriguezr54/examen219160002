using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace examencri.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagelistGeo : ContentPage
    {
        public PagelistGeo()
        {
            InitializeComponent();
        }

        private void listlocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        protected async  override void OnAppearing()
        {
            base.OnAppearing();

            listalocal.ItemsSource= await App.Database.GetLisLocalizaciones();   
           
        }

        private void listalocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var page = new views.PageMap();
            Navigation.PushAsync(page);
        }
    }
}