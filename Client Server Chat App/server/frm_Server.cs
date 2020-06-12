using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace GameSocket
{
   
    public class SocketT2h
    {
        public Socket _Socket { get; set; }
        public string _Name { get; set; }
        public SocketT2h(Socket socket)
        {
            this._Socket = socket;
        }
    }
    public partial class frm_Server : Form
    {
        public string t;


        private byte[] _buffer = new byte[1024];
        public List<SocketT2h> __ClientSockets { get; set; }

       
        List<string> _names = new List<string>();
        private Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public frm_Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            __ClientSockets = new List<SocketT2h>();
        }

        private void frm_Server_Load(object sender, EventArgs e)
        {
            SetupServer();
        }
        private void SetupServer()
        {
            

            lb_stt.Text = "Setting up server . . .";
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private void AppceptCallback(IAsyncResult ar)
        {
            Socket socket = _serverSocket.EndAccept(ar);
            __ClientSockets.Add(new SocketT2h(socket));
            string nae = socket.RemoteEndPoint.ToString();
          
            
             
                
            
            

            
           
            lb_soluong.Text = " The Client is Connected " + __ClientSockets.Count.ToString();
            
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {

            Socket socket = (Socket)ar.AsyncState;
            if (socket.Connected)
            {
                int received;
                try
                {
                    received = socket.EndReceive(ar);
                }
                catch (Exception)
                {
                    // client
                    for (int i = 0; i < __ClientSockets.Count; i++)
                    {
                        if (__ClientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            __ClientSockets.RemoveAt(i);
                            lb_soluong.Text = "Number of Clients Connected " + __ClientSockets.Count.ToString();
                        }
                    }
                    //  list
                    return;
                }
                if (received != 0)
                {
                    byte[] dataBuf = new byte[received];
                    Array.Copy(_buffer, dataBuf, received);
                    string text = Encoding.ASCII.GetString(dataBuf);
                    this.t = text + " Online :) " ;
                   

                    string reponse = string.Empty;
                    

                    for (int i = 0; i < __ClientSockets.Count; i++)
                    {
                        if (socket.RemoteEndPoint.ToString().Equals(__ClientSockets[i]._Socket.RemoteEndPoint.ToString()))
                        {
                            if(text.StartsWith("@@"))
                            {
                                list_Client.Items.Add(text);
                               
                                _names.Add(text);
                                broad();
                            }
                            rich_Text.AppendText("\n" + _names[i] + ": " + text);
                            
                            
                        }
                    }



                    if (text == "bye")
                    {
                        return;
                    }
                   
                }
                else
                {
                    for (int i = 0; i < __ClientSockets.Count; i++)
                    {
                        if (__ClientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            __ClientSockets.RemoveAt(i);
                            lb_soluong.Text = "Number of Clients Connected " + __ClientSockets.Count.ToString();
                        }
                    }
                }
            }
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        }
        void Sendata(Socket socket, string noidung)
        {
            byte[] data = Encoding.ASCII.GetBytes(noidung);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

     
        private void btnBroadCast_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list_Client.Items.Count; i++)
            {
                __ClientSockets[i]._Socket.Send(Encoding.ASCII.GetBytes(txt_Text.Text));
            }

 
        }

        public void broad()
        {

            for (int i = 0; i < list_Client.Items.Count; i++)
            {
                __ClientSockets[i]._Socket.Send(Encoding.ASCII.GetBytes(this.t));
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list_Client.CheckedIndices.Count; i++)
            {
                string y = list_Client.CheckedIndices[i].ToString();
            

                Sendata(__ClientSockets[Convert.ToInt32(y)]._Socket, txt_Text.Text);
               
            }
            rich_Text.AppendText("\nServer: " + txt_Text.Text);
        }
    }
}