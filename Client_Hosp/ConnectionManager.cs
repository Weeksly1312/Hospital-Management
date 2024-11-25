using System;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using Middle_Hosp;
using System.Windows.Forms;

namespace Client_Hosp.Utils
{
    public static class ConnectionManager
    {
        #region Configuration
        // Soufiane DB:
        public static readonly string ConnectionString = @"Data Source=DESKTOP-C03F80S\SQLEXPRESS01;Initial Catalog=DoctorManagements;Integrated Security=True;Connect Timeout=30;";
        
        //Mohammed DB:
        //public static readonly string ConnectionString = @"Data Source=DESKTOP-MVIQ4R9\SQLEXPRESS01;Initial Catalog=New Database;Integrated Security=True;Connect Timeout=30;";

        #endregion

        #region Connection Management
        public static RPC InitializeRPCConnection(string serviceName)
        {
            try
            {
                EnsureChannelExists();
                return CreateRPCConnection(serviceName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to initialize connection: {ex.Message}");
            }
        }

        private static void EnsureChannelExists()
        {
            TcpChannel existingChannel = GetExistingTcpChannel();
            
            if (existingChannel == null)
            {
                TcpChannel channel = new TcpChannel();
                ChannelServices.RegisterChannel(channel, false);
            }
        }

        private static TcpChannel GetExistingTcpChannel()
        {
            foreach (IChannel chan in ChannelServices.RegisteredChannels)
            {
                if (chan is TcpChannel tcpChannel)
                {
                    return tcpChannel;
                }
            }
            return null;
        }

        private static RPC CreateRPCConnection(string serviceName)
        {
            RPC rpc = (RPC)Activator.GetObject(
                typeof(RPC),
                $"tcp://localhost:2222/{serviceName}");

            if (rpc == null)
                throw new Exception($"Failed to connect to {serviceName} service");

            return rpc;
        }
        #endregion

        #region Message Display
        public static void Show(string message, string title = "Information")
        {
            ShowMessage(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string message, string title = "Error", 
            MessageBoxButtons buttons = MessageBoxButtons.OK, 
            MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            ShowMessage(message, title, buttons, icon);
        }

        public static void ShowSuccess(string message, string title = "Success")
        {
            ShowMessage(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void ShowMessage(string message, string title, 
            MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }
        #endregion
    }
}