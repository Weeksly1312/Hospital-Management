using System;
using System.Data.SqlClient;

namespace Server_Hosp.Utils
{
    public static class ServerManager
    {
        #region Configuration
        // Connection Strings
        private const string SOUFIANE_DB = @"Data Source=DESKTOP-C03F80S\SQLEXPRESS01;Initial Catalog=DoctorManagements;Integrated Security=True;Connect Timeout=30;";
        private const string MED_DB = @"Data Source=DESKTOP-MVIQ4R9\SQLEXPRESS01;Initial Catalog=New Database;Integrated Security=True;Connect Timeout=30;";
        
        // Active Connection String
        public static readonly string ConnectionString = SOUFIANE_DB;
        #endregion

        #region Server Setup
        public static void RegisterServices()
        {
            try
            {
                SetupTcpChannel();
                RegisterServiceTypes();
                DisplayServerStatus();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting server: {ex.Message}");
            }
        }

        private static void SetupTcpChannel()
        {
            System.Runtime.Remoting.Channels.Tcp.TcpChannel channel =
                new System.Runtime.Remoting.Channels.Tcp.TcpChannel(2222);
            System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(channel, false);
        }

        private static void RegisterServiceTypes()
        {
            System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(LoginService),
                "login",
                System.Runtime.Remoting.WellKnownObjectMode.Singleton);

            System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(Doctor),
                "doctor",
                System.Runtime.Remoting.WellKnownObjectMode.Singleton);

            System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(
               typeof(Patient),
               "patient",
               System.Runtime.Remoting.WellKnownObjectMode.Singleton);
        }

        private static void DisplayServerStatus()
        {
            Console.WriteLine("Server is running on port 2222!");
            Console.WriteLine("Press Enter to exit...");
        }
        #endregion

        #region Database Operations
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        #endregion

        #region Error Handling
        public static void HandleSqlException(SqlException ex, ref string result)
        {
            if (ex.Number == 2627) 
            {
                result = "Error: A record with this ID already exists.";
            }
            else
            {
                result = $"Error: {ex.Message}";
            }
        }

        public static void HandleException(Exception ex, ref string result)
        {
            result = $"Error: {ex.Message}";
        }
        #endregion
    }
}