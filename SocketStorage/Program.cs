using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketStorage
{
    class Program
    {
        private static string socketPort = System.Configuration.ConfigurationManager.AppSettings["port"];
        private static Thread listenThread;
        private static Socket server;

        static void Main(string[] args)
        {
            BeginListen();
            Console.ReadLine();
            listenThread.Abort();
            server.Shutdown( SocketShutdown.Both);
            server.Close();
            server.Dispose();
        }

        public static void BeginListen()
        {
            string ip = "0.0.0.0";
            int port = int.Parse(string.IsNullOrEmpty(socketPort) ? "9022" : socketPort);

            //创建监听线程
            listenThread = new Thread(new ThreadStart(() =>
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress address = IPAddress.Parse(ip);
                IPEndPoint endPoint = new IPEndPoint(address, port);
                server.Bind(endPoint);
                server.Listen(100);
                while (true)
                {
                    try
                    {
                        Socket worker = server.Accept();
                        byte[] buffer = new byte[1024 * 200];
                        int count = worker.Receive(buffer);
                        string receiveText = Encoding.UTF8.GetString(buffer, 0, count);

                        //在此处处理你的html字符串

                        Log(receiveText);
                        worker.Shutdown(SocketShutdown.Both);
                        worker.Close();
                        worker.Dispose();
                    }
                    catch { }
                }
            }));
            listenThread.Start();
        }

        private static void Log(string message)
        {
            message += "___________________________________________________";
            string[] array = message.Split(new string[] { "\n" }, StringSplitOptions.None);
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
