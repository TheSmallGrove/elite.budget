using Elite.Budget.Mobile.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Elite.Budget.Mobile.Data
{
    class Migrator
    {
        public Migrator()
        {
        }

        public void Upgrade()
        {
            using (var connection = this.GetOrCreateDB())
            {
                this.UpgradeToV1(connection);
            }
        }

        private SQLiteConnection GetOrCreateDB()
        {
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "budget.db");

            if (!File.Exists(dbPath))
                File.Create(dbPath).Close();

            return new SQLiteConnection(dbPath);
        }

        private void UpgradeToV1(SQLiteConnection connection)
        {
            var result = connection.CreateTable<ImportRow>();
            //throw new NotImplementedException();
        }
    }
}
