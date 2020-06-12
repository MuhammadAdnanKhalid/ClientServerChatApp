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
using System.Windows.Forms;

namespace WindowsFormsApplication15
{
    public partial class Chat : Form
    {
        private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        byte[] receivedBuf = new byte[1024];
        byte[] dataBuf;
        string a = null;

        public Chat()
        {
            InitializeComponent();
        }

        private void Chat_Load(object sender, EventArgs e)
        {

        }

        private void ReceiveData(IAsyncResult ar)
        {



            Socket socket = (Socket)ar.AsyncState;
            int received = socket.EndReceive(ar);
            dataBuf = new byte[received];

            Array.Copy(receivedBuf, dataBuf, received);
            
            Thread.Sleep(1000);
            a = Encoding.ASCII.GetString(dataBuf);

            if (a.StartsWith("@@"))
            {
               
            }

            
            



            Invoke(new Action(() => rb_chat.AppendText("\nServer : " + a + "\n")));
            
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
        }

        private void SendLoop()
        {
            while (true)
            {
                
                byte[] receivedBuf = new byte[1024];
                int rev = _clientSocket.Receive(receivedBuf);
                if (rev != 0)
                {
                    byte[] data = new byte[rev];
                    Array.Copy(receivedBuf, data, rev);
                    lb_stt.Text = ("Received: " + Encoding.ASCII.GetString(data));
                    rb_chat.AppendText("\nServer: " + Encoding.ASCII.GetString(data));
                }
                else _clientSocket.Close();

            }
        }

        private void LoopConnect()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  

            // Get the IP  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(myIP, 100);

                }
                catch (SocketException)
                {
                    //Console.Clear();
                    lb_stt.Text = ("Connection attempts: " + attempts.ToString());
                }
            }
            lb_stt.Text = ("Connected!");
        }


        private void button4_Click(object sender, EventArgs e)
        {
            LoopConnect();
            // SendLoop();
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
            byte[] buffer = Encoding.ASCII.GetBytes("@@" + txt_Text.Text);
            _clientSocket.Send(buffer);
            Connect.Enabled = false;
            txt_Text.Enabled = false;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (_clientSocket.Connected)
            {

                byte[] buffer = Encoding.ASCII.GetBytes(txName.Text);
                _clientSocket.Send(buffer);
                rb_chat.AppendText("\n You : " + txName.Text);
            }
           
        }

        public void senddata(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(txName.Text);
            _clientSocket.Send(buffer);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(txName.Text);
                _clientSocket.Send(buffer);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_clientSocket.Connected)
            {

                byte[] buffer = Encoding.ASCII.GetBytes(txName.Text);
                _clientSocket.Send(buffer);
                rb_chat.AppendText("\n You : " + txName.Text);
            }
        }
    }
}
