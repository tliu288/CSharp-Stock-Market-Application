using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockExchangeMarket
{
    public partial class MarketByOrder : Form, StockMarketDisplay
    {
        RealTimedata StockMarket;
        String companyName;
        Company selectedCompany;

        StockSecuritiesExchange Mainform;
        StockMarketController control;


        public MarketByOrder(Object _subject, String Name)
        {
            Subject = _subject;
            companyName = Name;

            //Register itself as an observer
            StockMarket.Register(this);
            InitializeComponent();
            initialize();
        }

        public void loadControl()
        {
            Mainform = (StockSecuritiesExchange)this.MdiParent;
            control = (StockMarketController)Mainform.getControl();
        }


        public Object Subject
        {
            set
            {
                StockMarket = (RealTimedata)value;
            }
        }

        public void initialize()
        {
            ordersGrid.Rows.Clear();
            ordersGrid.Refresh();

            foreach (Company company in StockMarket.getCompanies())
            {
                if (company.Name == companyName)
                {
                    selectedCompany = company;
                    break;
                }
            }
            int i = 0;
            foreach (Order buyOrder in selectedCompany.getBuyOrders())
            {
                string[] row1 = { buyOrder.Size.ToString(), buyOrder.Price.ToString(), null, null };
                ordersGrid.Rows.Add(row1);
                i++;
                if (i == 10) break;
            }
            for (int j = i; j < 10; j++)
            {
                string[] row1 = { null, null, null, null };
                ordersGrid.Rows.Add(row1);
            }
            int k = 0;
            foreach (Order sellOrder in selectedCompany.getSellOrders())
            {
                ordersGrid[2, k].Value = sellOrder.Price.ToString();
                ordersGrid[3, k].Value = sellOrder.Size.ToString();
                k++;
                if (k == 10) break;
            }
        }

        public void update()
        {
            ordersGrid.Rows.Clear();
            ordersGrid.Refresh();

            foreach (Company company in StockMarket.getCompanies())
            {
                if (company.Name == companyName)
                {
                    selectedCompany = company;
                    break;
                }
            }

            this.loadControl();


            string buyres = control.ListBuyOrder(selectedCompany.Symbol);
            string sellres = control.ListSellOrder(selectedCompany.Symbol);


            if (buyres != "EMPTY" && sellres == "EMPTY")
            {
                MessageBox.Show("Buy list: \n" + buyres);
                var buysplit = buyres.Split('/');
                var buyorderlength = buysplit.Length;
                selectedCompany.populateBuy(buyorderlength, buysplit);
            }
            else if (buyres == "EMPTY" && sellres != "EMPTY") {
                MessageBox.Show("sell list: \n" + sellres);
                var sellsplit = sellres.Split('/');
                var sellorderlength = sellsplit.Length;
                selectedCompany.populateSell(sellorderlength, sellsplit);
            }
            else {
                var buysplit = buyres.Split('/');
                var buyorderlength = buysplit.Length;
                var sellsplit = sellres.Split('/');
                var sellorderlength = sellsplit.Length;
                selectedCompany.populateBoth(buyorderlength, sellorderlength, buysplit, sellsplit);
            }
       


            //MessageBox.Show("buy list: " + buyres + "sell list: " + sellres);
            //MessageBox.Show("length : " + (buyorderlength).ToString());

            int i = 0;
            foreach (Order buyOrder in selectedCompany.getBuyOrders())
            {
                string[] row1 = { buyOrder.Size.ToString(), buyOrder.Price.ToString(),null,null };
                ordersGrid.Rows.Add(row1);
                i++;
                if (i == 10) break;
            }
            for (int j=i; j<10; j++){
                string[] row1 = { null, null, null, null };
                ordersGrid.Rows.Add(row1);
            }
            int k = 0;
            foreach (Order sellOrder in selectedCompany.getSellOrders())
            {
                ordersGrid[2, k].Value = sellOrder.Price.ToString();
                ordersGrid[3, k].Value = sellOrder.Size.ToString();
                k++;
                if (k == 10) break;
            }
        }

        private void MarketByOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            StockMarket.unRegister(this);
        }
    }
}
