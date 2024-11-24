using System;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using Middle_Hosp;

namespace Client_Hosp.Utils
{
    public static class ConnectionManager
    {
        public static readonly string ConnectionString = @"Data Source=DESKTOP-C03F80S\SQLEXPRESS01;Initial Catalog=DoctorManagements;Integrated Security=True;Connect Timeout=30;";

        public static RPC InitializeRPCConnection(string serviceName)
        {
            try
            {
                // Check for existing TCP channel
                TcpChannel existingChannel = null;
                foreach (IChannel chan in ChannelServices.RegisteredChannels)
                {
                    if (chan is TcpChannel)
                    {
                        existingChannel = (TcpChannel)chan;
                        break;
                    }
                }

                // Register new channel if needed
                if (existingChannel == null)
                {
                    TcpChannel channel = new TcpChannel();
                    ChannelServices.RegisterChannel(channel, false);
                }

                // Get remote object
                RPC rpc = (RPC)Activator.GetObject(
                    typeof(RPC),
                    $"tcp://localhost:2222/{serviceName}");

                if (rpc == null)
                    throw new Exception($"Failed to connect to {serviceName} service");

                return rpc;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to initialize connection: {ex.Message}");
            }
        }

        public static void ShowError(string message, string title = "Error")
        {
            System.Windows.Forms.MessageBox.Show(
                message,
                title,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string message, string title = "Success")
        {
            System.Windows.Forms.MessageBox.Show(
                message,
                title,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information);
        }
    }
} 