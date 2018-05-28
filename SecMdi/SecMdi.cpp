// SecMdi.cpp : 定义 DLL 应用程序的导出函数。
//




#include "SecMdi.h"
#include <string.h>

SecMdi::SecMdi(void)
{
	_FrontConnected = NULL;
	_FrontDisconnected = NULL;
	_RtnNotice = NULL;
	_RspError = NULL;
	_RspStockUserLogin = NULL;
	_RspStockUserLogout = NULL;
	_RspSOPUserLogin = NULL;
	_RspSOPUserLogout = NULL;
	_RspFASLUserLogin = NULL;
	_RspFASLUserLogout = NULL;
	_RspStockSubMarketData = NULL;
	_RspStockUnSubMarketData = NULL;
	_RspSOPSubMarketData = NULL;
	_RspSOPUnSubMarketData = NULL;
	_StockMarketData = NULL;
	_SOPMarketData = NULL;
	_RspStockAvailableQuot = NULL;
	_RspSopAvailableQuot = NULL;
	_RspUserMDPasswordUpdate = NULL;

}
DLL_EXPORT_C_DECL void WINAPI SetOnFrontConnected(SecMdi* spi, void* func){ spi->_FrontConnected = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnFrontDisconnected(SecMdi* spi, void* func){ spi->_FrontDisconnected = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRtnNotice(SecMdi* spi, void* func){ spi->_RtnNotice = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspError(SecMdi* spi, void* func){ spi->_RspError = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockUserLogin(SecMdi* spi, void* func){ spi->_RspStockUserLogin = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspStockUserLogout(SecMdi* spi, void* func){ spi->_RspStockUserLogout = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPUserLogin(SecMdi* spi, void* func){ spi->_RspSOPUserLogin = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPUserLogout(SecMdi* spi, void* func){ spi->_RspSOPUserLogout = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLUserLogin(SecMdi* spi, void* func){ spi->_RspFASLUserLogin = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspFASLUserLogout(SecMdi* spi, void* func){ spi->_RspFASLUserLogout = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockSubMarketData(SecMdi* spi, void* func){ spi->_RspStockSubMarketData = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspStockUnSubMarketData(SecMdi* spi, void* func){ spi->_RspStockUnSubMarketData = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspSOPSubMarketData(SecMdi* spi, void* func){ spi->_RspSOPSubMarketData = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnSOPMarketData(SecMdi* spi, void* func){ spi->_SOPMarketData = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnStockMarketData(SecMdi* spi, void* func){ spi->_StockMarketData = func; }

DLL_EXPORT_C_DECL void WINAPI SetOnRspStockAvailableQuot(SecMdi* spi, void* func){ spi->_RspStockAvailableQuot = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspSopAvailableQuot(SecMdi* spi, void* func){ spi->_RspSopAvailableQuot = func; }
DLL_EXPORT_C_DECL void WINAPI SetOnRspUserMDPasswordUpdate(SecMdi* spi, void* func){ spi->_RspUserMDPasswordUpdate = func; }


DLL_EXPORT_C_DECL void* WINAPI CreateApi(){ return DFITCSECMdApi::CreateDFITCMdApi("./log/"); }

DLL_EXPORT_C_DECL void* WINAPI CreateSpi(){ return new SecMdi(); }

DLL_EXPORT_C_DECL void* WINAPI Release(DFITCSECMdApi *api){ api->Release(); return 0; }
DLL_EXPORT_C_DECL void* WINAPI Init(DFITCSECMdApi *api, char *pszSvrAddr, DFITCSECMdSpi * pSpi){ api->Init(pszSvrAddr, pSpi); return 0; }
DLL_EXPORT_C_DECL void* WINAPI SubscribeStockMarketData(DFITCSECMdApi *api, char *ppInstrumentID[], int nCount, int nRequestID){ api->SubscribeStockMarketData(ppInstrumentID, nCount, nRequestID); return 0; }
DLL_EXPORT_C_DECL void* WINAPI UnSubscribeStockMarketData(DFITCSECMdApi *api, char *ppInstrumentID[], int nCount, int nRequestID){ api->UnSubscribeStockMarketData(ppInstrumentID, nCount, nRequestID); return 0; }

DLL_EXPORT_C_DECL void* WINAPI SubscribeSOPMarketData(DFITCSECMdApi *api, char *ppInstrumentID[], int nCount, int nRequestID){ api->SubscribeSOPMarketData(ppInstrumentID, nCount, nRequestID); return 0; }
DLL_EXPORT_C_DECL void* WINAPI UnSubscribeSOPMarketData(DFITCSECMdApi *api, char *ppInstrumentID[], int nCount, int nRequestID){ api->UnSubscribeSOPMarketData(ppInstrumentID, nCount, nRequestID); return 0; }

DLL_EXPORT_C_DECL void* WINAPI ReqStockUserLogin(DFITCSECMdApi *api,  DFITCSECReqUserLoginField *pReqUserLoginField){ api->ReqStockUserLogin(pReqUserLoginField); return 0; }
DLL_EXPORT_C_DECL void* WINAPI ReqStockUserLogout(DFITCSECMdApi *api,  DFITCSECReqUserLogoutField *pReqUserLogoutField){ api->ReqStockUserLogout(pReqUserLogoutField); return 0; }

DLL_EXPORT_C_DECL void* WINAPI ReqSOPUserLogin(DFITCSECMdApi *api,  DFITCSECReqUserLoginField *pReqUserLoginField){ api->ReqSOPUserLogin(pReqUserLoginField); return 0; }
DLL_EXPORT_C_DECL void* WINAPI ReqSOPUserLogout(DFITCSECMdApi *api,  DFITCSECReqUserLogoutField *pReqUserLogoutField){ api->ReqSOPUserLogout(pReqUserLogoutField); return 0; }

DLL_EXPORT_C_DECL void* WINAPI ReqFASLUserLogin(DFITCSECMdApi *api,  DFITCSECReqUserLoginField *pReqUserLoginField){ api->ReqFASLUserLogin(pReqUserLoginField); return 0; }
DLL_EXPORT_C_DECL void* WINAPI ReqFASLUserLogout(DFITCSECMdApi *api,  DFITCSECReqUserLogoutField *pReqUserLogoutField){ api->ReqFASLUserLogout(pReqUserLogoutField); return 0; }

DLL_EXPORT_C_DECL void* WINAPI ReqStockAvailableQuotQry(DFITCSECMdApi *api, DFITCReqQuotQryField *pReqQuotQryField){ api->ReqStockAvailableQuotQry(pReqQuotQryField); return 0; }
DLL_EXPORT_C_DECL void* WINAPI ReqSopAvailableQuotQry(DFITCSECMdApi *api,  DFITCReqQuotQryField *pReqQuotQryField){ api->ReqSopAvailableQuotQry(pReqQuotQryField); return 0; }

DLL_EXPORT_C_DECL void* WINAPI ReqUserMDPasswordUpdate(DFITCSECMdApi *api,  DFITCSECReqMDPasswordUpdateField *pReqMDPasswordUpdate){ api->ReqUserMDPasswordUpdate(pReqMDPasswordUpdate); return 0; }




