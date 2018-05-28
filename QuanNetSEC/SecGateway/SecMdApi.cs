using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Text.RegularExpressions;
using QuanNetCommon.Gateway;
using QuanNetCommon;

namespace QuanNetSEC.SecGateway
{
    public class SecMdApi : SECMDI, IMdApi
    {
        //内部变量
        private CancellationTokenSource cts;
        private int processorNumber;
        private static readonly List<Delegate> ListDele = new List<Delegate>();

        # region 属性设置

        private string userID;
        private string password;

        private string mdAddress;
        private string brokerID;

        private int frontID;
        private int sessionID;
        private int reqID = 0;
        private ConnectionStatus stockConnectStatus;
        private ConnectionStatus optionConnectStatus;
        public string UserID
        {
            get
            {
                return userID;
            }
            private set
            {
                userID = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            private set
            {
                password = value;
            }
        }

        public string MdAddress
        {
            get
            {
                return mdAddress;
            }
            private set
            {
                mdAddress = value;
            }
        }

        public string BrokerID
        {
            get
            {
                return brokerID;
            }
            private set
            {
                brokerID = value;
            }
        }

        public ConnectionStatus StockConnectStatus
        {
            get
            {
                return stockConnectStatus;
            }
            private set
            {
                stockConnectStatus = value;
            }
        }

        public ConnectionStatus OptionConnectStatus
        {
            get
            {
                return optionConnectStatus;
            }
            private set
            {
                optionConnectStatus = value;
            }
        }

        public int FrontID
        {
            get
            {
                return frontID;
            }
            private set
            {
                frontID = value;
            }
        }

        public int SessionID
        {
            get
            {
                return sessionID;
            }
            private set
            {
                sessionID = value;
            }
        }
        # endregion

        //构造函数
        public SecMdApi(string userID1, string password1, string mdAddress1, SecGateway gateway, string pFile = "./sec_dll/SecMdi.dll")
            : base(pFile)
        {
            //初始化
            this.cts = new CancellationTokenSource();
            this.processorNumber = 1000;
            this.UserID = userID1;
            this.Password = password1;

            this.MdAddress = mdAddress1;
                stockConnectStatus= ConnectionStatus.Disconnected;
                optionConnectStatus=ConnectionStatus.Disconnected;

            //注册回调
            this.SetOnFrontConnected((DeleOnFrontConnected)AddDele(new DeleOnFrontConnected(SecMdApi_OnFrontConnected)));
            this.SetOnFrontDisconnected((DeleOnFrontDisconnected)AddDele(new DeleOnFrontDisconnected(SecMdApi_OnFrontDisconnected)));
            this.SetOnRtnNotice((DeleOnRtnNotice)AddDele(new DeleOnRtnNotice(SecMdApi_OnRtnNotice)));
            this.SetOnRspError((DeleOnRspError)AddDele(new DeleOnRspError(SecMdApi_OnRspError)));
            this.SetOnRspStockUserLogin((DeleOnRspStockUserLogin)AddDele(new DeleOnRspStockUserLogin(SecMdApi_OnRspStockUserLogin)));

            this.SetOnRspSOPUserLogin((DeleOnRspSOPUserLogin)AddDele(new DeleOnRspSOPUserLogin(SecMdApi_OnRspSOPUserLogin)));
            this.SetOnRspSOPSubMarketData((DeleOnRspSOPSubMarketData)AddDele(new DeleOnRspSOPSubMarketData(SecMdApi_OnRspSOPSubMarketData)));
            this.SetOnRspStockSubMarketData((DeleOnRspStockSubMarketData)AddDele(new DeleOnRspStockSubMarketData(SecMdApi_OnRspStockSubMarketData)));
            this.SetOnStockMarketData((DeleOnStockMarketData)AddDele(new DeleOnStockMarketData(SecMdApi_OnStockMarketData)));
            this.SetOnSOPMarketData((DeleOnSOPMarketData)AddDele(new DeleOnSOPMarketData(SecMdApi_OnSOPMarketData)));

        }


        Delegate AddDele(Delegate d) { ListDele.Add(d); return d; }

        //属性
        public int nTimeLapse { get; private set; }
        public string Error { get; private set; }
        public int ProcessorNumber { get { return processorNumber; } set { processorNumber = value; } }
        public CancellationTokenSource CTS { get { return cts; } }




        /// <summary>
        /// 服务器连接
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="CancelToken"></param>
        /// <returns></returns>
        public async Task AsyncConnect(CancellationToken CancelToken)
        {

            if (stockConnectStatus == ConnectionStatus.Connected || stockConnectStatus == ConnectionStatus.Connecting)
            {
                return;
            }

            int result = (int)this.Init(this.mdAddress);
    
            while (stockConnectStatus != ConnectionStatus.Connected && optionConnectStatus != ConnectionStatus.Connected)
            {
                await Task.Delay(100);
                CancelToken.ThrowIfCancellationRequested();
            }

        }

        public async Task AsyncLogin(CancellationToken CancelToken)
        {
            DFITCSECReqUserLoginField req = new DFITCSECReqUserLoginField();
            req.accountID = this.UserID;
            req.password = this.Password;
            this.reqID += 1;
            req.requestID = this.reqID;
            int result1 = (int)this.ReqSOPUserLogin(req);
            this.reqID += 1;
            req.requestID = this.reqID;
            int result2 = (int)this.ReqStockUserLogin(req);

            stockConnectStatus = ConnectionStatus.Logining;
            optionConnectStatus = ConnectionStatus.Logining;

            while (optionConnectStatus != ConnectionStatus.Logined && stockConnectStatus != ConnectionStatus.Logined)
            {
                await Task.Delay(100);
                CancelToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        /// 订阅行情
        /// </summary>
        /// <param name="pInstrument"></param>
        /// <returns></returns>
        public int Subscribe(params string[] pInstrument)
        {
            this.reqID += 1;
            int size = Marshal.SizeOf(typeof(IntPtr));
            IntPtr insts = Marshal.AllocHGlobal(size * pInstrument.Length);
            var tmp = insts;
            foreach (string instrumentID in pInstrument)
            {
                if (!MainData.DicMarketData.Keys.Contains(instrumentID))
                {
                    var tick = new TickData();
                    MainData.AllMarketData.Insert(0, tick);
                    MainData.DicMarketData.TryAdd(instrumentID, tick);
                }
            }
            for (int i = 0; i < pInstrument.Length; i++, tmp += size)
            {
                var contract = MainData.DicContract[pInstrument[i]];
                pInstrument[i] = contract.exchange + pInstrument[i];
                Marshal.StructureToPtr(Marshal.StringToHGlobalAnsi(pInstrument[i]), tmp, false);
            }
            return (int)this.SubscribeSOPMarketData(insts, pInstrument.Length, this.reqID);
        }

        /// <summary>
        /// 订阅行情
        /// </summary>
        /// <param name="pInstrument"></param>
        /// <returns></returns>
        public int Subscribe( string stockOrOption,params string[] pInstrument)
        {
            int size = Marshal.SizeOf(typeof(IntPtr));
            IntPtr insts = Marshal.AllocHGlobal(size * pInstrument.Length);
            var tmp = insts;
            foreach (string instrumentID in pInstrument)
            {
                if (!MainData.DicMarketData.Keys.Contains(instrumentID))
                {
                    var tick = new TickData();
                   
                    MainData.AllMarketData.Insert(0, tick);
                    MainData.DicMarketData.TryAdd(instrumentID, tick);

                 
                }
            }
            for (int i = 0; i < pInstrument.Length; i++, tmp += size)
            {
                var contract = MainData.DicContract[pInstrument[i]];
                pInstrument[i] = contract.exchange + pInstrument[i];
                Marshal.StructureToPtr(Marshal.StringToHGlobalAnsi(pInstrument[i]), tmp, false);
            }
            this.reqID += 1;
            if (stockOrOption == TradeCanstant.productOption)
            {
                int a = (int)this.SubscribeSOPMarketData(insts, pInstrument.Length, this.reqID);
                return a;
            }
            else
                return (int)this.SubscribeStockMarketData(insts, pInstrument.Length, this.reqID);
        }
       

        public int ReqUnSubscribeMarketData(params string[] pInstrument)
        {
            int size = Marshal.SizeOf(typeof(IntPtr));
            IntPtr insts = Marshal.AllocHGlobal(size * pInstrument.Length);
            var tmp = insts;
            for (int i = 0; i < pInstrument.Length; i++, tmp += size)
            {
                Marshal.StructureToPtr(pInstrument[i], tmp, false);
            }
            this.reqID += 1;
            return (int)this.UnSubscribeSOPMarketData(insts, pInstrument.Length, this.reqID);
        }


        #region 封装回调函数
        private void SecMdApi_OnFrontConnected()
        {
            optionConnectStatus = ConnectionStatus.Connected;
            stockConnectStatus = ConnectionStatus.Connected;
        }

        private void SecMdApi_OnFrontDisconnected(int nReason)
        {
            optionConnectStatus = ConnectionStatus.Disconnected;
            stockConnectStatus = ConnectionStatus.Disconnected;
        }

        /// <summary>
        /// 通知推送
        /// </summary>
        /// <param name="pNotice"></param>
        private void SecMdApi_OnRtnNotice(ref DFITCSECRspNoticeField pNotice)
        {
            var log = new LogData();
            log.gatewayName = "SEC";
            log.logContent = "行情消息通知" + pNotice.noticeMsg;
        }

        /// <summary>
        /// 股票登录回报
        /// </summary>
        /// <param name="pRspUserLogin"></param>
        /// <param name="pRspInfo"></param>
        private void SecMdApi_OnRspStockUserLogin(ref DFITCSECRspUserLoginField pRspUserLogin, ref DFITCSECRspInfoField pRspInfo)
        {
            if (string.IsNullOrEmpty(pRspInfo.errorMsg))
            {
                stockConnectStatus = ConnectionStatus.Logined;
                var log = new LogData();
                log.gatewayName = "SEC";
                log.logContent = "SEC股票行情服务器登录完成!";
                Console.Write("SEC股票行情服务器登录完成!");
            }
            // 否则，推送错误信息
            else
            {
                var err = new ErrorData();
                err.errorID = Convert.ToString(pRspInfo.errorID);
                err.errorMsg = pRspInfo.errorMsg;
            }
        }

        /// <summary>
        /// 错误回报
        /// </summary>
        /// <param name="pRspInfo"></param>
        private void SecMdApi_OnRspError(ref DFITCSECRspInfoField pRspInfo)
        {
            var err = new ErrorData();
            err.errorID =Convert.ToString(pRspInfo.errorID);
            err.errorMsg = pRspInfo.errorMsg;
           
        }
        /// <summary>
        /// 期权登录回报
        /// </summary>
        /// <param name="pRspUserLogin"></param>
        /// <param name="pRspInfo"></param>
        private void SecMdApi_OnRspSOPUserLogin(ref DFITCSECRspUserLoginField pRspUserLogin, ref DFITCSECRspInfoField pRspInfo)
        {
            Console.Write(pRspInfo.errorMsg);
            if (string.IsNullOrEmpty(pRspInfo.errorMsg))
            {
                this.optionConnectStatus = ConnectionStatus.Logined;
                var log = new LogData();
                log.gatewayName = "SEC";
                log.logContent = "SEC期权行情服务器登录完成!";
                Console.Write("SEC期权行情服务器登录完成!");
            }
            else
            {
                var err = new ErrorData();
                err.errorID = Convert.ToString(pRspInfo.errorID);
                err.errorMsg = pRspInfo.errorMsg;
            }
        }
        /// <summary>
        /// 股票行情推送
        /// </summary>
        /// <param name="pMarketDataField"></param>
        private void SecMdApi_OnStockMarketData(ref DFITCStockDepthMarketDataField pMarketDataField)
        {
            TickData tick=MainData.DicMarketData[pMarketDataField.staticDataField.securityID];

  
            tick.gatewayName = "SEC";

            tick.symbol = pMarketDataField.staticDataField.securityID;
            tick.exchange = pMarketDataField.staticDataField.exchangeID;

            tick.lastPrice = pMarketDataField.sharedDataField.latestPrice;
            tick.volume = (int)pMarketDataField.sharedDataField.tradeQty;
            tick.time = pMarketDataField.sharedDataField.updateTime;
            tick.date = Convert.ToString(pMarketDataField.staticDataField.tradingDay);

            tick.openPrice = pMarketDataField.staticDataField.openPrice;
            tick.highPrice = pMarketDataField.sharedDataField.highestPrice;
            tick.lowPrice = pMarketDataField.sharedDataField.lowestPrice;
            tick.preClosePrice = pMarketDataField.staticDataField.preClosePrice;

            tick.upperLimit = pMarketDataField.staticDataField.upperLimitPrice;
            tick.lowerLimit = pMarketDataField.staticDataField.lowerLimitPrice;

            tick.bidPrice1 = pMarketDataField.sharedDataField.bidPrice1;
            tick.bidPrice2 = pMarketDataField.sharedDataField.bidPrice2;
            tick.bidPrice3 = pMarketDataField.sharedDataField.bidPrice3;
            tick.bidPrice4 = pMarketDataField.sharedDataField.bidPrice4;
            tick.bidPrice5 = pMarketDataField.sharedDataField.bidPrice5;

            tick.askPrice1 = pMarketDataField.sharedDataField.askPrice1;
            tick.askPrice2 = pMarketDataField.sharedDataField.askPrice2;
            tick.askPrice3 = pMarketDataField.sharedDataField.askPrice3;
            tick.askPrice4 = pMarketDataField.sharedDataField.askPrice4;
            tick.askPrice5 = pMarketDataField.sharedDataField.askPrice5;

            tick.bidVolume1 = (int)pMarketDataField.sharedDataField.bidQty1;
            tick.bidVolume2 = (int)pMarketDataField.sharedDataField.bidQty2;
            tick.bidVolume3 = (int)pMarketDataField.sharedDataField.bidQty3;
            tick.bidVolume4 = (int)pMarketDataField.sharedDataField.bidQty4;
            tick.bidVolume5 = (int)pMarketDataField.sharedDataField.bidQty5;

            tick.askVolume1 = (int)pMarketDataField.sharedDataField.askQty1;
            tick.askVolume2 = (int)pMarketDataField.sharedDataField.askQty2;
            tick.askVolume3 = (int)pMarketDataField.sharedDataField.askQty3;
            tick.askVolume4 = (int)pMarketDataField.sharedDataField.askQty4;
            tick.askVolume5 = (int)pMarketDataField.sharedDataField.askQty5;
            Task.Run(() => MainData.MainEvent._OnTick.Invoke(tick));
        }

        /// <summary>
        /// 期权行情推送
        /// </summary>
        /// <param name="pMarketDataField"></param>
        private void SecMdApi_OnSOPMarketData(ref DFITCSOPDepthMarketDataField pMarketDataField)
        {
            TickData tick = MainData.DicMarketData[pMarketDataField.staticDataField.securityID];

            //if (MainData.DicMarketData.ContainsKey(pMarketDataField.staticDataField.securityID))
            //{
            //    tick = MainData.DicMarketData[pMarketDataField.staticDataField.securityID];
            //}
            //else
            //{
            //    tick = new TickData();
            //    MainData.AllMarketData.Insert(0, tick);
            //    MainData.DicMarketData.TryAdd(pMarketDataField.staticDataField.securityID, tick);
            //}
            tick.gatewayName = "SEC";

            tick.symbol = pMarketDataField.staticDataField.securityID;
            tick.exchange = pMarketDataField.staticDataField.exchangeID;

            tick.lastPrice = pMarketDataField.sharedDataField.latestPrice;
            tick.volume = (int)pMarketDataField.sharedDataField.tradeQty;
            tick.time = pMarketDataField.sharedDataField.updateTime;
            tick.openInterest = (int)pMarketDataField.specificDataField.positionQty;
            tick.date = Convert.ToString(pMarketDataField.staticDataField.tradingDay);

            tick.openPrice = pMarketDataField.staticDataField.openPrice;
            tick.highPrice = pMarketDataField.sharedDataField.highestPrice;
            tick.lowPrice = pMarketDataField.sharedDataField.lowestPrice;
            tick.preClosePrice = pMarketDataField.staticDataField.preClosePrice;

            tick.upperLimit = pMarketDataField.staticDataField.upperLimitPrice;
            tick.lowerLimit = pMarketDataField.staticDataField.lowerLimitPrice;

            tick.bidPrice1 = pMarketDataField.sharedDataField.bidPrice1;
            tick.bidPrice2 = pMarketDataField.sharedDataField.bidPrice2;
            tick.bidPrice3 = pMarketDataField.sharedDataField.bidPrice3;
            tick.bidPrice4 = pMarketDataField.sharedDataField.bidPrice4;
            tick.bidPrice5 = pMarketDataField.sharedDataField.bidPrice5;

            tick.askPrice1 = pMarketDataField.sharedDataField.askPrice1;
            tick.askPrice2 = pMarketDataField.sharedDataField.askPrice2;
            tick.askPrice3 = pMarketDataField.sharedDataField.askPrice3;
            tick.askPrice4 = pMarketDataField.sharedDataField.askPrice4;
            tick.askPrice5 = pMarketDataField.sharedDataField.askPrice5;

            tick.bidVolume1 = (int)pMarketDataField.sharedDataField.bidQty1;
            tick.bidVolume2 = (int)pMarketDataField.sharedDataField.bidQty2;
            tick.bidVolume3 = (int)pMarketDataField.sharedDataField.bidQty3;
            tick.bidVolume4 = (int)pMarketDataField.sharedDataField.bidQty4;
            tick.bidVolume5 = (int)pMarketDataField.sharedDataField.bidQty5;

            tick.askVolume1 = (int)pMarketDataField.sharedDataField.askQty1;
            tick.askVolume2 = (int)pMarketDataField.sharedDataField.askQty2;
            tick.askVolume3 = (int)pMarketDataField.sharedDataField.askQty3;
            tick.askVolume4 = (int)pMarketDataField.sharedDataField.askQty4;
            tick.askVolume5 = (int)pMarketDataField.sharedDataField.askQty5;
            Task.Run(() => MainData.MainEvent._OnTick.Invoke(tick));
        }

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="pDepthMarketData"></param>
        private void SecMdApi_OnRspSOPSubMarketData(ref DFITCSECSpecificInstrumentField pSpecificInstrument, ref DFITCSECRspInfoField pRspInfo)
        {
            if (string.IsNullOrEmpty(pRspInfo.errorMsg))
                Console.Write(pRspInfo.errorMsg);
        }
                /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="pDepthMarketData"></param>
        private void SecMdApi_OnRspStockSubMarketData(ref DFITCSECSpecificInstrumentField pSpecificInstrument, ref DFITCSECRspInfoField pRspInfo)
        {
            if (string.IsNullOrEmpty(pRspInfo.errorMsg))
                Console.Write(pRspInfo.errorMsg);
        }

        #endregion 封装回调函数


        public void Connect()
        {
            throw new NotImplementedException();
        }
    }


}
