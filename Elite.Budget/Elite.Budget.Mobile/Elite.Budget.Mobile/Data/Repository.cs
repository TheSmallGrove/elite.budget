using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elite.Budget.Mobile.Data
{
    class Repository
    {
        private SQLiteConnection Connection ;

        public Repository(string connectionString)
        {
            this.Connection = new SQLiteConnection(connectionString);
        }
    }
}
