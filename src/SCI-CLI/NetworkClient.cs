using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SCI_Logger;

namespace SCI_CLI
{
	internal class NetworkClient
	{
		private static string _data = string.Empty;

		public static string SendData(string dataIn)
		{
			_data = dataIn;
			byte[] bytes = new byte[1024];
			string response = string.Empty;
			try
			{
				Logging.Info($"Connecting to {Data.ServerIP}:{Data.ServerPort}");
				IPAddress ipAddress = IPAddress.Parse(Data.ServerIP);
				IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, Data.ServerPort);
				Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				try
				{
					sender.Connect(remoteEndPoint);
					if (sender.RemoteEndPoint != null)
					{
						//Logging.Info("Socket connected to " + sender.RemoteEndPoint.ToString());
						byte[] bDataToServer = Encoding.UTF8.GetBytes(_data + "<EOF>");
						int bytesSend = sender.Send(bDataToServer);
						int bytesReceive = sender.Receive(bytes);
						response = Encoding.UTF8.GetString(bytes, 0, bytesReceive);
					}
					sender.Shutdown(SocketShutdown.Both);
					sender.Close();
				}
				catch (Exception ex)
				{
					Logging.Error(ex.Message);
					return "null";
				}
			}
			catch (Exception ex)
			{
				Logging.Error(ex.Message);
				return "null";
			}
			return response;
		}
	}
}
