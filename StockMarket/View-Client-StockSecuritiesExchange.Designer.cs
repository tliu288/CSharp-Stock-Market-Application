namespace StockExchangeMarket
{
    partial class StockSecuritiesExchange
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockSecuritiesExchange));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.marketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beginTradingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTradingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockStateSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marketByOrderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.marketByPriceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.askToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CName = new System.Windows.Forms.Label();
            this.clientName = new System.Windows.Forms.TextBox();
            this.clientIP = new System.Windows.Forms.TextBox();
            this.clientPort = new System.Windows.Forms.TextBox();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.serverPort = new System.Windows.Forms.TextBox();
            this.CIP = new System.Windows.Forms.Label();
            this.CPORT = new System.Windows.Forms.Label();
            this.SIP = new System.Windows.Forms.Label();
            this.SPORT = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marketToolStripMenuItem,
            this.watchToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(2238, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // marketToolStripMenuItem
            // 
            this.marketToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beginTradingToolStripMenuItem,
            this.stopTradingToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.marketToolStripMenuItem.Name = "marketToolStripMenuItem";
            this.marketToolStripMenuItem.Size = new System.Drawing.Size(286, 36);
            this.marketToolStripMenuItem.Text = "&Join <<Disconnected>>";
            // 
            // beginTradingToolStripMenuItem
            // 
            this.beginTradingToolStripMenuItem.Name = "beginTradingToolStripMenuItem";
            this.beginTradingToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.beginTradingToolStripMenuItem.Text = "Register";
            this.beginTradingToolStripMenuItem.Click += new System.EventHandler(this.beginTradingToolStripMenuItem_Click);
            // 
            // stopTradingToolStripMenuItem
            // 
            this.stopTradingToolStripMenuItem.Name = "stopTradingToolStripMenuItem";
            this.stopTradingToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.stopTradingToolStripMenuItem.Text = "Unregister";
            this.stopTradingToolStripMenuItem.Click += new System.EventHandler(this.stopTradingToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(265, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // watchToolStripMenuItem
            // 
            this.watchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockStateSummaryToolStripMenuItem,
            this.marketByOrderToolStripMenuItem1,
            this.marketByPriceToolStripMenuItem1});
            this.watchToolStripMenuItem.Name = "watchToolStripMenuItem";
            this.watchToolStripMenuItem.Size = new System.Drawing.Size(93, 36);
            this.watchToolStripMenuItem.Text = "Watc&h";
            this.watchToolStripMenuItem.Visible = false;
            // 
            // stockStateSummaryToolStripMenuItem
            // 
            this.stockStateSummaryToolStripMenuItem.Name = "stockStateSummaryToolStripMenuItem";
            this.stockStateSummaryToolStripMenuItem.Size = new System.Drawing.Size(339, 38);
            this.stockStateSummaryToolStripMenuItem.Text = "&Stock State Summary";
            this.stockStateSummaryToolStripMenuItem.Click += new System.EventHandler(this.StockStateSummaryToolStripMenuItem_Click);
            // 
            // marketByOrderToolStripMenuItem1
            // 
            this.marketByOrderToolStripMenuItem1.Name = "marketByOrderToolStripMenuItem1";
            this.marketByOrderToolStripMenuItem1.Size = new System.Drawing.Size(339, 38);
            this.marketByOrderToolStripMenuItem1.Text = "Market By &Order";
            // 
            // marketByPriceToolStripMenuItem1
            // 
            this.marketByPriceToolStripMenuItem1.Name = "marketByPriceToolStripMenuItem1";
            this.marketByPriceToolStripMenuItem1.Size = new System.Drawing.Size(339, 38);
            this.marketByPriceToolStripMenuItem1.Text = "Market By &Price";
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bidToolStripMenuItem,
            this.askToolStripMenuItem});
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(98, 36);
            this.ordersToolStripMenuItem.Text = "&Orders";
            this.ordersToolStripMenuItem.Visible = false;
            // 
            // bidToolStripMenuItem
            // 
            this.bidToolStripMenuItem.Name = "bidToolStripMenuItem";
            this.bidToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.bidToolStripMenuItem.Text = "&Bid";
            this.bidToolStripMenuItem.Click += new System.EventHandler(this.bidToolStripMenuItem_Click);
            // 
            // askToolStripMenuItem
            // 
            this.askToolStripMenuItem.Name = "askToolStripMenuItem";
            this.askToolStripMenuItem.Size = new System.Drawing.Size(268, 38);
            this.askToolStripMenuItem.Text = "&Ask";
            this.askToolStripMenuItem.Click += new System.EventHandler(this.askToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.horizontalTileToolStripMenuItem,
            this.verticalTileToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(124, 36);
            this.windowsToolStripMenuItem.Text = "&Windows";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // horizontalTileToolStripMenuItem
            // 
            this.horizontalTileToolStripMenuItem.Name = "horizontalTileToolStripMenuItem";
            this.horizontalTileToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.horizontalTileToolStripMenuItem.Text = "Horizontal Tile";
            this.horizontalTileToolStripMenuItem.Click += new System.EventHandler(this.horizontalTileToolStripMenuItem_Click);
            // 
            // verticalTileToolStripMenuItem
            // 
            this.verticalTileToolStripMenuItem.Name = "verticalTileToolStripMenuItem";
            this.verticalTileToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.verticalTileToolStripMenuItem.Text = "Vertical Tile ";
            this.verticalTileToolStripMenuItem.Click += new System.EventHandler(this.verticalTileToolStripMenuItem_Click);
            // 
            // CName
            // 
            this.CName.AutoSize = true;
            this.CName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CName.Location = new System.Drawing.Point(814, 12);
            this.CName.Name = "CName";
            this.CName.Size = new System.Drawing.Size(68, 25);
            this.CName.TabIndex = 2;
            this.CName.Text = "Name";
            // 
            // clientName
            // 
            this.clientName.Location = new System.Drawing.Point(902, 9);
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(139, 31);
            this.clientName.TabIndex = 3;
            this.clientName.Text = "Alice";
            // 
            // clientIP
            // 
            this.clientIP.Location = new System.Drawing.Point(1145, 9);
            this.clientIP.Name = "clientIP";
            this.clientIP.Size = new System.Drawing.Size(193, 31);
            this.clientIP.TabIndex = 4;
            this.clientIP.Text = "127.0.0.1";
            // 
            // clientPort
            // 
            this.clientPort.Location = new System.Drawing.Point(1462, 6);
            this.clientPort.Name = "clientPort";
            this.clientPort.Size = new System.Drawing.Size(100, 31);
            this.clientPort.TabIndex = 5;
            this.clientPort.Text = "3700";
            // 
            // serverIP
            // 
            this.serverIP.Location = new System.Drawing.Point(1696, 6);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(169, 31);
            this.serverIP.TabIndex = 6;
            this.serverIP.Text = "127.0.0.1";
            // 
            // serverPort
            // 
            this.serverPort.Location = new System.Drawing.Point(2013, 6);
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(99, 31);
            this.serverPort.TabIndex = 7;
            this.serverPort.Text = "8000";
            // 
            // CIP
            // 
            this.CIP.AutoSize = true;
            this.CIP.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CIP.Location = new System.Drawing.Point(1047, 9);
            this.CIP.Name = "CIP";
            this.CIP.Size = new System.Drawing.Size(92, 25);
            this.CIP.TabIndex = 8;
            this.CIP.Text = "Client IP";
            // 
            // CPORT
            // 
            this.CPORT.AutoSize = true;
            this.CPORT.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CPORT.Location = new System.Drawing.Point(1344, 12);
            this.CPORT.Name = "CPORT";
            this.CPORT.Size = new System.Drawing.Size(112, 25);
            this.CPORT.TabIndex = 9;
            this.CPORT.Text = "Client Port";
            // 
            // SIP
            // 
            this.SIP.AutoSize = true;
            this.SIP.ForeColor = System.Drawing.SystemColors.Highlight;
            this.SIP.Location = new System.Drawing.Point(1590, 9);
            this.SIP.Name = "SIP";
            this.SIP.Size = new System.Drawing.Size(100, 25);
            this.SIP.TabIndex = 10;
            this.SIP.Text = "Server IP";
            // 
            // SPORT
            // 
            this.SPORT.AutoSize = true;
            this.SPORT.ForeColor = System.Drawing.SystemColors.Highlight;
            this.SPORT.Location = new System.Drawing.Point(1887, 9);
            this.SPORT.Name = "SPORT";
            this.SPORT.Size = new System.Drawing.Size(120, 25);
            this.SPORT.TabIndex = 11;
            this.SPORT.Text = "Server Port";
            // 
            // StockSecuritiesExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2238, 1010);
            this.Controls.Add(this.SPORT);
            this.Controls.Add(this.SIP);
            this.Controls.Add(this.CPORT);
            this.Controls.Add(this.CIP);
            this.Controls.Add(this.serverPort);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.clientPort);
            this.Controls.Add(this.clientIP);
            this.Controls.Add(this.clientName);
            this.Controls.Add(this.CName);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "StockSecuritiesExchange";
            this.Text = "Stock Security Exchange";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem marketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalTileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalTileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beginTradingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTradingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem watchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockStateSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marketByOrderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem marketByPriceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem askToolStripMenuItem;
        private System.Windows.Forms.Label CName;
        private System.Windows.Forms.TextBox clientName;
        private System.Windows.Forms.TextBox clientIP;
        private System.Windows.Forms.TextBox clientPort;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.TextBox serverPort;
        private System.Windows.Forms.Label CIP;
        private System.Windows.Forms.Label CPORT;
        private System.Windows.Forms.Label SIP;
        private System.Windows.Forms.Label SPORT;
    }
}