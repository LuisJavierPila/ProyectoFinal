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
    public partial class UI_Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public UI_Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteBD>().GetConnection();
        }

        private void btn_login_Clicked(object sender, EventArgs e)
        {
            string user =usuario.Text;
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "parqueadero1.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<datosUsuario>();

                IEnumerable<datosUsuario> resultado = SELECT_WHERE(db, usuario.Text, contra.Text);
                if (resultado.Count() > 0)
                {
                   Navigation.PushAsync(new UI_Usuario(user));
                }
                else
                {
                    DisplayAlert("Mensaje", "usuario no registrado Contrasenia", "Ok");
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "ok");
            }

        }

        private IEnumerable<datosUsuario> SELECT_WHERE(SQLiteConnection db, string usuario, string contra)
        {
            return db.Query<datosUsuario>("SELECT *FROM datosUsuario where usuario=? and password=?", usuario, contra);
        }

        private async void btn_Registrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UI_Registro());
        }
    }
}