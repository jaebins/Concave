using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omok
{
    public partial class Game_Client : Form
    {
        private const int bs = 30;
        private const int screenSize = 30;

        public bool isHost;
        public string conAddress = string.Empty;
        public int order;
        int counter = 0;
        bool isPlaying;
        bool myTurn;

        Point[] buildList_Black;
        Point[] buildList_White;
        Point mousePos;

        Brush playerBrush;
        Socket client;
        Graphics screen = null;

        public Game_Client()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(isHost)
            {
                MessageBox.Show("주소는 " + conAddress + " 입니다. 다른 사용자에게 알려주세요");
                myTurn = true;
            }

            Thread t1 = new Thread(ServerJoin);
            t1.IsBackground = true;
            t1.Start();

            buildList_Black = new Point[bs * screenSize / 2];
            buildList_White = new Point[bs * screenSize / 2];
            SetClientSizeCore(bs * screenSize, bs * screenSize);
            screen = CreateGraphics();
        }

        private void ServerJoin()
        {
            byte[] buffer = new byte[1024];
            int length = 0;
            string msg = string.Empty;

            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint point = new IPEndPoint(IPAddress.Parse(conAddress), 8000);
                client.Connect(point);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                Application.Exit();
            }

            while (true)
            {
                try
                {
                    length = client.Receive(buffer);
                    msg = Encoding.UTF8.GetString(buffer, 0, length);

                    if (msg.Equals("1")) 
                    {
                        if (!isHost)
                        {
                            order = int.Parse(msg);
                        }

                        isPlaying = true;
                    }
                    if (msg.Equals("2"))
                    {
                        if (!isPlaying && !isHost)
                        {
                            order = int.Parse(msg);
                        }
                    }
                    else if(msg.Contains("Black") || msg.Contains("White"))
                    {
                        string[] player = msg.Split(',');
                        Point point = new Point(int.Parse(player[1]), int.Parse(player[2]));

                        if (!player[3].Equals(order.ToString()))
                        {
                            myTurn = true;
                        }
                        if (msg.Contains("Black"))
                        {
                            Confirm_build(buildList_Black, point, "Black");
                        }
                        else if (msg.Contains("White"))
                        {
                            Confirm_build(buildList_White, point, "White");
                        }
                    }
                } 
                catch(SocketException se)
                {
                    MessageBox.Show(se.Message);
                    break;
                } 
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    break;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            screen.Clear(Color.Gray);
            SetBackground(screen);
        }

        private void SetBackground(Graphics g)
        {
            SetHorizontal(g);
            SetVertical(g);
        }

        private void SetHorizontal(Graphics g)
        {
            Point start = new Point();
            Point end = new Point();

            for(int i = 0; i < screenSize; i++)
            {
                start.X = 0;
                start.Y = bs * i;
                end.X = bs * screenSize;
                end.Y = start.Y;
                g.DrawLine(Pens.Black, start, end);
            }
        }

        private void SetVertical(Graphics g)
        {
            Point start = new Point();
            Point end = new Point();

            for (int i = 0; i < screenSize; i++)
            {
                start.X = bs * i;
                start.Y = 0;
                end.X = start.X;
                end.Y = bs * screenSize;
                g.DrawLine(Pens.Black, start, end);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && myTurn && isPlaying)
            {
                mousePos = new Point(e.X - e.X % 30, e.Y - e.Y % 30);

                if (order == 0)
                {
                    SendMessage(mousePos, "Black");
                    myTurn = false;
                }
                else if(order == 1)
                {
                    SendMessage(mousePos, "White");
                    myTurn = false;
                }
            }
        }

        private void SendMessage(Point mousePos, string player)
        {
            string msg = player + "," + mousePos.X.ToString() + "," + mousePos.Y.ToString() + "," + order.ToString();
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            client.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private void Confirm_build(Point[] buildList, Point mousePos, string player)
        {
            if (player.Equals("Black"))
            {
                playerBrush = new SolidBrush(Color.Black);
            }
            else
            {
                playerBrush = new SolidBrush(Color.White);
            }
            buildList[counter] = new Point(mousePos.X, mousePos.Y);

            // 왼쪽 위
            if (buildList.Contains(new Point(mousePos.X - 30, mousePos.Y - 30)))
            {
                Inspect_build(buildList, -30, -30, player);
            }
            // 오른쪽 위
            if (buildList.Contains(new Point(mousePos.X + 30, mousePos.Y - 30)))
            {
                Inspect_build(buildList, 30, -30, player);
            }
            // 왼쪽 아래
            if (buildList.Contains(new Point(mousePos.X - 30, mousePos.Y + 30)))
            {
                Inspect_build(buildList, -30, 30, player);
            }
            // 오른쪽 아래
            if (buildList.Contains(new Point(mousePos.X + 30, mousePos.Y + 30)))
            {
                Inspect_build(buildList, 30, 30, player);
            }
            // 오른쪽
            if (buildList.Contains(new Point(mousePos.X + 30, mousePos.Y)))
            {
                Inspect_build(buildList, 30, 0, player);
            }
            // 왼쪽
            if (buildList.Contains(new Point(mousePos.X - 30, mousePos.Y)))
            {
                Inspect_build(buildList, -30, 0, player);
            }
            // 위쪽
            if (buildList.Contains(new Point(mousePos.X, mousePos.Y - 30)))
            {
                Inspect_build(buildList, 0, -30, player);
            }
            // 아래쪽
            if (buildList.Contains(new Point(mousePos.X, mousePos.Y + 30)))
            {
                Inspect_build(buildList, 0, 30, player);
            }

            screen.FillEllipse(playerBrush, mousePos.X, mousePos.Y, 30, 30);
            counter++;
        }

        private void Inspect_build(Point[] buildList, int x, int y, string player)
        {
            for (int i = 2; i < 5; i++)
            {
                if (buildList.Contains(new Point(mousePos.X + x * i, mousePos.Y + y * i)))
                {
                    Console.Write("통과");
                }
                else
                {
                    break;
                }
                if (i == 4)
                {
                    Victory(player);
                }
            }
        }

        private void Victory(string player)
        {
            MessageBox.Show(player + "가 이겼습니다!");
            order = 3;
        }

        private void Game_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
 