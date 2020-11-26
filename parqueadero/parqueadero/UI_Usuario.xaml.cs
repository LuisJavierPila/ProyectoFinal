using Plugin.Media;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace parqueadero
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UI_Usuario : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public UI_Usuario(string user)
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteBD>().GetConnection();
            string usuario1 = lblusuario.Text;
            lblusuario.Text = usuario1 + user;
        }

        private async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            Imagen.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private async void btnSeleccionarFoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });


            if (file == null)
                return;

            Imagen.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private async void btn_Salir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UI_Login());
        }

        private async void btn_PaVe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UI_PagosVehiculo());
        }
    }
}