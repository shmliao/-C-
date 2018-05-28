using System.Runtime.InteropServices;

namespace QuanNetSEC
{

    //ERR-错误信息
    public struct DFITCSECRspInfoField
    {
        public int requestID;                //请求ID
        public int sessionID;                //会话标识
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int errorID;                  //错误ID
        public int localOrderID;             //本地委托号
        public int spdOrderID;               //柜台委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string errorMsg;                 //错误信息
    };

    //ERR-消息通知
    public struct DFITCSECRspNoticeField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string noticeMsg;                 //通知
    };

    //SEC-登录请求
    public struct DFITCSECReqUserLoginField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string password;                 //密码(Y)
        DFITCSECMDCompressFalgType compressflag;             //行情压缩标志(N)(只有登录行情账户的时候该字段有效)
    };

    //SEC-登录响应
    public struct DFITCSECRspUserLoginField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int sessionID;                //会话编号
        public int frontID;                  //前置编号
        public int localOrderID;             //本地委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string loginTime;                //登录时间
        public int tradingDay;               //交易日
        public int result;                   //结果
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string rtnMsg;                   //返回信息
    };

    //SEC-登出请求
    public struct DFITCSECReqUserLogoutField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
    };

    //SEC-登出响应 
    public struct DFITCSECRspUserLogoutField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int result;                   //结果
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string rtnMsg;                   //返回信息
    };

    //SEC-更新用户密码请求
    public struct DFITCSECReqPasswordUpdateField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string oldPassword;              //旧密码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string newPassword;              //新密码(Y)
        DFITCSECPasswordTypeType passwordType;             //密码类型(Y)
    };

    //SEC-更新用户密码响应
    public struct DFITCSECRspPasswordUpdateField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        DFITCSECPasswordTypeType passwordType;             //密码类型
        public int result;                   //更新结果
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string rtnMsg;                   //更新返回信息
    };

    //SEC-更新行情账户密码请求
    public struct DFITCSECReqMDPasswordUpdateField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string oldPassword;              //旧密码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string newPassword;              //新密码(Y)
    };

    //SEC-更新行情账户密码响应
    public struct DFITCSECRspMDPasswordUpdateField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int result;                   //更新结果
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string rtnMsg;                   //更新返回信息
    };

    //SEC-撤单请求
    public struct DFITCSECReqWithdrawOrderField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int spdOrderID;               //柜台委托号(N)
        public int localOrderID;             //本地委托号(N)(柜台委托号和本地委托号二选一)
    };

    //SEC-撤单响应
    public struct DFITCSECRspWithdrawOrderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int localOrderID;             //本地委托号
        public int spdOrderID;               //柜台委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string entrustTime;              //委托时间(股票没有这个字段，期权有)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string cancelMsg;                //撤单返回信息
    };

    //STOCK-委托请求
    public struct DFITCStockReqEntrustOrderField
    {
        public int requestID;                //请求ID(Y)
        public int localOrderID;             //本地委托号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public double entrustPrice;             //委托价格(N)
        public DFITCSECEntrustDirectionType entrustDirection;         //委托类别(Y)
        public int entrustQty;               //委托数量(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码(Y)
        public DFITCSECOrderTypeType orderType;                //订单类型(Y)
        public int entrustBatchID;           //委托批次号(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string eachSeatID;               //对方席位号(N)
        public DFITCSECHKEntrustLimitType hkEntrustLimit;           //港股交易限制(港股交易：Y)
        public DFITCSECHKOrderTypeType hkOrderType;              //港股订单属性(港股交易：Y)
    };

    //STOCK-委托响应
    public struct DFITCStockRspEntrustOrderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int localOrderID;             //本地委托号
        public int spdOrderID;               //柜台委托号
        public int entrustBatchID;           //委托批次号(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string entrustMsg;               //委托返回信息Type.ByValTStr, SizeConst = 129)] public string
    };

    //STOCK-委托查询请求
    public struct DFITCStockReqQryEntrustOrderField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int spdOrderID;               //委托号(N)
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码(N)
        public int entrustBatchID;           //委托批次号(N)
        DFITCSECEntrustQryFlagType entrustQryFlag;           //查询标志(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string incQryIndex;              //增量查询索引值(N)(不能超过int最大值)
    };

    //STOCK-委托查询响应
    public struct DFITCStockRspQryEntrustOrderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string offerShareholderID;       //报盘股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public double turnover;                 //成交金额
        public double tradePrice;               //成交价格
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string tradeTime;                //成交时间
        public int tradeQty;                 //成交数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        public double clearFunds;               //清算资金
        DFITCSECEntrustTypeType entrustType;              //委托方式
        public int spdOrderID;               //委托号
        public double entrustPrice;             //委托价格
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        public int entrustQty;               //委托数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string securityType;             //证券类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string entrustTime;              //委托时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string declareTime;              //申报时间
        DFITCSECDeclareResultType declareResult;            //申报结果
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        public double freezeFunds;              //冻结资金
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string noteMsg;                  //结果说明
        public int withdrawQty;              //撤单数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string declareOrderID;           //申报委托号
        DFITCSECOrderTypeType orderType;                //订单类型
        public int entrustBatchID;           //委托批次号
        public int freezeFundsSerialID;      //资金冻结流水号
        public int freezeStockSerialID;      //证券冻结流水号
        public int declareDate;              //申报日期
        public int declareSerialID;          //申报记录号
        public int entrustDate;              //委托日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string incQryIndex;              //增量查询索引值
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string ipAddr;                   //IP地址
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string macAddr;                  //MAC地址
    };

    //STOCK-实时成交查询请求
    public struct DFITCStockReqQryRealTimeTradeField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码(N)
        public int entrustBatchID;           //委托批次号(N)
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别(N)
        public int spdOrderID;               //柜台委托号(N)
        DFITCSECTradeQryFlagType queryFlag;                //查询标志(N)
    };

    //STOCK-实时成交查询响应
    public struct DFITCStockRspQryRealTimeTradeField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int spdOrderID;               //柜台委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string declareOrderID;           //申报委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        public int entrustQty;               //委托数量
        public double entrustPrice;             //委托价格
        public int withdrawQty;              //撤单数量
        public int tradeQty;                 //成交数量
        public double turnover;                 //成交金额
        public double tradePrice;               //成交价格
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string tradeTime;                //成交时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public double clearFunds;               //清算资金
        public int entrustBatchID;           //委托批次号
        DFITCSECOrderTypeType orderType;                //订单类型
    };

    //STOCK-分笔成交查询请求
    public struct DFITCStockReqQrySerialTradeField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int spdOrderID;               //柜台委托号(N)
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码(N)
        public int entrustBatchID;           //委托批次号(N)
        DFITCSECTradeQryFlagType tradeQryFlag;             //查询标志(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string incQryIndex;              //增量查询索引值(N)
    };

    //STOCK-分笔成交查询响应
    public struct DFITCStockRspQrySerialTradeField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string tradeID;                  //成交编号
        public double turnover;                 //成交金额
        public double tradePrice;               //成交价格
        public int tradeQty;                 //成交数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        public double clearFunds;               //清算资金
        public int spdOrderID;               //柜台委托号
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string securityType;             //证劵类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        public double commission;               //佣金
        public int rtnSerialID;              //回报序号
        public double interestQuote;            //利息报价
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string declareOrderID;           //申报委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string incQryIndex;              //增量查询索引值
        public double interest;                 //利息
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string tradeTime;                //成交时间
    };

    //STOCK-持仓查询请求
    public struct DFITCStockReqQryPositionField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码(N)
        DFITCSECPositionQryFlagType posiQryFlag;              //查询标志(N)
    };

    //STOCK-持仓查询响应
    public struct DFITCStockRspQryPositionField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public double sellTurnover;             //当日卖出成交金额
        public int sellTradeQty;             //当日卖出成交数量
        public int sellEntrustQty;           //当日卖出委托数量
        public double buyTurnover;              //当日买入成交金额
        public int buyTradeQty;              //当日买入成交数量
        public int buyEntrustQty;            //当日买入委托数量
        public int nonCirculateQty;          //非流通数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所
        public int openDate;                 //开仓日期
        public int ableSellQty;              //可卖出数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string securityType;             //证券类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        public int securityQty;              //证券数量
        public int position;                 //今持仓量
        public int unSettleQty;              //未交收数量
        public int changeDate;               //变动日期
        public int ablePurchaseQty;          //可申购数量
        public int ableRedemptionQty;        //可赎回数量
        public int freezeQty;                //冻结数量
        public int offsetSQty;               //卖出抵消数量
        public int offsetBQty;               //买入抵消数量
        public int purchaseTradeQty;         //申购成交数量
        public int redemptionTradeQty;       //赎回成交数量
        public int tradeUnit;                //交易单位(N)
        public int totalSellQty;             //累计卖出数量(N)
        public int totalBuyQty;              //累计买入数量(N)
        public int rationedSharesQty;        //配股数量(N)
        public int purchaseQty;              //送股数量(N)
        public double dilutedFloatProfitLoss;   //摊薄浮动盈亏(N)
        public double dilutedBreakevenPrice;    //摊薄保本价(N)
        public double dilutedCost;              //摊薄成本价(N)
        public double avgPositionPrice;         //持仓均价(N)
        public double floatProfitLoss;          //浮动盈亏(N)
        public double dividend;                 //红利金额(N)
        public double totalFloatProfitLoss;     //累计浮动盈亏(N)
        public double sellAmount;               //卖出金额(N)
        public double buyAmount;                //买入金额(N)
        public double buyAvgPrice;              //买入均价(N)
        public double rationedSharesAmount;     //配股金额(N)
        public double latestMarket;             //最新市值(N)
        public double breakevenPrice;           //保本价(N)
        public double latestPrice;              //最新价(N)
        public double nonCirculateMarket;       //非流通市值(N)
        public double interestQuote;            //利息报价(N)
        public double preClosePrice;            //昨收盘价(N)(预留)
    };

    //STOCK-客户资金查询请求
    public struct DFITCStockReqQryCapitalAccountField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        DFITCSECFundsQryFlagType FundsQryFlag;             //查询标志(N)
    };

    //STOCK-客户资金查询响应
    public struct DFITCStockRspQryCapitalAccountField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public double availableFunds;           //可用资金
        public double t2AvailableFunds;         //T+2可用资金
        public double anticipatedInterest;      //预计利息
        public double accountBalance;           //账户余额
        DFITCSECAccountStatusType accountStatus;            //帐户状态
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public double freezeFunds;              //冻结资金
        public double t2FreezeFunds;            //T+2冻结资金
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //机构代码
        public double totalFunds;               //总资金(查询标志为1时会返回值
        public double totalMarket;              //总市值(查询标志为1时会返回值)
    };

    //STOCK-客户信息查询请求
    public struct DFITCStockReqQryAccountField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
    };

    //STOCK-客户信息查询响应
    public struct DFITCStockRspQryAccountField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string tel;                      //电话
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string accountName;              //客户姓名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string accountIdentityID;        //证件编号
        DFITCSECAccountIdentityTypeType accountIdentityType;      //证件类型
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //机构编码
        public int branchType;               //机构标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string mobile;                   //移动电话
        DFITCSECEntrustTypeType entrustType;              //委托方式
        DFITCSECAccountStatusType accountStatus;            //客户状态
        DFITCSECPasswdSyncFlagType pwdSynFlag;               //密码同步标志
    };

    //STOCK-股东信息查询请求
    public struct DFITCStockReqQryShareholderField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
    };

    //STOCK-股东信息查询响应
    public struct DFITCStockRspQryShareholderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string account;                  //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        DFITCSECShareholderSpecPropType shareholderSpecProp;      //股东指定属性
        DFITCSECTradePermissionsType tradePermissions;         //交易权限
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所
        DFITCSECShareholderStatusType shareholderStatus;        //股东状态
        DFITCSECMainAccountFlagType mainAccountFlag;          //主账户标志
        DFITCSECShareholderCtlPropType shareholderCtlProp;       //股东控制属性
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //机构编码
        public int shareholderType;          //股东类别
    };

    //STOCK-资金调转请求
    public struct DFITCStockReqTransferFundsField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string summaryMsg;               //摘要(N)
        public double operateFunds;             //发生金额(Y)
        DFITCSECFundsTransferFlagType fundsTransFlag;           //资金调转标志(Y)
    };

    //STOCK-资金调转响应
    public struct DFITCStockRspTransferFundsField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int serialID;                 //流水号
        public double accountBanlance;          //账户余额
        public double availableFunds;           //可用资金
        public double t2AvailableFunds;         //T+2可用资金
        DFITCSECFundsTransferFlagType fundsTransFlag;           //资金调转标志
    };

    //STOCK-批量委托请求
    public struct DFITCStockReqEntrustBatchOrderField
    {
        public int requestID;                //请求ID(Y)
        public int localOrderID;             //本地委托号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int entrustCount;             //委托数量(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string entrustDetail;            //委托详细信息(Y)
        public int entrustBatchID;           //委托批次号(N)
    };

    //STOCK-批量委托响应
    public struct DFITCStockRspEntrustBatchOrderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int localOrderID;             //本地委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string orderRangeID;             //委托号范围
        public int entrustBatchID;           //委托批次号
        public int sucEntrustCount;          //成功委托笔数
    };

    //STOCK-批量撤单请求
    public struct DFITCStockReqWithdrawBatchOrderField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string orderRangeID;             //委托号范围(Y)
        public int entrustBatchID;           //委托批次号(N)
    };

    //STOCK-批量撤单响应
    public struct DFITCStockRspWithdrawBatchOrderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string result;                   //撤单结果
    };

    //STOCK-计算可委托数量请求
    public struct DFITCStockReqCalcAbleEntrustQtyField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public double entrustPrice;             //委托价格(N)(限价订单必须送入数值)
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码(Y)
        DFITCSECOrderTypeType orderType;                //订单类型(Y)
    };

    //STOCK-计算可委托数量响应
    public struct DFITCStockRspCalcAbleEntrustQtyField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        public int ableEntrustQty;           //可委托数量
    };

    //STOCK-计算可买入ETF股票篮数请求
    public struct DFITCStockReqCalcAblePurchaseETFQtyField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码(Y)
    };

    //STOCK-计算可买入ETF股票篮数响应
    public struct DFITCStockRspCalcAblePurchaseETFQtyField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        public int ablePurchaseETFQty;       //可委托数量
    };

    //STOCK-资金冻结明细查询请求
    public struct DFITCStockReqQryFreezeFundsDetailField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种(N)
        DFITCSECFundsFreezeTypeType fundsFreezeType;          //冻结类别(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int serialID;                 //流水号(N)
    };

    //STOCK-资金冻结明细查询响应
    public struct DFITCStockRspQryFreezeFundsDetailField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        DFITCSECFundsFreezeTypeType fundsFreezeType;          //冻结类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string accountName;              //客户姓名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string summaryMsg;               //摘要
        public int serialID;                 //流水号
        public double operatorFunds;            //发生金额
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string operatorTime;             //发生时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //机构代码
        public int operatorDate;             //发生日期
    };

    //STOCK-证券冻结明细查询请求
    public struct DFITCStockReqQryFreezeStockDetailField
    {
        public int requestID;                //请求ID(Y)
        DFITCSECStockFreezeTypeType stockFreezeType;          //冻结类别(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码(N)
        public int serialID;                 //流水号(N)
    };

    //STOCK-证券冻结明细查询响应
    public struct DFITCStockRspQryFreezeStockDetailField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        DFITCSECStockFreezeTypeType stockFreezeType;          //冻结类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string accountName;              //客户姓名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string securityType;             //证券类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string summaryMsg;               //摘要
        public int serialID;                 //流水号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string operatorTime;             //发生时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //营业部
        public int operatorDate;             //发生日期
        public int operatorQty;              //发生数量
    };

    //STOCK-查询资金调拨明细请求
    public struct DFITCStockReqQryTransferFundsDetailField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种(N)
        DFITCSECTransFundsFreezeTypeType fundsFreezeType;          //冻结类别(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int serialID;                 //流水号(N)
    };

    //STOCK-资金调拨明细查询响应
    public struct DFITCStockRspQryTransferFundsDetailField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        DFITCSECTransFundsFreezeTypeType fundsFreezeType;          //冻结类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string accountName;              //客户姓名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string summaryMsg;               //摘要
        public int serialID;                 //流水号
        public double operatorFunds;            //发生金额
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string operatorTime;             //发生时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //机构代码
        public int operatorDate;             //发生日期
    };

    //STOCK-查询客户证券调拨明细请求
    public struct DFITCStockReqQryTransferStockDetailField
    {
        public int requestID;                 //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所编码(N)
        DFITCSECStockFreezeTypeType stockFreezeType;           //冻结类别(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string incQryIndex;               //增量查询索引值(N)
        public int serialID;                  //流水号(N)
    };

    //STOCK-查询客户证券调拨明细响应
    public struct DFITCStockRspQryTransferStockDetailField
    {
        public int requestID;                 //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string accountName;               //客户名称
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                  //机构代码
        public int operatorDate;              //发生日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所编码
        DFITCSECStockFreezeTypeType stockFreezeType;           //冻结类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;                //证劵代码
        public int serialID;                  //流水号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;             //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string summaryMsg;                //摘要
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string operatorTime;              //发生时间
        public int operatorQty;               //发生数量
    };

    //STOCK-证券信息查询请求
    public struct DFITCStockReqQryStockField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码(Y)
    };

    //STOCK-证券信息查询响应
    public struct DFITCStockRspQryStockField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        DFITCSECStockTradeFlagType stopFlag;                 //停牌标志
        public double latestPrice;              //最新价
        public double preClosePrice;            //昨收盘价
        public double openPrice;                //开盘价
        public int tradeQty;                 //成交数量
        public double turnover;                 //成交金额
        public double priceHigher;              //最高价
        public double priceLower;               //最低价
        public double bidPrice1;                //申买价一
        public int bidQty1;                  //申买量一
        public double askPrice1;                //申卖价一
        public int askQty1;                  //申卖量一
        public double bidPrice2;                //申买价二
        public int bidQty2;                  //申买量二
        public double askPrice2;                //申卖价二
        public int askQty2;                  //申卖量二
        public double bidPrice3;                //申买价三
        public int bidQty3;                  //申买量三
        public double askPrice3;                //申卖价三
        public int askQty3;                  //申卖量三
        public double bidPrice4;                //申买价四
        public int bidQty4;                  //申买量四
        public double askPrice4;                //申卖价四
        public int askQty4;                  //申卖量四
        public double bidPrice5;                //申买价五
        public int bidQty5;                  //申买量五
        public double askPrice5;                //申卖价五
        public int askQty5;                  //申卖量五
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        public double interestQuote;            //利息报价
        public double securityFaceValue;        //证券面值
        DFITCSECBidTradeFlagType bidTradeFlag;             //竞价交易标志
        public int tradeUnit;                //交易单位
        DFITCSECBusinessLimitType businessLimit;            //买卖限制
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string securityType;             //证券类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        public double upperLimitPrice;          //涨停板价
        public double lowerLimitPrice;          //跌停板价
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string orderLimits;              //订单类型限制
    };

    //STOCK-查询交易时间请求
    public struct DFITCStockReqQryTradeTimeField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
    };

    //STOCK-查询交易时间响应
    public struct DFITCStockRspQryTradeTimeField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int sysTradingDay;            //系统当前日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string sysTime;                  //系统当前时间
    };

    //STOCK-委托回报
    public struct DFITCStockEntrustOrderRtnField
    {
        public int localOrderID;             //本地委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int sessionID;                //会话编号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string securityType;             //证券类别
        public int withdrawQty;              //撤单数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        public double freezeFunds;              //冻结资金
        public int spdOrderID;               //柜台委托号
        public DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        public DFITCSECDeclareResultType declareResult;            //申报结果
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string noteMsg;                  //结果说明
        public int entrustQty;               //委托数量
        DFITCSECOrderConfirmFlagType orderConfirmFlag;         //委托确认标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string entrustTime;              //委托时间
        public double entrustPrice;             //委托价格
        DFITCSECOrderTypeType orderType;                //订单类型
    };

    //STOCK-成交回报
    public struct DFITCStockTradeRtnField
    {
        public int localOrderID;             //本地委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int sessionID;                //会话编号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string securityType;             //证券类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string tradeID;                  //成交编号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string tradeTime;                //成交时间
        public int withdrawQty;              //撤单数量
        public int spdOrderID;               //柜台委托号
        public DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        public double clearFunds;               //清算资金
        public int totalTradeQty;            //委托总成交数量
        public double totalTurnover;            //委托总成交金额
        public int tradeQty;                 //本次成交数量
        public double tradePrice;               //本次成交价格
        public double turnover;                 //本次成交金额
        public int entrustQty;               //委托数量
        public DFITCSECDeclareResultType declareResult;            //申报结果(预留字段)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string noteMsg;                  //结果说明(预留字段)
    };

    //STOCK-撤单回报
    public struct DFITCStockWithdrawOrderRtnField
    {
        public int localOrderID;             //本地委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int sessionID;                //会话编号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string securityType;             //证券类别
        public int withdrawQty;              //撤单数量
        public int tradeQty;                 //成交数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        public double freezeFunds;              //冻结资金
        public int spdOrderID;               //柜台委托号
        public DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        public int entrustQty;               //委托数量
        DFITCSECDeclareResultType declareResult;            //申报结果(预留字段)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string noteMsg;                  //结果说明(预留字段)
    };

    //SOP-委托请求
    public struct DFITCSOPReqEntrustOrderField
    {
        public int requestID;                //请求ID(Y)
        public int localOrderID;             //本地委托号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string subAccountID;             //子账户编码(N)(预留字段)
        public int entrustQty;               //委托数量(Y)
        public double entrustPrice;             //委托价格(N)
        public DFITCSECEntrustDirectionType entrustDirection;         //委托类别(Y)
        public DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志(Y)
        public DFITCSECCoveredFlagType coveredFlag;              //备兑类型(Y)
        public DFITCSECOrderTypeType orderType;                //订单类型(Y)
        public DFITCSECOrderExpiryDateType orderExpiryDate;          //订单时效限制(N)
        public DFITCSECOrderCategoryType orderCategory;            //委托单类别(Y)
        public int serialID;                 //扩展流水号(N)(预留字段)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string devID;                    //厂商ID(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string devDecInfo;               //用户自定义字段(N)
    };

    //SOP-委托响应
    public struct DFITCSOPRspEntrustOrderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int localOrderID;             //本地委托号
        public int spdOrderID;               //柜台委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string entrustTime;              //委托时间
        public double freezeFunds;              //冻结资金
    };

    //SOP-委托回报
    public struct DFITCSOPEntrustOrderRtnField
    {
        public int localOrderID;             //本地委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int sessionID;                //会话编号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //机构代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public int spdOrderID;               //柜台委托号
        public DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        public DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志
        public double entrustPrice;             //委托价格
        public int entrustQty;               //委托数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string entrustTime;              //委托时间
        public DFITCSECCoveredFlagType coveredFlag;              //备兑类型
        public DFITCSECOrderTypeType orderType;                //订单类型
        public  DFITCSECOrderExpiryDateType orderExpiryDate;          //订单时效限制
        public DFITCSECOrderCategoryType orderCategory;            //委托单类别
        public DFITCSECDeclareResultType declareResult;            //申报结果
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string noteMsg;                  //结果说明
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string devID;                    //厂商ID(N),下单时填入该字段，才会返回
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string devDecInfo;               //用户自定义字段(N)，下单时填入该字段，才会返回
    };

    //SOP-成交回报
    public struct DFITCSOPTradeRtnField
    {
        public int localOrderID;             //本地委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int sessionID;                //会话编号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public int spdOrderID;               //柜台委托号
        public DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        public DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志
        public DFITCSECCoveredFlagType coveredFlag;              //备兑标志
        public DFITCSECOrderCategoryType orderCategory;            //委托单类别
        public double tradePrice;               //成交价格
        public int tradeQty;                 //成交数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string tradeID;                  //成交编号
        public int rtnSerialID;              //回报序号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string declareOrderID;           //申报委托号
        public DFITCSECDeclareResultType declareResult;            //申报结果
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string noteMsg;                  //结果说明
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string devID;                    //厂商ID(N),下单时填入该字段，才会返回
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string devDecInfo;               //用户自定义字段(N),下单时填入该字段，才会返回
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string tradeTime;                //成交时间
    };

    //SOP-撤单回报
    public struct DFITCSOPWithdrawOrderRtnField
    {
        public int localOrderID;             //本地委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int sessionID;                //会话编号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public int spdOrderID;               //柜台委托号
        public DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        public DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志
        public int withdrawQty;              //撤单数量
        public int tradeQty;                 //成交数量
        public DFITCSECDeclareResultType declareResult;            //申报结果
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string noteMsg;                  //结果说明
        public double wdUnFreezeFunds;          //撤单解冻资金
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string devID;                    //厂商ID(N),下单时填入该字段，才会返回
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string devDecInfo;               //用户自定义字段(N),下单时填入该字段，才会返回
    };

    //SOP-证券锁定解锁委托请求
    public struct DFITCSOPReqLockOUnLockStockField
    {
        public int requestID;                //请求ID(Y)
        public int localOrderID;             //本地委托号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string subAccountID;             //子账户编码 (N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //合约代码(Y)
        public int entrustQty;               //委托数量(Y)
        DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string devID;                    //厂商ID(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string devDecInfo;               //用户自定义字段(N)
    };

    //SOP-证券锁定解锁委托响应
    public struct DFITCSOPRspLockOUnLockStockField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int localOrderID;             //本地委托号
        public int spdOrderID;               //柜台委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string entrustTime;              //委托时间
        public double freezeFunds;              //冻结资金
    };

    //SOP-分笔成交查询请求
    public struct DFITCSOPReqQrySerialTradeField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码(N)
        public int spdOrderID;               //委托号(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string incQryIndex;              //增量查询索引值(N)(预留字段)
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别(N)
        public int entrustBatchID;           //委托批次号(N)(预留字段)
        DFITCSECTradeQryFlagType tradeQryFlag;             //查询标志(N)(预留字段)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种(N)
        public int rowIndex;                 //分页索引值(N)
        public int rowCount;                 //每页查询笔数(N)
    };

    //SOP-分笔成交查询响应
    public struct DFITCSOPRspQrySerialTradeField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        public int rtnSerialID;              //回报序号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string declareOrderID;           //申报委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string tradeID;                  //成交编号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string tradeTime;                //成交时间
        public int tradeQty;                 //成交数量
        DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志
        DFITCSECCoveredFlagType coveredFlag;              //备兑标志
        public int spdOrderID;               //委托号
        public double turnover;                 //成交金额
        public double tradePrice;               //成交价格
        public double clearFunds;               //清算资金
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string rotationTime;             //回转时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string incQryIndex;              //分页索引值
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string capitalID;                //资金账号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string devID;                    //厂商ID(N),委托时传入该字段才会返回
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string devDecInfo;               //用户自定义字段(N),委托时传入该字段才会返回
    };

    //SOP-委托查询请求
    public struct DFITCSOPReqQryEntrustOrderField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志(N)
        public int exSerialID;               //扩展流水号(N)(预留字段)
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别(N)
        public int spdOrderID;               //委托号(N)
        DFITCSECEntrustQryFlagType entrustQryFlag;           //查询标志(N)
        public int rowIndex;                 //分页索引值(N)
        public int rowCount;                 //每页查询笔数(N)
    };

    //SOP-委托查询响应
    public struct DFITCSOPRspQryEntrustOrderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int spdOrderID;               //委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string withdrawOrderID;          //撤销委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string declareOrderID;           //申报委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;             //撤销标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码
        DFITCSECOptionTypeType optType;                  //期权类别
        DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志
        DFITCSECCoveredFlagType coveredFlag;              //备兑标志
        public int entrustQty;               //委托数量
        public double entrustPrice;             //委托价格
        public int entrustDate;              //委托日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string entrustTime;              //委托时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string offerShareholderID;       //报盘股东号
        public int declareDate;              //申报日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string declareTime;              //申报时间
        public int declareSerialID;          //申报记录号
        DFITCSECDeclareResultType declareResult;            //申报结果
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string noteMsg;                  //结果说明
        public int withdrawQty;              //撤单数量
        public int tradeQty;                 //成交数量
        public double turnover;                 //成交金额
        public double tradePrice;               //成交价格
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public double freezeFunds;              //冻结资金
        public double clearFunds;               //清算资金
        DFITCSECEntrustTypeType entrustType;              //委托方式
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string macAddr;                  //MAC地址
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string ipAddr;                   //IP地址
        public int entrustBatchID;           //委托批次号
        DFITCSECOrderTypeType orderType;                //委托类型
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string incQryIndex;              //增量查询索引值
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string capitalID;                //资金账号
        DFITCSECOrderExpiryDateType orderExpiryDate;          //订单时效限制
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string devID;                    //厂商ID(N),委托时传入该字段才会返回
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string devDecInfo;               //用户自定义字段(N),委托时传入该字段才会返回
    };

    //SOP-持仓查询请求
    public struct DFITCSOPReqQryPositionField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码(N)
        public int rowIndex;                 //分页索引值(N)
        public int rowCount;                 //每页查询笔数(N)
    };

    //SOP-持仓查询响应
    public struct DFITCSOPRspQryPositionField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string subAccountID;             //子账户编码            //子账户编码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string contractID;               //期权编码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string contractName;             //期权名称
        public DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        public DFITCSECCoveredFlagType coveredFlag;              //备兑标志
        public int executeDate;              //行权日期
        public int totalQty;                 //当前数量
        public int availableQty;             //可用数量
        public double latestPrice;              //最新价
        public double optionMarket;             //期权市值
        public int freezeQty;                //冻结数量
        public int executeQty;               //执行数量
        public int openEntrustQty;           //开仓委托数量
        public int openTradeQty;             //开仓成交数量
        public int prePosition;              //昨持仓
        public int closeEntrustQty;          //平仓委托数量
        public int closeTradeQty;            //平仓成交数量
        public double deposit;                  //保证金
        public double openDeposit;              //本日开仓保证金
        public double closeDeposit;             //本日平仓保证金
        public double exchangeDeposit;          //交易所保证金
        public double exchangeOpenDeposit;      //交易所开仓保证金
        public double exchangeCloseDeposit;     //交易所平仓保证金
        public double openAvgPrice;             //开仓均价
        DFITCSECOptionTypeType optType;                  //期权类型
        DFITCSECContractObjectTypeType contractObjectType;       //标的类型
        public int contractUnit;             //合约单位
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public double totalTradeCost;           //累计交易成本(到昨日位置累计)
        public double tradeCost;                //本日交易成本(实时更新)
        public double realizeProfitLoss;        //实现盈亏(预留字段)
        public double profitLoss;               //盈亏金额(预留字段)
        DFITCSECContractAdjustRemindType adjustRemind;             //合约调整提醒标志
        DFITCSECContraceExpireRemindType expireRemind;             //合约即将到期提醒标志
    };

    //SOP-客户担保持仓查询请求
    public struct DFITCSOPReqQryCollateralPositionField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码(N)
    };

    //SOP-客户担保持仓查询响应
    public struct DFITCSOPRspQryCollateralPositionField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        public int availableQty;             //可用数量
    };

    //SOP-客户资金查询请求
    public struct DFITCSOPReqQryCapitalAccountField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种(N)(当前只支持人民币)
        DFITCSECFundsQryFlagType FundsQryFlag;             //查询标志(预留字段)
    };

    //SOP-客户资金查询响应
    public struct DFITCSOPRspQryCapitalAccountField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //机构编码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public double accountBanlance;          //账户余额
        public double availableFunds;           //可用资金
        public double freezeFunds;              //冻结资金
        public double anticipatedInterest;      //预计利息
        public double usedDeposit;              //占用保证金
        DFITCSECAccountStatusType accountStatus;            //客户状态
        public double totalFunds;               //总资金
        public double totalMarket;              //总市值
        public double cashAssets;               //现金资产
        public double execGuaranteeRatio;       //履约担保比例
        public double buyLimits;                //买入额度
    };

    //SOP-客户信息查询请求
    public struct DFITCSOPReqQryAccountField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
    };

    //SOP-客户信息查询响应
    public struct DFITCSOPRspQryAccountField
    {
        public int requestID;                //请求
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string accountName;              //客户姓名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string accountFullName;          //客户全名
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //机构编码
        DFITCSECAccountIdentityTypeType identityType;             //证件类型
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string accountIdentityID;        //证件编号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string tel;                      //客户电话
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string mobile;                   //移动电话
        DFITCSECAccountTypeType accountType;              //投资者分类
        DFITCSECAccountPropType accountProp;              //客户属性
        DFITCSECTradePermissionsType tradePermissions;         //交易权限(预留字段)
        DFITCSECEntrustTypeType entrustType;              //委托方式
        DFITCSECAccountStatusType accountStatus;            //客户状态
        DFITCSECPasswdSyncFlagType pwdSynFlag;               //密码同步标志
        public int accountNodeID;            //客户所属节点编号
    };

    //SOP-可委托数量查询请求
    public struct DFITCSOPReqCalcAbleEntrustQtyField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string subAccountID;             //子账户编码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码(Y)
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别(Y)
        DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志(Y)
        DFITCSECCoveredFlagType coveredFlag;              //备兑标志(N)
        public double entrustPrice;             //委托价格(N)
        DFITCSECCheckUpLimitFlagType checkUpLimit;             //是否检查委托上限(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string devID;                    //厂商ID(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string devDecInfo;               //用户自定义字段(N)
    };

    //SOP-可委托数量查询响应
    public struct DFITCSOPRspCalcAbleEntrustQtyField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码
        public int entrustQty;               //委托数量
    };

    //SOP-股东信息查询请求
    public struct DFITCSOPReqQryShareholderField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
    };

    //SOP-股东信息查询响应
    public struct DFITCSOPRspQryShareholderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //机构编码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        DFITCSECTradePermissionsType tradePermissions;         //交易权限
        DFITCSECShareholderSpecPropType shareholderSpecProp;      //股东指定属性
        DFITCSECShareholderCtlPropType shareholderCtlProp;       //股东控制属性
        DFITCSECShareholderStatusType shareholderStatus;        //股东状态
        DFITCSECMainAccountFlagType mainAccountFlag;          //主账户标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
    };

    //SOP-客户可锁定证券查询请求
    public struct DFITCSOPReqQryAbleLockStockField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码(Y)
    };

    //SOP-客户可锁定证券查询响应
    public struct DFITCSOPRspQryAbleLockStockField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称(预留字段)
        public int securityQty;              //持有数量(预留字段)
        public int position;                 //当前数量(预留字段)
        public double avgPositionPrice;         //持仓均价(预留字段)
        public double dilutedCost;              //摊薄成本价(预留字段)
        public double breakevenPrice;           //保本价(预留字段)
        public double dilutedBreakevenPrice;    //摊薄保本价(预留字段)
        public int ableSellQty;              //可卖出数量
        public double latestMarket;             //最新市值(预留字段)
        public double latestPrice;              //最新价(预留字段)
        public double floatProfitLoss;          //浮动盈亏(预留字段)
        public double dilutedFloatProfitLoss;   //摊薄浮动盈亏(预留字段)
        public int tradeUnit;                //交易单位(预留字段)
        public int openBuyQty;               //今开仓买入持仓量(预留字段)
        public int openSellQty;              //今开仓卖出持仓量(预留字段)
        public int buyUnSettleQty;           //买入未交收持仓量(预留字段)
        public int sellUnSettleQty;          //卖出未交收持仓量(预留字段)
        public int openEntrustSellQty;       //今开仓委托卖出量(预留字段)
        public int ableLockQty;              //可锁定数量
    };

    //SOP-客户行权指派信息查询请求
    public struct DFITCSOPReqQryExecAssiInfoField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码(N)
        public int tradeDate;                //查询日期(N)
    };

    //SOP-客户行权指派信息查询响应
    public struct DFITCSOPRspQryExecAssiInfoField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int tradeDate;                //成交日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string branchID;                 //机构代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string subAccountID;             //子账户
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        DFITCSECOptionTypeType optType;                  //期权类型
        DFITCSECContractObjectTypeType contractObjectType;       //标的类型
        DFITCSECCoveredFlagType coveredFlag;              //备兑标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //标的代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string seatID;                   //席位代码
        public double execPrice;                //行权价格
        public int execQty;                  //行权数量
        public int tradeQty;                 //成交数量
        public double clearFunds;               //清算金额
        public double settleFunds;              //结算金额
        public double commission;               //佣金
        public double stampTax;                 //印花税
        public double transferFee;              //过户费
        public double fee3;                     //费用3
        public double fee4;                     //费用4
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string summaryMsg;               //摘要
    };

    //SOP-期权合约代码查询请求
    public struct DFITCSOPReqQryContactField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //标的代码(N)
        DFITCSECContractObjectTypeType contractObjectType;       //标的类型(N)
        DFITCSECOptionTypeType optType;                  //期权类型(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string rowIndex;                 //分页索引值(预留字段)(N)
        public int rowCount;                 //每页查询笔数(预留字段)(N)
    };

    //SOP-期权合约代码查询响应
    public struct DFITCSOPRspQryContactField
    {
        public int requestID;                 //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;          //期权交易代码(10000031)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string contractID;                //期权标识代码(600104C1406M01200)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string contractName;              //期权名称(上汽集团购6月1200)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;                //标的代码(600104)
        public DFITCSECContractObjectTypeType contractObjectType;        //标的类型
        public DFITCSECExecuteTypeType execType;                  //行权方式
        public DFITCSECDeliveryTypeType deliType;                  //交割方式(预留字段)
        public DFITCSECOptionTypeType optType;                   //期权类型
        public int contactUnit;               //合约单位
        public double latestPrice;               //最新价
        public int beginTradingDay;           //开始交易日
        public int endTradingDay;             //最后交易日
        public int execDate;                  //行权日期
        public int endDate;                   //到期日
        public int positionUpLimit;           //持仓上限
        public double priceUpLimit;              //涨停价
        public double priceDownLimit;            //跌停价
        public double priceHigher;               //最高价
        public double priceLower;                //最低价
        public int entrustUpLimit;            //委托上限
        public int entrustDownLimit;          //委托下限
        public int entrustUpLimitMarketPri;   //市价委托上限(MP=Market Price)
        public int entrustDownLimitMarketPri; //市价委托下限
        DFITCSECOpenLimitsType openLimit;                 //开仓限制
        DFITCSECStockTradeFlagType stockTradeFlag;            //停牌标志
        public double depositUnit;               //单位保证金
        public double depositRatioC;             //保证金比例1
        public double depositRatioE;             //保证金比例2
        public double preClosePrice;             //昨收盘价
        public double closePrice;                //今收盘价
        public double preSettlePrice;            //昨结算价
        public double openPrice;                 //开盘价
        public int tradeQty;                  //成交数量
        public double turnover;                  //成交金额
        public double settlePrice;               //结算价(预留字段)
        public double endCashSettlePrice;        //到期现金结算价
        public int handQty;                   //整手数
        public int unClosePositionQty;        //未平仓合约
        public int approachExpireFlag;        //临近到期标志
        public int tempAdjustFlag;            //临时调整标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string stockListFlag;             //股票挂牌标志
        public double execPrice;                 //行权价格
        public double bidPrice1;                 //申买价1
        public int bidQty1;                   //申买量1
        public double bidPrice2;                 //申买价2
        public int bidQty2;                   //申买量2
        public double bidPrice3;                 //申买价3
        public int bidQty3;                   //申买量3
        public double bidPrice4;                 //申买价4
        public int bidQty4;                   //申买量4
        public double bidPrice5;                 //申买价5
        public int bidQty5;                   //申买量5
        public double askPrice1;                 //申卖价1
        public int askQty1;                   //申卖量1
        public double askPrice2;                 //申卖价2
        public int askQty2;                   //申卖量2
        public double askPrice3;                 //申卖价3
        public int askQty3;                   //申卖量3
        public double askPrice4;                 //申卖价4
        public int askQty4;                   //申卖量4
        public double askPrice5;                 //申卖价5
        public int askQty5;                   //申卖量5
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string optionIndex;               //股票期权索引值
        public double miniPriceChange;           //最小变动价位
    };

    //SOP-期权标的信息查询请求
    public struct DFITCSOPReqQryContractObjectField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //标的代码(N)
        DFITCSECContractObjectTypeType securityObjectType;       //标的类型(N)
    };

    //SOP-期权标的信息查询响应
    public struct DFITCSOPRspQryContractObjectField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //标的证券名称
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //标的代码
        DFITCSECContractObjectTypeType contractObjectType;       //标的类型
        DFITCSECContractObjectStatusType contractObjectStatus;     //标的证券状态
    };

    //SOP-执行委托请求
    public struct DFITCSOPReqExectueOrderField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int localOrderID;             //本地委托号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string subAccountID;             //子账户编码(N)
        public int entrustQty;               //委托数量(Y)
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别(Y)
        DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string devID;                    //厂商ID(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string devDecInfo;               //用户自定义字段(N)
    };

    //SOP-执行委托响应
    public struct DFITCSOPRspExectueOrderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int localOrderID;             //本地委托号
        public int spdOrderID;               //柜台委托号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string entrustTime;              //委托时间
        public double freezeFunds;              //冻结资金
    };

    //SOP-查询交易时间请求
    public struct DFITCSOPReqQryTradeTimeField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
    };

    //SOP-查询交易时间响应
    public struct DFITCSOPRspQryTradeTimeField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int sysTradingDay;            //系统当前日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string sysTime;                  //系统当前时间
    };

    //SOP-获取所有交易所参数请求
    public struct DFITCSOPReqQryExchangeInfoField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
    };

    //SOP-获取所有交易所参数响应
    public struct DFITCSOPRspQryExchangeInfoField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string exchangeName;             //交易所简称
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string callauctionBegining;      //集合竞价开始时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string callauctionEnding;        //集合竞价结束时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string morningOpening;           //上午开市时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string morningClosing;           //上午闭市时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string afternoonOpening;         //下午开市时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string afternoonClosing;         //下午闭市时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string execOpening;              //行权开始时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string execClosing;              //行权结束时间
        public int nightTradeFlag;           //夜市交易标志
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string nightOpening;             //夜市开始时间
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string nightClosing;             //夜市结束时间
        DFITCSECStockTradeFlagType stockTradeStatus;         //交易状态
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        public int tradingDayFlag;           //交易日标识
    };

    //SOP-查询手续费参数请求
    public struct DFITCSOPReqQryCommissionField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        DFITCSECReferenceTypeType refType;                  //参数类别(N)
        DFITCSECContractObjectTypeType contractObjectType;       //标的类型(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //分类代码(N)
        DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志(N)
        DFITCSECLvelType level;                    //级别(Y)
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别(N)
    };

    //SOP-查询手续费参数响应
    public struct DFITCSOPRspQryCommissionField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        DFITCSECReferenceTypeType refType;                  //参数类别
        DFITCSECContractObjectTypeType contractObjectType;       //标的类型
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //分类代码
        DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别
        DFITCSECLvelType level;                    //级别
        public double costRatio1;               //费用比例1
        public double unitCost1;                //单位费用1
        public double costUpLimit1;             //费用上限1
        public double costDonwLimit1;           //费用下限1
        public double costRatio2;               //费用比例2
        public double unitCost2;                //单位费用2
        public double costUpLimit2;             //费用上限2
        public double costDonwLimit2;           //费用下限2
        public double costRatio3;               //费用比例3
        public double unitCost3;                //单位费用3
        public double costRatio4;               //费用比例4
        public double unitCost4;                //单位费用4
    };

    //SOP-查询保证金率参数请求
    public struct DFITCSOPReqQryDepositField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
        DFITCSECReferenceTypeType refType;                  //参数类别(N)
        DFITCSECContractObjectTypeType securityObjectType;       //标的类型(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //分类代码(N)
        DFITCSECLvelType level;                    //级别(Y)
    };

    //SOP-查询保证金率参数响应
    public struct DFITCSOPRspQryDepositField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        DFITCSECReferenceTypeType refType;                  //参数类别
        DFITCSECContractObjectTypeType securityObjectType;       //标的类型
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //分类代码
        public double depositRateC;             //保证金比例1
        public double depositRateE;             //保证金比例2
        public double depositUnit;              //单位保证金
        public int calcType;                 //计算方式
        DFITCSECLvelType level;                    //级别
    };

    //FASL-客户可融资信息请求
    public struct DFITCFASLReqAbleFinInfoField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
    };

    //FASL-客户可融资信息响应
    public struct DFITCFASLRspAbleFinInfoField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public double accountBanlance;          //账户余额
        public double ableFinFunds;             //可融资资金
        public double turnover;                 //成交金额
        public double entrustFreezeFunds;       //委托冻结金额
    };

    //STOCK-可用行情信息查询请求
    public struct DFITCReqQuotQryField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
    };

    //STOCK-可用行情信息查询响应
    public struct DFITCRspQuotQryField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
    };

    //FASL-客户可融券信息请求
    public struct DFITCFASLReqAbleSloInfoField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
    };

    //FASL-客户可融券信息响应
    public struct DFITCFASLRspAbleSloInfoField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        public int ableSloQty;               //可融券数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        public int entrustQty;               //委托数量
        public int tradeQty;                 //成交数量
        DFITCSECTradeStatusType status;                   //状态
        public double sloDepositRatio;          //融券保证金比例
    };

    //FASL-担保物划转请求
    public struct DFITCFASLReqTransferCollateralField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int localOrderID;             //本地委托号(Y)
        DFITCSECEntrustDirectionType entrustDirection;         //委托类别(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码(Y)
        public int transferQty;              //划转数量(Y)
    };

    //FASL-担保物划转响应
    public struct DFITCFASLRspTransferCollateralField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int spdOrderID;               //柜台委托号
        public int localOrderID;             //本地委托号
    };

    //FASL-直接还款请求
    public struct DFITCFASLReqDirectRepaymentField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string contractNO;               //指定合约编号(N)
        public double repayFunds;               //偿还金额(Y)
    };

    //FASL-直接还款响应
    public struct DFITCFASLRspDirectRepaymentField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public double realRepayFunds;           //实际还款金额
    };

    //FASL-还券划转请求
    public struct DFITCFASLReqRepayStockTransferField
    {
        public int requestID;                 //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号(Y)
        public int localOrderID;              //本地委托号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所代码(Y)
        public int repayQty;                  //还券数量(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;                //证劵代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string contractNO;                //指定合约编号(N)
    };

    //FASL-还券划转响应
    public struct DFITCFASLRspRepayStockTransferField
    {
        public int requestID;                 //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号
        public int spdOrderID;                //柜台委托号
        public int localOrderID;              //本地委托号
    };

    //FASL-信用交易请求
    public struct DFITCFASLReqEntrustCrdtOrderField
    {
        public int requestID;                 //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号(Y)
        public int localOrderID;              //本地委托号(Y)
        DFITCSECEntrustDirectionType entrustDirection;          //委托类别(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string contractNO;                //指定合约编号(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;                //证劵代码(Y)
        DFITCSECOrderTypeType orderType;                 //订单类型(Y)
        public int entrustQty;                //委托数量(Y)
        public double entrustPrice;              //委托价格(Y)
    };

    //FASL-信用交易响应
    public struct DFITCFASLRspEntrustCrdtOrderField
    {
        public int requestID;                 //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号
        public int spdOrderID;                //柜台委托号
        public int localOrderID;              //本地委托号
    };


    //FASL-信用委托撤单请求
    public struct DFITCFASLReqWithdrawOrderField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int spdOrderID;               //柜台委托号(N)
        public int localOrderID;             //本地委托号(N)(柜台委托号和本地委托号二选一)
    };

    //FASL-信用委托撤单响应
    public struct DFITCFASLRspWithdrawOrderField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int localOrderID;             //本地委托号
        public int spdOrderID;               //柜台委托号
    };


    //FASL-融资融券交易请求
    public struct DFITCFASLReqEntrustOrderField
    {
        public int requestID;                 //请求ID(Y)
        public int localOrderID;              //本地委托号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号(Y)
        DFITCSECEntrustDirectionType entrustDirection;          //委托类别(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;                //证劵代码(Y)
        DFITCSECOrderTypeType orderType;                 //订单类型(Y)
        public int entrustQty;                //委托数量(Y)
        public double entrustPrice;              //委托价格(Y)
        DFITCSECPositionSourceType positionSource;            //头寸来源(N)
    };

    //FASL-融资融券交易响应
    public struct DFITCFASLRspEntrustOrderField
    {
        public int requestID;                 //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号
        public int localOrderID;              //本地委托号
        public int spdOrderID;                //柜台委托号
    };

    //FASL-信用可委托数量查询请求
    public struct DFITCFASLReqCalcAbleEntrustCrdtQtyField
    {
        public int requestID;                 //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号(Y)
        DFITCSECEntrustDirectionType entrustDirection;          //委托类别(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string contractNO;                //指定合约编号(N)(预留字段)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;                //证劵代码(Y)
        DFITCSECOrderTypeType orderType;                 //订单类型(Y)
        public double entrustPrice;              //委托价格(Y)
        DFITCSECPositionSourceType positionSource;            //头寸来源(N)
    };

    //FASL-信用可委托数量查询响应
    public struct DFITCFASLRspCalcAbleEntrustCrdtQtyField
    {
        public int requestID;                 //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号
        public int totalRepayQty;             //总应还数量
        public int entrustQty;                //委托数量
    };

    //FASL-查询信用资金请求
    public struct DFITCFASLReqQryCrdtFundsField
    {
        public int requestID;                 //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号(Y)
    };

    //FASL-查询信用资金响应
    public struct DFITCFASLRspQryCrdtFundsField
    {
        public int requestID;                 //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号
        public double availableDeposit;          //可用保证金
        public double maintGuaranteeRatio;       //维持担保比例
        public double antiMaintGuaranteeRatio;   //预计维持担保比例
        public double accountBanlance;           //账户余额
        public double availableFunds;            //可用资金
        public double clearFunds;                //清算资金
        public double stockMarket;               //证券市值
        public double guaranteeStockSubMarket;   //当天担保证券提交市值
        public double guaranteeStockMarket;      //担保证券市值
        public double tradeFinLiabilities;       //融资负债(已成交)
        public double tradeSloLiabilities;       //融券负债(已成交)
        public double orderFinLiabilities;       //融资负债(未成交)
        public double orderSloLiabilities;       //融券负债(未成交)
        public double sloOrderRepay;             //融券归还(未成交)
        public double fundsBalance;              //资金差额
        public double closeFunds;                //平仓金额
        public double activeCloseFunds;          //主动平仓金额
        public double ableWithdrawalAssetsStand; //可提资产标准
        public double withdrawalFunds;           //可取资金
        public double totalAssets;               //总资产
        public double unTransferStockMarket;     //未过户市值
        public double totalLiabilities;          //总负债
        public double netAssets;                 //净资产
        public double sellRepayFunds;            //本日卖出还款金额
        public double anticipatedInterest;       //预计利息/费用
        public double finProfitLoss;             //融资盈亏
        public double sloProfitLoss;             //融券盈亏
        public double sloFunds;                  //融券金额
        public double finCost;                   //融资费用
        public double sloCost;                   //融券费用
        public double finCurMarket;              //融资当前市值
        public double finUsedDeposit;            //融资占用保证金
        public double sloUsedDeposit;            //融券占用保证金
        public double finAntiInterest;           //融资预计利息
        public double sloAntiInterest;           //融券预计利息
        public double shGuaranteeStockMarket;    //上海担保证券市值
        public double szGuaranteeStockMarket;    //深圳担保证券市值
        public double finFloatProfit;            //融资浮盈折算
        public double finFloatLoss;              //融资浮亏
        public double sloFloatProfit;            //融券浮盈折算
        public double sloFloatLoss;              //融券浮亏
        public double finRatio;                  //融资利率
        public double sloRatio;                  //融券利率
        public int contractEndDate;           //合同到期日
        public double finUsedLimits;             //融资已用额度
        public double sloUsedLimits;             //融券已用额度
        public double finCreditLimits;           //融资授信额度
        public double sloCreditLimits;           //融券授信额度
        public double ableBuyCollateralFunds;    //可买担保品资金
        public double ableRepayFunds;            //可还款金额
        public double sloAvailableFunds;         //融券可用资金
        public double cashAssets;                //现金资产(所有资产、包括融券卖出)
        public double totalStockMarket;          //所有证券市值(包含融资买入、非担保品)
        public double finContractFunds;          //融资合约金额(不包含费用)
        public double contractObjectMarket;      //标的证券市值
        public double otherCharges;              //其他费用
        public double sloCurMarket;              //融券当前市值
    };

    //FASL-信用合约信息请求
    public struct DFITCFASLReqQryCrdtContractField
    {
        public int requestID;                 //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号(Y)
        public int openBeginDate;             //开仓起始日期(N)
        public int openEndDate;               //开仓结束日期(N)
        DFITCSECCrdtContractQryFlagType crdtConQryFlag;            //查询标志(N)
        public int spdOrderID;                //柜台委托号(N)
        DFITCSECEntrustDirectionType entrustDirection;          //委托类别(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string contractNO;                //指定合约编号(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;                //证劵代码(N)
        public int conSerialID;               //合约流水号(N)
    };

    //FASL-信用合约信息响应
    public struct DFITCFASLRspQryCrdtContractField
    {
        public int requestID;                 //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号
        public int conSerialNO;               //合约流水号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string contractNO;                //指定合约编号
        public int operatorDate;              //发生日期
        public int endDate;                   //到期日期
        public int spdOrderID;                //柜台委托号
        DFITCSECEntrustDirectionType entrustDirection;          //委托类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;                //证劵代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;              //证券名称
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                  //币种
        public int finQty;                    //融资数量
        public double finFunds;                  //融资金额
        public int sloQty;                    //融券数量
        public double sloFunds;                  //融券金额
        public int finEntrustQty;             //当日融资委托数量
        public double finEntrustFunds;           //当日融资委托金额
        public int sloEntrustQty;             //当日融券委托数量
        public double sloEntrustFunds;           //当日融券委托金额
        public int finTradeQty;               //当日融资成交数量
        public double finTradeFunds;             //当日融资成交金额
        public int sloTradeQty;               //当日融券成交数量
        public double sloTradeFunds;             //当日融券成交金额
        public double debtPrincipal;             //负债本金
        public double repayFunds;                //还款金额
        public int debtQty;                   //负债数量
        public int repayQty;                  //还劵数量
        public double sellStockRepayFunds;       //当日卖券还款额
        public int buyStockForRepayEntrustQty;//当日买券还券委托数量
        public int buyStockForRepayTradeQty;  //当日买券还券成交数量
        public double finCost;                   //融资费用
        public double sloCost;                   //融券费用
        public double totalInterest;             //总利息
        public double repaidInterest;            //已归还利息
        DFITCSECCrdtContractStatusType crdtConStatus;             //合约状态(预留字段)
        public double leftInterest;              //剩余利息
        public double sloLeftFunds;              //融券剩余资金
        public double buyStockFreezeFunds;       //买券冻结金额
        public double buyStockClearFunds;        //买券清算金额
        public double sloLeftAvaiFunds;          //融券剩余可用(买券还券可用资金)
        public double debtQtyEntrustMarket;      //负债数量(委托后)市值
        public double debtQtyTradeMarket;        //负债数量(成交后)市值
        public double debtFundsMarket;           //负债金额市值
        public double finProfitLoss;             //融资盈亏
        public double sloProfitLoss;             //融券盈亏
        public int entrustQty;                //委托数量
        public int conOpenQty;                //合约开仓数量
        public double conOpenFunds;              //合约开仓金额
        public double conOpenCost;               //合约开仓费用
        public int conInitQty;                //期初合约数量
        public double conInitFunds;              //期初合约金额
        public double conInitCost;               //期初合约费用
        public double unRepayConFunds;           //未还合约金额
        public int unRepayConQty;             //未还合约数量
        public double unRepayConCost;            //未还合约费用
        public int positionNO;                //头寸编号
    };

    //FASL-信用合约变动信息查询请求
    public struct DFITCFASLReqQryCrdtConChangeInfoField
    {
        public int requestID;                 //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;              //撤销标志(N)
        DFITCSECEntrustDirectionType entrustDirection;          //委托类别(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;                //证劵代码(N)
        public int conSerialNO;               //合约流水号(N)
    };

    //FASL-信用合约变动信息查询响应
    public struct DFITCFASLRspQryCrdtConChangeInfoField
    {
        public int requestID;                 //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                 //客户号
        public int serialNO;                  //合约流水号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string conChangeNO;               //合约变动序号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string withdrawFlag;              //撤销标志(预留字段)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;                //证劵代码
        DFITCSECEntrustDirectionType entrustDirection;          //委托类别
        public double operatorFunds;             //发生金额
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string operatorTime;              //发生时间
        public int operatorQty;               //发生数量
        public int operatorDate;              //发生日期
        DFITCSECClearFlagType clearFlag;                 //清算标志
        public double commission;                //手续费
        public double operatorFunds2;            //发生金额(预留字段)
        public double postFunds;                 //后资金额
        public int postQty;                   //后证券额
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;                //交易所代码
        public double operatorCost;              //发生费用
        public double postCost;                  //后余费用
        public double operatorInterest;          //发生利息
        public double postInterest;              //后余利息
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string changeNote;                //变动说明
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;             //股东号
    };

    //FASL-查询系统时间请求
    public struct DFITCFASLReqQryTradeTimeField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        DFITCSECSystemQryFlagType flag;                     //高精度返回标志(N)
    };

    //FASL-查询系统时间响应
    public struct DFITCFASLRspQryTradeTimeField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int sysTradingDay;            //系统当前日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string sysTime;                  //系统当前时间
        public int sysWeek;                  //系统当前星期(flag为1时才返回)
        public int sysMillisecond;           //系统当前毫秒(flag为1时才返回)
    };

    //FASL-可转入担保证券查询
    public struct DFITCFASLReqQryTransferredContractField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码(N)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(N)
    };

    //FASL-可转入担保证券查询响应
    public struct DFITCFASLRspQryTransferredContractField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string capitalID;                //资金账号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        public int ableSellQty;              //可卖出(转出)数量
    };

    //FASL-客户可取资金调出
    public struct DFITCFASLReqDesirableFundsOutField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种(Y)
        public double operateFunds;             //发生金额(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string summaryMsg;               //摘要(N)
    };

    //FASL-客户可取资金调出响应
    public struct DFITCFASLRspDesirableFundsOutField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        public int serialID;                 //流水号
        public double accountBanlance;          //账户余额
    };

    //FASL-担保证券查询
    public struct DFITCFASLReqQryGuaranteedContractField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
    };

    //FASL-担保证券查询响应
    public struct DFITCFASLRspQryGuaranteedContractField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        public double exchangRate;              //折算率
        DFITCSECTradeStatusType status;                   //状态
        DFITCSECAccountType accountType;              //类型
    };

    //FASL-标的证券查询
    public struct DFITCFASLReqQryUnderlyingContractField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
    };

    //FASL-标的证券查询响应
    public struct DFITCFASLRspQryUnderlyingContractField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        public double financeDepositRatio;      //融资保证金比例
        public double securityDepositRatio;     //融券保证金比例
        DFITCSECTradeStatusType status;                   //状态
        DFITCSECAccountType accountType;              //类型
    };


    //QUOTE-指定的合约
    public struct DFITCSECSpecificInstrumentField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //合约代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
    };

    //sop 特有的
    public struct DFITCSOPSpecificDataField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string contractID;               //期权标识代码(601318C1412M03500)
        public double execPrice;                //行权价格
        public double preSettlePrice;           //昨结算价
        public double settlePrice;              //结算价
        public int positionQty;              //持仓数量
        public double auctionPrice;             //动态参考价格
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string latestEnquiryTime;        //预留时间字段
    };

    //stock 特有的
    public struct DFITCStockSpecificDataField
    {
        public double peRadio1;                 //市盈率1
        public double peRadio2;                 //市盈率2
    };

    //共有静态的
    public struct DFITCStaticDataField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证券代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        public int tradingDay;               //交易日
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        public double preClosePrice;            //昨收盘
        public double openPrice;                //今开盘
        public double upperLimitPrice;          //涨停板价
        public double lowerLimitPrice;          //跌停板价

    };

    //共有动态的
    public struct DFITCSharedDataField
    {
        public double latestPrice;              //最新价
        public double turnover;                 //成交金额
        public double highestPrice;             //最高价
        public double lowestPrice;              //最低价
        public int tradeQty;                 //成交数量
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string updateTime;               //时间戳
        public double bidPrice1;                //申买价一
        public int bidQty1;                  //申买量一
        public double askPrice1;                //申卖价一
        public int askQty1;                  //申卖量一
        public double bidPrice2;                //申买价二
        public int bidQty2;                  //申买量二
        public double askPrice2;                //申卖价二
        public int askQty2;                  //申卖量二
        public double bidPrice3;                //申买价三
        public int bidQty3;                  //申买量三
        public double askPrice3;                //申卖价三
        public int askQty3;                  //申卖量三
        public double bidPrice4;                //申买价四
        public int bidQty4;                  //申买量四
        public double askPrice4;                //申卖价四
        public int askQty4;                  //申卖量四
        public double bidPrice5;                //申买价五
        public int bidQty5;                  //申买量五
        public double askPrice5;                //申卖价五
        public int askQty5;                  //申卖量五
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string tradingPhaseCode;         //产品实时阶段及标志
    };

    public struct DFITCSOPDepthMarketDataField
    {
        public DFITCSOPSpecificDataField specificDataField;        //特有的
        public DFITCStaticDataField staticDataField;          //共有的静态
        public DFITCSharedDataField sharedDataField;          //公有的动态 
    };

    public struct DFITCStockDepthMarketDataField
    {
        public DFITCStockSpecificDataField specificDataField;
        public DFITCStaticDataField staticDataField;          //共有的静态
        public DFITCSharedDataField sharedDataField;         //公有的动态 
    };

    //STOCK-证券静态信息查询请求
    public struct DFITCStockReqQryStockStaticField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
    };

    //STOCK-证券静态信息查询响应
    public struct DFITCStockRspQryStockStaticField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        DFITCSECStockTradeFlagType stopFlag;                 //停牌标志
        public double preClosePrice;            //昨收盘价
        public double openPrice;                //今开盘价
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityID;               //证劵代码
        public double interestQuote;            //利息报价
        public double securityFaceValue;        //证券面值
        public DFITCSECBidTradeFlagType bidTradeFlag;             //竞价交易标志
        public int tradeUnit;                //交易单位
        public DFITCSECBusinessLimitType businessLimit;            //买卖限制
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string securityType;             //证券类别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string securityName;             //证券名称
        public double upperLimitPrice;          //涨停板价
        public double lowerLimitPrice;          //跌停板价
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string orderLimits;              //订单类型限制
    };

    //SOP-交易所持仓组合拆分委托请求
    public struct DFITCSOPReqGroupSplitField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
        public int localOrderID;             //本地委托号(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID;         //期权代码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string subAccountID;             //子账户编码(N)(预留字段)
        DFITCSECOpenCloseFlagType openCloseFlag;            //开平标志(Y)
        DFITCSECExchangeGroupTypeType groupType;                //组合类型(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string groupCode;                //组合编码(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID1;        //期权代码1腿(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID2;        //期权代码2腿(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID3;        //期权代码3腿(N)(预留字段)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID4;        //期权代码4腿(N)(预留字段)
        public int entrustQty;               //委托数量(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string devID;                    //厂商ID(N)(预留字段)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string devDecInfo;               //用户自定义字段(N)(预留字段)
    };

    //SOP-查询客户组合持仓明细请求
    public struct DFITCSOPReqQryGroupPositionField
    {
        public int requestID;                //请求ID(Y)
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号(Y)
    };

    //SOP-查询客户组合持仓明细响应
    public struct DFITCSOPRspQryGroupPositionField
    {
        public int requestID;                //请求ID
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string accountID;                //客户号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string exchangeID;               //交易所代码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string shareholderID;            //股东号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string subAccountID;             //子账户编码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string currency;                 //币种
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string capitalID;                //资金账号
        DFITCSECExchangeGroupTypeType groupType;                //组合类型
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string groupCode;                //组合编码
        public int groupQty;                 //组合数量
        public int enableSplitQty;           //可拆分数量
        public int splitEntrustQty;          //拆分委托数量
        public int splitTradeQty;            //拆分成交数量
        public double groupDeposit;             //组合保证金
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID1;        //期权代码1腿
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID2;        //期权代码2腿
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID3;        //期权代码3腿
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string securityOptionID4;        //期权代码4腿
    };

    //重传方式
    public enum RESUME_TYPE
    {
        TERT_QUICK,
        TERT_RESUME,
        TERT_RESTART
    };

}
