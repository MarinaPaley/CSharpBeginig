using System;

namespace DataAccessLayer
{
    public sealed class Settings
    {
        private string dabaseServerName;

        private string databaseName;

        public void AddDabaseServer(string serverName)
        {
            this.dabaseServerName = serverName;
        }

        public string GetDatabaseServer()
        {
            return this.dabaseServerName;
        }

        public void AddDatabase(string databaseName)
        {
            this.databaseName = databaseName;
        }

        public string GetDatabaseName()
        {
            return this.databaseName;
        }
    }
}
