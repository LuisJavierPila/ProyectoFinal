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
    public partial class modificarRegistro : ContentPage
    {
        private int IdSeleccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<datosVehiculo> ResultadoDelete;
        IEnumerable<datosVehiculo> ResultadoUpdate;

       
        public modificarRegistro(int id)
        {
            _conn = DependencyService.Get<ISQLiteBD>().GetConnection();
            IdSeleccionado = id;
            InitializeComponent();
        }

        private void btn_Actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "parqueadero1.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db, Marca.Text, Placa.Text, Hora.Text, IdSeleccionado);
                DisplayAlert("Alerta","Se actualizo","Ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error" + ex.Message, "Ok");
            }
        }

        private IEnumerable<datosVehiculo> Update(SQLiteConnection db, string marca, string placa, string hora, int id)
        {
            return db.Query<datosVehiculo>("UPDATE datosVehiculo SET Marca =?, Placas=?, " +
            "Hora=? where idAuto =?", marca, placa, hora, id);
        }

        private void btn_Eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "parqueadero1.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimino correcto","Ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error" + ex.Message, "OK");
            }
        }

        private IEnumerable<datosVehiculo> Delete(SQLiteConnection db, int id)
        {
            return db.Query<datosVehiculo>("DELETE FROM datosVehiculo where idAuto=?",id);
        }
    }
}