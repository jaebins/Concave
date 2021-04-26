using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omok
{
    class ServerConnect
    {
        int counter = 0;
        public Dictionary<Socket, string> clientList = new Dictionary<Socket, string>();
        Socket serverSoc;

        public ServerConnect(string address, bool makeRoom)
        {
            if (makeRoom)
            {
                address = Get_MyIP();

                Thread t1 = new Thread(MakeRoom);
                t1.IsBackground = true;
                t1.Start();

                JoinRoom(0, address, true);
            }
            else
            {
                JoinRoom(1, address, false);
            }
        }

        public void MakeRoom()
        {
            try
            {
                serverSoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint point = new IPEndPoint(IPAddress.Any, 8000);
                serverSoc.Bind(point);
                serverSoc.Listen(10);

                while (true)
                {
                    Socket client = serverSoc.Accept();
                    clientList.Add(client, client.RemoteEndPoint.ToString());

                    if (counter == 1)
                    {
                        SendMessage("1");
                    }
                    else if (counter > 1)
                    {
                        SendMessage("2");
                    }

                    Handler handler = new Handler();
                    handler.ReceiveMessage += new Handler.ReceivedMessageEvent(ReceivedMessage);
                    handler.DisconnectPlayer += new Handler.DisconnectedPlayerEvent(DisconnectPlayer);
                    handler.HandlerStart(client, clientList);

                    counter++;
                }
            } catch(SocketException se)
            {
                Console.WriteLine(se.Message);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            serverSoc.Close();
            Application.Exit();
        }

        private void ReceivedMessage(string msg)
        {
            SendMessage(msg);
        }

        private void DisconnectPlayer(Socket client)
        {
            if (clientList.ContainsKey(client))
            {
                counter--;
                clientList.Remove(client);
            }
        }

        private void SendMessage(string msg)
        {
            foreach(var pair in clientList)
            {
                Socket client = pair.Key;
                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                client.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }
        }

        private void JoinRoom(int order, string address, bool isHost)
        {
            Game_Client game = new Game_Client();
            game.conAddress = address;
            game.order = order;
            game.isHost = isHost;
            game.Show();
        }

        public string Get_MyIP()
        {
            IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();
            return myip;
        }
    }
}
