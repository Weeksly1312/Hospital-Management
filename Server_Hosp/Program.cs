using System;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace Server_Hosp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Unregister any existing channels first
                //foreach (var channel in ChannelServices.RegisteredChannels)
                //{
                //    ChannelServices.UnregisterChannel(channel);
                //}

                // Create and register new TCP channel
                TcpChannel channel = new TcpChannel(2222);
                ChannelServices.RegisterChannel(channel, false);

                // Register service types
                RemotingConfiguration.RegisterWellKnownServiceType(
                    typeof(LoginService),
                    "login",
                    WellKnownObjectMode.Singleton);

                RemotingConfiguration.RegisterWellKnownServiceType(
                    typeof(Doctor),
                    "doctor",
                    WellKnownObjectMode.Singleton);

                RemotingConfiguration.RegisterWellKnownServiceType(
                   typeof(Server_Hosp.Patient),
                   "patient",
                   WellKnownObjectMode.Singleton);

                Console.WriteLine("Server is running on port 2222!");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting server: {ex.Message}");
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
        }
    }
}
