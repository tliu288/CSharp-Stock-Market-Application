using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace StockExchangeMarket
{
    
    public class StockMarketController
    {
        // Create form instances in the controller
        StockMarketClient client = new StockMarketClient();

        // variable declaration
        int CSeq;

        //Default controller
        public StockMarketController()
        {
        }

        public void openConnection(string name, string serverIP, int serverPort)
        {

            // Return server port and IP for creating the client
            //client.setIP(Mainform.getIP());
            //client.setPort(Mainform.getPort());

            client.setIP(serverIP);
            client.setPort(serverPort); 

            // create Socket    
            client.createSocket();

            if (client.openConnection() == true)
            {
                MessageBox.Show(name + " has successfully connected.");
            }
        }

        public string Register(string userName, int clientPort)
        {
            string request = "REGISTER;" + userName + ';' + (clientPort).ToString(); 
            string response = client.getResponse(request);

            if (response != "")
            {
                var split = response.Split('/');
                //MessageBox.Show((split[2].GetType()).ToString());
                // Console.Write(response);
                //MessageBox.Show((split.Length).ToString());
            }
            return response;
        }

        public string ListCompany()
        {
            string request = "LISTCOMPANIES;SME/TCP-1.0";
            string response = client.getResponse(request);
            return response;
        }

        public string ListBuyOrder(string companyname)
        {
            string request = "LISTBUYORDER;" + companyname + ";SME/TCP-1.0";
            string response = client.getResponse(request);
            return response;
        }

        public string ListSellOrder(string companyname)
        {
            string request = "LISTSELLORDER;"+ companyname +";SME/TCP-1.0";
            string response = client.getResponse(request);
            return response;
        }

        public void BuyOrder(double buy_price, int buy_size,string company_name)
        {
            string request = "BUYORDER" + ';' + buy_price + ';' + buy_size + ';' + company_name;
            string response = client.getResponse(request);
            MessageBox.Show(response);
        }

        // Sell Order Request
        public void SellOrder(double sell_price, int sell_size, string company_name)
        {
            string request = "SELLORDER" + ';' + sell_price + ';' + sell_size+';'+ company_name;
            string response = client.getResponse(request);
            MessageBox.Show(response);
        }

        // Unregister Request
        public void Unegister(string userName)
        {
            CSeq = 1;
            string request = "UNREGISTER SME/TCP-1.0" + "ID: " + userName + "CSeq: " + Convert.ToString(CSeq);
            string response = client.getResponse(request);
            


            if (response != "")
            {
                MessageBox.Show(response);
            }

            if (client.closeConnection() == true)
            {
                MessageBox.Show(userName + " has successfully left the session.");
            }
        }

        
    }
}
