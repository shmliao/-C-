using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanNetCommon.Gateway;
using QuanNetCommon;
using System.Threading;
using System.Collections.Concurrent;

namespace QuanNetSEC.SecGateway
{
    //命令
    public enum EnumReqCmdType
    {
        ReqSOPQryPosition,
        ReqStockQryPosition,
        ReqSOPQryContactInfo,
        ReqStockQryStockStaticInfo,

        ReqStockQryCapitalAccountInfo,
        ReqSOPQryCapitalAccountInfo
    }
    /// <summary>
    /// SEC接口注意事项：
    /// 1、报单号一致性维护需要基于柜台委托号spdOrderID，本地委托号基本没什么作用
    /// </summary>
    public class SecTdApi:SECTDI,ITdApi
    {
        # region oldcode

        public async void Connect()
        {
            await Task.Run(async () =>
            {
                await Task.Delay(100);
            });
        }

        public void QryAccount()
        {
            throw new NotImplementedException();
        }

        public void QryPosition()
        {
            throw new NotImplementedException();
        }
        # endregion


        # region 属性设置

        private string userID;
        private string password;

        private string tdAddress;
        private string brokerID;
        private string authCode;
        private string userProductInfo;
        private List<string> Contract;

        private ConnectionStatus stockConnectStatus;
        private ConnectionStatus sopConnectStatus;

        private long frontID;
        private long sessionID;

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

        public string TdAddress
        {
            get
            {
                return tdAddress;
            }
            private set
            {
                tdAddress = value;
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

        public ConnectionStatus SopConnectStatus
        {
            get
            {
                return sopConnectStatus;
            }
            private set
            {
                sopConnectStatus = value;
            }
        }

        public long FrontID
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

        public long SessionID
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

        public string AuthCode
        {
            get
            {
                return authCode;
            }
            private set
            {
                authCode = value;
            }
        }

        public string UserProductInfo
        {
            get
            {
                return userProductInfo;
            }
            private set
            {
                userProductInfo = value;
            }
        }
        # endregion

        //内部变量
        private bool  isFirstTimeLogin;
        private bool isReqSOPQryPositionCompleted,
       isReqStockQryPositionCompleted,
       isReqSOPQryContactInfoCompleted,
       isReqStockQryStockStaticInfoCompleted,

       isReqStockQryCapitalAccountInfoCompleted,
       isReqSOPQryCapitalAccountInfoCompleted;
        private StringBuilder sbSettlementInfo, sbSettlementInfoConfirm;
        private readonly ConcurrentStack<Tuple<EnumReqCmdType, object>> stackQuery;
        private readonly List<Delegate> ListDele;
        /// <summary>
        /// 委托号记录
        /// </summary>
        private int maxOrderLocalID = 1;
        private int reqID=0;


        //属性
        Delegate AddDele(Delegate d) { ListDele.Add(d); return d; }
        public string SettlementInfoContent { get { return sbSettlementInfo.ToString(); } }
        public string SettlementInfoConfirmDateTime { get { return sbSettlementInfoConfirm.ToString(); } }
        public ConcurrentStack<Tuple<EnumReqCmdType, object>> StackQuery { get { return stackQuery; } }

        private bool canExecuteStackQuery = true;

        //static DeleOnRspOrderInsert deleOrderInsert;
        //static DeleOnErrRtnOrderInsert deleErrRtnOrderInsert;
        //static DeleOnRtnTrade deletrade;
        //static DeleOnRspOrderAction deleOrderAction;
        //static DeleOnRtnOrder deleOrder;


        //构造函数
        public SecTdApi(string userID1, string password1, string tdAddress1, SecGateway gateway, string pFile = "./sec_dll/SecTdi.dll")
            : base(pFile)
        {
            this.UserID = userID1;
            this.Password = password1;
            this.TdAddress = tdAddress1;
            this.ListDele = new List<Delegate>();

            stockConnectStatus = ConnectionStatus.Disconnected;
            sopConnectStatus = ConnectionStatus.Disconnected;
            //内部变量初始化
            isReqSOPQryPositionCompleted=true;
       isReqStockQryPositionCompleted=true;
       isReqSOPQryContactInfoCompleted=true;
       isReqStockQryStockStaticInfoCompleted=true;

       isReqStockQryCapitalAccountInfoCompleted = true;
       isReqSOPQryCapitalAccountInfoCompleted = true;
            this.isFirstTimeLogin = true;
            this.sbSettlementInfo = new StringBuilder();
            this.sbSettlementInfoConfirm = new StringBuilder();
            this.Contract = new List<string>();


            this.stackQuery = new ConcurrentStack<Tuple<EnumReqCmdType, object>>();


            this.SetOnFrontConnected((DeleOnFrontConnected)AddDele(new DeleOnFrontConnected(SecTdApi_OnFrontConnected)));
            this.SetOnFrontDisconnected((DeleOnFrontDisconnected)AddDele(new DeleOnFrontDisconnected(SecTdApi_OnFrontDisConnected)));
            this.SetOnRtnNotice((DeleOnRtnNotice)AddDele(new DeleOnRtnNotice(SecTdApi_OnRtnNotice)));
            this.SetOnRspError((DeleOnRspError)AddDele(new DeleOnRspError(SecTdApi_OnRspError)));

            this.SetOnRspStockEntrustOrder((DeleOnRspStockEntrustOrder)AddDele(new DeleOnRspStockEntrustOrder(SecTdApi_OnRspStockEntrustOrder)));
            this.SetOnRspSOPEntrustOrder((DeleOnRspSOPEntrustOrder)AddDele(new DeleOnRspSOPEntrustOrder(SecTdApi_OnRspSOPEntrustOrder)));
            this.SetOnRspStockUserLogin((DeleOnRspStockUserLogin)AddDele(new DeleOnRspStockUserLogin(SecTdApi_OnRspStockUserLogin)));
            this.SetOnRspSOPUserLogin((DeleOnRspSOPUserLogin)AddDele(new DeleOnRspSOPUserLogin(SecTdApi_OnRspSOPUserLogin)));

            this.SetOnRspStockQryPosition((DeleOnRspStockQryPosition)AddDele(new DeleOnRspStockQryPosition(SecTdApi_OnRspStockQryPosition)));
            this.SetOnRspSOPQryPosition((DeleOnRspSOPQryPosition)AddDele(new DeleOnRspSOPQryPosition(SecTdApi_OnRspSOPQryPosition)));
            
            this.SetOnRspStockQryCapitalAccountInfo((DeleOnRspStockQryCapitalAccountInfo)AddDele(new DeleOnRspStockQryCapitalAccountInfo(SecTdApi_OnRspStockQryCapitalAccountInfo)));
            this.SetOnRspSOPQryCapitalAccountInfo((DeleOnRspSOPQryCapitalAccountInfo)AddDele(new DeleOnRspSOPQryCapitalAccountInfo(SecTdApi_OnRspSOPQryCapitalAccountInfo)));

            this.SetOnRspStockQryStockStaticInfo((DeleOnRspStockQryStockStaticInfo)AddDele(new DeleOnRspStockQryStockStaticInfo(SecTdApi_OnRspStockQryStockStaticInfo)));
            
            this.SetOnRspSOPQryContactInfo((DeleOnRspSOPQryContactInfo)AddDele(new DeleOnRspSOPQryContactInfo(SecTdApi_OnRspSOPQryContactInfo)));

            this.SetOnStockEntrustOrderRtn((DeleOnStockEntrustOrderRtn)AddDele(new DeleOnStockEntrustOrderRtn(SecTdApi_OnStockEntrustOrderRtn)));
            this.SetOnSOPEntrustOrderRtn((DeleOnSOPEntrustOrderRtn)AddDele(new DeleOnSOPEntrustOrderRtn(SecTdApi_OnSOPEntrustOrderRtn)));
            
            this.SetOnStockTradeRtn((DeleOnStockTradeRtn)AddDele(new DeleOnStockTradeRtn(SecTdApi_OnStockTradeRtn)));
            this.SetOnSOPTradeRtn((DeleOnSOPTradeRtn)AddDele(new DeleOnSOPTradeRtn(SecTdApi_OnSOPTradeRtn)));


            this.SetOnStockWithdrawOrderRtn((DeleOnStockWithdrawOrderRtn)AddDele(new DeleOnStockWithdrawOrderRtn(SecTdApi_OnStockWithdrawOrderRtn)));
            this.SetOnSOPWithdrawOrderRtn((DeleOnSOPWithdrawOrderRtn)AddDele(new DeleOnSOPWithdrawOrderRtn(SecTdApi_OnSOPWithdrawOrderRtn)));
            //this.SetOnRspQryInvestorPositionDetail((DeleOnRspQryInvestorPositionDetail)AddDele(new DeleOnRspQryInvestorPositionDetail(CTradeApi_OnRspQryInvestorPositionDetail)));
            //deleOrder = (DeleOnRtnOrder)AddDele(new DeleOnRtnOrder(CTradeApi_OnRtnOrder));
            //this.SetOnRtnOrder(deleOrder);
            //GC.KeepAlive(deleOrder);

        }


        private void SecTdApi_OnFrontConnected()
        {
            this.stockConnectStatus = ConnectionStatus.Connected;
            this.sopConnectStatus = ConnectionStatus.Connected;
        }
        private void SecTdApi_OnFrontDisConnected(int reason)
        {
            this.stockConnectStatus = ConnectionStatus.Disconnected;
            this.sopConnectStatus = ConnectionStatus.Disconnected;
        }

        /// <summary>
        /// 通知推送
        /// </summary>
        /// <param name="pData"></param>
        public void SecTdApi_OnRtnNotice(ref DFITCSECRspNoticeField pData)
        {
            var log = new LogData();
            log.gatewayName = "SEC";
            log.accountID = this.UserID;
            log.logContent = "SEC交易消息通知" + pData.noticeMsg;
            MainData.MainEvent._OnLog.Invoke(log);
        }
        /// <summary>
        /// 错误回报
        /// </summary>
        /// <param name="pData"></param>
        public void SecTdApi_OnRspError(ref DFITCSECRspInfoField pData)
        {
        //err = VtErrorData()
        //err.gatewayName = self.gatewayName
        //err.errorID = error['errorID']
        //err.errorMsg = error['errorMsg'].decode('gbk')
        //self.gateway.onError(err)
            var err = new ErrorData();
            err.accountID = this.UserID;
            err.gatewayName = "SEC";
            err.errorMsg = pData.errorMsg;
            err.errorID = Convert.ToString(pData.errorID);
            MainData.MainEvent._OnError.Invoke(err);
        }
        /// <summary>
        /// 股票登录回报
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
        public void SecTdApi_OnRspStockUserLogin( ref DFITCSECRspUserLoginField pData, ref DFITCSECRspInfoField pRspInfo)
        {
            if (pRspInfo.errorID == 0)
            {
                this.stockConnectStatus = ConnectionStatus.Logined;
                this.FrontID = pData.frontID;
                this.SessionID = pData.sessionID;
            }
            else
            {
                var err = new ErrorData();
                err.accountID = this.UserID;
                err.gatewayName = "SEC";
                err.errorMsg = pRspInfo.errorMsg;
                err.errorID = Convert.ToString(pRspInfo.errorID);
                MainData.MainEvent._OnError.Invoke(err);
            }
        }

              /// <summary>
          /// 期权登录回报
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnRspSOPUserLogin( ref DFITCSECRspUserLoginField pData, ref DFITCSECRspInfoField pRspInfo)
        {
            if (pRspInfo.errorID == 0)
            {
                this.sopConnectStatus = ConnectionStatus.Logined;
                this.FrontID = pData.frontID;
                this.SessionID = pData.sessionID;
            }
            else
            {
                var err = new ErrorData();
                err.accountID = this.UserID;
                err.gatewayName = "SEC";
                err.errorMsg = pRspInfo.errorMsg;
                err.errorID = Convert.ToString(pRspInfo.errorID);
                MainData.MainEvent._OnError.Invoke(err);
            }
        }

          private readonly List<DFITCStockRspQryPositionField> ListStockPosition = new List<DFITCStockRspQryPositionField>();
            /// <summary>
        /// 股票持仓查询回报
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
        public void SecTdApi_OnRspStockQryPosition(ref DFITCStockRspQryPositionField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast)
        {
            this.isReqStockQryPositionCompleted = bIsLast;
            var qnPositionName = "SEC" + "_" + this.UserID + "_" + pData.securityID + "_" + TradeCanstant.DirectLong;

            PositionData pos;

            ///如果持仓为0 或者之前有数据都删除
            if (MainData.DicPosition.Keys.Contains(qnPositionName))
            {
                if (MainData.DicPosition.TryRemove(qnPositionName, out pos))
                {
                    MainData.AllPositionData.Remove(pos);
                }

            }
            pos = new PositionData();
            pos.gatewayName = "SEC";

            pos.symbol = pData.securityID;
            pos.exchange = pData.exchangeID;

            pos.direction = TradeCanstant.DirectLong;
            pos.qnPositionName =qnPositionName;
            pos.totalPosition = pData.position;
            //股票t+1机制，昨仓作为可卖数量
            pos.ydPosition=pData.ableSellQty;
            pos.accountID=pData.accountID;
            pos.avgOpenPrice = pData.avgPositionPrice;

            MainData.DicPosition.TryAdd(qnPositionName, pos);
            MainData.AllPositionData.Insert(0, pos);
            if (MainData.MainEvent._OnPosition != null)
            {
                MainData.MainEvent._OnPosition.Invoke(pos);
            }

        }

                    /// <summary>
        /// 期权持仓查询回报
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnRspSOPQryPosition(ref DFITCSOPRspQryPositionField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast)
        {

            this.isReqStockQryPositionCompleted = bIsLast;
            string direction = "";
            if (pData.entrustDirection == DFITCSECEntrustDirectionType.DFITCSEC_ED_Buy )
            {
                direction = TradeCanstant.DirectLong;
            }
            else if (pData.entrustDirection == DFITCSECEntrustDirectionType.DFITCSEC_ED_Sell)
            {
                direction = TradeCanstant.DirectShort;
            }

            var qnPositionName = "SEC" + "_" + this.UserID + "_" + pData.securityOptionID + "_" + direction;

            PositionData pos;

            ///如果持仓为0 或者之前有数据都删除
            if (MainData.DicPosition.Keys.Contains(qnPositionName))
            {
                if (MainData.DicPosition.TryRemove(qnPositionName, out pos))
                {
                    MainData.AllPositionData.Remove(pos);
                }

            }
            pos = new PositionData();
            pos.gatewayName = "SEC";

            pos.symbol = pData.securityOptionID;
            pos.exchange = pData.exchangeID;

            pos.direction = direction;
            pos.qnPositionName = qnPositionName;
            pos.accountID = pData.accountID;
            pos.totalPosition = pData.totalQty;
            
            if (pos.totalPosition <= 0) 
            {
                return;
            }
            pos.avgOpenPrice = pData.openAvgPrice;
            MainData.DicPosition.TryAdd(qnPositionName, pos);
            MainData.AllPositionData.Insert(0, pos);
            if (MainData.MainEvent._OnPosition != null)
            {
                MainData.MainEvent._OnPosition.Invoke(pos);
            }
        }

         /// <summary>
        /// 股票资金账户查询回报
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnRspStockQryCapitalAccountInfo(ref DFITCStockRspQryCapitalAccountField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast)
        {

            string qnAccountID = "SEC" + "_" + "stock" + "_" + pData.accountID;
            AccountData account;
            account = MainData.GetAccount(qnAccountID);
            account.accountID = pData.accountID;
            account.qnAccountID = qnAccountID;
            account.gatewayName = "SEC";
            account.available = pData.availableFunds;
            account.balance = pData.totalFunds;
            //account.marketValue = pData.totalMarket;

            this.isReqStockQryCapitalAccountInfoCompleted = bIsLast;
            Task.Run(() => MainData.MainEvent._OnAccount.Invoke(account));
        }

        /// <summary>
        /// 期权资金账户查询回报
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnRspSOPQryCapitalAccountInfo(ref DFITCSOPRspQryCapitalAccountField pData, ref DFITCSECRspInfoField pRspInfo)
        {

            string qnAccountID = "SEC" + "_" + "option" + "_" + pData.accountID;
            AccountData account;
            account = MainData.GetAccount(qnAccountID);
            account.accountID = pData.accountID;
            account.gatewayName = "SEC";
            account.qnAccountID = qnAccountID;

            account.available = pData.availableFunds;
            account.balance = pData.totalFunds;
            account.margin = pData.usedDeposit;
            //account.marketValue = pData.totalMarket;
            this.isReqSOPQryCapitalAccountInfoCompleted = true;
            Task.Run(() => MainData.MainEvent._OnAccount.Invoke(account));
        }

                         /// <summary>
        /// 股票合约查询回报
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnRspStockQryStockStaticInfo(ref DFITCStockRspQryStockStaticField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast)
        {
            if (string.IsNullOrEmpty(pData.securityID))
                return;
            ContractData contract;
            this.isReqStockQryStockStaticInfoCompleted = bIsLast;
            this.Contract.Add(pData.securityID);
            if (MainData.DicContract.TryGetValue(pData.securityID, out contract))
            {
                
            }
            else 
            {
                contract = new ContractData();
                contract.symbol = pData.securityID;
                contract.qnSymbol = pData.securityID + "_" + pData.exchangeID;


                    contract.symbol = pData.securityID;
                    contract.exchange = pData.exchangeID;

                    contract.name =pData.securityName;

                    contract.size = pData.tradeUnit;
                    // 50ETF的最小价格变动
                if (contract.symbol.Equals("510050"))
                   
                    contract.priceTick = 0.001 ;

                contract.productClass = TradeCanstant.productEquity;

                if (MainData.DicContract.TryAdd(pData.securityID, contract))
                {
                    MainData.AllContract.Add(contract);
                }

                Task.Run(() => MainData.MainEvent._OnContract.Invoke(contract));
            }
    
            if (isReqStockQryStockStaticInfoCompleted)
             {
                    var log = new LogData();
                    log.gatewayName = "SEC";
                    log.accountID = this.UserID;
                    log.logContent = "SEC股票交易合约信息获取完成";
                    Console.Write("SEC股票交易合约信息获取完成!");
                    //MainData.MainEvent._OnLog.Invoke(log);
             }
        }

        /// <summary>
        /// 期权合约查询回报
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnRspSOPQryContactInfo(ref DFITCSOPRspQryContactField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast)
        {
            if (string.IsNullOrEmpty(pData.securityOptionID))
                return;
            ContractData contract;
            this.isReqSOPQryContactInfoCompleted = bIsLast;
            this.Contract.Add(pData.securityOptionID);
            if (MainData.DicContract.TryGetValue(pData.securityOptionID, out contract))
            {
               
            }
            else
            {
                contract = new ContractData();
                contract.symbol = pData.securityOptionID;
                contract.qnSymbol = pData.securityOptionID + "_" + pData.exchangeID;


                contract.exchange = pData.exchangeID;

                contract.name = pData.contractName;

                contract.size = pData.contactUnit;

                contract.priceTick = pData.miniPriceChange;
                contract.strikePrice = pData.execPrice;

                contract.productClass = TradeCanstant.productEquity;


                contract.underlyingSymbol = pData.securityID + "-" + pData.endTradingDay.ToString().Trim().Substring(0, 4);
                contract.expiryDate = pData.endTradingDay.ToString();
                contract.productClass = TradeCanstant.productOption;

                if (pData.optType == DFITCSECOptionTypeType.DFITCSEC_OT_CALL)
                    contract.optionType = TradeCanstant.optionCall;
                else
                    contract.optionType = TradeCanstant.optionPut;

                if (MainData.DicContract.TryAdd(pData.securityOptionID, contract))
                {
                    MainData.AllContract.Add(contract);
                }

                Task.Run(() => MainData.MainEvent._OnContract.Invoke(contract));
            }
            if (isReqSOPQryContactInfoCompleted)
             {
                    var log = new LogData();
                    log.gatewayName = "SEC";
                    log.accountID = this.UserID;
                    log.logContent = "SEC期权交易合约信息获取完成";
                    Console.Write("SEC期权交易合约信息获取完成!");
                    //MainData.MainEvent._OnLog.Invoke(log);
             }

        }
        
        
                         /// <summary>
        /// 股票报单回报
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnStockEntrustOrderRtn(ref DFITCStockEntrustOrderRtnField pData)
        {

                          this.maxOrderLocalID = Math.Max(pData.localOrderID, this.maxOrderLocalID);
                          string qnOrderID = "SEC" + "_" + this.UserID + "_" + Convert.ToString(pData.localOrderID);
            OrderData order = MainData.GetOrder(qnOrderID);
            order.gatewayName = "SEC";
            order.accountID = this.UserID;

                order.symbol = pData.securityID;
                order.exchange = pData.exchangeID;
                order.spdOrderID= pData.spdOrderID;


                order.orderID = Convert.ToString(pData.localOrderID);
                order.qnOrderID =qnOrderID;

                order.direction =(pData.entrustDirection== DFITCSECEntrustDirectionType.DFITCSEC_ED_Buy?TradeCanstant.DirectLong:TradeCanstant.DirectShort);

                order.price = pData.entrustPrice;
                order.totalVolume = pData.entrustQty;
                order.orderTime = pData.entrustTime;
             

                order.productClass = TradeCanstant.productEquity;

            ///确定委托状态
            if (order.totalVolume == order.tradedVolume)
                order.status = TradeCanstant.statusAllTraded;
            else if( order.tradedVolume > 0)
                order.status = TradeCanstant.statusPartTraded;
            else
                order.status = TradeCanstant.statusNotTraded;

            if (pData.sessionID==-1 && pData.localOrderID==-1)
                order.status=TradeCanstant.statusCanceled;
        }
                                 /// <summary>
        /// 期权报单回报
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnSOPEntrustOrderRtn(ref DFITCSOPEntrustOrderRtnField pData)
        {
            this.maxOrderLocalID = Math.Max(pData.localOrderID, this.maxOrderLocalID);
            string qnOrderID = "SEC" +  "_" + this.UserID + "_"+Convert.ToString(pData.localOrderID);
            OrderData order = MainData.GetOrder(qnOrderID);
            order.gatewayName = "SEC";
            order.accountID = this.UserID;

                order.symbol = pData.securityID;
                order.exchange = pData.exchangeID;
                order.spdOrderID= pData.spdOrderID;


                order.orderID = Convert.ToString(pData.localOrderID);
                order.qnOrderID =qnOrderID;

                order.direction =(pData.entrustDirection== DFITCSECEntrustDirectionType.DFITCSEC_ED_Buy?TradeCanstant.DirectLong:TradeCanstant.DirectShort);
                order.offset = (pData.openCloseFlag== DFITCSECOpenCloseFlagType.DFITCSEC_OCF_Open?TradeCanstant.offsetOpen:TradeCanstant.offsetClose);

                order.price = pData.entrustPrice;
                order.totalVolume = pData.entrustQty;
                order.orderTime = pData.entrustTime;

                order.productClass = TradeCanstant.productOption;

            ///确定委托状态
            if (order.totalVolume == order.tradedVolume)
                order.status = TradeCanstant.statusAllTraded;
            else if( order.tradedVolume > 0)
                order.status = TradeCanstant.statusPartTraded;
            else
                order.status = TradeCanstant.statusNotTraded;

            if (pData.sessionID==-1 && pData.localOrderID==-1)
                order.status=TradeCanstant.statusCanceled;
        }
        

        /// <summary>
        /// 股票成交推送
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnStockTradeRtn(ref DFITCStockTradeRtnField pData)
        {
            string qnTradeID = "SEC" + "_" + this.UserID + "_" + pData.tradeID.Trim();
            var trade = MainData.GetTrade(qnTradeID);
            trade.gatewayName = "SEC";
            trade.accountID = this.UserID;
            trade.symbol = pData.securityID;
            trade.exchange = pData.exchangeID;

            trade.tradeID = pData.tradeID;
            trade.qnTradeID = qnTradeID;
            trade.orderID = Convert.ToString(pData.localOrderID);

            trade.direction = (pData.entrustDirection == DFITCSECEntrustDirectionType.DFITCSEC_ED_Sell ? TradeCanstant.DirectLong : TradeCanstant.DirectShort);

            trade.price = pData.tradePrice;
            trade.volume = pData.tradeQty;
            trade.tradeTime = pData.tradeTime;


            string qnOrderID = "SEC" + "_" + this.UserID + "_" + Convert.ToString(pData.localOrderID);
            OrderData order = MainData.GetOrder(qnOrderID);
            order.gatewayName = "SEC";
            order.accountID = this.UserID;
            order.tradedVolume += trade.volume;
            order.tradedVolume = Math.Min(order.totalVolume, order.tradedVolume);
            if (order.totalVolume == order.tradedVolume)
            {
                order.status = TradeCanstant.statusAllTraded;
            }
            else
            {
                order.status = TradeCanstant.statusPartTraded;
            }
          }

                /// <summary>
        /// 期权成交推送
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
        public void SecTdApi_OnSOPTradeRtn(ref DFITCSOPTradeRtnField pData)
        {
            string qnTradeID = "SEC" + "_" + this.UserID + "_" + pData.tradeID.Trim();
            var trade = MainData.GetTrade(qnTradeID);
            trade.gatewayName = "SEC";
            trade.accountID = this.UserID;
            trade.symbol = pData.securityID;
            trade.exchange = pData.exchangeID;

            trade.tradeID = pData.tradeID;
            trade.qnTradeID =qnTradeID;
            trade.orderID = Convert.ToString(pData.localOrderID);

            trade.direction = (pData.entrustDirection == DFITCSECEntrustDirectionType.DFITCSEC_ED_Sell ? TradeCanstant.DirectLong : TradeCanstant.DirectShort);
            trade.offset =(pData.openCloseFlag== DFITCSECOpenCloseFlagType.DFITCSEC_OCF_Close?TradeCanstant.offsetClose:TradeCanstant.offsetOpen);

            trade.price = pData.tradePrice;
            trade.volume = pData.tradeQty;
            trade.tradeTime = pData.tradeTime;


            string qnOrderID = "SEC" +  "_" + this.UserID + "_" +Convert.ToString(pData.localOrderID);
            OrderData order = MainData.GetOrder(qnOrderID);
            order.gatewayName = "SEC";
            order.accountID = this.UserID;
            order.tradedVolume += trade.volume;
            order.tradedVolume = Math.Min(order.totalVolume, order.tradedVolume);
            if (order.totalVolume == order.tradedVolume)
            {
                order.status = TradeCanstant.statusAllTraded;
            }else
            {
                order.status = TradeCanstant.statusPartTraded;
            }
          }
        
             /// <summary>
        /// 股票撤单推送
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnStockWithdrawOrderRtn(ref DFITCStockWithdrawOrderRtnField pData)
        {
            //# 更新最大报单编号

            this.maxOrderLocalID = Math.Max(pData.localOrderID, this.maxOrderLocalID);
            string qnOrderID = "SEC" + "_" + this.UserID + "_"+ Convert.ToString(pData.localOrderID);
            OrderData order = MainData.GetOrder(qnOrderID);
            order.gatewayName = "SEC";
            order.accountID = this.UserID;

            order.symbol = pData.securityID;
            order.exchange = pData.exchangeID;

            order.orderID = Convert.ToString(pData.localOrderID);
            order.qnOrderID = qnOrderID;

            order.direction = (pData.entrustDirection == DFITCSECEntrustDirectionType.DFITCSEC_ED_Sell ? TradeCanstant.DirectLong : TradeCanstant.DirectShort);

            order.tradedVolume = pData.tradeQty;
            order.totalVolume = pData.tradeQty + pData.withdrawQty;

            order.productClass = TradeCanstant.productEquity;
            if (pData.withdrawQty > 0)
            {
                order.status = TradeCanstant.statusCanceled;
            }
          }


                     /// <summary>
        /// 期权撤单推送
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
          public void SecTdApi_OnSOPWithdrawOrderRtn(ref DFITCSOPWithdrawOrderRtnField pData)
        {
        //# 更新最大报单编号

            this.maxOrderLocalID = Math.Max(pData.localOrderID, this.maxOrderLocalID);
            string qnOrderID = "SEC" + "_" + this.UserID + "_" + Convert.ToString(pData.localOrderID);
            OrderData order= MainData.GetOrder(qnOrderID);
                order.gatewayName ="SEC";
              order.accountID=this.UserID;

                order.symbol =pData.securityID;
                order.exchange =pData.exchangeID;

                order.orderID = Convert.ToString(pData.localOrderID);
                order.qnOrderID =qnOrderID;

                order.direction = (pData.entrustDirection== DFITCSECEntrustDirectionType.DFITCSEC_ED_Sell?TradeCanstant.DirectLong:TradeCanstant.DirectShort);
                order.offset = (pData.openCloseFlag== DFITCSECOpenCloseFlagType.DFITCSEC_OCF_Close?TradeCanstant.offsetClose:TradeCanstant.offsetOpen);

                order.tradedVolume = pData.tradeQty;
                order.totalVolume = pData.tradeQty + pData.withdrawQty;

                order.productClass = TradeCanstant.productOption;
                if (pData.withdrawQty > 0) 
                {
                    order.status = TradeCanstant.statusCanceled;
                }
          }
        

        
        
        
        

        /// <summary>
        /// 股票发单错误
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
         public void SecTdApi_OnRspStockEntrustOrder(ref DFITCStockRspEntrustOrderField pData, ref DFITCSECRspInfoField pRspInfo)
        {
            if (!string.IsNullOrEmpty(pRspInfo.errorMsg))
            {
                string qnOrderID = "SEC" + "_" + this.UserID + "_" + Convert.ToString(pData.localOrderID);
                OrderData orderData = MainData.GetOrder(qnOrderID);
                orderData.orderID = Convert.ToString(pData.localOrderID);
                orderData.qnOrderID = qnOrderID;
                orderData.status = TradeCanstant.statusReject;
                orderData.accountID = this.UserID;
                orderData.gatewayName = "SEC";
       
                var error = new ErrorData();
                error.gatewayName = "SEC";
                error.accountID = this.UserID;
                error.errorMsg = pRspInfo.errorMsg;
                error.errorID = Convert.ToString(pRspInfo.errorID);
            }
            
        }

           /// <summary>
         /// 期权发单错误
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pRspInfo"></param>
         public void SecTdApi_OnRspSOPEntrustOrder(ref DFITCSOPRspEntrustOrderField pData, ref DFITCSECRspInfoField pRspInfo)
        {
            if (!string.IsNullOrEmpty(pRspInfo.errorMsg))
            {
                string qnOrderID = "SEC" + "_" + this.UserID + "_" + Convert.ToString(pData.localOrderID);
                OrderData orderData = MainData.GetOrder(qnOrderID);
                orderData.orderID = Convert.ToString(pData.localOrderID);
                orderData.qnOrderID = qnOrderID;
                orderData.status = TradeCanstant.statusReject;
                orderData.accountID = this.UserID;
                orderData.gatewayName = "SEC";
          
                var error = new ErrorData();
                error.gatewayName = "SEC";
                error.accountID = this.UserID;
                error.errorMsg = pRspInfo.errorMsg;
                error.errorID = Convert.ToString(pRspInfo.errorID);
            }
            
        }
        /// <summary>
        /// 流控查询
        /// </summary>
        /// <returns></returns>
        public async Task ExecStackQuery()
        {
            if (!this.canExecuteStackQuery)
            {//防止上次查询还未完成就再次使用该函数！
                return;
            }
            this.canExecuteStackQuery = false;
            Tuple<EnumReqCmdType, object> query;
            this.reqID+=1;

            while (this.stackQuery.TryPop(out query))
            {
                switch (query.Item1)
                {
                    case EnumReqCmdType.ReqSOPQryPosition:
                        await Task.Run(async () =>
                        {
                            this.isReqSOPQryPositionCompleted = false;
                            DFITCSOPReqQryPositionField req=new DFITCSOPReqQryPositionField();
                            req.accountID=this.UserID;
                            req.requestID=this.reqID;
                            this.ReqSOPQryPosition(req);
                            while (!this.isReqSOPQryPositionCompleted)
                                await Task.Delay(100);
                        });
                        break;
                    case EnumReqCmdType.ReqStockQryPosition:
                        await Task.Run(async () =>
                        {
                            this.isReqStockQryPositionCompleted  = false;
                            DFITCStockReqQryPositionField req=new DFITCStockReqQryPositionField();
                            req.accountID=this.UserID;
                            req.requestID=this.reqID;
                            this.ReqStockQryPosition(req);
                            while (!this.isReqStockQryPositionCompleted)
                                await Task.Delay(100);
                        });
                        break;
                    case EnumReqCmdType.ReqStockQryCapitalAccountInfo:
                        await Task.Run(async () =>
                        {
                            this.isReqStockQryCapitalAccountInfoCompleted  = false;
                            DFITCStockReqQryCapitalAccountField req=new DFITCStockReqQryCapitalAccountField();
                            req.accountID=this.UserID;
                            req.requestID=this.reqID;
                            this.ReqStockQryCapitalAccountInfo(req);
                            while (!this.isReqStockQryCapitalAccountInfoCompleted)
                                await Task.Delay(100);
                        });
                        break;
                   case EnumReqCmdType.ReqSOPQryCapitalAccountInfo:
                        await Task.Run(async () =>
                        {
                            this.isReqSOPQryCapitalAccountInfoCompleted  = false;
                            DFITCSOPReqQryCapitalAccountField req=new DFITCSOPReqQryCapitalAccountField();
                            req.accountID=this.UserID;
                            req.requestID=this.reqID;
                            this.ReqSOPQryCapitalAccountInfo(req);
                            while (!this.isReqSOPQryCapitalAccountInfoCompleted)
                                await Task.Delay(100);
                        });
                        break;

                             
                   case EnumReqCmdType.ReqSOPQryContactInfo:
                        await Task.Run(async () =>
                        {
                            this.isReqSOPQryContactInfoCompleted = false;
                            DFITCSOPReqQryContactField req = new DFITCSOPReqQryContactField();
                            req.accountID = this.UserID;
                            req.requestID = this.reqID;
                            this.ReqSOPQryContactInfo(req);
                            while (!this.isReqSOPQryContactInfoCompleted)
                                await Task.Delay(100);
                        });
                        break;
                     case EnumReqCmdType.ReqStockQryStockStaticInfo:
                        await Task.Run(async () =>
                        {
                            this.isReqStockQryStockStaticInfoCompleted = false;
                            DFITCStockReqQryStockStaticField req = new DFITCStockReqQryStockStaticField();
                            req.accountID = this.UserID;
                            req.requestID = this.reqID;
                            req.exchangeID = "SH";
                            int a=(int)this.ReqStockQryStockStaticInfo(req);
                            while (!this.isReqStockQryStockStaticInfoCompleted)
                                await Task.Delay(100);
                        });
                        break;
                    default:
                        break;
                }
            }
            this.canExecuteStackQuery = true;
        }

        //查询函数
        public async Task AsyncConnect(CancellationToken CancelToken)
        {
            if (this.stockConnectStatus == ConnectionStatus.Connected || this.sopConnectStatus == ConnectionStatus.Connecting)
            {
                return;
            }
            int result = (int)this.Init(this.TdAddress);
            int a=(int)this.SubscribePrivateTopic(RESUME_TYPE.TERT_RESTART);
            if (result != 0)
            {
                //throw new Exception(result.ToString());
            }
            while (this.stockConnectStatus != ConnectionStatus.Connected && this.sopConnectStatus != ConnectionStatus.Connected)
            {
                await Task.Delay(100);
                CancelToken.ThrowIfCancellationRequested();
            }
        }
        public async Task AsyncLogin(CancellationToken CancelToken)
        {
            DFITCSECReqUserLoginField req=new DFITCSECReqUserLoginField();
            req.accountID=this.UserID;
            req.password=this.password;
            this.reqID += 1;
            req.requestID = this.reqID;
            this.ReqSOPUserLogin(req);
            
            this.reqID += 1;
            req.requestID = this.reqID;
            int result=(int)this.ReqStockUserLogin(req);
            if (result != 0)
            {
                throw new Exception(result.ToString());
            }
            this.stockConnectStatus = ConnectionStatus.Logining;
            this.sopConnectStatus = ConnectionStatus.Logining;
            while (this.sopConnectStatus != ConnectionStatus.Logined && this.stockConnectStatus != ConnectionStatus.Logined)
            {
                await Task.Delay(100);
                CancelToken.ThrowIfCancellationRequested();
            }
        }

 

        /// <summary>
        /// /检查是否为期权代码
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public bool CheckOptionSymbol(string symbol){
            if (symbol.Count()> 6)
                return true;
            return false;
            }
        /// <summary>
        /// 下普通单
        /// </summary>
        /// <param name="req"></param>
        public string SendOrder(OrderReq req)
        {

            this.reqID += 1;
            this.maxOrderLocalID += 1;
            string product="";
            int result = -1;
            string qnOrderID = "SEC" + "_" + this.UserID + "_" + Convert.ToString(this.maxOrderLocalID);
             if (CheckOptionSymbol(req.symbol))
             {
                 var order=new DFITCSOPReqEntrustOrderField();
                 order.securityID=req.symbol;
                 order.exchangeID=req.exchange;
                 order.entrustPrice=req.price;
                 order.entrustQty=req.volume;
                 order.localOrderID=this.maxOrderLocalID;
                 order.accountID=this.userID;
                 order.requestID=this.reqID;
                 order.entrustDirection=(req.direction==TradeCanstant.DirectLong?DFITCSECEntrustDirectionType.DFITCSEC_ED_Buy:DFITCSECEntrustDirectionType.DFITCSEC_ED_Sell );
                 order.orderType= DFITCSECOrderTypeType.DFITCSEC_SOP_LimitPrice;
                 order.openCloseFlag=(req.offset==TradeCanstant.offsetOpen?DFITCSECOpenCloseFlagType.DFITCSEC_OCF_Open:DFITCSECOpenCloseFlagType.DFITCSEC_OCF_Close) ;
                 product=TradeCanstant.productOption;
                 result=(int)this.ReqSOPEntrustOrder(order);
             }
             else
             {
                 var order=new DFITCStockReqEntrustOrderField();
                 order.securityID=req.symbol;
                 order.exchangeID=req.exchange;
                 order.entrustPrice=req.price;
                 order.entrustQty=req.volume;
                 order.localOrderID=this.maxOrderLocalID;
                 order.accountID=this.userID;
                 order.requestID=this.reqID;
                 order.entrustDirection=(req.direction==TradeCanstant.DirectLong?DFITCSECEntrustDirectionType.DFITCSEC_ED_Buy:DFITCSECEntrustDirectionType.DFITCSEC_ED_Sell );
                 order.orderType= DFITCSECOrderTypeType.DFITCSEC_OT_LimitPrice;
                 product=TradeCanstant.productEquity;
                 result = (int)this.ReqStockEntrustOrder(order);
             }
             if (result != 0) 
             {
                 return "发单失败";
             }

             OrderData orderData = MainData.GetOrder(qnOrderID);
             orderData.orderID = Convert.ToString(this.maxOrderLocalID);
             orderData.qnOrderID = qnOrderID;
             orderData.gatewayName = "SEC";
             orderData.symbol = req.symbol;
             orderData.exchange = req.exchange;
             orderData.price = req.price;
             orderData.totalVolume = req.volume;
             orderData.direction = req.direction;
             orderData.offset = req.offset;
             orderData.productClass = product;
             return "";
        }

        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="req"></param>
        public void CancelOrder(CancelOrderReq cancelOrderReq)
        {
            DFITCSECReqWithdrawOrderField req=new DFITCSECReqWithdrawOrderField();
                this.reqID += 1;
                req.localOrderID = Convert.ToInt32(cancelOrderReq.orderID);
                req.accountID = this.UserID;
                req.requestID = this.reqID;
                req.spdOrderID= cancelOrderReq.spdOrderID;
                int iResult;
                if(CheckOptionSymbol(cancelOrderReq.symbol))
                {
                    iResult=(int)ReqSOPWithdrawOrder(req);
                }
                else{
                iResult = (int)ReqStockWithdrawOrder(req);
                }
   
            Console.WriteLine("--->>> 撤单操作请求: " + ((iResult == 0) ? "成功" : "失败"));
        }


        /// <summary>
        /// 每当有报单成交时，则要更新持仓
        /// </summary>
        /// <param name="tf"></param>
        private void UpdatePositionFromRtnTrade(TradeData td)
        {
            lock (MainData.DicPosition)
            {
                //更新_dicPosition
                ContractData contract;
                if (!MainData.DicContract.TryGetValue(td.symbol, out contract))
                {
                    return;
                }
                string qnPositionName = "";
                ///如果是开仓，不必要去处理旧的持仓
                if (td.offset == TradeCanstant.offsetOpen)
                    qnPositionName = "CTP" + "_" + this.UserID + "_" + td.symbol + "_" + td.direction;
                ///如果是平仓，那个要去出去反方向的持仓
                else
                    qnPositionName = "CTP" + "_" + this.UserID + "_" + td.symbol + "_" + (td.direction == TradeCanstant.DirectLong ? TradeCanstant.DirectShort : TradeCanstant.DirectLong);

                PositionData position = MainData.GetPosition(qnPositionName);


                position.gatewayName = "CTP";
                position.accountID = this.userID;
                position.symbol = td.symbol;
                position.direction = td.direction;
                position.hedge = td.hedge;
                position.qnPositionName = qnPositionName;
                var size = MainData.DicContract[position.symbol].size;
                switch (td.offset)
                {
                    //开仓成交
                    case TradeCanstant.offsetOpen:
                        position.totalPosition += td.volume;
                        position.tdPosition += td.volume;
                        position.positionCost += td.price * td.volume * size;
                        position.openCost += td.price * td.volume * size;
                        position.avgOpenPrice = position.openCost / position.totalPosition / size;
                        break;
                    case TradeCanstant.offsetCloseToday:
                        position.totalPosition -= td.volume;
                        position.tdPosition -= td.volume;
                        position.positionCost -= td.price * td.volume * size;
                        if (position.totalPosition == 0)
                        {
                            PositionData tmp;
                            if (MainData.DicPosition.TryRemove(qnPositionName, out tmp))
                            {
                                MainData.AllPositionData.Remove(position);
                                return;
                            }
                        }
                        position.openCost = position.openCost * position.totalPosition / (position.totalPosition + td.volume);
                        position.avgOpenPrice = position.openCost / position.totalPosition / size;
                        break;
                    //平昨
                    case TradeCanstant.offsetClose:
                        position.totalPosition -= td.volume;
                        //position.ydPosition -= td.volume;
                        position.positionCost -= td.price * td.volume * size;
                        if (position.totalPosition == 0)
                        {
                            PositionData tmp;
                            if (MainData.DicPosition.TryRemove(qnPositionName, out tmp))
                            {
                                MainData.AllPositionData.Remove(position);
                                return;
                            }
                        }
                        position.openCost = position.openCost * position.totalPosition / (position.totalPosition + td.volume);
                        position.avgOpenPrice = position.openCost / position.totalPosition / size;
                        break;
                    case TradeCanstant.offsetCloseYesterday:
                        position.totalPosition -= td.volume;
                        position.ydPosition -= td.volume;
                        position.positionCost -= td.price * td.volume * size;
                        if (position.totalPosition == 0)
                        {
                            PositionData tmp;
                            if (MainData.DicPosition.TryRemove(qnPositionName, out tmp))
                            {
                                MainData.AllPositionData.Remove(position);
                                return;
                            }
                        }
                        position.openCost = position.openCost * position.totalPosition / (position.totalPosition + td.volume);
                        position.avgOpenPrice = position.openCost / position.totalPosition / size;
                        break;

                    default:
                        break;

                }
            }
        }

 
     
     
        public List<string> ContractList
        {
            get
            {
                return this.Contract;
            }
        }
    }
}
