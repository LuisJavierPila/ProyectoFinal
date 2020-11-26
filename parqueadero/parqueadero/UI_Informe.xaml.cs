using parqueadero.modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace parqueadero
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UI_Informe : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<datosVehiculo> _TablaVehiculo;

        public UI_Informe()
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteBD>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }
        protected async override void OnAppearing()
        {
            var ResulVehiculo = await _conn.Table<datosVehiculo>().ToListAsync();
            _TablaVehiculo = new ObservableCollection<datosVehiculo>(ResulVehiculo);
            ListaPagos.ItemsSource = _TablaVehiculo;
            base.OnAppearing();

        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (datosVehiculo)e.SelectedItem;
            var item = Obj.idAuto.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new modificarRegistro(ID));

            }
            catch (Exception)
            {
                throw;
            }

        }

        private async void Regresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UI_PagosVehiculo());
        }
    }
}