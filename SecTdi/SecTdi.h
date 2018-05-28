
#pragma once
#ifdef _WINDOWS  //64位系统没有预定义 WIN32
#ifdef __cplusplus
#define DLL_EXPORT_C_DECL extern "C" __declspec(dllexport)
#else
#define DLL_EXPORT_DECL __declspec(dllexport)
#endif
#else
#ifdef __cplusplus
#define DLL_EXPORT_C_DECL extern "C"
#else
#define DLL_EXPORT_DECL extern
#endif
#endif

#ifdef _WINDOWS
#define WINAPI      __stdcall
#define WIN32_LEAN_AND_MEAN             //  从 Windows 头文件中排除极少使用的信息
#include "stddef.h"
#include "../DFITC_SEC_Api_v1.6.128/windows_x64_DFITC_TEST_001/include/DFITCSECTraderApi.h"
#pragma comment(lib, "../DFITC_SEC_Api_v1.6.128/windows_x64_DFITC_TEST_001/lib/DFITCSECTraderApi.lib")
#else
#define WINAPI
#include "../DFITC_SEC_Api_v1.6.128/windows_x64_DFITC_TEST_001/include/DFITCSECTraderApi.h"
#endif

#include <string.h>


class SecTdi : DFITCSECTraderSpi
{
public:
	SecTdi(void);
	~SecTdi(void);
	//针对收到空反馈的处理
	DFITCSECRspInfoField rif;
	DFITCSECRspInfoField* repare(DFITCSECRspInfoField *pRspInfo)
	{
		if (pRspInfo == NULL)
		{
			memset(&rif, 0, sizeof(rif));
			return &rif;
		}
		else
			return pRspInfo;
	}

	typedef int (WINAPI *FrontConnected)();

	typedef int (WINAPI *FrontDisconnected)(int nReason);

	typedef int (WINAPI *RtnNotice)(DFITCSECRspNoticeField *pNotice);

	typedef int (WINAPI *RspError)(DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockUserLogin)(DFITCSECRspUserLoginField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockUserLogout)(DFITCSECRspUserLogoutField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockUserPasswordUpdate)(DFITCSECRspPasswordUpdateField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockEntrustOrder)(DFITCStockRspEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockWithdrawOrder)(DFITCSECRspWithdrawOrderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockQryEntrustOrder)(DFITCStockRspQryEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQryRealTimeTrade)(DFITCStockRspQryRealTimeTradeField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQrySerialTrade)(DFITCStockRspQrySerialTradeField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQryPosition)(DFITCStockRspQryPositionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQryCapitalAccountInfo)(DFITCStockRspQryCapitalAccountField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQryAccountInfo)(DFITCStockRspQryAccountField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockQryShareholderInfo)(DFITCStockRspQryShareholderField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockTransferFunds)(DFITCStockRspTransferFundsField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockEntrustBatchOrder)(DFITCStockRspEntrustBatchOrderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockWithdrawBatchOrder)(DFITCStockRspWithdrawBatchOrderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockCalcAbleEntrustQty)(DFITCStockRspCalcAbleEntrustQtyField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockCalcAblePurchaseETFQty)(DFITCStockRspCalcAblePurchaseETFQtyField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspStockQryFreezeFundsDetail)(DFITCStockRspQryFreezeFundsDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQryFreezeStockDetail)(DFITCStockRspQryFreezeStockDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQryTransferStockDetail)(DFITCStockRspQryTransferStockDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQryTransferFundsDetail)(DFITCStockRspQryTransferFundsDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQryStockInfo)(DFITCStockRspQryStockField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQryStockStaticInfo)(DFITCStockRspQryStockStaticField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspStockQryTradeTime)(DFITCStockRspQryTradeTimeField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *StockEntrustOrderRtn)(DFITCStockEntrustOrderRtnField * pData);

	typedef int (WINAPI *StockTradeRtn)(DFITCStockTradeRtnField * pData);

	typedef int (WINAPI *StockWithdrawOrderRtn)(DFITCStockWithdrawOrderRtnField * pData);


	typedef int (WINAPI *RspSOPUserLogin)(DFITCSECRspUserLoginField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspSOPUserLogout)(DFITCSECRspUserLogoutField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspSOPUserPasswordUpdate)(DFITCSECRspPasswordUpdateField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspSOPEntrustOrder)(DFITCSOPRspEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *RspSOPGroupSplit)(DFITCSOPRspEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspSOPQryGroupPosition)(DFITCSOPRspQryGroupPositionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPLockOUnLockStock)(DFITCSOPRspLockOUnLockStockField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPWithdrawOrder)(DFITCSECRspWithdrawOrderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspSOPQryEntrustOrder)(DFITCSOPRspQryEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPQrySerialTrade)(DFITCSOPRspQrySerialTradeField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPQryPosition)(DFITCSOPRspQryPositionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPQryCollateralPosition)(DFITCSOPRspQryCollateralPositionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPQryCapitalAccountInfo)(DFITCSOPRspQryCapitalAccountField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspSOPQryAccountInfo)(DFITCSOPRspQryAccountField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspSOPQryShareholderInfo)(DFITCSOPRspQryShareholderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspSOPCalcAbleEntrustQty)(DFITCSOPRspCalcAbleEntrustQtyField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspSOPQryAbleLockStock)(DFITCSOPRspQryAbleLockStockField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPQryContactInfo)(DFITCSOPRspQryContactField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPExectueOrder)(DFITCSOPRspExectueOrderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspSOPQryExecAssiInfo)(DFITCSOPRspQryExecAssiInfoField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPQryTradeTime)(DFITCSOPRspQryTradeTimeField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPQryExchangeInfo)(DFITCSOPRspQryExchangeInfoField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPQryCommission)(DFITCSOPRspQryCommissionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPQryDeposit)(DFITCSOPRspQryDepositField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspSOPQryContractObjectInfo)(DFITCSOPRspQryContractObjectField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *SOPEntrustOrderRtn)(DFITCSOPEntrustOrderRtnField * pData);

	typedef int (WINAPI *SOPTradeRtn)(DFITCSOPTradeRtnField * pData);

	typedef int (WINAPI *SOPWithdrawOrderRtn)(DFITCSOPWithdrawOrderRtnField * pData);

	typedef int (WINAPI *RspFASLUserLogin)(DFITCSECRspUserLoginField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLUserLogout)(DFITCSECRspUserLogoutField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLQryAbleFinInfo)(DFITCFASLRspAbleFinInfoField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLQryAbleSloInfo)(DFITCFASLRspAbleSloInfoField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLTransferCollateral)(DFITCFASLRspTransferCollateralField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLDirectRepayment)(DFITCFASLRspDirectRepaymentField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLRepayStockTransfer)(DFITCFASLRspRepayStockTransferField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLEntrustCrdtOrder)(DFITCFASLRspEntrustCrdtOrderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLEntrustOrder)(DFITCFASLRspEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLCalcAbleEntrustCrdtQty)(DFITCFASLRspCalcAbleEntrustCrdtQtyField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLQryCrdtFunds)(DFITCFASLRspQryCrdtFundsField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLQryCrdtContract)(DFITCFASLRspQryCrdtContractField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLat);

	typedef int (WINAPI *RspFASLQryCrdtConChangeInfo)(DFITCFASLRspQryCrdtConChangeInfoField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLTransferFunds)(DFITCStockRspTransferFundsField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLQryAccountInfo)(DFITCStockRspQryAccountField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLQryCapitalAccountInfo)(DFITCStockRspQryCapitalAccountField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLQryShareholderInfo)(DFITCStockRspQryShareholderField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLQryPosition)(DFITCStockRspQryPositionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLQryEntrustOrder)(DFITCStockRspQryEntrustOrderField * pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLQrySerialTrade)(DFITCStockRspQrySerialTradeField * pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLQryRealTimeTrade)(DFITCStockRspQryRealTimeTradeField * pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLQryFreezeFundsDetail)(DFITCStockRspQryFreezeFundsDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLQryFreezeStockDetail)(DFITCStockRspQryFreezeStockDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLQryTransferFundsDetail)(DFITCStockRspQryTransferFundsDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLWithdrawOrder)(DFITCFASLRspWithdrawOrderField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLQrySystemTime)(DFITCFASLRspQryTradeTimeField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLQryTransferredContract)(DFITCFASLRspQryTransferredContractField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLDesirableFundsOut)(DFITCFASLRspDesirableFundsOutField *pData, DFITCSECRspInfoField *pRspInfo);

	typedef int (WINAPI *RspFASLQryGuaranteedContract)(DFITCFASLRspQryGuaranteedContractField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *RspFASLQryUnderlyingContract)(DFITCFASLRspQryUnderlyingContractField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast);

	typedef int (WINAPI *FASLEntrustOrderRtn)(DFITCStockEntrustOrderRtnField *pData);

	typedef int (WINAPI *FASLTradeRtn)(DFITCStockTradeRtnField *pData);

	typedef int (WINAPI *FASLWithdrawOrderRtn)(DFITCStockWithdrawOrderRtnField *pData);


	void *_FrontConnected;


	void *_FrontDisconnected;

	void *_RtnNotice;

	void *_RspError;

	void *_RspStockUserLogin;

	void *_RspStockUserLogout;

	void *_RspStockUserPasswordUpdate;

	void *_RspStockEntrustOrder;

	void *_RspStockWithdrawOrder;

	void *_RspStockQryEntrustOrder;

	void *_RspStockQryRealTimeTrade;

	void *_RspStockQrySerialTrade;

	void *_RspStockQryPosition;

	void *_RspStockQryCapitalAccountInfo;

	void *_RspStockQryAccountInfo;

	void *_RspStockQryShareholderInfo;

	void *_RspStockTransferFunds;

	void *_RspStockEntrustBatchOrder;

	void *_RspStockWithdrawBatchOrder;

	void *_RspStockCalcAbleEntrustQty;

	void *_RspStockCalcAblePurchaseETFQty;

	void *_RspStockQryFreezeFundsDetail;

	void *_RspStockQryFreezeStockDetail;

	void *_RspStockQryTransferStockDetail;

	void *_RspStockQryTransferFundsDetail;

	void *_RspStockQryStockInfo;

	void *_RspStockQryStockStaticInfo;

	void *_RspStockQryTradeTime;

	void *_StockEntrustOrderRtn;

	void *_StockTradeRtn;

	void *_StockWithdrawOrderRtn;


	void *_RspSOPUserLogin;

	void *_RspSOPUserLogout;

	void *_RspSOPUserPasswordUpdate;

	void *_RspSOPEntrustOrder;
	void *_RspSOPGroupSplit;

	void *_RspSOPQryGroupPosition;

	void *_RspSOPLockOUnLockStock;

	void *_RspSOPWithdrawOrder;

	void *_RspSOPQryEntrustOrder;

	void *_RspSOPQrySerialTrade;

	void *_RspSOPQryPosition;

	void *_RspSOPQryCollateralPosition;

	void *_RspSOPQryCapitalAccountInfo;

	void *_RspSOPQryAccountInfo;

	void *_RspSOPQryShareholderInfo;

	void *_RspSOPCalcAbleEntrustQty;

	void *_RspSOPQryAbleLockStock;

	void *_RspSOPQryContactInfo;

	void *_RspSOPExectueOrder;

	void *_RspSOPQryExecAssiInfo;

	void *_RspSOPQryTradeTime;
	void *_RspSOPQryExchangeInfo;

	void *_RspSOPQryCommission;

	void *_RspSOPQryDeposit;

	void *_RspSOPQryContractObjectInfo;

	void *_SOPEntrustOrderRtn;

	void *_SOPTradeRtn;

	void *_SOPWithdrawOrderRtn;

	void *_RspFASLUserLogin;

	void *_RspFASLUserLogout;

	void *_RspFASLQryAbleFinInfo;

	void *_RspFASLQryAbleSloInfo;

	void *_RspFASLTransferCollateral;

	void *_RspFASLDirectRepayment;

	void *_RspFASLRepayStockTransfer;

	void *_RspFASLEntrustCrdtOrder;

	void *_RspFASLEntrustOrder;

	void *_RspFASLCalcAbleEntrustCrdtQty;

	void *_RspFASLQryCrdtFunds;

	void *_RspFASLQryCrdtContract;

	void *_RspFASLQryCrdtConChangeInfo;

	void *_RspFASLTransferFunds;

	void *_RspFASLQryAccountInfo;
	void *_RspFASLQryCapitalAccountInfo;
	void *_RspFASLQryShareholderInfo;

	void *_RspFASLQryPosition;

	void *_RspFASLQryEntrustOrder;

	void *_RspFASLQrySerialTrade;

	void *_RspFASLQryRealTimeTrade;

	void *_RspFASLQryFreezeFundsDetail;

	void *_RspFASLQryFreezeStockDetail;

	void *_RspFASLQryTransferFundsDetail;

	void *_RspFASLWithdrawOrder;

	void *_RspFASLQrySystemTime;

	void *_RspFASLQryTransferredContract;

	void *_RspFASLDesirableFundsOut;

	void *_RspFASLQryGuaranteedContract;

	void *_RspFASLQryUnderlyingContract;
	void *_FASLEntrustOrderRtn;

	void *_FASLTradeRtn;

	void *_FASLWithdrawOrderRtn;























	virtual void OnFrontConnected(){ if (_FrontConnected) ((FrontConnected)_FrontConnected)(); };

	virtual void OnFrontDisconnected(int nReason){ if (_FrontDisconnected) ((FrontDisconnected)_FrontDisconnected)(nReason); };

	virtual void OnRtnNotice(DFITCSECRspNoticeField *pNotice){ if (_RtnNotice) ((RtnNotice)_RtnNotice)(pNotice); };

	virtual void OnRspError(DFITCSECRspInfoField *pRspInfo){ if (_RspError) ((RspError)_RspError)(pRspInfo); };

	virtual void OnRspStockUserLogin(DFITCSECRspUserLoginField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockUserLogin)
		{
			if (pData)
				((RspStockUserLogin)_RspStockUserLogin)(pData, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLoginField f; memset(&f, 0, sizeof(f));
				((RspStockUserLogin)_RspStockUserLogin)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockUserLogout(DFITCSECRspUserLogoutField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockUserLogout)
		{
			if (pData)
				((RspStockUserLogout)_RspStockUserLogout)(pData, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLogoutField f; memset(&f, 0, sizeof(f));
				((RspStockUserLogout)_RspStockUserLogout)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockUserPasswordUpdate(DFITCSECRspPasswordUpdateField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockUserPasswordUpdate)
		{
			if (pData)
				((RspStockUserPasswordUpdate)_RspStockUserPasswordUpdate)(pData, repare(pRspInfo));
			else
			{
				DFITCSECRspPasswordUpdateField f; memset(&f, 0, sizeof(f));
				((RspStockUserPasswordUpdate)_RspStockUserPasswordUpdate)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockEntrustOrder(DFITCStockRspEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockEntrustOrder)
		{
			if (pData)
				((RspStockEntrustOrder)_RspStockEntrustOrder)(pData, repare(pRspInfo));
			else
			{
				DFITCStockRspEntrustOrderField f; memset(&f, 0, sizeof(f));
				((RspStockEntrustOrder)_RspStockEntrustOrder)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockWithdrawOrder(DFITCSECRspWithdrawOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockWithdrawOrder)
		{
			if (pData)
				((RspStockWithdrawOrder)_RspStockWithdrawOrder)(pData, repare(pRspInfo));
			else
			{
				DFITCSECRspWithdrawOrderField f; memset(&f, 0, sizeof(f));
				((RspStockWithdrawOrder)_RspStockWithdrawOrder)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockQryEntrustOrder(DFITCStockRspQryEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryEntrustOrder)
		{
			if (pData)
				((RspStockQryEntrustOrder)_RspStockQryEntrustOrder)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryEntrustOrderField f; memset(&f, 0, sizeof(f));
				((RspStockQryEntrustOrder)_RspStockQryEntrustOrder)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQryRealTimeTrade(DFITCStockRspQryRealTimeTradeField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryRealTimeTrade)
		{
			if (pData)
				((RspStockQryRealTimeTrade)_RspStockQryRealTimeTrade)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryRealTimeTradeField f; memset(&f, 0, sizeof(f));
				((RspStockQryRealTimeTrade)_RspStockQryRealTimeTrade)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQrySerialTrade(DFITCStockRspQrySerialTradeField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQrySerialTrade)
		{
			if (pData)
				((RspStockQrySerialTrade)_RspStockQrySerialTrade)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQrySerialTradeField f; memset(&f, 0, sizeof(f));
				((RspStockQrySerialTrade)_RspStockQrySerialTrade)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQryPosition(DFITCStockRspQryPositionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryPosition)
		{
			if (pData)
				((RspStockQryPosition)_RspStockQryPosition)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryPositionField f; memset(&f, 0, sizeof(f));
				((RspStockQryPosition)_RspStockQryPosition)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQryCapitalAccountInfo(DFITCStockRspQryCapitalAccountField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryCapitalAccountInfo)
		{
			if (pData)
				((RspStockQryCapitalAccountInfo)_RspStockQryCapitalAccountInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryCapitalAccountField f; memset(&f, 0, sizeof(f));
				((RspStockQryCapitalAccountInfo)_RspStockQryCapitalAccountInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQryAccountInfo(DFITCStockRspQryAccountField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockQryAccountInfo)
		{
			if (pData)
				((RspStockQryAccountInfo)_RspStockQryAccountInfo)(pData, repare(pRspInfo));
			else
			{
				DFITCStockRspQryAccountField f; memset(&f, 0, sizeof(f));
				((RspStockQryAccountInfo)_RspStockQryAccountInfo)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockQryShareholderInfo(DFITCStockRspQryShareholderField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryShareholderInfo)
		{
			if (pData)
				((RspStockQryShareholderInfo)_RspStockQryShareholderInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryShareholderField f; memset(&f, 0, sizeof(f));
				((RspStockQryShareholderInfo)_RspStockQryShareholderInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockTransferFunds(DFITCStockRspTransferFundsField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockTransferFunds)
		{
			if (pData)
				((RspStockTransferFunds)_RspStockTransferFunds)(pData, repare(pRspInfo));
			else
			{
				DFITCStockRspTransferFundsField f; memset(&f, 0, sizeof(f));
				((RspStockTransferFunds)_RspStockTransferFunds)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockEntrustBatchOrder(DFITCStockRspEntrustBatchOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockEntrustBatchOrder)
		{
			if (pData)
				((RspStockEntrustBatchOrder)_RspStockEntrustBatchOrder)(pData, repare(pRspInfo));
			else
			{
				DFITCStockRspEntrustBatchOrderField f; memset(&f, 0, sizeof(f));
				((RspStockEntrustBatchOrder)_RspStockEntrustBatchOrder)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockWithdrawBatchOrder(DFITCStockRspWithdrawBatchOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockWithdrawBatchOrder)
		{
			if (pData)
				((RspStockWithdrawBatchOrder)_RspStockWithdrawBatchOrder)(pData, repare(pRspInfo));
			else
			{
				DFITCStockRspWithdrawBatchOrderField f; memset(&f, 0, sizeof(f));
				((RspStockWithdrawBatchOrder)_RspStockWithdrawBatchOrder)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockCalcAbleEntrustQty(DFITCStockRspCalcAbleEntrustQtyField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockCalcAbleEntrustQty)
		{
			if (pData)
				((RspStockCalcAbleEntrustQty)_RspStockCalcAbleEntrustQty)(pData, repare(pRspInfo));
			else
			{
				DFITCStockRspCalcAbleEntrustQtyField f; memset(&f, 0, sizeof(f));
				((RspStockCalcAbleEntrustQty)_RspStockCalcAbleEntrustQty)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockCalcAblePurchaseETFQty(DFITCStockRspCalcAblePurchaseETFQtyField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockCalcAblePurchaseETFQty)
		{
			if (pData)
				((RspStockCalcAblePurchaseETFQty)_RspStockCalcAblePurchaseETFQty)(pData, repare(pRspInfo));
			else
			{
				DFITCStockRspCalcAblePurchaseETFQtyField f; memset(&f, 0, sizeof(f));
				((RspStockCalcAblePurchaseETFQty)_RspStockCalcAblePurchaseETFQty)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspStockQryFreezeFundsDetail(DFITCStockRspQryFreezeFundsDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryFreezeFundsDetail)
		{
			if (pData)
				((RspStockQryFreezeFundsDetail)_RspStockQryFreezeFundsDetail)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryFreezeFundsDetailField f; memset(&f, 0, sizeof(f));
				((RspStockQryFreezeFundsDetail)_RspStockQryFreezeFundsDetail)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQryFreezeStockDetail(DFITCStockRspQryFreezeStockDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryFreezeStockDetail)
		{
			if (pData)
				((RspStockQryFreezeStockDetail)_RspStockQryFreezeStockDetail)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryFreezeStockDetailField f; memset(&f, 0, sizeof(f));
				((RspStockQryFreezeStockDetail)_RspStockQryFreezeStockDetail)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQryTransferStockDetail(DFITCStockRspQryTransferStockDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryTransferStockDetail)
		{
			if (pData)
				((RspStockQryTransferStockDetail)_RspStockQryTransferStockDetail)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryTransferStockDetailField f; memset(&f, 0, sizeof(f));
				((RspStockQryTransferStockDetail)_RspStockQryTransferStockDetail)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQryTransferFundsDetail(DFITCStockRspQryTransferFundsDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryTransferFundsDetail)
		{
			if (pData)
				((RspStockQryTransferFundsDetail)_RspStockQryTransferFundsDetail)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryTransferFundsDetailField f; memset(&f, 0, sizeof(f));
				((RspStockQryTransferFundsDetail)_RspStockQryTransferFundsDetail)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQryStockInfo(DFITCStockRspQryStockField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryStockInfo)
		{
			if (pData)
				((RspStockQryStockInfo)_RspStockQryStockInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryStockField f; memset(&f, 0, sizeof(f));
				((RspStockQryStockInfo)_RspStockQryStockInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQryStockStaticInfo(DFITCStockRspQryStockStaticField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspStockQryStockStaticInfo)
		{
			if (pData)
				((RspStockQryStockStaticInfo)_RspStockQryStockStaticInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryStockStaticField f; memset(&f, 0, sizeof(f));
				((RspStockQryStockStaticInfo)_RspStockQryStockStaticInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspStockQryTradeTime(DFITCStockRspQryTradeTimeField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockQryTradeTime)
		{
			if (pData)
				((RspStockQryTradeTime)_RspStockQryTradeTime)(pData, repare(pRspInfo));
			else
			{
				DFITCStockRspQryTradeTimeField f; memset(&f, 0, sizeof(f));
				((RspStockQryTradeTime)_RspStockQryTradeTime)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnStockEntrustOrderRtn(DFITCStockEntrustOrderRtnField * pData)
	{
		if (_StockEntrustOrderRtn) ((StockEntrustOrderRtn)_StockEntrustOrderRtn)(pData);
	};

	virtual void OnStockTradeRtn(DFITCStockTradeRtnField * pData)
	{
		if (_StockTradeRtn) ((StockTradeRtn)_StockTradeRtn)(pData);
	};

	virtual void OnStockWithdrawOrderRtn(DFITCStockWithdrawOrderRtnField * pData)
	{
		if (_StockWithdrawOrderRtn) ((StockWithdrawOrderRtn)_StockWithdrawOrderRtn)(pData);

	};


	virtual void OnRspSOPUserLogin(DFITCSECRspUserLoginField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPUserLogin)
		{
			if (pData)
				((RspSOPUserLogin)_RspSOPUserLogin)(pData, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLoginField f; memset(&f, 0, sizeof(f));
				((RspSOPUserLogin)_RspSOPUserLogin)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspSOPUserLogout(DFITCSECRspUserLogoutField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPUserLogout)
		{
			if (pData)
				((RspSOPUserLogout)_RspSOPUserLogout)(pData, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLogoutField f; memset(&f, 0, sizeof(f));
				((RspSOPUserLogout)_RspSOPUserLogout)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspSOPUserPasswordUpdate(DFITCSECRspPasswordUpdateField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPUserPasswordUpdate)
		{
			if (pData)
				((RspSOPUserPasswordUpdate)_RspSOPUserPasswordUpdate)(pData, repare(pRspInfo));
			else
			{
				DFITCSECRspPasswordUpdateField f; memset(&f, 0, sizeof(f));
				((RspSOPUserPasswordUpdate)_RspSOPUserPasswordUpdate)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspSOPEntrustOrder(DFITCSOPRspEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPEntrustOrder)
		{
			if (pData)
				((RspSOPEntrustOrder)_RspSOPEntrustOrder)(pData, repare(pRspInfo));
			else
			{
				DFITCSOPRspEntrustOrderField f; memset(&f, 0, sizeof(f));
				((RspSOPEntrustOrder)_RspSOPEntrustOrder)(&f, repare(pRspInfo));
			}
		}
	};
	virtual void OnRspSOPGroupSplit(DFITCSOPRspEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPGroupSplit)
		{
			if (pData)
				((RspSOPGroupSplit)_RspSOPGroupSplit)(pData, repare(pRspInfo));
			else
			{
				DFITCSOPRspEntrustOrderField f; memset(&f, 0, sizeof(f));
				((RspSOPGroupSplit)_RspSOPGroupSplit)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspSOPQryGroupPosition(DFITCSOPRspQryGroupPositionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryGroupPosition)
		{
			if (pData)
				((RspSOPQryGroupPosition)_RspSOPQryGroupPosition)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryGroupPositionField f; memset(&f, 0, sizeof(f));
				((RspSOPQryGroupPosition)_RspSOPQryGroupPosition)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPLockOUnLockStock(DFITCSOPRspLockOUnLockStockField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPLockOUnLockStock)
		{
			if (pData)
				((RspSOPLockOUnLockStock)_RspSOPLockOUnLockStock)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspLockOUnLockStockField f; memset(&f, 0, sizeof(f));
				((RspSOPLockOUnLockStock)_RspSOPLockOUnLockStock)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPWithdrawOrder(DFITCSECRspWithdrawOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPWithdrawOrder)
		{
			if (pData)
				((RspSOPWithdrawOrder)_RspSOPWithdrawOrder)(pData, repare(pRspInfo));
			else
			{
				DFITCSECRspWithdrawOrderField f; memset(&f, 0, sizeof(f));
				((RspSOPWithdrawOrder)_RspSOPWithdrawOrder)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspSOPQryEntrustOrder(DFITCSOPRspQryEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryEntrustOrder)
		{
			if (pData)
				((RspSOPQryEntrustOrder)_RspSOPQryEntrustOrder)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryEntrustOrderField f; memset(&f, 0, sizeof(f));
				((RspSOPQryEntrustOrder)_RspSOPQryEntrustOrder)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPQrySerialTrade(DFITCSOPRspQrySerialTradeField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQrySerialTrade)
		{
			if (pData)
				((RspSOPQrySerialTrade)_RspSOPQrySerialTrade)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQrySerialTradeField f; memset(&f, 0, sizeof(f));
				((RspSOPQrySerialTrade)_RspSOPQrySerialTrade)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPQryPosition(DFITCSOPRspQryPositionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryPosition)
		{
			if (pData)
				((RspSOPQryPosition)_RspSOPQryPosition)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryPositionField f; memset(&f, 0, sizeof(f));
				((RspSOPQryPosition)_RspSOPQryPosition)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPQryCollateralPosition(DFITCSOPRspQryCollateralPositionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryCollateralPosition)
		{
			if (pData)
				((RspSOPQryCollateralPosition)_RspSOPQryCollateralPosition)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryCollateralPositionField f; memset(&f, 0, sizeof(f));
				((RspSOPQryCollateralPosition)_RspSOPQryCollateralPosition)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPQryCapitalAccountInfo(DFITCSOPRspQryCapitalAccountField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPQryCapitalAccountInfo)
		{
			if (pData)
				((RspSOPQryCapitalAccountInfo)_RspSOPQryCapitalAccountInfo)(pData, repare(pRspInfo));
			else
			{
				DFITCSOPRspQryCapitalAccountField f; memset(&f, 0, sizeof(f));
				((RspSOPQryCapitalAccountInfo)_RspSOPQryCapitalAccountInfo)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspSOPQryAccountInfo(DFITCSOPRspQryAccountField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPQryAccountInfo)
		{
			if (pData)
				((RspSOPQryAccountInfo)_RspSOPQryAccountInfo)(pData, repare(pRspInfo));
			else
			{
				DFITCSOPRspQryAccountField f; memset(&f, 0, sizeof(f));
				((RspSOPQryAccountInfo)_RspSOPQryAccountInfo)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspSOPQryShareholderInfo(DFITCSOPRspQryShareholderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPQryShareholderInfo)
		{
			if (pData)
				((RspSOPQryShareholderInfo)_RspSOPQryShareholderInfo)(pData, repare(pRspInfo));
			else
			{
				DFITCSOPRspQryShareholderField f; memset(&f, 0, sizeof(f));
				((RspSOPQryShareholderInfo)_RspSOPQryShareholderInfo)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspSOPCalcAbleEntrustQty(DFITCSOPRspCalcAbleEntrustQtyField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPCalcAbleEntrustQty)
		{
			if (pData)
				((RspSOPCalcAbleEntrustQty)_RspSOPCalcAbleEntrustQty)(pData, repare(pRspInfo));
			else
			{
				DFITCSOPRspCalcAbleEntrustQtyField f; memset(&f, 0, sizeof(f));
				((RspSOPCalcAbleEntrustQty)_RspSOPCalcAbleEntrustQty)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspSOPQryAbleLockStock(DFITCSOPRspQryAbleLockStockField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryAbleLockStock)
		{
			if (pData)
				((RspSOPQryAbleLockStock)_RspSOPQryAbleLockStock)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryAbleLockStockField f; memset(&f, 0, sizeof(f));
				((RspSOPQryAbleLockStock)_RspSOPQryAbleLockStock)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPQryContactInfo(DFITCSOPRspQryContactField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryContactInfo)
		{
			if (pData)
				((RspSOPQryContactInfo)_RspSOPQryContactInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryContactField f; memset(&f, 0, sizeof(f));
				((RspSOPQryContactInfo)_RspSOPQryContactInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPExectueOrder(DFITCSOPRspExectueOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPExectueOrder)
		{
			if (pData)
				((RspSOPExectueOrder)_RspSOPExectueOrder)(pData, repare(pRspInfo));
			else
			{
				DFITCSOPRspExectueOrderField f; memset(&f, 0, sizeof(f));
				((RspSOPExectueOrder)_RspSOPExectueOrder)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspSOPQryExecAssiInfo(DFITCSOPRspQryExecAssiInfoField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryExecAssiInfo)
		{
			if (pData)
				((RspSOPQryExecAssiInfo)_RspSOPQryExecAssiInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryExecAssiInfoField f; memset(&f, 0, sizeof(f));
				((RspSOPQryExecAssiInfo)_RspSOPQryExecAssiInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPQryTradeTime(DFITCSOPRspQryTradeTimeField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryTradeTime)
		{
			if (pData)
				((RspSOPQryTradeTime)_RspSOPQryTradeTime)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryTradeTimeField f; memset(&f, 0, sizeof(f));
				((RspSOPQryTradeTime)_RspSOPQryTradeTime)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPQryExchangeInfo(DFITCSOPRspQryExchangeInfoField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryExchangeInfo)
		{
			if (pData)
				((RspSOPQryExchangeInfo)_RspSOPQryExchangeInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryExchangeInfoField f; memset(&f, 0, sizeof(f));
				((RspSOPQryExchangeInfo)_RspSOPQryExchangeInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPQryCommission(DFITCSOPRspQryCommissionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryCommission)
		{
			if (pData)
				((RspSOPQryCommission)_RspSOPQryCommission)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryCommissionField f; memset(&f, 0, sizeof(f));
				((RspSOPQryCommission)_RspSOPQryCommission)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPQryDeposit(DFITCSOPRspQryDepositField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryDeposit)
		{
			if (pData)
				((RspSOPQryDeposit)_RspSOPQryDeposit)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryDepositField f; memset(&f, 0, sizeof(f));
				((RspSOPQryDeposit)_RspSOPQryDeposit)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspSOPQryContractObjectInfo(DFITCSOPRspQryContractObjectField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspSOPQryContractObjectInfo)
		{
			if (pData)
				((RspSOPQryContractObjectInfo)_RspSOPQryContractObjectInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCSOPRspQryContractObjectField f; memset(&f, 0, sizeof(f));
				((RspSOPQryContractObjectInfo)_RspSOPQryContractObjectInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnSOPEntrustOrderRtn(DFITCSOPEntrustOrderRtnField * pData)
	{
		if (_SOPEntrustOrderRtn) ((SOPEntrustOrderRtn)_SOPEntrustOrderRtn)(pData);
	};

	virtual void OnSOPTradeRtn(DFITCSOPTradeRtnField * pData)
	{
		if (_SOPTradeRtn) ((SOPTradeRtn)_SOPTradeRtn)(pData);
	};

	virtual void OnSOPWithdrawOrderRtn(DFITCSOPWithdrawOrderRtnField * pData)
	{
		if (_SOPWithdrawOrderRtn) ((SOPWithdrawOrderRtn)_SOPWithdrawOrderRtn)(pData);
	};

	virtual void OnRspFASLUserLogin(DFITCSECRspUserLoginField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLUserLogin)
		{
			if (pData)
				((RspFASLUserLogin)_RspFASLUserLogin)(pData, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLoginField f; memset(&f, 0, sizeof(f));
				((RspFASLUserLogin)_RspFASLUserLogin)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLUserLogout(DFITCSECRspUserLogoutField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLUserLogout)
		{
			if (pData)
				((RspFASLUserLogout)_RspFASLUserLogout)(pData, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLogoutField f; memset(&f, 0, sizeof(f));
				((RspFASLUserLogout)_RspFASLUserLogout)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLQryAbleFinInfo(DFITCFASLRspAbleFinInfoField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLQryAbleFinInfo)
		{
			if (pData)
				((RspFASLQryAbleFinInfo)_RspFASLQryAbleFinInfo)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspAbleFinInfoField f; memset(&f, 0, sizeof(f));
				((RspFASLQryAbleFinInfo)_RspFASLQryAbleFinInfo)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLQryAbleSloInfo(DFITCFASLRspAbleSloInfoField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryAbleSloInfo)
		{
			if (pData)
				((RspFASLQryAbleSloInfo)_RspFASLQryAbleSloInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCFASLRspAbleSloInfoField f; memset(&f, 0, sizeof(f));
				((RspFASLQryAbleSloInfo)_RspFASLQryAbleSloInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLTransferCollateral(DFITCFASLRspTransferCollateralField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLTransferCollateral)
		{
			if (pData)
				((RspFASLTransferCollateral)_RspFASLTransferCollateral)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspTransferCollateralField f; memset(&f, 0, sizeof(f));
				((RspFASLTransferCollateral)_RspFASLTransferCollateral)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLDirectRepayment(DFITCFASLRspDirectRepaymentField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLDirectRepayment)
		{
			if (pData)
				((RspFASLDirectRepayment)_RspFASLDirectRepayment)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspDirectRepaymentField f; memset(&f, 0, sizeof(f));
				((RspFASLDirectRepayment)_RspFASLDirectRepayment)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLRepayStockTransfer(DFITCFASLRspRepayStockTransferField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLRepayStockTransfer)
		{
			if (pData)
				((RspFASLRepayStockTransfer)_RspFASLRepayStockTransfer)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspRepayStockTransferField f; memset(&f, 0, sizeof(f));
				((RspFASLRepayStockTransfer)_RspFASLRepayStockTransfer)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLEntrustCrdtOrder(DFITCFASLRspEntrustCrdtOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLEntrustCrdtOrder)
		{
			if (pData)
				((RspFASLEntrustCrdtOrder)_RspFASLEntrustCrdtOrder)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspEntrustCrdtOrderField f; memset(&f, 0, sizeof(f));
				((RspFASLEntrustCrdtOrder)_RspFASLEntrustCrdtOrder)(&f, repare(pRspInfo));
			}
		}
	}
	;

	virtual void OnRspFASLEntrustOrder(DFITCFASLRspEntrustOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLEntrustOrder)
		{
			if (pData)
				((RspFASLEntrustOrder)_RspFASLEntrustOrder)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspEntrustOrderField f; memset(&f, 0, sizeof(f));
				((RspFASLEntrustOrder)_RspFASLEntrustOrder)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLCalcAbleEntrustCrdtQty(DFITCFASLRspCalcAbleEntrustCrdtQtyField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLCalcAbleEntrustCrdtQty)
		{
			if (pData)
				((RspFASLCalcAbleEntrustCrdtQty)_RspFASLCalcAbleEntrustCrdtQty)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspCalcAbleEntrustCrdtQtyField f; memset(&f, 0, sizeof(f));
				((RspFASLCalcAbleEntrustCrdtQty)_RspFASLCalcAbleEntrustCrdtQty)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLQryCrdtFunds(DFITCFASLRspQryCrdtFundsField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLQryCrdtFunds)
		{
			if (pData)
				((RspFASLQryCrdtFunds)_RspFASLQryCrdtFunds)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspQryCrdtFundsField f; memset(&f, 0, sizeof(f));
				((RspFASLQryCrdtFunds)_RspFASLQryCrdtFunds)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLQryCrdtContract(DFITCFASLRspQryCrdtContractField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryCrdtContract)
		{
			if (pData)
				((RspFASLQryCrdtContract)_RspFASLQryCrdtContract)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCFASLRspQryCrdtContractField f; memset(&f, 0, sizeof(f));
				((RspFASLQryCrdtContract)_RspFASLQryCrdtContract)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLQryCrdtConChangeInfo(DFITCFASLRspQryCrdtConChangeInfoField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryCrdtConChangeInfo)
		{
			if (pData)
				((RspFASLQryCrdtConChangeInfo)_RspFASLQryCrdtConChangeInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCFASLRspQryCrdtConChangeInfoField f; memset(&f, 0, sizeof(f));
				((RspFASLQryCrdtConChangeInfo)_RspFASLQryCrdtConChangeInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLTransferFunds(DFITCStockRspTransferFundsField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLTransferFunds)
		{
			if (pData)
				((RspFASLTransferFunds)_RspFASLTransferFunds)(pData, repare(pRspInfo));
			else
			{
				DFITCStockRspTransferFundsField f; memset(&f, 0, sizeof(f));
				((RspFASLTransferFunds)_RspFASLTransferFunds)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLQryAccountInfo(DFITCStockRspQryAccountField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLQryAccountInfo)
		{
			if (pData)
				((RspFASLQryAccountInfo)_RspFASLQryAccountInfo)(pData, repare(pRspInfo));
			else
			{
				DFITCStockRspQryAccountField f; memset(&f, 0, sizeof(f));
				((RspFASLQryAccountInfo)_RspFASLQryAccountInfo)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLQryCapitalAccountInfo(DFITCStockRspQryCapitalAccountField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryCapitalAccountInfo)
		{
			if (pData)
				((RspFASLQryCapitalAccountInfo)_RspFASLQryCapitalAccountInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryCapitalAccountField f; memset(&f, 0, sizeof(f));
				((RspFASLQryCapitalAccountInfo)_RspFASLQryCapitalAccountInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLQryShareholderInfo(DFITCStockRspQryShareholderField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryShareholderInfo)
		{
			if (pData)
				((RspFASLQryShareholderInfo)_RspFASLQryShareholderInfo)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryShareholderField f; memset(&f, 0, sizeof(f));
				((RspFASLQryShareholderInfo)_RspFASLQryShareholderInfo)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLQryPosition(DFITCStockRspQryPositionField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryPosition)
		{
			if (pData)
				((RspFASLQryPosition)_RspFASLQryPosition)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryPositionField f; memset(&f, 0, sizeof(f));
				((RspFASLQryPosition)_RspFASLQryPosition)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLQryEntrustOrder(DFITCStockRspQryEntrustOrderField * pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryEntrustOrder)
		{
			if (pData)
				((RspFASLQryEntrustOrder)_RspFASLQryEntrustOrder)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryEntrustOrderField f; memset(&f, 0, sizeof(f));
				((RspFASLQryEntrustOrder)_RspFASLQryEntrustOrder)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLQrySerialTrade(DFITCStockRspQrySerialTradeField * pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQrySerialTrade)
		{
			if (pData)
				((RspFASLQrySerialTrade)_RspFASLQrySerialTrade)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQrySerialTradeField f; memset(&f, 0, sizeof(f));
				((RspFASLQrySerialTrade)_RspFASLQrySerialTrade)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLQryRealTimeTrade(DFITCStockRspQryRealTimeTradeField * pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryRealTimeTrade)
		{
			if (pData)
				((RspFASLQryRealTimeTrade)_RspFASLQryRealTimeTrade)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryRealTimeTradeField f; memset(&f, 0, sizeof(f));
				((RspFASLQryRealTimeTrade)_RspFASLQryRealTimeTrade)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLQryFreezeFundsDetail(DFITCStockRspQryFreezeFundsDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryFreezeFundsDetail)
		{
			if (pData)
				((RspFASLQryFreezeFundsDetail)_RspFASLQryFreezeFundsDetail)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryFreezeFundsDetailField f; memset(&f, 0, sizeof(f));
				((RspFASLQryFreezeFundsDetail)_RspFASLQryFreezeFundsDetail)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLQryFreezeStockDetail(DFITCStockRspQryFreezeStockDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryFreezeStockDetail)
		{
			if (pData)
				((RspFASLQryFreezeStockDetail)_RspFASLQryFreezeStockDetail)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryFreezeStockDetailField f; memset(&f, 0, sizeof(f));
				((RspFASLQryFreezeStockDetail)_RspFASLQryFreezeStockDetail)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLQryTransferFundsDetail(DFITCStockRspQryTransferFundsDetailField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryTransferFundsDetail)
		{
			if (pData)
				((RspFASLQryTransferFundsDetail)_RspFASLQryTransferFundsDetail)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCStockRspQryTransferFundsDetailField f; memset(&f, 0, sizeof(f));
				((RspFASLQryTransferFundsDetail)_RspFASLQryTransferFundsDetail)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLWithdrawOrder(DFITCFASLRspWithdrawOrderField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLWithdrawOrder)
		{
			if (pData)
				((RspFASLWithdrawOrder)_RspFASLWithdrawOrder)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspWithdrawOrderField f; memset(&f, 0, sizeof(f));
				((RspFASLWithdrawOrder)_RspFASLWithdrawOrder)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLQrySystemTime(DFITCFASLRspQryTradeTimeField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLQrySystemTime)
		{
			if (pData)
				((RspFASLQrySystemTime)_RspFASLQrySystemTime)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspQryTradeTimeField f; memset(&f, 0, sizeof(f));
				((RspFASLQrySystemTime)_RspFASLQrySystemTime)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLQryTransferredContract(DFITCFASLRspQryTransferredContractField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryTransferredContract)
		{
			if (pData)
				((RspFASLQryTransferredContract)_RspFASLQryTransferredContract)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCFASLRspQryTransferredContractField f; memset(&f, 0, sizeof(f));
				((RspFASLQryTransferredContract)_RspFASLQryTransferredContract)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLDesirableFundsOut(DFITCFASLRspDesirableFundsOutField *pData, DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLDesirableFundsOut)
		{
			if (pData)
				((RspFASLDesirableFundsOut)_RspFASLDesirableFundsOut)(pData, repare(pRspInfo));
			else
			{
				DFITCFASLRspDesirableFundsOutField f; memset(&f, 0, sizeof(f));
				((RspFASLDesirableFundsOut)_RspFASLDesirableFundsOut)(&f, repare(pRspInfo));
			}
		}
	};

	virtual void OnRspFASLQryGuaranteedContract(DFITCFASLRspQryGuaranteedContractField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryGuaranteedContract)
		{
			if (pData)
				((RspFASLQryGuaranteedContract)_RspFASLQryGuaranteedContract)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCFASLRspQryGuaranteedContractField f; memset(&f, 0, sizeof(f));
				((RspFASLQryGuaranteedContract)_RspFASLQryGuaranteedContract)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnRspFASLQryUnderlyingContract(DFITCFASLRspQryUnderlyingContractField *pData, DFITCSECRspInfoField *pRspInfo, bool bIsLast)
	{
		if (_RspFASLQryUnderlyingContract)
		{
			if (pData)
				((RspFASLQryUnderlyingContract)_RspFASLQryUnderlyingContract)(pData, repare(pRspInfo), bIsLast);
			else
			{
				DFITCFASLRspQryUnderlyingContractField f; memset(&f, 0, sizeof(f));
				((RspFASLQryUnderlyingContract)_RspFASLQryUnderlyingContract)(&f, repare(pRspInfo), bIsLast);
			}
		}
	};

	virtual void OnFASLEntrustOrderRtn(DFITCStockEntrustOrderRtnField *pData)
	{
		if (_FASLEntrustOrderRtn) ((FASLEntrustOrderRtn)_FASLEntrustOrderRtn)(pData);
	};

	virtual void OnFASLTradeRtn(DFITCStockTradeRtnField *pData)
	{
		if (_FASLTradeRtn) ((FASLTradeRtn)_FASLTradeRtn)(pData);
	};

	virtual void OnFASLWithdrawOrderRtn(DFITCStockWithdrawOrderRtnField *pData)
	{
		if (_FASLWithdrawOrderRtn) ((FASLWithdrawOrderRtn)_FASLWithdrawOrderRtn)(pData);
	};
};
