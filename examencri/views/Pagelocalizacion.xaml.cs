using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using examencri.Models;
using System.Runtime.InteropServices.ComTypes;

namespace examencri.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagelocalizacion : ContentPage
    {
        Location location = null;
        public Pagelocalizacion()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {

            try
            {
               

                if (location != null && !string.IsNullOrEmpty(descripcioncorta.Text) && !string.IsNullOrEmpty(descripcionlarga.Text))
                {
                    latitud.Text = Convert.ToString(location.Latitude);
                    longitud.Text = Convert.ToString(location.Longitude);
                 
                    var local = new Models.localizacion
                    {
                        latitud = location.Latitude,
                        longitud = location.Longitude,
                        descripcioncorta = descripcioncorta.Text,
                        descripcionlarga = descripcionlarga.Text,

                    };
                    if (await App.Database.SaveGeo(local) > 0)
                    {

                        await DisplayAlert("aviso", "localizacion Guardada ", "OK");
                    }

                }
                else
                {

                    if (location == null)
                    {
                        await DisplayAlert("Error", "Error no esta activo el GPS ", "OK");
                    }
                    else if (string.IsNullOrEmpty(descripcioncorta.Text))
                    {
                        await DisplayAlert("Error", "Error sin Descripcion Corta ", "OK");
                    }
                    else if (string.IsNullOrEmpty(descripcionlarga.Text))
                    {
                        await DisplayAlert("Error", "Error sin Descripcion Larga ", "OK");
                    }

                }
            }

            catch (Exception ex)
            {
                if (location == null)
                {
                    await DisplayAlert("Error", "Error no esta activo el GPS ", "OK");
                }

            }
        }

        private async  void  btnsalvar_Clicked(object sender, EventArgs e)
        {
            var page = new views.PagelistGeo();
           await  Navigation.PushAsync(page); 

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    latitud.Text = Convert.ToString(location.Latitude);
                    longitud.Text = Convert.ToString(location.Longitude);

                }
                
            }
            catch (Exception ex)
            {
                
            }     

        }
    }
}