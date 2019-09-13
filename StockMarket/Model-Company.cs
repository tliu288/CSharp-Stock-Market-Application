using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchangeMarket
{
    public class Company
    {

        private String _symbol;
        private String _name;
        private Double _openPrice;
        private Double _closePrice;
        private Double _currentPrice;
        private StockMarket market;
        private int _volume;
        private List<Order> BuyOrders = new List<Order>();
        private List<Order> SellOrders = new List<Order>();
        private List<Order> Transactions = new List<Order>();


        public Company(String symbol, String _name, double openPrice, StockMarket handledBy)
        {
            this._symbol = symbol;
            this._openPrice = openPrice;
            this._closePrice = 0;
            this._currentPrice = 0;
            this._volume = 0;
            this.market = handledBy;
            this._name = _name;
        }

        // Gets or sets the price
        public double lastSale
        {
            get { return _currentPrice; }
            set
            {
                if (_currentPrice != value)
                {
                    _currentPrice = value;
                    //market.Notify();
                }
            }
        }

        public double OpenPrice
        {
            get { return _openPrice; }
            set { _openPrice = value; }
        }

        public double ClosePrice
        {
            get { return _closePrice; }
            set { _closePrice = value; }
        }

        public String Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }



        public void addBuyOrder(Double buy_price, int buy_size)
        {
            if (SellOrders.Count > 0)
            {
  //              var SortedSellOrders = SellOrders.OrderBy(SellOrder => SellOrder.Price).ThenBy(SellOrder => SellOrder.TimeStamp).ToList();
  //              SellOrders = SortedSellOrders;



                BuyOrder sale;
                foreach (SellOrder sell_order in SellOrders)
                {
                    // if we have sell order with the same price do the trasaction and add it into Transaction list
                    if (buy_price >= sell_order.Price)
                    {
                        if (sell_order.Size == buy_size)
                        {
                            // do full transacqion
                            // do not add to buyOrders list
                            // remove sellOrder from the sellOrders list
                            sale = new BuyOrder(buy_price, buy_size);
                            Transactions.Add(sale);
                            SellOrders.Remove(sell_order);
                            lastSale = buy_price;
                            break;
                            //                        market.Notify();
                        }
                        else if (sell_order.Size > buy_size)
                        {
                            // do partial transacqion
                            // do not add to buyOrders list
                            // update sellOrder size to the remaining size in sellOrders list
                            int remainingSize = sell_order.Size - buy_size;
                            sale = new BuyOrder(buy_price, buy_size);
                            Transactions.Add(sale);
                            sell_order.Size = remainingSize;
                            lastSale = buy_price;
                            break;
                            //                           market.Notify();
                        }
                        else if (sell_order.Size < buy_size)
                        {
                            // do partial transacqion
                            // remove sellOrder from the sellOrders list
                            // add to buyOrders for the remaining size in buyOrders list
                            int remainingSize = buy_size - sell_order.Size;
                            sale = new BuyOrder(buy_price, sell_order.Size);
                            Transactions.Add(sale);
                            SellOrders.Remove(sell_order);

                            //BuyOrder buyOrder = new BuyOrder(buy_price, remainingSize);
                            //BuyOrders.Add(buyOrder);
                            //var SortedBuyOrders = BuyOrders.OrderByDescending(BuyOrder => BuyOrder.Price).ThenBy(BuyOrder => BuyOrder.TimeStamp).ToList();
                            //BuyOrders = SortedBuyOrders;

                            lastSale = buy_price;
                            addBuyOrder(buy_price, remainingSize);
                                
                                
                                break;
                            //                        market.Notify();
                        }
                    }
                    else
                    {
                        BuyOrder buyOrder = new BuyOrder(buy_price, buy_size);
                        BuyOrders.Add(buyOrder);
                        var SortedBuyOrders = BuyOrders.OrderByDescending(BuyOrder => BuyOrder.Price).ThenBy(BuyOrder => BuyOrder.TimeStamp).ToList();
                        BuyOrders = SortedBuyOrders;
                        break;
                        //                   market.Notify();
                    }
                }
            }
            else
            {
                BuyOrder buyOrder = new BuyOrder(buy_price, buy_size);
                BuyOrders.Add(buyOrder);
                var SortedBuyOrders = BuyOrders.OrderByDescending(BuyOrder => BuyOrder.Price).ThenBy(BuyOrder => BuyOrder.TimeStamp).ToList();
                BuyOrders = SortedBuyOrders;
            }
            //market.Notify();
        }

        public void runUpdate()
        {
            market.Notify();
        }

        public void addSellOrder(Double sale_price, int sale_size)
        {
            if (BuyOrders.Count > 0)
            {

//                var SortedBuyOrders = BuyOrders.OrderByDescending(BuyOrder => BuyOrder.Price).ThenBy(BuyOrder => BuyOrder.TimeStamp).ToList();
//                BuyOrders = SortedBuyOrders;

                SellOrder sale;
                foreach (BuyOrder buy_order in BuyOrders)
                {
                    // if we have buy order with the same price do the trasaction and add it into Transaction list
                    if (buy_order.Price >= sale_price)
                    {
                        if (buy_order.Size == sale_size)
                        {
                            // do full transacqion
                            // do not add to sellOrders list
                            // remove buyOrder from the buyOrders list
                            sale = new SellOrder(sale_price, sale_size);
                            Transactions.Add(sale);
                            BuyOrders.Remove(buy_order);
                            lastSale = sale_price;
                            break;
                        }
                        else if (buy_order.Size > sale_size)
                        {
                            // do partial transacqion
                            // do not add to sellOrders list
                            // update buyOrder size to the remaining size in buyOrders list
                            int remainingSize = buy_order.Size - sale_size;
                            sale = new SellOrder(sale_price, sale_size);
                            Transactions.Add(sale);
                            buy_order.Size = remainingSize;
                            lastSale = sale_price;
                            break;
                        }
                        else if (buy_order.Size < sale_size)
                        {
                            // do partial transacqion
                            // remove buyOrder from the buyOrders list
                            // add to sellOrders for the remaining size in sellOrders list
                            int remainingSize = sale_size - buy_order.Size;
                            sale = new SellOrder(sale_price, buy_order.Size);
                            Transactions.Add(sale);                      
                            BuyOrders.Remove(buy_order);
                            lastSale = sale_price;
                            
                            addSellOrder(sale_price, remainingSize);                
                            
                            break;


                       //     SellOrder sellOrder = new SellOrder(sale_price, remainingSize);
                       //     SellOrders.Add(sellOrder);
                      //      var SortedSellOrders = SellOrders.OrderBy(SellOrder => SellOrder.Price).ThenBy(SellOrder => SellOrder.TimeStamp).ToList();
                       //     SellOrders = SortedSellOrders;                    
                        }
                    }
                    else
                    {
                        SellOrder sellOrder = new SellOrder(sale_price, sale_size);
                        SellOrders.Add(sellOrder);
                        var SortedSellOrders = SellOrders.OrderBy(SellOrder => SellOrder.Price).ThenBy(SellOrder => SellOrder.TimeStamp).ToList();
                        SellOrders = SortedSellOrders;
                        break;
                    }
                }
            }
            else
            {
                SellOrder sellOrder = new SellOrder(sale_price, sale_size);
                SellOrders.Add(sellOrder);
                var SortedSellOrders = SellOrders.OrderBy(SellOrder => SellOrder.Price).ThenBy(SellOrder => SellOrder.TimeStamp).ToList();
                SellOrders = SortedSellOrders;
            }
           // market.Notify();

            
        }

        public void populateBuy(int BuyOrderLengh, string[] buyOrder)
        {
            this.BuyOrders.Clear();
            this.SellOrders.Clear();
            this.Transactions.Clear();
            int buyindex = 0;
            int i = 0;
            while (buyindex < (BuyOrderLengh - 1) / 2)
            {
                this.addBuyOrder(Double.Parse(buyOrder[i]), Int32.Parse(buyOrder[i + 1]));
                i += 2;
                buyindex++;
            }
        }

        public void populateSell(int SellOrderLengh, string[] sellOrder)
        {
            this.BuyOrders.Clear();
            this.SellOrders.Clear();
            this.Transactions.Clear();
            int sellindex = 0;
            int i = 0;
            while (sellindex < (SellOrderLengh - 1) / 2)
            {
                this.addBuyOrder(Double.Parse(sellOrder[i]), Int32.Parse(sellOrder[i + 1]));
                i += 2;
                sellindex++;
            }
        }

        public void populateBoth(int BuyOrderLengh,int SellOrderLengh, string[] buyOrder, string[] sellOrder)
        {
            this.BuyOrders.Clear();
            this.SellOrders.Clear();
            this.Transactions.Clear();

            int buyindex = 0;
            int sellindex = 0;
            int i = 0;
            int j = 0;
 
            while (buyindex < (BuyOrderLengh-1)/2)
            {
                this.addBuyOrder(Double.Parse(buyOrder[i]), Int32.Parse(buyOrder[i+1]));
                i+=2;
                buyindex++;
            }

            
            while (sellindex < (SellOrderLengh-1)/2)
            {
                this.addSellOrder(Double.Parse(sellOrder[j]), Int32.Parse(sellOrder[j + 1]));
                j+=2;
                sellindex++;
            }
           
        }

        public List<Order> getBuyOrders()
        {
            return BuyOrders;
        }
        public List<Order> getSellOrders()
        {
            return SellOrders;
        }
        public int getVolume()
        {
            int shareVolume = 0;
            foreach (Order deal in Transactions)
            {
                shareVolume += deal.Size;
            }
            return Volume;
        }
    }
}
