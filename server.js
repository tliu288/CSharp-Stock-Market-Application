// JavaScript source code
var net = require("net");
// Create a TCP socket listener
var server = net.createServer();

class Compnay {
    constructor(name, symbol, openPrice) {
        this.name = name;
        this.symbol = symbol;
        this.openPrice = openPrice;
        this.currentrice = 0;
        this.lastPrice = 0;
        this.volume = 0;
        this.BuyOrderList =[];
        this.SellOrderList=[];
    }
}

class SellOrder {
    constructor(orderPrice, orderSize) {
        this.orderSize = orderSize;
        this.orderPrice = orderPrice;
    }
}

class BuyOrder {
    constructor(orderPrice, orderSize) {
        this.orderSize = orderSize;
        this.orderPrice = orderPrice;
    }
}

function NotifyClient() {
    var serversocket = new net.Socket();
    serversocket.connect(3700);
    serversocket.write("Notify");
}

server.on("connection", function (socket) {
    var remoteAddress = socket.remoteAddress + ":" + socket.remotePort;
    console.log("A trader at (", remoteAddress, "): is connected.");
    // Session number
    var ProtocolName = " SME/TCP - 1.0";
    var CSeq = 1;
    var userName;
    var session = Math.floor(Math.random() * 200);

    

    // Hard code Real Time data, SellOrderList and BuyOrderList
    var RealTimeData = [];
    //var BuyOrderList = [];
    //var SellOrderList = [];
    // Initialize company infomation
    var MSFT = new Compnay('Microsoft Corporation', 'MSFT', '46.13');
    var APPL = new Compnay('Apple Inc', 'APPL', '105.22');
    var FB = new Compnay('Facebook Inc', 'FB', '80.67');
    RealTimeData.push(MSFT, APPL, FB);

    socket.on("data", function (d) {
        var response = "";
        // convert bytes to string
        var request = d.toString('utf8');
        console.log("----------------------------" + request.split(';')[0]+"------------------------------\n");

        // split request and extract infomation
        var requestType = request.split(';')[0];
        

            // Register Request handle
        if (requestType === "REGISTER") {
            // print screen server
            userName = request.split(';')[1];
            console.log(request.split(';')[1] + " requests: \n");
            console.log(requestType + ProtocolName + "\n");
            console.log("ID: " + request.split(';')[1] + " CSeq: " + String(CSeq) + " Notification Port: " + String(request.split(';')[2]) + ".\n");
            //Retrieve company information. Seperate with /
            RealTimeData.forEach(function (com) {
                response += com.symbol + '/';
                response += com.name + '/';
                response += com.openPrice + '/';
            });
            console.log("Server respond: \n");
            console.log(ProtocolName + " OK\n");
            console.log("CSeq: " + String(CSeq) + "  Session: " + session + "\n\n");
            socket.write(response);
        }

             // List Company response
        else if (requestType === "LISTCOMPANIES") {
            ++CSeq;
            console.log(userName + " requests: \n");
            console.log(requestType + ProtocolName + "\n");

            RealTimeData.forEach(function (com) {
                response += com.symbol + ';';
                response += com.name + ';';
                response += com.openPrice + ';';
                response += com.lastPrice + ';';
                response += com.volume + ';';
            });

            // Response Screen
            console.log("Server respond: \n");
            console.log(ProtocolName + " OK\n");
            console.log("CSeq: " + String(CSeq) + "  Session: " + session + "\n\n");
            socket.write(response);
        }

        // Client request to get all buy order
        else if (requestType === "LISTBUYORDER")
        {
            ++CSeq;
            // Request Title
            console.log(userName + " requests: \n");
            console.log(requestType + ProtocolName + "\n");
                            /*
            RealTimeData.forEach(function (com) {
                //Populate buy order for companies

                (com.BuyOrderList).forEach(function (bo) {
                    response += bo.orderPrice + '/';
                    response += bo.orderSize + '/';
                });
                response += ';';
            });
                */

            var whichcomrequest = request.split(';')[1];
            if (whichcomrequest === "MSFT") {
                (MSFT.BuyOrderList).forEach(function (bo) {
                    response += bo.orderPrice + '/';
                    response += bo.orderSize + '/';
                });
            }
            else if (whichcomrequest === "APPL") {
                (APPL.BuyOrderList).forEach(function (bo) {
                    response += bo.orderPrice + '/';
                    response += bo.orderSize + '/';
                });
            }
            else {
                (FB.BuyOrderList).forEach(function (bo) {
                    response += bo.orderPrice + '/';
                    response += bo.orderSize + '/';
                });
            }
                    

            if (response !== "") { response = response }
            else { response = "EMPTY" };

            // Response Screen
            console.log("\n\n " + response +"\n\n");
            console.log("Server respond: \n");
            console.log(ProtocolName + " OK\n");
            console.log("CSeq: " + String(CSeq) + "  Session: " + session+"\n\n");


            socket.write(response);
        }

        else if (requestType === "LISTSELLORDER")
        {
            ++CSeq;
            // Request Title
            console.log(userName + " requests: \n");
            console.log(requestType + ProtocolName + "\n");

            var whichcomrequest2 = request.split(';')[1];
            if (whichcomrequest2 === "MSFT") {
                (MSFT.SellOrderList).forEach(function (bo) {
                    response += bo.orderPrice + '/';
                    response += bo.orderSize + '/';
                });
            }
            else if (whichcomrequest2 === "APPL") {
                (APPL.SellOrderList).forEach(function (bo) {
                    response += bo.orderPrice + '/';
                    response += bo.orderSize + '/';
                });

            }
            else {
                (FB.SellOrderList).forEach(function (bo) {
                    response += bo.orderPrice + '/';
                    response += bo.orderSize + '/';
                });
            }

            if (response !== "") { response = response }
            else { response = "EMPTY" };

            // Response Screen
            console.log("Server respond: \n");
            console.log(ProtocolName + " OK\n");
            console.log("CSeq: " + String(CSeq) + "  Session: " + session + "\n\n");



            socket.write(response);
        }

            // Client request to bid order
        else if (requestType === "BUYORDER")
        {
            ++CSeq;
         
            // Request Title
            console.log(userName + " requests: \n");
            console.log(requestType + ProtocolName + "\n");
            console.log("Company: " + request.split(';')[3]+  " Buy Price: " + request.split(';')[1] + " Buy Size: " + String(request.split(';')[2]) + ".\n");

            // Add Buy Order to the list
            var newBuyOrder = new BuyOrder(parseInt(request.split(';')[1]), parseInt(request.split(';')[2]));

            var whichcompany = request.split(';')[3];

            if (whichcompany === "MSFT") {
                MSFT.BuyOrderList.push(newBuyOrder);
                MSFT.volume = MSFT.volume + parseInt(request.split(';')[2]);
                //console.log("Buy order added : (size)" + MSFT.BuyOrderList[0].orderSize + " (price)" + MSFT.BuyOrderList[0].orderPrice + "\n");
            }
            else if (whichcompany === "APPL") {
                APPL.BuyOrderList.push(newBuyOrder);
                APPL.volume = APPL.volume + parseInt(request.split(';')[2]);
                //console.log("Buy order added : (size)" + APPL.BuyOrderList[0].orderSize + " (price)" + APPL.BuyOrderList[0].orderPrice + "\n");
            }
            else {
                FB.BuyOrderList.push(newBuyOrder);
                FB.volume = FB.volume + parseInt(request.split(';')[2]);
                //console.log("Buy order added : (size)" + FB.BuyOrderList[0].orderSize + " (price)" + FB.BuyOrderList[0].orderPrice + "\n");
            }

            // Response Screen
            console.log("Server respond: \n");
            console.log(ProtocolName + " OK\n");
            console.log("CSeq: " + String(CSeq) + "  Session: " + session +"\n\n");
            socket.write("Buy order (price)" + request.split(';')[1] + " (size)" + request.split(';')[2] + " added successful to " + request.split(';')[3] + " in the server.\n");

            // After order is added, notify the client.
            NotifyClient();
            console.log("----------------------------NOFITY------------------------------\n");
            console.log("Server send: \n");
            console.log("NOTIFY " + ProtocolName + "\n");
        }
            // Client request to sell order
        else if (requestType === "SELLORDER")
        {
            ++CSeq;
            // Request Title
            console.log(userName + " requests: \n");
            console.log(requestType + ProtocolName + "\n");
            console.log("Company: " + request.split(';')[2] + " Sell Price: " + request.split(';')[1] + " Sell Size: " + String(request.split(';')[2]) + ".\n");

            // Add Sell Order to the list
            var newSellOrder = new SellOrder(parseInt(request.split(';')[1]), parseInt(request.split(';')[2]));


            // Determine Company
            var whichcompany2 = request.split(';')[3];
            if (whichcompany2 === "MSFT") {
                MSFT.SellOrderList.push(newSellOrder);
                // Add volumne to total volume
                MSFT.volume = MSFT.volume + parseInt(request.split(';')[2]);
                // Set last price to the price of sell added
                MSFT.lastPrice = parseInt(request.split(';')[1]);
            }
            else if (whichcompany2 === "APPL") {
                APPL.SellOrderList.push(newSellOrder);
                // Add volumne to total volume
                APPL.volume = APPL.volume + parseInt(request.split(';')[2]);
                // Set last price to the price of sell added
                APPL.lastPrice = parseInt(request.split(';')[1]);
            }
            else {
                FB.SellOrderList.push(newSellOrder);
                // Add volumne to total volume
                FB.volume = FB.volume + parseInt(request.split(';')[2]);
                // Set last price to the price of sell added
                FB.lastPrice = parseInt(request.split(';')[1]);
            }
            
            //console.log("Sell order added : (size)" + MSFT.SellOrderList[0].orderSize + " (price)" + MSFT.SellOrderList[0].orderPrice + "\n");
            // Response Screen
            console.log("Server respond: \n");
            console.log(ProtocolName + " OK\n");
            console.log("CSeq: " + String(CSeq) + "  Session: " + session + "\n\n");
            socket.write("Sell order (price)" + request.split(';')[1] + " (size)" + request.split(';')[2] + " added successful to " + request.split(';')[3] + " in the server.");

            // After order is added, notify the client.
            NotifyClient();
            console.log("----------------------------NOFITY------------------------------\n");
            console.log("Server send: \n");
            console.log("NOTIFY " + ProtocolName+"\n");
        }
        else if (requestType === "UNREGISTER")
        {
            ++CSeq;
            // Request Title
            console.log(userName + " requests: \n");
            console.log(requestType + ProtocolName + "\n");
            //socket.write()

            if (serversocket !== null) {
                serversocket.disconnect();
            }



        }
        else {

            response = "SME/TCP-1.0 FAIL";
            socket.write("Server respone: \n" + response);

        }

       
    });

    socket.once("close", function () {
        console.log("Trader " + userName + " at %s has left the session", remoteAddress);
    });

socket.on("error", function (err) {
    console.log("SME/TCP-1.0 FAIL");
});

});


server.listen(8000, function () {
    console.log("Stock Exchange Server available on 127.0.0.1:8000 \n\n");
});

