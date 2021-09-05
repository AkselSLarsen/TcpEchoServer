using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpEchoServer {
    public class EchoServerSocket {
        public TcpListener Server;

        public EchoServerSocket(IPAddress ip, int port) {
            Console.WriteLine("This is the server");

            Server = new TcpListener(ip, port);
        }

        public void Run() {
            Server.Start();

            Console.WriteLine("Server ready");
            while (true) {
                TcpClient client = Server.AcceptTcpClient();
                Task.Run(() => ServiceClient(client));
            }
        }

        private void ServiceClient(TcpClient client) {
            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);

            bool end = false;
            while (!end) {
                try {
                    string message = reader.ReadLine();
                    Console.WriteLine("Server received: " + message);

                    writer.WriteLine(message);
                    writer.Flush();
                } catch (Exception e) {
                    //Console.WriteLine(e.Message);
                    if(e != null) {
                        end = true;
                        writer.WriteLine("Server connection severed");
                        writer.Flush();
                    }
                }
            }
            client.Close();
        }
    }
}
