
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
#include "../DFITC_SEC_Api_v1.6.128/windows_x64_DFITC_TEST_001/include/DFITCSECMdApi.h"
#pragma comment(lib, "../DFITC_SEC_Api_v1.6.128/windows_x64_DFITC_TEST_001/lib/DFITCSECMdApi.lib")
#else
#define WINAPI
#include "../DFITC_SEC_Api_v1.6.128/windows_x64_DFITC_TEST_001/include/DFITCSECMdApi.h"
#endif

#include <string.h>


class SecMdi : DFITCSECMdSpi
{
public:
	SecMdi(void);
	~SecMdi(void);
	//针对收到空反馈的处理
	DFITCSECRspInfoField rif;
	DFITCSECRspInfoField*repare(DFITCSECRspInfoField *pRspInfo)
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
	typedef int (WINAPI *RspError)( DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *RspStockUserLogin)( DFITCSECRspUserLoginField *pRspUserLogin,  DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *RspStockUserLogout)( DFITCSECRspUserLogoutField *pRspUsrLogout,  DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *RspSOPUserLogin)( DFITCSECRspUserLoginField *pRspUserLogin,  DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *RspSOPUserLogout)( DFITCSECRspUserLogoutField *pRspUsrLogout,  DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *RspFASLUserLogin)( DFITCSECRspUserLoginField *pRspUserLogin,  DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *RspFASLUserLogout)( DFITCSECRspUserLogoutField *pRspUsrLogout,  DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *RspStockSubMarketData)( DFITCSECSpecificInstrumentField *pSpecificInstrument,  DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *RspStockUnSubMarketData)( DFITCSECSpecificInstrumentField *pSpecificInstrument,  DFITCSECRspInfoField *pRspInfo);


	typedef int (WINAPI *RspSOPSubMarketData)( DFITCSECSpecificInstrumentField *pSpecificInstrument,  DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *RspSOPUnSubMarketData)( DFITCSECSpecificInstrumentField *pSpecificInstrument,  DFITCSECRspInfoField *pRspInfo);
	typedef int (WINAPI *StockMarketData)( DFITCStockDepthMarketDataField *pMarketDataField);
	//typedef int (WINAPI *StockMarketData)(DFITCSharedDataField pMarketDataField);
	typedef int (WINAPI *SOPMarketData)( DFITCSOPDepthMarketDataField *pMarketDataField);

	typedef int (WINAPI *RspStockAvailableQuot)( DFITCRspQuotQryField *pAvailableQuotInfo,  DFITCSECRspInfoField *pRspInfo, bool flag);
	typedef int (WINAPI *RspSopAvailableQuot)( DFITCRspQuotQryField *pAvailableQuotInfo,  DFITCSECRspInfoField *pRspInfo, bool flag);
	typedef int (WINAPI *RspUserMDPasswordUpdate)( DFITCSECRspMDPasswordUpdateField *pMDPasswordUpdate,  DFITCSECRspInfoField *pRspInfo);

	void *_FrontConnected;
	void *_FrontDisconnected;
	void *_RtnNotice;
	void *_RspError;
	void *_RspStockUserLogin;
	void *_RspStockUserLogout;
	void *_RspSOPUserLogin;
	void *_RspSOPUserLogout;
	void *_RspFASLUserLogin;
	void *_RspFASLUserLogout;
	void *_RspStockSubMarketData;
	void *_RspStockUnSubMarketData;

	void *_RspSOPSubMarketData;
	void *_RspSOPUnSubMarketData;
	void *_StockMarketData;
	void *_SOPMarketData;
	void *_RspStockAvailableQuot;
	void *_RspSopAvailableQuot;
	void *_RspUserMDPasswordUpdate;

	virtual void OnFrontConnected() { if (_FrontConnected) ((FrontConnected)_FrontConnected)(); }
	virtual void OnFrontDisconnected(int nReason) { if (_FrontDisconnected) ((FrontDisconnected)_FrontDisconnected)(nReason); }


	virtual void OnRtnNotice(DFITCSECRspNoticeField *pNotice)
	{
		if (_RtnNotice) ((RtnNotice)_RtnNotice)(pNotice);
	}


	virtual void OnStockMarketData(DFITCStockDepthMarketDataField *pMarketDataField)
	{
		if (_StockMarketData) ((StockMarketData)_StockMarketData)(pMarketDataField);
	}


	virtual void OnSOPMarketData( DFITCSOPDepthMarketDataField *pMarketDataField)
	{
		if (_SOPMarketData) ((SOPMarketData)_SOPMarketData)(pMarketDataField);
	}

	virtual void OnRspError(DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspError) ((RspError)_RspError)(pRspInfo);
	}


	virtual void OnRspStockUserLogin( DFITCSECRspUserLoginField *pRspUserLogin,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockUserLogin)
		{
			if (pRspUserLogin)
				((RspStockUserLogin)_RspStockUserLogin)(pRspUserLogin, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLoginField f; memset(&f, 0, sizeof(f));
				((RspStockUserLogin)_RspStockUserLogin)(&f, repare(pRspInfo));
			}
		}
	}

	virtual void OnRspStockUserLogout( DFITCSECRspUserLogoutField *pRspUsrLogout,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockUserLogout)
		{
			if (pRspUsrLogout)
				((RspStockUserLogout)_RspStockUserLogout)(pRspUsrLogout, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLogoutField f; memset(&f, 0, sizeof(f));
				((RspStockUserLogout)_RspStockUserLogout)(&f, repare(pRspInfo));
			}
		}
	}


	virtual void OnRspSOPUserLogin( DFITCSECRspUserLoginField *pRspUserLogin,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPUserLogin)
		{
			if (pRspUserLogin)
				((RspSOPUserLogin)_RspSOPUserLogin)(pRspUserLogin, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLoginField f; memset(&f, 0, sizeof(f));
				((RspSOPUserLogin)_RspSOPUserLogin)(&f, repare(pRspInfo));
			}
		}
	}

	virtual void OnRspSOPUserLogout( DFITCSECRspUserLogoutField *pRspUsrLogout,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPUserLogout)
		{
			if (pRspUsrLogout)
				((RspSOPUserLogout)_RspSOPUserLogout)(pRspUsrLogout, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLogoutField f; memset(&f, 0, sizeof(f));
				((RspSOPUserLogout)_RspSOPUserLogout)(&f, repare(pRspInfo));
			}
		}
	}

	virtual void OnRspFASLUserLogin( DFITCSECRspUserLoginField *pRspUserLogin,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLUserLogin)
		{
			if (pRspUserLogin)
				((RspFASLUserLogin)_RspFASLUserLogin)(pRspUserLogin, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLoginField f; memset(&f, 0, sizeof(f));
				((RspFASLUserLogin)_RspFASLUserLogin)(&f, repare(pRspInfo));
			}
		}
	}

	virtual void OnRspFASLUserLogout( DFITCSECRspUserLogoutField *pRspUsrLogout,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspFASLUserLogout)
		{
			if (pRspUsrLogout)
				((RspFASLUserLogout)_RspFASLUserLogout)(pRspUsrLogout, repare(pRspInfo));
			else
			{
				DFITCSECRspUserLogoutField f; memset(&f, 0, sizeof(f));
				((RspFASLUserLogout)_RspFASLUserLogout)(&f, repare(pRspInfo));
			}
		}
	}




	virtual void OnRspStockSubMarketData( DFITCSECSpecificInstrumentField *pSpecificInstrument,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockSubMarketData)
		{
			if (pSpecificInstrument)
				((RspStockSubMarketData)_RspStockSubMarketData)(pSpecificInstrument, repare(pRspInfo));
			else
			{
				DFITCSECSpecificInstrumentField f; memset(&f, 0, sizeof(f));
				((RspStockSubMarketData)_RspStockSubMarketData)(&f, repare(pRspInfo));
			}
		}
	}

	virtual void OnRspStockUnSubMarketData( DFITCSECSpecificInstrumentField *pSpecificInstrument,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspStockUnSubMarketData)
		{
			if (pSpecificInstrument)
				((RspStockUnSubMarketData)_RspStockUnSubMarketData)(pSpecificInstrument, repare(pRspInfo));
			else
			{
				DFITCSECSpecificInstrumentField f; memset(&f, 0, sizeof(f));
				((RspStockUnSubMarketData)_RspStockUnSubMarketData)(&f, repare(pRspInfo));
			}
		}
	}

	virtual void OnRspSOPSubMarketData( DFITCSECSpecificInstrumentField *pSpecificInstrument,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPSubMarketData)
		{
			if (pSpecificInstrument)
				((RspSOPSubMarketData)_RspSOPSubMarketData)(pSpecificInstrument, repare(pRspInfo));
			else
			{
				DFITCSECSpecificInstrumentField f; memset(&f, 0, sizeof(f));
				((RspSOPSubMarketData)_RspSOPSubMarketData)(&f, repare(pRspInfo));
			}
		}
	}

	virtual void OnRspSOPUnSubMarketData( DFITCSECSpecificInstrumentField *pSpecificInstrument,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspSOPUnSubMarketData)
		{
			if (pSpecificInstrument)
				((RspSOPUnSubMarketData)_RspSOPUnSubMarketData)(pSpecificInstrument, repare(pRspInfo));
			else
			{
				DFITCSECSpecificInstrumentField f; memset(&f, 0, sizeof(f));
				((RspSOPUnSubMarketData)_RspSOPUnSubMarketData)(&f, repare(pRspInfo));
			}
		}
	}

	virtual void OnRspUserMDPasswordUpdate( DFITCSECRspMDPasswordUpdateField *pMDPasswordUpdate,  DFITCSECRspInfoField *pRspInfo)
	{
		if (_RspUserMDPasswordUpdate)
		{
			if (pMDPasswordUpdate)
				((RspUserMDPasswordUpdate)_RspUserMDPasswordUpdate)(pMDPasswordUpdate, repare(pRspInfo));
			else
			{
				DFITCSECRspMDPasswordUpdateField f; memset(&f, 0, sizeof(f));
				((RspUserMDPasswordUpdate)_RspUserMDPasswordUpdate)(&f, repare(pRspInfo));
			}
		}
	}

	virtual void OnRspStockAvailableQuot( DFITCRspQuotQryField *pAvailableQuotInfo,  DFITCSECRspInfoField *pRspInfo, bool flag)
	{
		if (_RspStockAvailableQuot)
		{
			if (pAvailableQuotInfo)
				((RspStockAvailableQuot)_RspStockAvailableQuot)(pAvailableQuotInfo, repare(pRspInfo), flag);
			else
			{
				DFITCRspQuotQryField f; memset(&f, 0, sizeof(f));
				((RspStockAvailableQuot)_RspStockAvailableQuot)(&f, repare(pRspInfo), flag);
			}
		}
	}

	virtual void OnRspSopAvailableQuot( DFITCRspQuotQryField *pAvailableQuotInfo,  DFITCSECRspInfoField *pRspInfo, bool flag)
	{
		if (_RspSopAvailableQuot)
		{
			if (pAvailableQuotInfo)
				((RspSopAvailableQuot)_RspSopAvailableQuot)(pAvailableQuotInfo, repare(pRspInfo), flag);
			else
			{
				DFITCRspQuotQryField f; memset(&f, 0, sizeof(f));
				((RspSopAvailableQuot)_RspSopAvailableQuot)(&f, repare(pRspInfo), flag);
			}
		}
	}




};
