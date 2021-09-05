using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TcpEchoServer {
    public class Program {

        public static IPAddress IP = IPAddress.Loopback;
        public static int port = 7;

        public static void Main() {
            EchoServerSocket socket = new EchoServerSocket(IP, port);
            socket.Run();
        }
        /*
        private static string Reply(string message) {
            if (message.Contains(":")) {
                string[] vs = message.Split(":");
                if (vs[0].ToLower().Contains("toupper")) {
                    return vs[1].ToUpper();
                } else if (vs[0].ToLower().Contains("tolower")) {
                    return vs[1].ToLower();
                } else if (vs[0].ToLower().Contains("reverse")) {
                    string m = "";
                    for (int i = vs[1].Length - 1; i >= 0; i--) {
                        m += vs[1][i];
                    }
                    return m;
                }
            }
            return message;
        }
        */
    }
}