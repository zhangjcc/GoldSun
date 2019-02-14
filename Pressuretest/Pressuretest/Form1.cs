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

namespace Pressuretest
{
    //private Socket UDPSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }
        //private Thread mythead;




        private void button1_Click(object sender, EventArgs e)
        {
            Socket UDPSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            UDPSock.Bind(new  IPEndPoint(IPAddress.Any, 31028));
            string IP = IPNum.Text;
            byte[] Send_Buf = new byte[17] { 0x4A, 0x59,0x11,0x00,0x00,0x00,0x00,0x24,0xFF,0xFF,0x5b,0x59 ,0x67 ,0x4e,0x97,0x73,0x01 };
            try
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                for (int i = 0; i < int.Parse(textBox2.Text); i++)
                {
                    if (Send_Buf[16] == 0x01) Send_Buf[16] = 0x00;
                    else if (Send_Buf[16] == 0x00) Send_Buf[16] = 0x01;
                    Common.UDPConnectClass.UDP_Send(Send_Buf, IP, 1025, UDPSock);
                    Thread.Sleep(int.Parse(Sleept.Text));
                    
                }
            }
            catch (Exception ex) { }
            finally
            {
                UDPSock.Close();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Socket UDPSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            UDPSock.Bind(new IPEndPoint(IPAddress.Any, 31028));
            string IP = IPNum.Text;
            byte[] Send_Buf = new byte[17] { 0x4A, 0x59, 0x11, 0x00, 0x00, 0x00, 0x00, 0x04, 0xFF, 0xFF, 0x5b, 0x59, 0x67, 0x4e, 0x97, 0x73, 0x01 };
            try
            {

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                for (int i = 0; i < int.Parse(textBox2.Text); i++)
                {
                    if (Send_Buf[16] == 0x01) Send_Buf[16] = 0x00;
                    else if (Send_Buf[16] == 0x00) Send_Buf[16] = 0x01;
                    Common.UDPConnectClass.UDP_Send(Send_Buf, IP, 1025, UDPSock);
                    Thread.Sleep(int.Parse(Sleept.Text));
                    
                }
            }
            catch (Exception ex) { }
            finally
            { 
                UDPSock.Close();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Socket UDPSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            UDPSock.Bind(new IPEndPoint(IPAddress.Any, 31028));
            string IP = IPNum.Text;
            byte[] Send_Buf = new byte[20] { 0x4A, 0x59, 0x14, 0x00, 0x00, 0x00, 0x00, 0x20, 0xFF, 0xFF, 0x5b, 0x59, 0x67, 0x4e, 0x97, 0x73, 0x81,0xEA,0x68,0xC0 };
            byte[] Rec_Buf = new byte[22];
            byte[] Rec_Buf2 = new byte[60];
            try
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                //       Common.UDPConnectClass.UDP_Send(Send_Buf, IP, 1025, UDPSock);
                
                try
                {
                    IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), 1025);
                    EndPoint Remote = iep;
                    UDPSock.SendTimeout = 200;
                    UDPSock.ReceiveTimeout = 200;
                    UDPSock.SendTo(Send_Buf, Send_Buf.Length, 0, iep);
                    //Thread.Sleep(300);
                    //int recv = UDPSock.ReceiveFrom(Rec_Buf, ref Remote);
                    //Thread.Sleep(11000);
                    //int recv2 = UDPSock.ReceiveFrom(Rec_Buf2, ref Remote);
                    //MessageBox.Show(Rec_Buf.ToString());
                }
                catch
                {
                    
                }

            }
            catch (Exception Ex) { }
            finally
            {
                UDPSock.Close();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }


        //void myListen()
        //{
        //    while(true)
        //    {



        //        mythead.Abort();
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            //mythead = new Thread(myListen);
        }
    }
}
