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

namespace StockExchangeMarket
{

    public partial class StockSecuritiesExchange : Form
    {

        StockMarketController control;


        string _userName;
        string _serverIP;
        int _serverPort;
        string _clientIP;
        int _clientPort;

        public TcpListener server = null;
        TcpClient Tcpclient;

        // Return server IP and port for creating the client
        public string getIP()
        {
            return serverIP.Text;
        }

        public int getPort()
        {
            return int.Parse(serverPort.Text);
        }

        public StockMarketController getControl()
        {
            return control;
        }

        RealTimedata Subject;
        public StockSecuritiesExchange()
        {
            InitializeComponent();
            control = new StockMarketController();
            this.stopTradingToolStripMenuItem.Enabled = false;

            //Open connection to the server when click Join
            _userName = clientName.Text;
            _clientIP = clientIP.Text;
            _clientPort = Int32.Parse(clientPort.Text);
            _serverIP = serverIP.Text;
            _serverPort = Int32.Parse(serverPort.Text);





        }

        private void beginTradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create three stocks and add them to the market
            Subject = new RealTimedata();

            control.openConnection(_userName,_serverIP, _serverPort);
            string res = control.Register(_userName,_clientPort);

            var split = res.Split('/');
            MessageBox.Show(res);
            // Add all companies to the list for the first time
            Subject.addCompany(split[0], split[1], double.Parse(split[2]));
            Subject.addCompany(split[3], split[4], double.Parse(split[5]));
            Subject.addCompany(split[6], split[7], double.Parse(split[8]));
            // In this lab assignment we will add three companies only using the following format:
            // Company symbol , Company name , Open price
            //Subject.addCompany("MSFT", "Microsoft Corporation", 46.13);
            //Subject.addCompany("AAPL", "Apple Inc.", 105.22);
            //Subject.addCompany("FB", "Facebook, Inc.", 80.67);

            this.watchToolStripMenuItem.Visible = true;
            this.ordersToolStripMenuItem.Visible = true;
            this.beginTradingToolStripMenuItem.Enabled = false;

            //Create a Tcp Listener
            IPAddress localAddr = IPAddress.Parse(_clientIP);
            server = new TcpListener(localAddr, _clientPort);

            server.Start();

            //Openconnection(_userName, _serverIP, _serverPort, _clientIP, _clientPort);

            this.stopTradingToolStripMenuItem.Enabled = true;
            this.marketToolStripMenuItem.Text = "&Join <<Connected>>";

            MarketDepthSubMenu(this.marketByOrderToolStripMenuItem1);
            MarketDepthSubMenu(this.marketByPriceToolStripMenuItem1);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StockStateSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockStateSummary summaryObserver = new StockStateSummary(Subject);
            summaryObserver.MdiParent = this;

            // Display the new form.
            summaryObserver.Show();



        }
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cascade all MDI child windows.
            this.LayoutMdi(MdiLayout.Cascade);
        }



        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tile all child forms vertically.
            this.LayoutMdi(MdiLayout.ArrangeIcons);

        }

        private void horizontalTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tile all child forms horizontally.
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tile all child forms vertically.
            this.LayoutMdi(MdiLayout.TileVertical);

        }

        private void stopTradingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.beginTradingToolStripMenuItem.Enabled = true;
            control.Unegister(_userName);
            this.stopTradingToolStripMenuItem.Enabled = false;
            this.watchToolStripMenuItem.Visible = false;
            this.ordersToolStripMenuItem.Visible = false;
            if (server != null)
            {
                server.Stop();
            }
            DisposeAllButThis(this);
        }


        public void DisposeAllButThis(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == form.GetType()
                    && frm != form)
                {
                    frm.Dispose();
                    frm.Close();
                }
            }
        }

        public void MarketDepthSubMenu(ToolStripMenuItem MnuItems)
        {
            ToolStripMenuItem SSSMenu;
            List<Company> StockCompanies = Subject.getCompanies();
            foreach (Company company in StockCompanies)
            {
                if (MnuItems.Name == "marketByPriceToolStripMenuItem1")
                    SSSMenu = new ToolStripMenuItem(company.Name, null, marketByPriceToolStripMenuItem_Click);
                else
                    SSSMenu = new ToolStripMenuItem(company.Name, null, marketByOrderToolStripMenuItem_Click);
                MnuItems.DropDownItems.Add(SSSMenu);
            }
        }

        public void marketByOrderToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
           
            MarketByOrder newMDIChild = new MarketByOrder(Subject, sender.ToString());
            // Set the parent form of the child window.
            newMDIChild.Text = "Market Depth By Order (" + sender.ToString() + ")";

            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }
        private void marketByPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarketByPrice newMDIChild = new MarketByPrice(Subject, sender.ToString());
            // Set the parent form of the child window.
        
            newMDIChild.Text = "Market Depth By Price (" + sender.ToString() + ")";

            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void bidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaceBidOrder newMDIChild = new PlaceBidOrder(Subject);
            // Set the parent form of the child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void askToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaceSellOrder newMDIChild = new PlaceSellOrder(Subject);
            // Set the parent form of the child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }
    }
}
