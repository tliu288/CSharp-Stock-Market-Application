﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace StockExchangeMarket 
{
    public partial class StockStateSummary : Form, StockMarketDisplay
    {
        RealTimedata StockMarket;
        Bitmap upImage;
        Bitmap downImage;
        Bitmap noChange;
        StockSecuritiesExchange Mainform;
        StockMarketController control;

        public StockStateSummary(Object _subject)
        {
            Subject = _subject;
            //Register itself as an observer
            StockMarket.Register(this);
            InitializeComponent();

            try
            {
                upImage = new Bitmap(this.Icons.Images[1]);
            }
            catch (Exception)
            {

                upImage = null;
            }
            try
            {
                downImage = new Bitmap(this.Icons.Images[0]);
            }
            catch (Exception)
            {

                downImage = null;
            }
            try
            {
                noChange = new Bitmap(this.Icons.Images[2]);
            }
            catch (Exception)
            {

                noChange = null;
            }

            initialize();

        }

        public Object Subject
        {
            set
            {
                StockMarket = (RealTimedata) value;
            }
        }

        // Same as update, but it get called when form is created
        public void initialize()
        {
            summaryGrid.Rows.Clear();
            summaryGrid.Refresh();

            List<Company> StockCompanies = StockMarket.getCompanies();

            int i = 0;
            foreach (Company company in StockCompanies)
            {
                double changeNet;
                double changePer;
                int volume;
                Bitmap sign;
                sign = noChange;

                if (company.lastSale == 0)
                {
                    changeNet = 0;
                    changePer = 0;
                }
                else
                {
                    changeNet = company.lastSale - company.OpenPrice;
                    if (changeNet < 0) sign = downImage;
                    else if (changeNet > 0) sign = upImage;

                    changeNet = Math.Abs(company.lastSale - company.OpenPrice);
                    changePer = (changeNet / company.OpenPrice) * 100;
                }
                volume = company.getVolume();

                string[] row = { company.Name, company.Symbol, company.OpenPrice.ToString(), company.lastSale.ToString(), changeNet.ToString(), null, changePer.ToString("00.00"), volume.ToString() };
                summaryGrid.Rows.Add(row);
                summaryGrid[5, i].Value = sign;
                i++;
            }

        }

        public void loadControl()
        {
            Mainform = (StockSecuritiesExchange)this.MdiParent;
            control = (StockMarketController)Mainform.getControl();
        }


        // update function
        public void update()
        {
            summaryGrid.Rows.Clear();
            summaryGrid.Refresh();

            this.loadControl();
            string res = control.ListCompany();
            MessageBox.Show(res);

            var split = res.Split(';');

            StockMarket.getCompanies()[0].lastSale = double.Parse(split[3]);
            StockMarket.getCompanies()[0].Volume = Int32.Parse(split[4]);
            StockMarket.getCompanies()[1].lastSale = double.Parse(split[8]);
            StockMarket.getCompanies()[1].Volume = Int32.Parse(split[9]);
            StockMarket.getCompanies()[2].lastSale = double.Parse(split[13]);
            StockMarket.getCompanies()[2].Volume = Int32.Parse(split[14]);

            List<Company> StockCompanies = StockMarket.getCompanies();
  


            int i = 0;
            foreach (Company company in StockCompanies)
            {
                double changeNet;
                double changePer;
                int volume;
                Bitmap sign;
                sign = noChange;

                if (company.lastSale == 0)
                {
                    changeNet = 0;
                    changePer = 0;
                }
                else
                {
                    changeNet = company.lastSale - company.OpenPrice;
                    if (changeNet < 0) sign = downImage;
                    else if (changeNet > 0) sign = upImage;

                    changeNet = Math.Abs(company.lastSale - company.OpenPrice);
                    changePer = (changeNet / company.OpenPrice) * 100;
                }
                volume = company.getVolume();

                string[] row = { company.Name, company.Symbol, company.OpenPrice.ToString(), company.lastSale.ToString(), changeNet.ToString(), null, changePer.ToString("00.00"), volume.ToString() };
                summaryGrid.Rows.Add(row);
                summaryGrid[5, i].Value = sign;
                i++;
            }

        }

        private void StockStateSummary_FormClosed(object sender, FormClosedEventArgs e)
        {
            StockMarket.unRegister(this);
        }
    }
}
