using System;
using Server_Hosp.Utils;

namespace Server_Hosp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServerManager.RegisterServices();
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
