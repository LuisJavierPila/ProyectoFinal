using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using parqueadero.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
[assembly:Xamarin.Forms.Dependency(typeof(SQLiteClient))]

namespace parqueadero.Droid
{
    public class SQLiteClient : ISQLiteBD
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "parqueadero1.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}