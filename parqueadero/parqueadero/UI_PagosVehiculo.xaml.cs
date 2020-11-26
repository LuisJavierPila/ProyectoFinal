using parqueadero.modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace parqueadero

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UI_PagosVehiculo : ContentPage
    {
       
        private SQLiteAsyncConnection _conn;
        public UI_PagosVehiculo()
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteBD>().GetConnection();
            
        }

        private  void btn_Agregar1_Clicked(object sender, EventArgs e)
        {
            
            
            var DatosVehiculo = new datosVehiculo { Marca = Marca.Text, Placas = Placa.Text, Descripcion = Descripcion.Text, Hora = Convert.ToInt32(Hora.Text) };
            _conn.InsertAsync(DatosVehiculo);
            IngresarDatos();
           
        }

        void IngresarDatos()
        {
            DisplayAlert("Registro", "Agregado Vehiculo", "Ok");
        }

       void limpiarDatos()
        {
            Marca.Text = "   ";
            Placa.Text = "   ";
            Descripcion.Text = " ";
            Hora.Text = " ";
           // DisplayAlert("Registro", "Agregado Vehiculo", "Ok");

        }
        //Genero los valores de envio
        private  void btn_DatosIm_Clicked(object sender, EventArgs e)
        {
            string marc = Marca.Text;
            string hor = Hora.Text;
            string plac = Placa.Text;
            
            try
            {
                Navigation.PushAsync(new UI_DatosPagos(marc, hor, plac));
                limpiarDatos();
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta",ex.Message,"OK");

            }
            

        }

        private async void btn_historial_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new UI_Informe());
        }
    }
}