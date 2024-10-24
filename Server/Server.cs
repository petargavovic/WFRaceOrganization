using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        Socket socket;
        public static List<ClientHandler> clientHandlers = new List<ClientHandler>();

        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Start()
        {
            clientHandlers = new List<ClientHandler>();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));

            socket.Bind(endPoint);
            socket.Listen(5);

            Thread thread = new Thread(AcceptClient);
            thread.Start();
        }

        public void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Debug.Write("1111111111111");
                    Socket klijentskiSoket = socket.Accept();
                    Debug.Write("2222222222222");
                    ClientHandler handler = new ClientHandler(klijentskiSoket);
                    Debug.Write("33333333333333333");
                    clientHandlers.Add(handler);
                    Debug.Write("44444444444444");
                    Thread klijentskaNit = new Thread(handler.HandleRequest);
                    Debug.Write("55555555555555");
                    klijentskaNit.Start();
                    Debug.Write("66666666666");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            socket.Close();
        }
    }
}
