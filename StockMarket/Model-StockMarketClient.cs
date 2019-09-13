using System;
using System.Net;
using System.Net.Sockets;

namespace StockExchangeMarket
{
    public class StockMarketClient
    {
        IPAddress _serverIP;
        int _serverPort;
        Socket _mySocket;
        IPEndPoint _endPoint;

        // Client class
        public StockMarketClient()
        {
        }

    
        // set server IP
        public void setIP(string serverIP)
        {
            _serverIP = IPAddress.Parse(serverIP);
        }

        //Set Port
        public void setPort(int serverPort)
        {
            _serverPort = serverPort;
        }

        //Create the TCP Socket connection
        public void createSocket()
        {
            _endPoint = new IPEndPoint(_serverIP, _serverPort);
            _mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        //Connect the TCP Socket that was created
        public bool openConnection()
        {
            try
            {
                _mySocket.Connect(_endPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection error " + e);
            }
            return _mySocket.Connected;
        }

        // Close the connection
        public bool closeConnection()
        {
            try
            {
                _mySocket.Close();
           
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection error " + e);
            }
            return !(_mySocket.Connected);
        }
        // Register Function
        public string getResponse(string request)
        {
            string message = request;
            byte[] byteMessage = new byte[4096];
            byteMessage = System.Text.Encoding.UTF8.GetBytes(message);
            _mySocket.Send(byteMessage);

            //Create a byte array to store the response from the server
            byte[] response = new byte[4096];
            try
            {
                //Get the response and send it as a string back to the controller
                int t = _mySocket.Receive(response);
                string r = System.Text.Encoding.UTF8.GetString(response);
                return r;
            }
            catch (Exception e)
            {
                return "Response not received " + e;
            }
        }

    }
}
