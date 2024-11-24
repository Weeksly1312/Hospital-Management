using System;
using System.Data.SqlClient;

namespace Server_Hosp.Utils
{
    public static class ServerManager
    {

        //soufiane DB:
        public static readonly string ConnectionString = @"Data Source=DESKTOP-C03F80S\SQLEXPRESS01;Initial Catalog=DoctorManagements;Integrated Security=True;Connect Timeout=30;";

        //med DB:
        //public static readonly string ConnectionString = @"Data Source=DESKTOP-MVIQ4R9\SQLEXPRESS01;Initial Catalog=New Database;Integrated Security=True;Connect Timeout=30;";
        
        public static void RegisterServices()
        {
            try
            {
                // Create and register new TCP channel
                System.Runtime.Remoting.Channels.Tcp.TcpChannel channel =
                    new System.Runtime.Remoting.Channels.Tcp.TcpChannel(2222);
                System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(channel, false);

                // Register service types
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

                Console.WriteLine("Server is running on port 2222!");
                Console.WriteLine("Press Enter to exit...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting server: {ex.Message}");
            }
        }

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static void HandleSqlException(SqlException ex, ref string result)
        {
            if (ex.Number == 2627) // Unique constraint violation
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
    }
}