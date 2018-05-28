// SecTdi.cpp : 定义 DLL 应用程序的导出函数。
//

#include "SecTdi.h"
#include <string.h>
int nReq;

SecTdi::SecTdi(void)
{
	_FrontConnected = NULL;


	_FrontDisconnected = NULL;

	_RtnNotice = NULL;

	_RspError = NULL;

	_RspStockUserLogin = NULL;

	_RspStockUserLogout = NULL;

	_RspStockUserPasswordUpdate = NULL;

	_RspStockEntrustOrder = NULL;

	_RspStockWithdrawOrder = NULL;

	_RspStockQryEntrustOrder = NULL;

	_RspStockQryRealTimeTrade = NULL;

	_RspStockQrySerialTrade = NULL;

	_RspStockQryPosition = NULL;

	_RspStockQryCapitalAccountInfo = NULL;

	_RspStockQryAccountInfo = NULL;

	_RspStockQryShareholderInfo = NULL;

	_RspStockTransferFunds = NULL;

	_RspStockEntrustBatchOrder = NULL;

	_RspStockWithdrawBatchOrder = NULL;

	_RspStockCalcAbleEntrustQty = NULL;

	_RspStockCalcAblePurchaseETFQty = NULL;

	_RspStockQryFreezeFundsDetail = NULL;

	_RspStockQryFreezeStockDetail = NULL;

	_RspStockQryTransferStockDetail = NULL;

	_RspStockQryTransferFundsDetail = NULL;

	_RspStockQryStockInfo = NULL;

	_RspStockQryStockStaticInfo = NULL;

	_RspStockQryTradeTime = NULL;

	_StockEntrustOrderRtn = NULL;

	_StockTradeRtn = NULL;

	_StockWithdrawOrderRtn = NULL;


	_RspSOPUserLogin = NULL;

	_RspSOPUserLogout = NULL;

	_RspSOPUserPasswordUpdate = NULL;

	_RspSOPEntrustOrder = NULL;
	_RspSOPGroupSplit = NULL;

	_RspSOPQryGroupPosition = NULL;

	_RspSOPLockOUnLockStock = NULL;

	_RspSOPWithdrawOrder = NULL;

	_RspSOPQryEntrustOrder = NULL;

	_RspSOPQrySerialTrade = NULL;

	_RspSOPQryPosition = NULL;

	_RspSOPQryCollateralPosition = NULL;

	_RspSOPQryCapitalAccountInfo = NULL;

	_RspSOPQryAccountInfo = NULL;

	_RspSOPQryShareholderInfo = NULL;

	_RspSOPCalcAbleEntrustQty = NULL;

	_RspSOPQryAbleLockStock = NULL;

	_RspSOPQryContactInfo = NULL;

	_RspSOPExectueOrder = NULL;

	_RspSOPQryExecAssiInfo = NULL;

	_RspSOPQryTradeTime = NULL;
	_RspSOPQryExchangeInfo = NULL;

	_RspSOPQryCommission = NULL;

	_RspSOPQryDeposit = NULL;

	_RspSOPQryContractObjectInfo = NULL;

	_SOPEntrustOrderRtn = NULL;

	_SOPTradeRtn = NULL;

	_SOPWithdrawOrderRtn = NULL;

	_RspFASLUserLogin = NULL;

	_RspFASLUserLogout = NULL;

	_RspFASLQryAbleFinInfo = NULL;

	_RspFASLQryAbleSloInfo = NULL;

	_RspFASLTransferCollateral = NULL;

	_RspFASLDirectRepayment = NULL;

	_RspFASLRepayStockTransfer = NULL;

	_RspFASLEntrustCrdtOrder = NULL;

	_RspFASLEntrustOrder = NULL;

	_RspFASLCalcAbleEntrustCrdtQty = NULL;

	_RspFASLQryCrdtFunds = NULL;

	_RspFASLQryCrdtContract = NULL;

	_RspFASLQryCrdtConChangeInfo = NULL;

	_RspFASLTransferFunds = NULL;

	_RspFASLQryAccountInfo = NULL;
	_RspFASLQryCapitalAccountInfo = NULL;
	_RspFASLQryShareholderInfo = NULL;

	_RspFASLQryPosition = NULL;

	_RspFASLQryEntrustOrder = NULL;

	_RspFASLQrySerialTrade = NULL;

	_RspFASLQryRealTimeTrade = NULL;

	_RspFASLQryFreezeFundsDetail = NULL;

	_RspFASLQryFreezeStockDetail = NULL;

	_RspFASLQryTransferFundsDetail = NULL;

	_RspFASLWithdrawOrder = NULL;

	_RspFASLQrySystemTime = NULL;

	_RspFASLQryTransferredContract = NULL;

	_RspFASLDesirableFundsOut = NULL;

	_RspFASLQryGuaranteedContract = NULL;

	_RspFASLQryUnderlyingContract = NULL;
	_FASLEntrustOrderRtn = NULL;

	_FASLTradeRtn = NULL;

	_FASLWithdrawOrderRtn = NULL;


}

DLL_EXPORT_C_DECL void WINAPI SetOnFrontConnected(SecTdi* spi, void* func){ spi->_FrontConnected = func; }


DLL_EXPORT_C_DECL void WINAPI SetOnFrontDisconnected(SecTdi* spi, void* func){ spi->_FrontDisconnected = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRtnNotice(SecTdi* spi, void* func){ spi->_RtnNotice = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspError(SecTdi* spi, void* func){ spi->_RspError = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockUserLogin(SecTdi* spi, void* func){ spi->_RspStockUserLogin = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockUserLogout(SecTdi* spi, void* func){ spi->_RspStockUserLogout = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockUserPasswordUpdate(SecTdi* spi, void* func){ spi->_RspStockUserPasswordUpdate = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockEntrustOrder(SecTdi* spi, void* func){ spi->_RspStockEntrustOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockWithdrawOrder(SecTdi* spi, void* func){ spi->_RspStockWithdrawOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryEntrustOrder(SecTdi* spi, void* func){ spi->_RspStockQryEntrustOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryRealTimeTrade(SecTdi* spi, void* func){ spi->_RspStockQryRealTimeTrade = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQrySerialTrade(SecTdi* spi, void* func){ spi->_RspStockQrySerialTrade = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryPosition(SecTdi* spi, void* func){ spi->_RspStockQryPosition = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryCapitalAccountInfo(SecTdi* spi, void* func){ spi->_RspStockQryCapitalAccountInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryAccountInfo(SecTdi* spi, void* func){ spi->_RspStockQryAccountInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryShareholderInfo(SecTdi* spi, void* func){ spi->_RspStockQryShareholderInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockTransferFunds(SecTdi* spi, void* func){ spi->_RspStockTransferFunds = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockEntrustBatchOrder(SecTdi* spi, void* func){ spi->_RspStockEntrustBatchOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockWithdrawBatchOrder(SecTdi* spi, void* func){ spi->_RspStockWithdrawBatchOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockCalcAbleEntrustQty(SecTdi* spi, void* func){ spi->_RspStockCalcAbleEntrustQty = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockCalcAblePurchaseETFQty(SecTdi* spi, void* func){ spi->_RspStockCalcAblePurchaseETFQty = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryFreezeFundsDetail(SecTdi* spi, void* func){ spi->_RspStockQryFreezeFundsDetail = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryFreezeStockDetail(SecTdi* spi, void* func){ spi->_RspStockQryFreezeStockDetail = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryTransferStockDetail(SecTdi* spi, void* func){ spi->_RspStockQryTransferStockDetail = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryTransferFundsDetail(SecTdi* spi, void* func){ spi->_RspStockQryTransferFundsDetail = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryStockInfo(SecTdi* spi, void* func){ spi->_RspStockQryStockInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryStockStaticInfo(SecTdi* spi, void* func){ spi->_RspStockQryStockStaticInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockQryTradeTime(SecTdi* spi, void* func){ spi->_RspStockQryTradeTime = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnStockEntrustOrderRtn(SecTdi* spi, void* func){ spi->_StockEntrustOrderRtn = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnStockTradeRtn(SecTdi* spi, void* func){ spi->_StockTradeRtn = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnStockWithdrawOrderRtn(SecTdi* spi, void* func){ spi->_StockWithdrawOrderRtn = func; }


DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPUserLogin(SecTdi* spi, void* func){ spi->_RspSOPUserLogin = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPUserLogout(SecTdi* spi, void* func){ spi->_RspSOPUserLogout = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPUserPasswordUpdate(SecTdi* spi, void* func){ spi->_RspSOPUserPasswordUpdate = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPEntrustOrder(SecTdi* spi, void* func){ spi->_RspSOPEntrustOrder = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPGroupSplit(SecTdi* spi, void* func){ spi->_RspSOPGroupSplit = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryGroupPosition(SecTdi* spi, void* func){ spi->_RspSOPQryGroupPosition = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPLockOUnLockStock(SecTdi* spi, void* func){ spi->_RspSOPLockOUnLockStock = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPWithdrawOrder(SecTdi* spi, void* func){ spi->_RspSOPWithdrawOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryEntrustOrder(SecTdi* spi, void* func){ spi->_RspSOPQryEntrustOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQrySerialTrade(SecTdi* spi, void* func){ spi->_RspSOPQrySerialTrade = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryPosition(SecTdi* spi, void* func){ spi->_RspSOPQryPosition = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryCollateralPosition(SecTdi* spi, void* func){ spi->_RspSOPQryCollateralPosition = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryCapitalAccountInfo(SecTdi* spi, void* func){ spi->_RspSOPQryCapitalAccountInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryAccountInfo(SecTdi* spi, void* func){ spi->_RspSOPQryAccountInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryShareholderInfo(SecTdi* spi, void* func){ spi->_RspSOPQryShareholderInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPCalcAbleEntrustQty(SecTdi* spi, void* func){ spi->_RspSOPCalcAbleEntrustQty = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryAbleLockStock(SecTdi* spi, void* func){ spi->_RspSOPQryAbleLockStock = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryContactInfo(SecTdi* spi, void* func){ spi->_RspSOPQryContactInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPExectueOrder(SecTdi* spi, void* func){ spi->_RspSOPExectueOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryExecAssiInfo(SecTdi* spi, void* func){ spi->_RspSOPQryExecAssiInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryTradeTime(SecTdi* spi, void* func){ spi->_RspSOPQryTradeTime = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryExchangeInfo(SecTdi* spi, void* func){ spi->_RspSOPQryExchangeInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryCommission(SecTdi* spi, void* func){ spi->_RspSOPQryCommission = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryDeposit(SecTdi* spi, void* func){ spi->_RspSOPQryDeposit = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPQryContractObjectInfo(SecTdi* spi, void* func){ spi->_RspSOPQryContractObjectInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnSOPEntrustOrderRtn(SecTdi* spi, void* func){ spi->_SOPEntrustOrderRtn = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnSOPTradeRtn(SecTdi* spi, void* func){ spi->_SOPTradeRtn = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnSOPWithdrawOrderRtn(SecTdi* spi, void* func){ spi->_SOPWithdrawOrderRtn = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLUserLogin(SecTdi* spi, void* func){ spi->_RspFASLUserLogin = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLUserLogout(SecTdi* spi, void* func){ spi->_RspFASLUserLogout = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryAbleFinInfo(SecTdi* spi, void* func){ spi->_RspFASLQryAbleFinInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryAbleSloInfo(SecTdi* spi, void* func){ spi->_RspFASLQryAbleSloInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLTransferCollateral(SecTdi* spi, void* func){ spi->_RspFASLTransferCollateral = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLDirectRepayment(SecTdi* spi, void* func){ spi->_RspFASLDirectRepayment = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLRepayStockTransfer(SecTdi* spi, void* func){ spi->_RspFASLRepayStockTransfer = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLEntrustCrdtOrder(SecTdi* spi, void* func){ spi->_RspFASLEntrustCrdtOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLEntrustOrder(SecTdi* spi, void* func){ spi->_RspFASLEntrustOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLCalcAbleEntrustCrdtQty(SecTdi* spi, void* func){ spi->_RspFASLCalcAbleEntrustCrdtQty = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryCrdtFunds(SecTdi* spi, void* func){ spi->_RspFASLQryCrdtFunds = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryCrdtContract(SecTdi* spi, void* func){ spi->_RspFASLQryCrdtContract = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryCrdtConChangeInfo(SecTdi* spi, void* func){ spi->_RspFASLQryCrdtConChangeInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLTransferFunds(SecTdi* spi, void* func){ spi->_RspFASLTransferFunds = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryAccountInfo(SecTdi* spi, void* func){ spi->_RspFASLQryAccountInfo = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryCapitalAccountInfo(SecTdi* spi, void* func){ spi->_RspFASLQryCapitalAccountInfo = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryShareholderInfo(SecTdi* spi, void* func){ spi->_RspFASLQryShareholderInfo = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryPosition(SecTdi* spi, void* func){ spi->_RspFASLQryPosition = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryEntrustOrder(SecTdi* spi, void* func){ spi->_RspFASLQryEntrustOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQrySerialTrade(SecTdi* spi, void* func){ spi->_RspFASLQrySerialTrade = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryRealTimeTrade(SecTdi* spi, void* func){ spi->_RspFASLQryRealTimeTrade = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryFreezeFundsDetail(SecTdi* spi, void* func){ spi->_RspFASLQryFreezeFundsDetail = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryFreezeStockDetail(SecTdi* spi, void* func){ spi->_RspFASLQryFreezeStockDetail = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryTransferFundsDetail(SecTdi* spi, void* func){ spi->_RspFASLQryTransferFundsDetail = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLWithdrawOrder(SecTdi* spi, void* func){ spi->_RspFASLWithdrawOrder = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQrySystemTime(SecTdi* spi, void* func){ spi->_RspFASLQrySystemTime = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryTransferredContract(SecTdi* spi, void* func){ spi->_RspFASLQryTransferredContract = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLDesirableFundsOut(SecTdi* spi, void* func){ spi->_RspFASLDesirableFundsOut = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryGuaranteedContract(SecTdi* spi, void* func){ spi->_RspFASLQryGuaranteedContract = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLQryUnderlyingContract(SecTdi* spi, void* func){ spi->_RspFASLQryUnderlyingContract = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnFASLEntrustOrderRtn(SecTdi* spi, void* func){ spi->_FASLEntrustOrderRtn = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnFASLTradeRtn(SecTdi* spi, void* func){ spi->_FASLTradeRtn = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnFASLWithdrawOrderRtn(SecTdi* spi, void* func){ spi->_FASLWithdrawOrderRtn = func; }











DLL_EXPORT_C_DECL void* WINAPI CreateApi(){ return DFITCSECTraderApi::CreateDFITCSECTraderApi("./log/"); }

DLL_EXPORT_C_DECL void* WINAPI CreateSpi(){ return new SecTdi(); }

DLL_EXPORT_C_DECL void* WINAPI Release(DFITCSECTraderApi *api){ api->Release(); return 0; }


DLL_EXPORT_C_DECL void* WINAPI  Init(DFITCSECTraderApi *api, const char *pszFrontAddress, DFITCSECTraderSpi *pSpi){ api->Init(pszFrontAddress, pSpi); return 0; }

DLL_EXPORT_C_DECL void* WINAPI  SubscribePrivateTopic(DFITCSECTraderApi *api, RESUME_TYPE nResumeType){ api->SubscribePrivateTopic(nResumeType); return 0; }

DLL_EXPORT_C_DECL void* WINAPI  ReqStockUserLogin(DFITCSECTraderApi *api, DFITCSECReqUserLoginField *p){ api->ReqStockUserLogin(p); return 0; }
/**
* STOCK-登出请求
* @param p:指向用户登出请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockUserLogout(DFITCSECTraderApi *api, DFITCSECReqUserLogoutField *p){ api->ReqStockUserLogout(p); return 0; }
/**
* STOCK-密码更新请求
* @param p:指向用户密码更新请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockUserPasswordUpdate(DFITCSECTraderApi *api, DFITCSECReqPasswordUpdateField *p){ api->ReqStockUserPasswordUpdate(p); return 0; }
/**
* STOCK-委托请求
* @param p:指向用户委托请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockEntrustOrder(DFITCSECTraderApi *api, DFITCStockReqEntrustOrderField *p){ api->ReqStockEntrustOrder(p); return 0; }
/**
* STOCK-撤单请求
* @param p:指向用户撤单请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockWithdrawOrder(DFITCSECTraderApi *api, DFITCSECReqWithdrawOrderField *p) { api->ReqStockWithdrawOrder(p); return 0; }
/**
* STOCK-委托查询请求
* @param p:指向用户委托查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryEntrustOrder(DFITCSECTraderApi *api, DFITCStockReqQryEntrustOrderField *p)  { api->ReqStockQryEntrustOrder(p); return 0; }
/**
* STOCK-实时成交查询请求
* @param p:指向用户实时成交查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryRealTimeTrade(DFITCSECTraderApi *api, DFITCStockReqQryRealTimeTradeField *p) { api->ReqStockQryRealTimeTrade(p); return 0; }
/**
* STOCK-分笔成交查询请求
* @param p:指向用户分笔成交查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQrySerialTrade(DFITCSECTraderApi *api, DFITCStockReqQrySerialTradeField *p){ api->ReqStockQrySerialTrade(p); return 0; }
/**
* STOCK-持仓查询请求
* @param p:指向用户持仓查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryPosition(DFITCSECTraderApi *api, DFITCStockReqQryPositionField *p) { api->ReqStockQryPosition(p); return 0; }
/**
* STOCK-资金账户查询请求
* @param p:指向用户资金账户查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryCapitalAccountInfo(DFITCSECTraderApi *api, DFITCStockReqQryCapitalAccountField *p){ api->ReqStockQryCapitalAccountInfo(p); return 0; }
/**
* STOCK-账户查询请求
* @param p:指向用户账户查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryAccountInfo(DFITCSECTraderApi *api, DFITCStockReqQryAccountField *p) { api->ReqStockQryAccountInfo(p); return 0; }
/**
* STOCK-股东查询请求
* @param p:指向用户股东查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryShareholderInfo(DFITCSECTraderApi *api, DFITCStockReqQryShareholderField *p)  { api->ReqStockQryShareholderInfo(p); return 0; }
/**
* STOCK-调拨资金请求
* @param p:指向用户调拨资金请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockTransferFunds(DFITCSECTraderApi *api, DFITCStockReqTransferFundsField *p)  { api->ReqStockTransferFunds(p); return 0; }
/**
* STOCK-批量委托请求
* @param p:指向用户批量委托请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockEntrustBatchOrder(DFITCSECTraderApi *api, DFITCStockReqEntrustBatchOrderField *p)  { api->ReqStockEntrustBatchOrder(p); return 0; }
/**
* STOCK-批量撤单请求
* @param p:指向用户批量撤单请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockWithdrawBatchOrder(DFITCSECTraderApi *api, DFITCStockReqWithdrawBatchOrderField *p)  { api->ReqStockWithdrawBatchOrder(p); return 0; }
/**
* STOCK-计算可委托数量请求
* @param p:指向用户计算可委托数量请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockCalcAbleEntrustQty(DFITCSECTraderApi *api, DFITCStockReqCalcAbleEntrustQtyField *p) { api->ReqStockCalcAbleEntrustQty(p); return 0; }
/**
* STOCK-计算可申购ETF篮子数请求
* @param p:指向用户计算可申购ETF篮子数请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockCalcAblePurchaseETFQty(DFITCSECTraderApi *api, DFITCStockReqCalcAblePurchaseETFQtyField *p)  { api->ReqStockCalcAblePurchaseETFQty(p); return 0; }
/**
* STOCK-冻结资金明细查询请求
* @param p:指向用户冻结资金明细查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryFreezeFundsDetail(DFITCSECTraderApi *api, DFITCStockReqQryFreezeFundsDetailField *p){ api->ReqStockQryFreezeFundsDetail(p); return 0; }
/**
* STOCK-冻结证券明细查询
* @param p:指向用户冻结证券明细查询结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryFreezeStockDetail(DFITCSECTraderApi *api, DFITCStockReqQryFreezeStockDetailField *p){ api->ReqStockQryFreezeStockDetail(p); return 0; }
/**
* STOCK-调拨资金明细查询请求
* @param p:指向用户调拨资金明细查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryTransferFundsDetail(DFITCSECTraderApi *api, DFITCStockReqQryTransferFundsDetailField *p) { api->ReqStockQryTransferFundsDetail(p); return 0; }
/**
* STOCK-调拨证券明细查询请求
* @param p:指向用户调拨证券明细查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryTransferStockDetail(DFITCSECTraderApi *api, DFITCStockReqQryTransferStockDetailField *p) { api->ReqStockQryTransferStockDetail(p); return 0; }



DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryStockInfo(DFITCSECTraderApi *api, DFITCStockReqQryStockField *p)  { api->ReqStockQryStockInfo(p); return 0; }
/**
* STOCK-股票静态信息查询请求
* @param p:指向用户股票静态信息查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryStockStaticInfo(DFITCSECTraderApi *api, DFITCStockReqQryStockStaticField *p)  { api->ReqStockQryStockStaticInfo(p); return 0; }
/**
* STOCK-交易时间查询请求
* @param p:指向用户交易时间查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryTradeTime(DFITCSECTraderApi *api, DFITCStockReqQryTradeTimeField *p)  { api->ReqStockQryTradeTime(p); return 0; }
/**
* SOP-登录请求
* @param p:指向用户登录请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPUserLogin(DFITCSECTraderApi *api, DFITCSECReqUserLoginField *p)  { api->ReqSOPUserLogin(p); return 0; }
/**
* SOP-登出请求
* @param p:指向用户登出请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPUserLogout(DFITCSECTraderApi *api, DFITCSECReqUserLogoutField *p)  { api->ReqSOPUserLogout(p); return 0; }
/**
* SOP-交易密码更新请求
* @param p:指向用户密码更新请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPUserPasswordUpdate(DFITCSECTraderApi *api, DFITCSECReqPasswordUpdateField *p)  { api->ReqSOPUserPasswordUpdate(p); return 0; }
/**
* SOP-报单请求
* @param p:指向用户报单请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPEntrustOrder(DFITCSECTraderApi *api, DFITCSOPReqEntrustOrderField *p)  { api->ReqSOPEntrustOrder(p); return 0; }
/**
* SOP-持仓组合拆分委托请求
* @param p:指向用户交易所持仓组合拆分委托请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPGroupSplit(DFITCSECTraderApi *api, DFITCSOPReqGroupSplitField *p)  { api->ReqSOPGroupSplit(p); return 0; }
/**
* SOP-查询客户组合持仓明细请求
* @param p:指向用户查询客户组合持仓明细请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryGroupPosition(DFITCSECTraderApi *api, DFITCSOPReqQryGroupPositionField *p)  { api->ReqSOPQryGroupPosition(p); return 0; }
/**
* SOP-证券锁定解锁请求
* @param p:指向用户证券锁定解锁请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPLockOUnLockStock(DFITCSECTraderApi *api, DFITCSOPReqLockOUnLockStockField *p)  { api->ReqSOPLockOUnLockStock(p); return 0; }
/**
* SOP-撤单请求
* @param p:指向用户撤单请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPWithdrawOrder(DFITCSECTraderApi *api, DFITCSECReqWithdrawOrderField *p)  { api->ReqSOPWithdrawOrder(p); return 0; }
/**
* SOP-当日委托查询请求
* @param p:指向用户当日委托查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryEntrustOrder(DFITCSECTraderApi *api, DFITCSOPReqQryEntrustOrderField *p)  { api->ReqSOPQryEntrustOrder(p); return 0; }
/**
* SOP-分笔成交查询请求
* @param p:指向用户分笔成交查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQrySerialTrade(DFITCSECTraderApi *api, DFITCSOPReqQrySerialTradeField *p)  { api->ReqSOPQrySerialTrade(p); return 0; }
/**
* SOP-持仓查询请求
* @param p:指向用户持仓查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryPosition(DFITCSECTraderApi *api, DFITCSOPReqQryPositionField *p)  { api->ReqSOPQryPosition(p); return 0; }
/**
* SOP-担保物持仓查询请求
* @param p:指向用户担保物持仓查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryCollateralPosition(DFITCSECTraderApi *api, DFITCSOPReqQryCollateralPositionField *p)  { api->ReqSOPQryCollateralPosition(p); return 0; }
/**
* SOP-资金信息查询请求
* @param p:指向用户资金信息查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryCapitalAccountInfo(DFITCSECTraderApi *api, DFITCSOPReqQryCapitalAccountField *p)  { api->ReqSOPQryCapitalAccountInfo(p); return 0; }
/**
* SOP-客户信息查询请求
* @param p:指向用户客户信息查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryAccountInfo(DFITCSECTraderApi *api, DFITCSOPReqQryAccountField *p)  { api->ReqSOPQryAccountInfo(p); return 0; }
/**
* SOP-股东信息查询请求
* @param p:指向用户股东信息查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryShareholderInfo(DFITCSECTraderApi *api, DFITCSOPReqQryShareholderField *p)  { api->ReqSOPQryShareholderInfo(p); return 0; }
/**
* SOP-可委托数量计算请求
* @param p:指向用户可委托数量计算请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPCalcAbleEntrustQty(DFITCSECTraderApi *api, DFITCSOPReqCalcAbleEntrustQtyField *p)  { api->ReqSOPCalcAbleEntrustQty(p); return 0; }
/**
* SOP-可锁定证券数量查询请求
* @param p:指向用户可锁定证券数量查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryAbleLockStock(DFITCSECTraderApi *api, DFITCSOPReqQryAbleLockStockField *p)  { api->ReqSOPQryAbleLockStock(p); return 0; }
/**
* SOP-期权合约代码查询请求
* @param p:指向用户期权合约代码查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryContactInfo(DFITCSECTraderApi *api, DFITCSOPReqQryContactField *p)  { api->ReqSOPQryContactInfo(p); return 0; }
/**
* SOP-行权委托请求
* @param p:指向用户行权委托请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPExectueOrder(DFITCSECTraderApi *api, DFITCSOPReqExectueOrderField *p)  { api->ReqSOPExectueOrder(p); return 0; }
/**
* SOP-行权指派信息查询请求
* @param p:指向用户行权指派信息查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryExecAssiInfo(DFITCSECTraderApi *api, DFITCSOPReqQryExecAssiInfoField *p)  { api->ReqSOPQryExecAssiInfo(p); return 0; }
/**
* SOP-交易时间查询请求
* @param p:指向用户交易时间查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryTradeTime(DFITCSECTraderApi *api, DFITCSOPReqQryTradeTimeField *p)  { api->ReqSOPQryTradeTime(p); return 0; }
/**
* SOP-交易所信息查询请求
* @param p:指向用户交易所信息查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryExchangeInfo(DFITCSECTraderApi *api, DFITCSOPReqQryExchangeInfoField *p)  { api->ReqSOPQryExchangeInfo(p); return 0; }
/**
* SOP-手续费查询请求
* @param p:指向用户手续费查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryCommission(DFITCSECTraderApi *api, DFITCSOPReqQryCommissionField *p)  { api->ReqSOPQryCommission(p); return 0; }
/**
* SOP-保证金查询请求
* @param p:指向用户保证金查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryDeposit(DFITCSECTraderApi *api, DFITCSOPReqQryDepositField *p)  { api->ReqSOPQryDeposit(p); return 0; }
/**
* SOP-标的信息查询请求
* @param p:指向用户标的信息查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryContractObjectInfo(DFITCSECTraderApi *api, DFITCSOPReqQryContractObjectField *p)  { api->ReqSOPQryContractObjectInfo(p); return 0; }
/**
* FASL-登录请求
* @param p:指向用户登录请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLUserLogin(DFITCSECTraderApi *api, DFITCSECReqUserLoginField *p)  { api->ReqFASLUserLogin(p); return 0; }
/**
* FASL-登出请求
* @param p:指向用户登出请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLUserLogout(DFITCSECTraderApi *api, DFITCSECReqUserLogoutField *p)  { api->ReqFASLUserLogout(p); return 0; }
/**
* FASL-客户可融资信息请求
* @param p:指向用户客户可融资信息请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryAbleFinInfo(DFITCSECTraderApi *api, DFITCFASLReqAbleFinInfoField *p)  { api->ReqFASLQryAbleFinInfo(p); return 0; }
/**
* FASL-客户可融券信息请求
* @param p:指向用户客户可融券信息请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryAbleSloInfo(DFITCSECTraderApi *api, DFITCFASLReqAbleSloInfoField *p)  { api->ReqFASLQryAbleSloInfo(p); return 0; }
/**
* FASL-担保物划转请求
* @param p:指向用户担保物划转请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLTransferCollateral(DFITCSECTraderApi *api, DFITCFASLReqTransferCollateralField *p)  { api->ReqFASLTransferCollateral(p); return 0; }
/**
* FASL-直接还款请求
* @param p:指向用户直接还款请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLDirectRepayment(DFITCSECTraderApi *api, DFITCFASLReqDirectRepaymentField *p)  { api->ReqFASLDirectRepayment(p); return 0; }
/**
* FASL-还券划转请求
* @param p:指向用户还券划转请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLRepayStockTransfer(DFITCSECTraderApi *api, DFITCFASLReqRepayStockTransferField *p)  { api->ReqFASLRepayStockTransfer(p); return 0; }
/**
* FASL-信用交易请求
* @param p:指向用户信用交易请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLEntrustCrdtOrder(DFITCSECTraderApi *api, DFITCFASLReqEntrustCrdtOrderField *p)  { api->ReqFASLEntrustCrdtOrder(p); return 0; }
/**
* FASL-融资融券交易请求
* @param p:指向用户融资融券交易请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLEntrsuctOrder(DFITCSECTraderApi *api, DFITCFASLReqEntrustOrderField *p)  { api->ReqFASLEntrsuctOrder(p); return 0; }
/**
* FASL-撤单请求
* @param p:指向用户撤单请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLWithdrawOrder(DFITCSECTraderApi *api, DFITCFASLReqWithdrawOrderField *p)  { api->ReqFASLWithdrawOrder(p); return 0; }
/**
* FASL-信用可委托数量查询请求
* @param p:指向用户信用可委托数量查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLCalcAbleEntrustCrdtQty(DFITCSECTraderApi *api, DFITCFASLReqCalcAbleEntrustCrdtQtyField *p)  { api->ReqFASLCalcAbleEntrustCrdtQty(p); return 0; }
/**
* FASL-查询信用资金请求
* @param p:指向用户查询信用资金请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryCrdtFunds(DFITCSECTraderApi *api, DFITCFASLReqQryCrdtFundsField *p)  { api->ReqFASLQryCrdtFunds(p); return 0; }
/**
* FASL-信用合约信息请求
* @param p:指向用户信用合约信息请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryCrdtContract(DFITCSECTraderApi *api, DFITCFASLReqQryCrdtContractField *p)  { api->ReqFASLQryCrdtContract(p); return 0; }
/**
* FASL-信用合约变动信息查询请求
* @param p:指向用户信用合约变动信息查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryCrdtConChangeInfo(DFITCSECTraderApi *api, DFITCFASLReqQryCrdtConChangeInfoField *p)  { api->ReqFASLQryCrdtConChangeInfo(p); return 0; }
/**
* FASL-资金调转请求
* @param p:指向用户资金调转请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLTransferFunds(DFITCSECTraderApi *api, DFITCStockReqTransferFundsField *p)  { api->ReqFASLTransferFunds(p); return 0; }
/**
* FASL-客户信息查询请求
* @param p:指向用户客户信息查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryAccountInfo(DFITCSECTraderApi *api, DFITCStockReqQryAccountField *p)  { api->ReqFASLQryAccountInfo(p); return 0; }
/**
* FASL-客户资金查询请求
* @param p:指向用户客户资金查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryCapitalAccountInfo(DFITCSECTraderApi *api, DFITCStockReqQryCapitalAccountField *p)  { api->ReqFASLQryCapitalAccountInfo(p); return 0; }
/**
* FASL-股东信息查询请求
* @param p:指向用户股东信息查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryShareholderInfo(DFITCSECTraderApi *api, DFITCStockReqQryShareholderField *p)  { api->ReqFASLQryShareholderInfo(p); return 0; }
/**
* FASL-持仓查询请求
* @param p:指向用户持仓查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryPosition(DFITCSECTraderApi *api, DFITCStockReqQryPositionField *p)  { api->ReqFASLQryPosition(p); return 0; }
/**
* FASL-委托查询请求
* @param p:指向用户委托查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryEntrustOrder(DFITCSECTraderApi *api, DFITCStockReqQryEntrustOrderField *p)  { api->ReqFASLQryEntrustOrder(p); return 0; }
/**
* FASL-分笔成交查询请求
* @param p:指向用户分笔成交查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQrySerialTrade(DFITCSECTraderApi *api, DFITCStockReqQrySerialTradeField *p)  { api->ReqFASLQrySerialTrade(p); return 0; }
/**
* FASL-实时成交查询请求
* @param p:指向用户实时成交查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryRealTimeTrade(DFITCSECTraderApi *api, DFITCStockReqQryRealTimeTradeField *p)  { api->ReqFASLQryRealTimeTrade(p); return 0; }
/**
* FASL-资金冻结明细查询请求
* @param p:指向用户资金冻结明细查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryFreezeFundsDetail(DFITCSECTraderApi *api, DFITCStockReqQryFreezeFundsDetailField *p)  { api->ReqFASLQryFreezeFundsDetail(p); return 0; }
/**
* FASL-证券冻结明细查询请求
* @param p:指向用户证券冻结明细查询请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryFreezeStockDetail(DFITCSECTraderApi *api, DFITCStockReqQryFreezeStockDetailField *p)  { api->ReqFASLQryFreezeStockDetail(p); return 0; }
/**
* FASL-查询资金调拨明细请求
* @param p:指向用户查询资金调拨明细请求结构的地址
* @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryTransferFundsDetail(DFITCSECTraderApi *api, DFITCStockReqQryTransferFundsDetailField *p)  { api->ReqFASLQryTransferFundsDetail(p); return 0; }
/**
* FASL-当前系统时间查询请求
* @param p:指向用户交易时间查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQrySystemTime(DFITCSECTraderApi *api, DFITCFASLReqQryTradeTimeField *p)  { api->ReqFASLQrySystemTime(p); return 0; }
/**
* FASL-可转入担保证券查询请求
* @param p:指向可转入担保证券查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryTransferredContract(DFITCSECTraderApi *api, DFITCFASLReqQryTransferredContractField *p)  { api->ReqFASLQryTransferredContract(p); return 0; }
/**
* FASL-客户可取资金调出请求
* @param p:指向客户可取资金调出请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLDesirableFundsOut(DFITCSECTraderApi *api, DFITCFASLReqDesirableFundsOutField *p)  { api->ReqFASLDesirableFundsOut(p); return 0; }
/**
* FASL-担保证券查询请求
* @param p:指向担保证券查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryGuaranteedContract(DFITCSECTraderApi *api, DFITCFASLReqQryGuaranteedContractField *p)  { api->ReqFASLQryGuaranteedContract(p); return 0; }
/**
* FASL-标的证券查询请求
* @param p:指向标的证券查询请求结构体的地址
* @return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryUnderlyingContract(DFITCSECTraderApi *api, DFITCFASLReqQryUnderlyingContractField *p)  { api->ReqFASLQryUnderlyingContract(p); return 0; }

