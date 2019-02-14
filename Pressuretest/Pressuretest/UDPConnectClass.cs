using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;


namespace Common
{
    public class UDPConnectClass
    {
        public static bool UDP_Send(byte[] Send_Buf,string RemoteIP,int RemotePort,Socket sock)
        {
            try
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(RemoteIP),RemotePort);
                EndPoint Remote = iep;
                sock.SendTimeout = 200;
                sock.ReceiveTimeout = 200;
                sock.SendTo(Send_Buf,Send_Buf.Length,0,iep);

            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool UDP_Send_Recv(byte[] Send_Buf,byte[] Rece_Buf,string RemoteIP,int RemotePort,Socket sock)
        {
            try
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(RemoteIP),RemotePort);
                EndPoint Remote = (EndPoint)(iep);
                sock.SendTimeout = 100;
                sock.ReceiveTimeout = 100;
                sock.SendTo(Send_Buf,Send_Buf.Length,0,iep);
                Thread.Sleep(100);
                int recv = sock.ReceiveFrom(Rece_Buf,ref Remote);
               

                // Form1.str1 = Remote.ToString();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
