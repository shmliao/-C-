﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetSEC
{
    /// <summary>
    /// 银行帐号类型类型
    ///</summary>
    public enum DFITCSECMDCompressFalgType : int
    {
        /// <summary>
        /// 不要求行情前置压缩行情
        ///</summary>
        DFITCSEC_COMPRESS_FALSE = 0,
        /// <summary>
        /// 要求行情前置压缩行情
        ///</summary>
        DFITCSEC_COMPRESS_TRUE = 1,
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECPasswordTypeType 是一个密码类别类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECPasswordTypeType : int
    {
        /// <summary>
        /// 不要求行情前置压缩行情
        ///</summary>
        DFITCSEC_PWT_Trade = 1,
        /// <summary>
        /// 要求行情前置压缩行情
        ///</summary>
        DFITCSEC_PWT_Funds = 2,
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECEntrustDirectionType 是一个委托类别类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECEntrustDirectionType : int
    {
        ///买
        DFITCSEC_ED_Buy =1,
        ///卖
        DFITCSEC_ED_Sell = 2,
        ///配股缴款
        DFITCSEC_ED_RightsIssueContribution = 3,
        ///回购融资
        DFITCSEC_ED_RepurchaseFinancing = 4,
        ///回购融券
        DFITCSEC_ED_RepurchaseSecurities =5,
       /// <summary>
       /// 深圳转托管
       /// </summary>
         DFITCSEC_ED_CustodyTransfer                               = 7,
        ///上海指定交易
         DFITCSEC_ED_DesignateTrading                              = 9,
        ///上海撤指交易
         DFITCSEC_ED_RevocationDesignateTrading                    = 10,
        ///债转股
         DFITCSEC_ED_DebtToEquity                                  =11,
        ///转债回售
         DFITCSEC_ED_BondsSoldBack                                 = 12,
        ///配售申购
         DFITCSEC_ED_PlacingPurchase                               = 14,
        ///投票
         DFITCSEC_ED_Vote                                          =23,
        ///ETF申购
         DFITCSEC_ED_Purchase                                      =29,
        ///ETF赎回
         DFITCSEC_ED_Redemp                                       = 30,
        ///质押券入库
         DFITCSEC_ED_PledgeVoucherIn                               =37,
        ///质押券出库
         DFITCSEC_ED_PledgeVoucherOut                             = 38,
        ///基金认购
         DFITCSEC_ED_FundSubscribe                                = 41,
        ///基金申购
         DFITCSEC_ED_FundPurchase                                 = 42,
        ///基金赎回
         DFITCSEC_ED_FundRedemption                               = 43,
        ///基金分红设置
         DFITCSEC_ED_FundBonusSetting                            =  44,
        ///基金转换
         DFITCSEC_ED_FundConversion                              =  46,
        ///基金分拆
         DFITCSEC_ED_FundSplit                                   =  47,
        ///基金合并
         DFITCSEC_ED_FundMerge                                   =  48,
        ///权证行权
         DFITCSEC_ED_WarrantExercise                             =  50,
        ///融资买入
         DFITCSEC_ED_FinancingToBuy                              =  61,
        ///卖券还款
         DFITCSEC_ED_SellSecPayment                              =  62,
        ///买券还券
         DFITCSEC_ED_BuySecRepaySec                              =  63,
        ///融券卖出
         DFITCSEC_ED_SecuritiesToSell                           =   64,
        ///担保划入
         DFITCSEC_ED_GuaranteeInto                               =  65,
        ///担保划出
         DFITCSEC_ED_GuaranteeLayOff                            =   66,
        ///融资强平
         DFITCSEC_ED_FinancingForceSelling                      =   71,
        ///融券强平
         DFITCSEC_ED_SecuritiesForceSelling                    =    72,
        ///预受要约
         DFITCSEC_ED_AcceptOffer                               =    76,
        ///解除预受要约
         DFITCSEC_ED_GiveUpAcceptOffer                         =    77
    }

    public enum DFITCSECOrderTypeType : int
    {
        ////STOCK部分的订单类型
        ///限价,
        DFITCSEC_OT_LimitPrice = 0,
        ///最优五档立即成交剩余撤单（上海）,
        DFITCSEC_OT_SHBESTFRTradeLeftWithdraw = 1,
        ///最优五档立即成交剩余转限价（上海）
        DFITCSEC_OT_SHBESTFRTradeLeftTLimit = 2,
        ///对方最优价格（深圳）
        DFITCSEC_OT_SZOtherBestPrice = 101,
        ///本方最优价格（深圳）
        DFITCSEC_OT_SZBestPrice = 102,
        ///即时成交剩余撤销（深圳）
        DFITCSEC_OT_SZImdeTradeLeftWithdraw = 103,
        ///最优五档即时成交剩余撤销（深圳）
        DFITCSEC_OT_SZBESTFRTradeLeftWithdraw = 104,
        ///全额成交或撤销
        DFITCSEC_OT_SZBESTTotalTradeOWithdraw = 105,
        ////SOP部分的订单类型
        ///限价
        DFITCSEC_SOP_LimitPrice = 1,
        ///市价
        DFITCSEC_SOP_LastPrice = 2,
        ///市价剩余转限价（上海）
        DFITCSEC_SOP_LastTLimit = 3,
        ///市价本方最优（深圳）
        DFITCSEC_SOP_MineBestPrice = 4,
        ///市价最优五档成交剩余撤销（深圳）
        DFITCSEC_SOP_OptimalFive = 5
    }

    public enum DFITCSECHKEntrustLimitType : int
    {
        ///普通股票
        DFITCSEC_HKEL_NormalStolk = 0,
        ///竞价
        DFITCSEC_HKEL_Bid = 1,
        ///开市竞价
        DFITCSEC_HKEL_OpeningBid = 2,
        ///零股               
        DFITCSEC_HKEL_OddStock = 3,
    }

    public enum DFITCSECHKOrderTypeType : int
    {
        //当日有
        DFITCSEC_HKOT_GFT = 0,
        //全额即时
        DFITCSEC_HKOT_FOK = 4,
    }
    public enum DFITCSECEntrustQryFlagType : int
    {
        /// <summary>
        /// 所有委托
        /// </summary>
        DFITCSTOCK_EQF_Total = 0,
        ///可撤单委托
        DFITCSTOCK_EQF_AbleWithdraw = 1
    }

    public enum DFITCSECEntrustTypeType : int
    {
        ///电话
        DFITCSEC_ET_Phone = 1,
        ///磁卡
        DFITCSEC_ET_MagicCard = 2,
        ///热键
        DFITCSEC_ET_Hotkey = 4,
        ///柜台
        DFITCSEC_ET_Spd = 8,
        ///远程
        DFITCSEC_ET_Remote = 16,
        ///互联网=
        DFITCSEC_ET_Internet = 32,
        ///手机
        DFITCSEC_ET_Mobile = 64
    }

    public enum DFITCSECDeclareResultType : int
    {
        ///未申报
        DFITCSEC_DR_UnDeclare = 0,
        ///正在申报
        DFITCSEC_DR_Declaring = 1,
        ///已申报未成交,
        DFITCSEC_DR_UnTrade = 2,
        ///非法委托/废单
        DFITCSEC_DR_EntrustFail = 3,
        ///交易所已确认
        DFITCSEC_DR_Confirm = 4,
        ///部分成交
        DFITCSEC_DR_PartTrade = 5,
        ///全部成交
        DFITCSEC_DR_TotalTrade = 6,
        ///部成部撤
        DFITCSEC_DR_TradeAWithdraw = 7,
        ///全部撤单
        DFITCSEC_DR_TotalWithdraw = 8,
        ///撤单未成
        DFITCSEC_DR_WithdrawFail = 9,
        ///等待人工申报
        DFITCSEC_DR_ManualDeclare = 10,
    }
    public enum DFITCSECTradeQryFlagType : int
    {
        ///所有回转记录含撤单回转
        DFITCSEC_TQF_Total = 0,
        ///返回成交记录
        DFITCSEC_TQF_Trade = 1
    }


    ////////////////////////////////////////////////////////////
    ///DFITCSECPositionQryFlagType 是一个成交查询标志类型
    ////////////////////////////////////////////////////////////
    public enum DFITCSECPositionQryFlagType : int
    {
        ///无扩展信息
        DFITCSEC_PQF_Normal = 0,
        ///返回扩展信息
        DFITCSEC_PQF_Extend = 1
    }

    ////////////////////////////////////////////////////////////
    ///DFITCSECFundsQryFlagType 是一个资金查询标志类型
    ////////////////////////////////////////////////////////////
    public enum DFITCSECFundsQryFlagType : int
    {
        ///无扩展信息
        DFITCSEC_FQF_Normal = 0,
        ///返回扩展信息
        DFITCSEC_FQF_Extend = 1
    }

    ////////////////////////////////////////////////////////////
    ///DFITCSECAccountStatusType 是一个状态标志类型
    ////////////////////////////////////////////////////////////
    public enum DFITCSECAccountStatusType : int
    {
        ///正常
        DFITCSEC_AS_Normal = 0,
        ///冻结
        DFITCSEC_AS_Freeze = 1,
        ///客户卡挂失
        DFITCSEC_AS_LossReporting = 2,
        ///销户
        DFITCSEC_AS_CloseAccount = 3,
        ///小额休眠
        DFITCSEC_AS_MicroDormancy = 6,
        ///不合格
        DFITCSEC_AS_UnQualified = 7,
        ///公司不合格
        DFITCSEC_AS_CompUnQualified = 9
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECAccountIdentityTypeType 是一个证件标示类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECAccountIdentityTypeType : int
    {
        ///身份证
        DFITCSEC_AI_IDcard = 0,
        ///护照
        DFITCSEC_AI_PasPrt = 1,
        ///军官证
        DFITCSEC_AI_OffCard = 2,
        ///士兵证=
        DFITCSEC_AI_SolderCard = 3,
        ///回乡证=
        DFITCSEC_AI_RntryPrmt = 4,
        ///户口本
        DFITCSEC_AI_HusHldRgstr = 5,
        ///外国护照
        DFITCSEC_AI_FrignPasPrt = 6,
        ///技术监督局代码
        DFITCSEC_AI_TechSupBruCode = 7,
        ///营业执照
        DFITCSEC_AI_BsnsLicence = 8,
        ///行政机关
        DFITCSEC_AI_AdminOrgan = 9,
        ///社会团体
        DFITCSEC_AI_SocialGrup = 10,
        ///军队
        DFITCSEC_AI_Army = 11,
        ///武警
        DFITCSEC_AI_ArmdPolice = 12,
        ///下属机构
        DFITCSEC_AI_SubBody = 13,
        ///基金会
        DFITCSEC_AI_Foundation = 14,
        ///台胞证
        DFITCSEC_AI_TaiWanCard = 15,
        ///港澳台居民身份证
        DFITCSEC_AI_HMTIDcard = 16,
        ///其他=
        DFITCSEC_AI_OtherCard = 99
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECPasswdSyncFlagType 是一个密码同步标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECPasswdSyncFlagType : int
    {
        ///不同步
        DFITCSEC_PSF_Sync = 0,
        ///同步
        DFITCSEC_PSF_UnSync = 1
    }



    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECShareholderSpecPropType 是一个股东限制属性类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECShareholderSpecPropType : int
    {
        ///当日指定
        DFITCSEC_SSP_SpecTheDay = 2,
        ///回购指定
        DFITCSEC_SSP_SpecRePurchase = 16,
        ///隔日指定
        DFITCSEC_SSP_SpecOtherDay = 32
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECTradePermissionsType 是一个交易权限类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECTradePermissionsType : int
    {
        ///基本交易权限
        DFITCSEC_TP_BasicTrade = 1,
        ///回购融资
        DFITCSEC_TP_ReprchFnc = 2,
        ///回购融券
        DFITCSEC_TP_ReprchSecLoan = 4,
        ///ETF申赎
        DFITCSEC_TP_ETF_SubRedemp = 8,
        ///权证交易
        DFITCSEC_TP_WarrantTrade = 16,
        ///三板报价转让
        DFITCSEC_TP_ThreeBrdTran = 32,
        ///创业板
        DFITCSEC_TP_GEM = 64,
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECShareholderStatusType 是一个股东状态类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECShareholderStatusType : int
    {
        ///正常
        DFITCSEC_SHS_Normal = 0,
        ///股东冻结
        DFITCSEC_SHS_Freeze = 1,
        ///股东卡挂失=
        DFITCSEC_SHS_LOSS = 2,
        ///小额休眠
        DFITCSEC_SHS_Dormancy = 6,
        ///不合格
        DFITCSEC_SHS_Unqualified = 7,
        ///激活,
        DFITCSEC_SHS_Activation = 8,
        ///公司不合格
        DFITCSEC_SHS_CompanyUnqualified = 9,
        ///使用申请中
        DFITCSEC_SHS_Applying = 10,
        ///使用申请失败
        DFITCSEC_SHS_ApplyFailed = 11,
        ///VIP状态
        DFITCSEC_SHS_VIP = 12
    }



    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECMainAccountFlagType 是一个主账户标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECMainAccountFlagType : int
    {
        ///辅助帐号
        DFITCSEC_MA_Auxiliary = 0,
        ///主帐号
        DFITCSEC_MA_Master = 1
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECShareholderCtlPropType 是一个股东控制属性类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECShareholderCtlPropType : int
    {
        ///正常
        DFITCSEC_SHC_Normal = 0,
        ///禁止买入
        DFITCSEC_SHC_ForbidBuy = 4,
        ///禁止卖出
        DFITCSEC_SHC_ForbidSell = 8,
        ///禁止撤指,
        DFITCSEC_SHC_ForbidWithdraw = 64,
        ///禁止转托管
        DFITCSEC_SHC_ForbidCustodyTransfer = 128
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECFundsTransferFlagType 是一个资金调转标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECFundsTransferFlagType : int
    {
        ///转入
        DFITCSEC_FTF_In = 1,
        ///转出
        DFITCSEC_FTF_Out = 2,
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECFundsFreezeTypeType 是一个资金冻结类别类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECFundsFreezeTypeType : int
    {
        ///委托冻结
        DFITCSEC_FFT_EntrustFreeze = 1,
        ///实时成交解冻
        DFITCSEC_FFT_RealtimeTradeUnFreeze = 2,
        ///手工冻结
        DFITCSEC_FFT_ManualFreeze = 3,
        ///手工解冻
        DFITCSEC_FFT_ManualUnFreeze = 4
    }



    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECStockFreezeTypeType 是一个证券冻结类别类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECStockFreezeTypeType : int
    {
        ///委托冻结
        DFITCSEC_SFT_EntrustFreeze = 1,
        ///增加可卖数量
        DFITCSEC_SFT_IncSellQty = 2,
        ///减少可卖数量
        DFITCSEC_SFT_DecSellQty = 3,
        ///手工长期冻结
        DFITCSEC_SFT_ManualFreeze = 4,
        ///清算冻结
        DFITCSEC_SFT_ClearFreeze = 5,
        ///ETF申购赎回冻结=
        DFITCSEC_SFT_PurchaseETFFreeze = 6,
        ///要约收购冻结
        DFITCSEC_SFT_OfferFreeze = 7,
        ///权证行权冻结
        DFITCSEC_SFT_ExeFreeze = 8,
        ///债券抵押转标准券冻结
        DFITCSEC_SFT_CollTranStandFreeze = 9,
        ///质押券入库冻结
        DFITCSEC_SFT_PledgeStoringFreeze = 10,
        ///初始化股份
        DFITCSEC_SFT_INITStock = 50,
        ///盘中证券调入
        DFITCSEC_SFT_StockIn = 53,
        ///盘中证券调出
        DFITCSEC_SFT_StockOut = 54,
    }



    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECTransFundsFreezeTypeType 是一个调拨资金冻结类别类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECTransFundsFreezeTypeType : int
    {
        ///初始化资金
        DFITCSEC_FFT_InitFunds = 50,
        ///盘中资金调入
        DFITCSEC_FFT_FundsIn = 51,
        ///盘中资金调出
        DFITCSEC_FFT_FundsOut = 52
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECStockTradeFlagType 是一个股票交易标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECStockTradeFlagType : int
    {
        ///为"停牌标志"时, 取值如下
        ///正常
        DFITCSEC_STF_Normal = 0,
        ///停牌
        DFITCSEC_STF_Stop = 1,
        ///为"交易状态"时, 取值
        ///发行
        DFITCSEC_STF_Issue = 2,
        ///首日上市
        DFITCSEC_STF_FirstList = 3,
        ///退市
        DFITCSEC_STF_UnList = 4
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECBidTradeFlagType 是一个竞价交易标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECBidTradeFlagType : int
    {
        ///不允许集合竞价期间交易 
        DFITCSEC_BTF_UnBidTrade = 0,
        ///允许集合竞价期间交易
        DFITCSEC_BTF_BidTrade = 1
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECBusinessLimitType 是一个买卖限制类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECBusinessLimitType : int
    {
        ///T+0交易
        DFITCSEC_T0_Transaction = 1,
        ///席位托管
        DFITCSEC_Seat_Hosting = 2,
        ///计算市值
        DFITCSEC_Computing_Market_Value = 8
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECOrderConfirmFlagType 是一个委托确认类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECOrderConfirmFlagType : int
    {
        ///委托成功
        DFITCSEC_ORDER_SUCCESS = 0,
        ///委托失败
        DFITCSEC_ORDER_FAIL = 1
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECOpenCloseFlagType 是一个开平标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECOpenCloseFlagType : int
    {
        ///开仓
        DFITCSEC_OCF_Open = 1,
        ///平仓
        DFITCSEC_OCF_Close = 2,
        ///执行
        DFITCSEC_OCF_Execute = 6,
        ///履约
        DFITCSEC_OCF_Perform = 7,
        ///实物意向交割
        DFITCSEC_OCF_RealIntenDevi = 8,
        ///合约持仓调整                     
        DFITCSEC_OCF_ConPosiAdj = 9,
        ///证券冻结
        DFITCSEC_OCF_SecFreeze = 10,
        ///证券解冻
        DFITCSEC_OCF_SecThaw = 11,
        ///强平
        DFITCSEC_OCF_ForceClose = 12,
        ///组合
        DFITCSEC_OCF_Group = 19,
        ///拆分
        DFITCSEC_OCF_Split = 20,
        ///转备对
        DFITCSEC_OCF_ToPrePare = 21
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECCoveredFlagType 是一个备兑标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECCoveredFlagType : int
    {
        ///非备兑
        DFITCSEC_CF_UnCovered = 0,
        ///备兑
        DFITCSEC_CF_Covered = 1,
        ///备兑优先(预留，目前不支持)
        DFITCSEC_CF_CoveredPrior = 2
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECOrderExpiryDateType 是一个订单时效限制类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECOrderExpiryDateType : int
    {
        ///当日有效
        DFITCSEC_OE_NONE = 0,
        ///立即成交剩余指令自动撤销指令 FAK(IOC)
        DFITCSEC_OE_FAK = 1,
        ///立即全部成交否则自动撤销指令 FOK,
        DFITCSEC_OE_FOK = 2
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECOrderCategoryType 是一个委托单类别类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECOrderCategoryType : int
    {
        ///普通委托
        DFITCSEC_OC_GeneralOrder = 0,
        ///手动强平单
        DFITCSEC_OC_ManualCloseOrder = 1,
        ///行情触发单(预留，目前系统不支持)
        DFITCSEC_OC_QuoteTriggOrder = 2,
        ///自动强平单 
        DFITCSEC_OC_AutoCloseOrder = 8
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECOptionTypeType 是一个期权类别类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECOptionTypeType : int
    {
        ///认购期权
        DFITCSEC_OT_CALL = 1,
        ///认沽期权
        DFITCSEC_OT_PUT = 2
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECContractObjectTypeType 是一个标的类型类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECContractObjectTypeType : int
    {
        ///A股
        DFITCSEC_COT_STOCK = 1,
        ///ETF
        DFITCSEC_COT_ETF = 2
    }


    //////////////////////////////////////////////////////////////////////////
    ///DFITCSECContractAdjustRemindType 是一个合约调整提醒类型
    //////////////////////////////////////////////////////////////////////////
    public enum DFITCSECContractAdjustRemindType : int
    {
        ///未调整
        DFITCSEC_CAR_NotAdj = 0,
        ///已调整
        DFITCSEC_CAR_Adj = 1
    }


    //////////////////////////////////////////////////////////////////////////
    ///DFITCSECContraceExpireRemindType 是一个合约即将到期提醒类型
    //////////////////////////////////////////////////////////////////////////
    public enum DFITCSECContraceExpireRemindType : int
    {
        ///未到期
        DFITCSEC_CER_NotExpire = 0,
        ///距离到期日不足10个交易日
        DFITCSEC_CER_WillExpire = 1
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECAccountTypeType 是一个投资者类别类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECAccountTypeType : int
    {
        ///个人
        DFITCSEC_AT_Personal = 1,
        ///机构
        DFITCSEC_AT_Organization = 2,
        ///自营
        DFITCSEC_AT_Selfoperation = 3,
        ///做市商
        DFITCSEC_AT_Marketmaker = 4,
        ///交易会员
        DFITCSEC_AT_member = 0
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECAccountPropType 是一个客户属性类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECAccountPropType : int
    {
        ///禁止存款
        DFITCSEC_AP_PrhbtDeposit = 1,
        ///禁止取款
        DFITCSEC_AP_PrhbtDrawMoney = 2,
        ///禁止银证转账
        DFITCSEC_AP_PrhbtBankTran = 4,
        ///禁止转托管
        DFITCSEC_AP_PrhbtTransfer = 8,
        ///禁止撤指
        DFITCSEC_AP_PrhbtCancelSpecTran = 16,
        ///禁止销户
        DFITCSEC_AP_PrhbtCancelAcc = 32,
        ///禁止开仓,
        DFITCSEC_AP_PrhbtTakePos = 64,
        ///禁止平仓
        DFITCSEC_AP_PrhbtClsPos = 128,
        ///禁止单户资金内转
        DFITCSEC_AP_PrhbtSngFamFunTran = 256
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECCheckUpLimitFlagType 是一个检查委托上限标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECCheckUpLimitFlagType : int
    {
        ///检查
        DFITCSEC_CULF_Check = 0,
        ///不检查
        DFITCSEC_CULF_UnChec = 1
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECExecuteTypeType 是一个行权方式类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECExecuteTypeType : int
    {
        ///美式
        DFITCSEC_ET_US = 0,
        ///欧式
        DFITCSEC_ET_Europe = 1
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECDeliveryTypeType 是一个交割方式类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECDeliveryTypeType : int
    {
        ///实物交割
        DFITCSEC_DT_Real = 1,
        ///现金交割
        DFITCSEC_DT_Cash = 2
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECOpenLimitsType 是一个开仓限制类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECOpenLimitsType : int
    {
        ///允许开仓
        DFITCSEC_OL_Permit = 0,
        ///限制开仓
        DFITCSEC_OL_UnPermit = 1
    }

    ////////////////////////////////////////////////////////////////////////
    ///DFITCSECContractObjectStatusType 是一个标的证券状态类型
    ////////////////////////////////////////////////////////////////////////
    public enum DFITCSECContractObjectStatusType : int
    {
        ///正常
        DFITCSEC_COS_Normal = 0,
        ///暂停
        DFITCSEC_COS_Suspend = 1,
        ///作废
        DFITCSEC_COS_Cancel = 2
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECReferenceTypeType 是一个费率参数类别类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECReferenceTypeType : int
    {
        ///按标的类型
        DFITCSEC_RT_ObjectType = 1,
        ///按标的代码
        DFITCSEC_RT_ObjectID = 2,
        ///按期权代码
        DFITCSEC_RT_OptionID = 3
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECLvelCategoryType 是一个级别类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECLvelType : int
    {
        ///交易所
        DFITCSEC_L_EXCHANGE = 1,
        ///公司
        DFITCSEC_L_COMPANY = 2,
        ///单户
        DFITCSEC_L_CUSTOMER = 3
    }


    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECTradeStatusType 是一个状态标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECTradeStatusType : int
    {
        ///正常
        DFITCSEC_TS_Normal = 0,
        ///暂停
        DFITCSEC_TS_Suspend = 2,
        ///调出
        DFITCSEC_TS_CallOut = 4
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECPositionSourceType 是一个头寸来源类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECPositionSourceType : int
    {
        ///普通头寸
        DFITCSEC_PS_General = 0,
        ///专项头寸
        DFITCSEC_PS_Special = 1
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECCrdtContractQryFlagType 是一个查询标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECCrdtContractQryFlagType : int
    {
        ///查询所有
        DFITCSEC_CCQF_Queryall = 0,
        ///当日了结
        DFITCSEC_CCQF_Endoftheday = 1,
        ///未了结
        DFITCSEC_CCQF_Unfinished = 2
    }
    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECCrdtContractStatusType 是一个合约状态类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECCrdtContractStatusType : int
    {
        ///未了结
        DFITCSEC_CCS_UnSettle = 0,
        ///已了结未清算=
        DFITCSEC_CCS_UnClear = 1,
        ///已了结
        DFITCSEC_CCS_Settle = 3
    }

    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECClearFlagType 是一个清算标志类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECClearFlagType : int
    {
        ///成交引起
        DFITCSEC_CF_TradeCause = 1,
        ///清算引起
        DFITCSEC_CF_ClearCause = 2,
        ///权益补偿引起=
        DFITCSEC_CF_ComCause = 3
    }

    ////////////////////////////////////////////////////////////
    ///DFITCSECSystemQryFlagType 是一个高精度返回标志类型
    ////////////////////////////////////////////////////////////
    public enum DFITCSECSystemQryFlagType : int
    {
        ///正常时间
        DFITCSEC_PQF_Normal = 0,
        ///高精度时间
        DFITCSEC_SQF_High = 1
    }



    /////////////////////////////////////////////////////////////////////////
    ///DFITCSECAccountType 是一个客户类型
    /////////////////////////////////////////////////////////////////////////
    public enum DFITCSECAccountType : int
    {
        ///公司
        DFITCSEC_AT_Company = 0,
        ///个人
        DFITCSEC_AT_Personal = 1
    }

    //////////////////////////////////////////////////////////////////////////
    ///DFITCSECExchangeGroupTypeType 是一个交易所组合类型
    //////////////////////////////////////////////////////////////////////////
    public enum DFITCSECExchangeGroupTypeType : int
    {
        ///转备兑
        DFITCSEC_EGT_ToPrepare = 1,
        ///认购牛市价差策略
        DFITCSEC_EGT_BullBuy = 2,
        ///认沽熊市价差策略
        DFITCSEC_EGT_BearSell = 3,
        ///认沽牛市价差策略=
        DFITCSEC_EGT_BullSell = 4,
        ///认购熊市价差策略
        DFITCSEC_EGT_BearBuy = 5,
        ///跨式空头
        DFITCSEC_EGT_ShortStraddle = 6,
        ///宽跨式空头
        DFITCSEC_EGT_WideStraddle = 7,
        ///备兑转现金
        DFITCSEC_EGT_CoveredToCash = 8
    }
}
