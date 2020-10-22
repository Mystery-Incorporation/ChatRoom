using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerClassLibrary;

namespace SocketClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketClient client = new SocketClient();

            Console.WriteLine("Welcom!");
            Console.WriteLine("Please Typ Valid Server IPA");

            string strIPAdress = Console.ReadLine();

            Console.WriteLine("Port number?");
            string strPortInput = Console.ReadLine();

            if (!client.SetServerIPAddress(strIPAdress) || !client.SetPortNumber(strPortInput))
            {
                Console.WriteLine(string.Format("Wrong ip adress or port number - {0} - {1}", strIPAdress,strPortInput));
                Console.ReadLine();
                return;
            }

            client.ConnectToServer();

            string strInputUser = null;

            do
            {
                strInputUser = Console.ReadLine();

                if (strInputUser.Trim() != "<Exit>")
                {
                    client.SendToServer(strInputUser);
                }

                
            } while (strInputUser != "<Exit>");

        }
    }
}
