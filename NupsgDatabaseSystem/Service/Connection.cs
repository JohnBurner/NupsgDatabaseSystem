using System.Data.SqlServerCe;

namespace NupsgDatabaseSystem.Service
{
    public class Connection
    {
        public Connection()
        {
            strconn = @"Data Source=" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)+
                "\\AppData\\NupsgDB.sdf;";
            connection = new SqlCeConnection(strconn);
            connected = false;
        }
        //connection string
        private string strconn;
        private SqlCeConnection connection;
        bool connected;

        public SqlCeConnection connectionOpen()
        {
            connection.Open();
            connected = true;
            return connection;
        }

        public SqlCeCommand cmd()
        {
            if (!connected) connection.Open();

            SqlCeCommand cmd = new SqlCeCommand();
            cmd = connection.CreateCommand();
            return cmd;
        }

        public SqlCeConnection connectionClose()
        {
            connection.Close();
            return connection;
        }
    }
}
