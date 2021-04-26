using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Omok
{
    class Handler
    {
        Socket client;
        Dictionary<Socket, string> clientList = new Dictionary<Socket, string>();

        public delegate void ReceivedMessageEvent(string msg);
        public event ReceivedMessageEvent ReceiveMessage;

        public delegate void DisconnectedPlayerEvent(Socket client);
        public event DisconnectedPlayerEvent DisconnectPlayer;

        public void HandlerStart(Socket client, Dictionary<Socket, string> clientList)
        {
            this.client = client;
            this.clientList = clientList;

            Thread t1 = new Thread(MessageReceive);
            t1.IsBackground = true;
            t1.Start();
        }

        public void MessageReceive()
        {
            byte[] buffer = new byte[1024];
            int length = 0;
            string msg = string.Empty;

            try
            {
                while (true)
                {
                    length = client.Receive(buffer);
                    msg = Encoding.UTF8.GetString(buffer, 0, length);
                    ReceiveMessage(msg);
                }
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
                DisconnectPlayer(client);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DisconnectPlayer(client);
                client.Close();
            }
        }
    }
}
