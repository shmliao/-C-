// SecTdi.cpp : ���� DLL Ӧ�ó���ĵ���������
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
* STOCK-�ǳ�����
* @param p:ָ���û��ǳ�����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockUserLogout(DFITCSECTraderApi *api, DFITCSECReqUserLogoutField *p){ api->ReqStockUserLogout(p); return 0; }
/**
* STOCK-�����������
* @param p:ָ���û������������ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockUserPasswordUpdate(DFITCSECTraderApi *api, DFITCSECReqPasswordUpdateField *p){ api->ReqStockUserPasswordUpdate(p); return 0; }
/**
* STOCK-ί������
* @param p:ָ���û�ί������ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockEntrustOrder(DFITCSECTraderApi *api, DFITCStockReqEntrustOrderField *p){ api->ReqStockEntrustOrder(p); return 0; }
/**
* STOCK-��������
* @param p:ָ���û���������ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockWithdrawOrder(DFITCSECTraderApi *api, DFITCSECReqWithdrawOrderField *p) { api->ReqStockWithdrawOrder(p); return 0; }
/**
* STOCK-ί�в�ѯ����
* @param p:ָ���û�ί�в�ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryEntrustOrder(DFITCSECTraderApi *api, DFITCStockReqQryEntrustOrderField *p)  { api->ReqStockQryEntrustOrder(p); return 0; }
/**
* STOCK-ʵʱ�ɽ���ѯ����
* @param p:ָ���û�ʵʱ�ɽ���ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryRealTimeTrade(DFITCSECTraderApi *api, DFITCStockReqQryRealTimeTradeField *p) { api->ReqStockQryRealTimeTrade(p); return 0; }
/**
* STOCK-�ֱʳɽ���ѯ����
* @param p:ָ���û��ֱʳɽ���ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQrySerialTrade(DFITCSECTraderApi *api, DFITCStockReqQrySerialTradeField *p){ api->ReqStockQrySerialTrade(p); return 0; }
/**
* STOCK-�ֲֲ�ѯ����
* @param p:ָ���û��ֲֲ�ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryPosition(DFITCSECTraderApi *api, DFITCStockReqQryPositionField *p) { api->ReqStockQryPosition(p); return 0; }
/**
* STOCK-�ʽ��˻���ѯ����
* @param p:ָ���û��ʽ��˻���ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryCapitalAccountInfo(DFITCSECTraderApi *api, DFITCStockReqQryCapitalAccountField *p){ api->ReqStockQryCapitalAccountInfo(p); return 0; }
/**
* STOCK-�˻���ѯ����
* @param p:ָ���û��˻���ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryAccountInfo(DFITCSECTraderApi *api, DFITCStockReqQryAccountField *p) { api->ReqStockQryAccountInfo(p); return 0; }
/**
* STOCK-�ɶ���ѯ����
* @param p:ָ���û��ɶ���ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryShareholderInfo(DFITCSECTraderApi *api, DFITCStockReqQryShareholderField *p)  { api->ReqStockQryShareholderInfo(p); return 0; }
/**
* STOCK-�����ʽ�����
* @param p:ָ���û������ʽ�����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockTransferFunds(DFITCSECTraderApi *api, DFITCStockReqTransferFundsField *p)  { api->ReqStockTransferFunds(p); return 0; }
/**
* STOCK-����ί������
* @param p:ָ���û�����ί������ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockEntrustBatchOrder(DFITCSECTraderApi *api, DFITCStockReqEntrustBatchOrderField *p)  { api->ReqStockEntrustBatchOrder(p); return 0; }
/**
* STOCK-������������
* @param p:ָ���û�������������ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockWithdrawBatchOrder(DFITCSECTraderApi *api, DFITCStockReqWithdrawBatchOrderField *p)  { api->ReqStockWithdrawBatchOrder(p); return 0; }
/**
* STOCK-�����ί����������
* @param p:ָ���û������ί����������ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockCalcAbleEntrustQty(DFITCSECTraderApi *api, DFITCStockReqCalcAbleEntrustQtyField *p) { api->ReqStockCalcAbleEntrustQty(p); return 0; }
/**
* STOCK-������깺ETF����������
* @param p:ָ���û�������깺ETF����������ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockCalcAblePurchaseETFQty(DFITCSECTraderApi *api, DFITCStockReqCalcAblePurchaseETFQtyField *p)  { api->ReqStockCalcAblePurchaseETFQty(p); return 0; }
/**
* STOCK-�����ʽ���ϸ��ѯ����
* @param p:ָ���û������ʽ���ϸ��ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryFreezeFundsDetail(DFITCSECTraderApi *api, DFITCStockReqQryFreezeFundsDetailField *p){ api->ReqStockQryFreezeFundsDetail(p); return 0; }
/**
* STOCK-����֤ȯ��ϸ��ѯ
* @param p:ָ���û�����֤ȯ��ϸ��ѯ�ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryFreezeStockDetail(DFITCSECTraderApi *api, DFITCStockReqQryFreezeStockDetailField *p){ api->ReqStockQryFreezeStockDetail(p); return 0; }
/**
* STOCK-�����ʽ���ϸ��ѯ����
* @param p:ָ���û������ʽ���ϸ��ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryTransferFundsDetail(DFITCSECTraderApi *api, DFITCStockReqQryTransferFundsDetailField *p) { api->ReqStockQryTransferFundsDetail(p); return 0; }
/**
* STOCK-����֤ȯ��ϸ��ѯ����
* @param p:ָ���û�����֤ȯ��ϸ��ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryTransferStockDetail(DFITCSECTraderApi *api, DFITCStockReqQryTransferStockDetailField *p) { api->ReqStockQryTransferStockDetail(p); return 0; }



DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryStockInfo(DFITCSECTraderApi *api, DFITCStockReqQryStockField *p)  { api->ReqStockQryStockInfo(p); return 0; }
/**
* STOCK-��Ʊ��̬��Ϣ��ѯ����
* @param p:ָ���û���Ʊ��̬��Ϣ��ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryStockStaticInfo(DFITCSECTraderApi *api, DFITCStockReqQryStockStaticField *p)  { api->ReqStockQryStockStaticInfo(p); return 0; }
/**
* STOCK-����ʱ���ѯ����
* @param p:ָ���û�����ʱ���ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqStockQryTradeTime(DFITCSECTraderApi *api, DFITCStockReqQryTradeTimeField *p)  { api->ReqStockQryTradeTime(p); return 0; }
/**
* SOP-��¼����
* @param p:ָ���û���¼����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPUserLogin(DFITCSECTraderApi *api, DFITCSECReqUserLoginField *p)  { api->ReqSOPUserLogin(p); return 0; }
/**
* SOP-�ǳ�����
* @param p:ָ���û��ǳ�����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPUserLogout(DFITCSECTraderApi *api, DFITCSECReqUserLogoutField *p)  { api->ReqSOPUserLogout(p); return 0; }
/**
* SOP-���������������
* @param p:ָ���û������������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPUserPasswordUpdate(DFITCSECTraderApi *api, DFITCSECReqPasswordUpdateField *p)  { api->ReqSOPUserPasswordUpdate(p); return 0; }
/**
* SOP-��������
* @param p:ָ���û���������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPEntrustOrder(DFITCSECTraderApi *api, DFITCSOPReqEntrustOrderField *p)  { api->ReqSOPEntrustOrder(p); return 0; }
/**
* SOP-�ֲ���ϲ��ί������
* @param p:ָ���û��������ֲ���ϲ��ί������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPGroupSplit(DFITCSECTraderApi *api, DFITCSOPReqGroupSplitField *p)  { api->ReqSOPGroupSplit(p); return 0; }
/**
* SOP-��ѯ�ͻ���ϳֲ���ϸ����
* @param p:ָ���û���ѯ�ͻ���ϳֲ���ϸ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryGroupPosition(DFITCSECTraderApi *api, DFITCSOPReqQryGroupPositionField *p)  { api->ReqSOPQryGroupPosition(p); return 0; }
/**
* SOP-֤ȯ������������
* @param p:ָ���û�֤ȯ������������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPLockOUnLockStock(DFITCSECTraderApi *api, DFITCSOPReqLockOUnLockStockField *p)  { api->ReqSOPLockOUnLockStock(p); return 0; }
/**
* SOP-��������
* @param p:ָ���û���������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPWithdrawOrder(DFITCSECTraderApi *api, DFITCSECReqWithdrawOrderField *p)  { api->ReqSOPWithdrawOrder(p); return 0; }
/**
* SOP-����ί�в�ѯ����
* @param p:ָ���û�����ί�в�ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryEntrustOrder(DFITCSECTraderApi *api, DFITCSOPReqQryEntrustOrderField *p)  { api->ReqSOPQryEntrustOrder(p); return 0; }
/**
* SOP-�ֱʳɽ���ѯ����
* @param p:ָ���û��ֱʳɽ���ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQrySerialTrade(DFITCSECTraderApi *api, DFITCSOPReqQrySerialTradeField *p)  { api->ReqSOPQrySerialTrade(p); return 0; }
/**
* SOP-�ֲֲ�ѯ����
* @param p:ָ���û��ֲֲ�ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryPosition(DFITCSECTraderApi *api, DFITCSOPReqQryPositionField *p)  { api->ReqSOPQryPosition(p); return 0; }
/**
* SOP-������ֲֲ�ѯ����
* @param p:ָ���û�������ֲֲ�ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryCollateralPosition(DFITCSECTraderApi *api, DFITCSOPReqQryCollateralPositionField *p)  { api->ReqSOPQryCollateralPosition(p); return 0; }
/**
* SOP-�ʽ���Ϣ��ѯ����
* @param p:ָ���û��ʽ���Ϣ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryCapitalAccountInfo(DFITCSECTraderApi *api, DFITCSOPReqQryCapitalAccountField *p)  { api->ReqSOPQryCapitalAccountInfo(p); return 0; }
/**
* SOP-�ͻ���Ϣ��ѯ����
* @param p:ָ���û��ͻ���Ϣ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryAccountInfo(DFITCSECTraderApi *api, DFITCSOPReqQryAccountField *p)  { api->ReqSOPQryAccountInfo(p); return 0; }
/**
* SOP-�ɶ���Ϣ��ѯ����
* @param p:ָ���û��ɶ���Ϣ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryShareholderInfo(DFITCSECTraderApi *api, DFITCSOPReqQryShareholderField *p)  { api->ReqSOPQryShareholderInfo(p); return 0; }
/**
* SOP-��ί��������������
* @param p:ָ���û���ί��������������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPCalcAbleEntrustQty(DFITCSECTraderApi *api, DFITCSOPReqCalcAbleEntrustQtyField *p)  { api->ReqSOPCalcAbleEntrustQty(p); return 0; }
/**
* SOP-������֤ȯ������ѯ����
* @param p:ָ���û�������֤ȯ������ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryAbleLockStock(DFITCSECTraderApi *api, DFITCSOPReqQryAbleLockStockField *p)  { api->ReqSOPQryAbleLockStock(p); return 0; }
/**
* SOP-��Ȩ��Լ�����ѯ����
* @param p:ָ���û���Ȩ��Լ�����ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryContactInfo(DFITCSECTraderApi *api, DFITCSOPReqQryContactField *p)  { api->ReqSOPQryContactInfo(p); return 0; }
/**
* SOP-��Ȩί������
* @param p:ָ���û���Ȩί������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPExectueOrder(DFITCSECTraderApi *api, DFITCSOPReqExectueOrderField *p)  { api->ReqSOPExectueOrder(p); return 0; }
/**
* SOP-��Ȩָ����Ϣ��ѯ����
* @param p:ָ���û���Ȩָ����Ϣ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryExecAssiInfo(DFITCSECTraderApi *api, DFITCSOPReqQryExecAssiInfoField *p)  { api->ReqSOPQryExecAssiInfo(p); return 0; }
/**
* SOP-����ʱ���ѯ����
* @param p:ָ���û�����ʱ���ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryTradeTime(DFITCSECTraderApi *api, DFITCSOPReqQryTradeTimeField *p)  { api->ReqSOPQryTradeTime(p); return 0; }
/**
* SOP-��������Ϣ��ѯ����
* @param p:ָ���û���������Ϣ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryExchangeInfo(DFITCSECTraderApi *api, DFITCSOPReqQryExchangeInfoField *p)  { api->ReqSOPQryExchangeInfo(p); return 0; }
/**
* SOP-�����Ѳ�ѯ����
* @param p:ָ���û������Ѳ�ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryCommission(DFITCSECTraderApi *api, DFITCSOPReqQryCommissionField *p)  { api->ReqSOPQryCommission(p); return 0; }
/**
* SOP-��֤���ѯ����
* @param p:ָ���û���֤���ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryDeposit(DFITCSECTraderApi *api, DFITCSOPReqQryDepositField *p)  { api->ReqSOPQryDeposit(p); return 0; }
/**
* SOP-�����Ϣ��ѯ����
* @param p:ָ���û������Ϣ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqSOPQryContractObjectInfo(DFITCSECTraderApi *api, DFITCSOPReqQryContractObjectField *p)  { api->ReqSOPQryContractObjectInfo(p); return 0; }
/**
* FASL-��¼����
* @param p:ָ���û���¼����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLUserLogin(DFITCSECTraderApi *api, DFITCSECReqUserLoginField *p)  { api->ReqFASLUserLogin(p); return 0; }
/**
* FASL-�ǳ�����
* @param p:ָ���û��ǳ�����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLUserLogout(DFITCSECTraderApi *api, DFITCSECReqUserLogoutField *p)  { api->ReqFASLUserLogout(p); return 0; }
/**
* FASL-�ͻ���������Ϣ����
* @param p:ָ���û��ͻ���������Ϣ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryAbleFinInfo(DFITCSECTraderApi *api, DFITCFASLReqAbleFinInfoField *p)  { api->ReqFASLQryAbleFinInfo(p); return 0; }
/**
* FASL-�ͻ�����ȯ��Ϣ����
* @param p:ָ���û��ͻ�����ȯ��Ϣ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryAbleSloInfo(DFITCSECTraderApi *api, DFITCFASLReqAbleSloInfoField *p)  { api->ReqFASLQryAbleSloInfo(p); return 0; }
/**
* FASL-�����ﻮת����
* @param p:ָ���û������ﻮת����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLTransferCollateral(DFITCSECTraderApi *api, DFITCFASLReqTransferCollateralField *p)  { api->ReqFASLTransferCollateral(p); return 0; }
/**
* FASL-ֱ�ӻ�������
* @param p:ָ���û�ֱ�ӻ�������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLDirectRepayment(DFITCSECTraderApi *api, DFITCFASLReqDirectRepaymentField *p)  { api->ReqFASLDirectRepayment(p); return 0; }
/**
* FASL-��ȯ��ת����
* @param p:ָ���û���ȯ��ת����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLRepayStockTransfer(DFITCSECTraderApi *api, DFITCFASLReqRepayStockTransferField *p)  { api->ReqFASLRepayStockTransfer(p); return 0; }
/**
* FASL-���ý�������
* @param p:ָ���û����ý�������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLEntrustCrdtOrder(DFITCSECTraderApi *api, DFITCFASLReqEntrustCrdtOrderField *p)  { api->ReqFASLEntrustCrdtOrder(p); return 0; }
/**
* FASL-������ȯ��������
* @param p:ָ���û�������ȯ��������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLEntrsuctOrder(DFITCSECTraderApi *api, DFITCFASLReqEntrustOrderField *p)  { api->ReqFASLEntrsuctOrder(p); return 0; }
/**
* FASL-��������
* @param p:ָ���û���������ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLWithdrawOrder(DFITCSECTraderApi *api, DFITCFASLReqWithdrawOrderField *p)  { api->ReqFASLWithdrawOrder(p); return 0; }
/**
* FASL-���ÿ�ί��������ѯ����
* @param p:ָ���û����ÿ�ί��������ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLCalcAbleEntrustCrdtQty(DFITCSECTraderApi *api, DFITCFASLReqCalcAbleEntrustCrdtQtyField *p)  { api->ReqFASLCalcAbleEntrustCrdtQty(p); return 0; }
/**
* FASL-��ѯ�����ʽ�����
* @param p:ָ���û���ѯ�����ʽ�����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryCrdtFunds(DFITCSECTraderApi *api, DFITCFASLReqQryCrdtFundsField *p)  { api->ReqFASLQryCrdtFunds(p); return 0; }
/**
* FASL-���ú�Լ��Ϣ����
* @param p:ָ���û����ú�Լ��Ϣ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryCrdtContract(DFITCSECTraderApi *api, DFITCFASLReqQryCrdtContractField *p)  { api->ReqFASLQryCrdtContract(p); return 0; }
/**
* FASL-���ú�Լ�䶯��Ϣ��ѯ����
* @param p:ָ���û����ú�Լ�䶯��Ϣ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryCrdtConChangeInfo(DFITCSECTraderApi *api, DFITCFASLReqQryCrdtConChangeInfoField *p)  { api->ReqFASLQryCrdtConChangeInfo(p); return 0; }
/**
* FASL-�ʽ��ת����
* @param p:ָ���û��ʽ��ת����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLTransferFunds(DFITCSECTraderApi *api, DFITCStockReqTransferFundsField *p)  { api->ReqFASLTransferFunds(p); return 0; }
/**
* FASL-�ͻ���Ϣ��ѯ����
* @param p:ָ���û��ͻ���Ϣ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryAccountInfo(DFITCSECTraderApi *api, DFITCStockReqQryAccountField *p)  { api->ReqFASLQryAccountInfo(p); return 0; }
/**
* FASL-�ͻ��ʽ��ѯ����
* @param p:ָ���û��ͻ��ʽ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryCapitalAccountInfo(DFITCSECTraderApi *api, DFITCStockReqQryCapitalAccountField *p)  { api->ReqFASLQryCapitalAccountInfo(p); return 0; }
/**
* FASL-�ɶ���Ϣ��ѯ����
* @param p:ָ���û��ɶ���Ϣ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryShareholderInfo(DFITCSECTraderApi *api, DFITCStockReqQryShareholderField *p)  { api->ReqFASLQryShareholderInfo(p); return 0; }
/**
* FASL-�ֲֲ�ѯ����
* @param p:ָ���û��ֲֲ�ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryPosition(DFITCSECTraderApi *api, DFITCStockReqQryPositionField *p)  { api->ReqFASLQryPosition(p); return 0; }
/**
* FASL-ί�в�ѯ����
* @param p:ָ���û�ί�в�ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryEntrustOrder(DFITCSECTraderApi *api, DFITCStockReqQryEntrustOrderField *p)  { api->ReqFASLQryEntrustOrder(p); return 0; }
/**
* FASL-�ֱʳɽ���ѯ����
* @param p:ָ���û��ֱʳɽ���ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQrySerialTrade(DFITCSECTraderApi *api, DFITCStockReqQrySerialTradeField *p)  { api->ReqFASLQrySerialTrade(p); return 0; }
/**
* FASL-ʵʱ�ɽ���ѯ����
* @param p:ָ���û�ʵʱ�ɽ���ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryRealTimeTrade(DFITCSECTraderApi *api, DFITCStockReqQryRealTimeTradeField *p)  { api->ReqFASLQryRealTimeTrade(p); return 0; }
/**
* FASL-�ʽ𶳽���ϸ��ѯ����
* @param p:ָ���û��ʽ𶳽���ϸ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryFreezeFundsDetail(DFITCSECTraderApi *api, DFITCStockReqQryFreezeFundsDetailField *p)  { api->ReqFASLQryFreezeFundsDetail(p); return 0; }
/**
* FASL-֤ȯ������ϸ��ѯ����
* @param p:ָ���û�֤ȯ������ϸ��ѯ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryFreezeStockDetail(DFITCSECTraderApi *api, DFITCStockReqQryFreezeStockDetailField *p)  { api->ReqFASLQryFreezeStockDetail(p); return 0; }
/**
* FASL-��ѯ�ʽ������ϸ����
* @param p:ָ���û���ѯ�ʽ������ϸ����ṹ�ĵ�ַ
* @return 0��ʾ�����ͳɹ�������ֵ��ʾ������ʧ�ܣ�������������error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryTransferFundsDetail(DFITCSECTraderApi *api, DFITCStockReqQryTransferFundsDetailField *p)  { api->ReqFASLQryTransferFundsDetail(p); return 0; }
/**
* FASL-��ǰϵͳʱ���ѯ����
* @param p:ָ���û�����ʱ���ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQrySystemTime(DFITCSECTraderApi *api, DFITCFASLReqQryTradeTimeField *p)  { api->ReqFASLQrySystemTime(p); return 0; }
/**
* FASL-��ת�뵣��֤ȯ��ѯ����
* @param p:ָ���ת�뵣��֤ȯ��ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryTransferredContract(DFITCSECTraderApi *api, DFITCFASLReqQryTransferredContractField *p)  { api->ReqFASLQryTransferredContract(p); return 0; }
/**
* FASL-�ͻ���ȡ�ʽ��������
* @param p:ָ��ͻ���ȡ�ʽ��������ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLDesirableFundsOut(DFITCSECTraderApi *api, DFITCFASLReqDesirableFundsOutField *p)  { api->ReqFASLDesirableFundsOut(p); return 0; }
/**
* FASL-����֤ȯ��ѯ����
* @param p:ָ�򵣱�֤ȯ��ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryGuaranteedContract(DFITCSECTraderApi *api, DFITCFASLReqQryGuaranteedContractField *p)  { api->ReqFASLQryGuaranteedContract(p); return 0; }
/**
* FASL-���֤ȯ��ѯ����
* @param p:ָ����֤ȯ��ѯ����ṹ��ĵ�ַ
* @return : 0 ��ʾ�����ͳɹ����� 0 ��ʾ������ʧ�ܣ����������ο�error.xml
*/
DLL_EXPORT_C_DECL void* WINAPI  ReqFASLQryUnderlyingContract(DFITCSECTraderApi *api, DFITCFASLReqQryUnderlyingContractField *p)  { api->ReqFASLQryUnderlyingContract(p); return 0; }

