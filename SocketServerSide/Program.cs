// A C# Program for Server
using SocketServerSide;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
	
	class Program
	{
		public static  MsgCollections1 msgC = new MsgCollections1();

		// Main Method

		public static void Main(string[] args)
		{
			
			try
            {
				
				ExecuteServer();

			}
			catch(Exception e)
            {
				Console.WriteLine(e);
            }
		}
		
		public static void ExecuteServer()
		{
			try
			{
				// Establish the local endpoint for the socket. Dns.GetHostName returns the name of the host running the application.
				IPHostEntry ipHost = Dns.GetHostEntry("10.30.8.233");
				IPAddress ipAddr = ipHost.AddressList[0];
				IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 2689);
				// Creation TCP/IP Socket using Socket Class Constructor
				Socket listener = new Socket(ipAddr.AddressFamily,
							SocketType.Stream, ProtocolType.Tcp);
				try
				{
					// Using Bind() method we associate a network address to the Server Socket All client that will connect to this Server Socket must know this network
					// Address
					listener.Bind(localEndPoint);
					// Using Listen() method we create the Client list that will want to connect to Server
					listener.Listen(100);
					while (true)
					{
						Console.WriteLine("Waiting connection ... ");
						// Suspend while waiting for incoming connection Using Accept() method the server will accept connection of client
						Socket clientSocket = listener.Accept();
						// Data buffer
						byte[] bytes = new Byte[1024];
						string data = null;

						while (true)
						{
							int numByte = clientSocket.Receive(bytes);

							data += Encoding.ASCII.GetString(bytes,
													0, numByte);

							if (data.IndexOf("") > -1)
								msgC.StatusMessage();

							if(data == "?Status")
                            {
								msgC.appendMsgToReturn = msgC.MsgTosendBack[0].ToString();
								Console.WriteLine("Text received -> {0} ", data);
								byte[] message1 = Encoding.ASCII.GetBytes(msgC.appendMsgToReturn.ToString());
								// Send a message to Client using Send() method
								clientSocket.Send(message1);
								//msgC.appendMsgToReturn = msgC.MsgTosendBack[0].ToString();

							}
							if (data == "?VECode")
                            {
								msgC.appendMsgToReturn = msgC.MsgTosendBack[1].ToString();
								Console.WriteLine("Text received -> {0} ", data);
								byte[] message2 = Encoding.ASCII.GetBytes(msgC.appendMsgToReturn.ToString());
								// Send a message to Client using Send() method
								clientSocket.Send(message2);

								//msgC.appendMsgToReturn = msgC.MsgTosendBack[1].ToString();
							}
							if (data == "=Pressure")
							{
								msgC.appendMsgToReturn = msgC.MsgTosendBack[2].ToString();
								Console.WriteLine("Text received -> {0} ", data);
								byte[] message3 = Encoding.ASCII.GetBytes(msgC.appendMsgToReturn.ToString());
								// Send a message to Client using Send() method
								clientSocket.Send(message3);

							}

							if (data == "=WaterDischarge")
							{
								msgC.appendMsgToReturn = msgC.MsgTosendBack[3].ToString();
								Console.WriteLine("Text received -> {0} ", data);
								byte[] message4 = Encoding.ASCII.GetBytes(msgC.appendMsgToReturn.ToString());
								// Send a message to Client using Send() method
								clientSocket.Send(message4);
							}

							if (data == $"=VECode")
								{
								//msgC.appendMsgToReturn = msgC.MsgTosendBack[4].ToString();
								Console.WriteLine("Text received -> {0} ", data);
								byte[] message = Encoding.ASCII.GetBytes(msgC.appendMsgToReturn.ToString());
									// Send a message to Client using Send() method;
									clientSocket.Send(message);

								}

							break;                                  
						}
						// Close client Socket using the Close() method. After closing, we can use the closed Socket
						// for a new Client Connection
						clientSocket.Shutdown(SocketShutdown.Both);
						clientSocket.Close();
					}
				}

				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message.ToString());
			}
		}
	}
}

