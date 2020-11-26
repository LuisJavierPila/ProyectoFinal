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
    public partial class UI_DatosPagos : ContentPage
    {
        private SQLiteAsyncConnection _conn;
      
       

        public UI_DatosPagos(string marc, string hor, string plac)
        {
            InitializeComponent();
       
            _conn = DependencyService.Get<ISQLiteBD>().GetConnection();
            string marc1 = lblmarca.Text;
            lblmarca.Text = marc1 + marc;

            string hora1 = lblhora.Text;
            lblhora.Text = hora1 + hor;

            string plac1 = lblplaca.Text;
            lblplaca.Text = plac1 + plac;
        }

       

        

    }
}