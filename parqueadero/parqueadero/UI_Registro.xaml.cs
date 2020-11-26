using parqueadero.modelo;
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
    public partial class UI_Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public UI_Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteBD>().GetConnection();
        }

        private void btn_Agregar_Clicked(object sender, EventArgs e)
        {
            var DatosRegistro = new datosUsuario { usuario = usuario.Text, correo = correo.Text, password = password.Text, telefono = telefono.Text };
            _conn.InsertAsync(DatosRegistro);
            limpiarRegistro();

        }

        void limpiarRegistro()
        {
            usuario.Text = "  ";
            correo.Text = "  ";
            password.Text = "  ";
            telefono.Text = "  ";
            DisplayAlert("Registro", "Agregado Registro", "Ok");

        }

        private async void btn_Regresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UI_Login());
        }
    }
}