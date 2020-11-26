using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace parqueadero
{
   public  interface ISQLiteBD
    {
        SQLiteAsyncConnection GetConnection();
    }
}
