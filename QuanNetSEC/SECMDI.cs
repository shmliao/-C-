using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetSEC
{
    public class SECMDI
    {
        #region Dll Load /UnLoad
        /// <summary>
        /// 原型是 :HMODULE LoadLibrary(LPCTSTR lpFileName);
        /// </summary>
        /// <param name="lpFileName"> DLL 文件名 </param>
        /// <returns> 函数库模块的句柄 </returns>
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        /// <summary>
        /// 原型是 : FARPROC GetProcAddress(HMODULE hModule, LPCWSTR lpProcName);
        /// </summary>
        /// <param name="hModule"> 包含需调用函数的函数库模块的句柄 </param>
        /// <param name="lpProcName"> 调用函数的名称 </param>
        /// <returns> 函数指针 </returns>
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        /// <summary>
        /// 原型是 : BOOL FreeLibrary(HMODULE hModule);
        /// </summary>
        /// <param name="hModule"> 需释放的函数库模块的句柄 </param>
        /// <returns> 是否已释放指定的 Dll </returns>
        [DllImport("kernel32", EntryPoint = "FreeLibrary", SetLastError = true)]
        private static extern bool FreeLibrary(IntPtr hModule);

        /// <summary>
        ///
        /// </summary>
        /// <param name="pHModule"></param>
        /// <param name="lpProcName"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static Delegate Invoke(IntPtr pHModule, string lpProcName, Type t)
        {
            // 若函数库模块的句柄为空，则抛出异常
            if (pHModule == IntPtr.Zero)
            {
                throw (new Exception(" 函数库模块的句柄为空 , 请确保已进行 LoadDll 操作 !"));
            }
            // 取得函数指针
            IntPtr farProc = GetProcAddress(pHModule, lpProcName);
            // 若函数指针，则抛出异常
            if (farProc == IntPtr.Zero)
            {
                throw (new Exception(" 没有找到 :" + lpProcName + " 这个函数的入口点 "));
            }
            return Marshal.GetDelegateForFunctionPointer(farProc, t);
        }
        #endregion

        IntPtr _handle = IntPtr.Zero, _api = IntPtr.Zero, _spi = IntPtr.Zero;
        delegate IntPtr Create();
        delegate IntPtr DeleRegisterSpi(IntPtr api, IntPtr pSpi);
        public SECMDI(string pFile)
        {
            string curPath = Environment.CurrentDirectory;
            Environment.CurrentDirectory = new FileInfo(pFile).DirectoryName;
            _handle = LoadLibrary(pFile);// Environment.CurrentDirectory + "/" + pFile);
            if (_handle == IntPtr.Zero)
            {
                throw (new Exception(String.Format("没有找到:", Environment.CurrentDirectory + "\\" + pFile)));
            }
            Environment.CurrentDirectory = curPath;
            Directory.CreateDirectory("log");

            _api = (Invoke(_handle, "CreateApi", typeof(Create)) as Create)();
            _spi = (Invoke(_handle, "CreateSpi", typeof(Create)) as Create)();
        }


        #region 声明REQ函数类型
        public delegate IntPtr DeleRelease(IntPtr api);
        public delegate IntPtr DeleInit(IntPtr api, string pszSvrAddr, IntPtr pSpi);
        public delegate IntPtr DeleSubscribeStockMarketData(IntPtr api, IntPtr ppInstrumentID, int nCount, int nRequestID);
        public delegate IntPtr DeleUnSubscribeStockMarketData(IntPtr api, IntPtr ppInstrumentID, int nCount, int nRequestID);

        public delegate IntPtr DeleSubscribeSOPMarketData(IntPtr api, IntPtr ppInstrumentID, int nCount, int nRequestID);
        public delegate IntPtr DeleUnSubscribeSOPMarketData(IntPtr api, IntPtr ppInstrumentID, int nCount, int nRequestID);

        public delegate IntPtr DeleReqStockUserLogin(IntPtr api, DFITCSECReqUserLoginField pReqUserLoginField);
        public delegate IntPtr DeleReqStockUserLogout(IntPtr api, DFITCSECReqUserLogoutField pReqUserLogoutField);
        public delegate IntPtr DeleReqSOPUserLogin(IntPtr api, DFITCSECReqUserLoginField pReqUserLoginField);
        public delegate IntPtr DeleReqSOPUserLogout(IntPtr api, DFITCSECReqUserLogoutField pReqUserLogoutField);

        public delegate IntPtr DeleReqFASLUserLogin(IntPtr api, DFITCSECReqUserLoginField pReqUserLoginField);
        public delegate IntPtr DeleReqFASLUserLogout(IntPtr api, DFITCSECReqUserLogoutField pReqUserLogoutField);

        public delegate IntPtr DeleReqStockAvailableQuotQry(IntPtr api, DFITCReqQuotQryField pReqQuotQryField);
        public delegate IntPtr DeleReqSopAvailableQuotQry(IntPtr api, DFITCReqQuotQryField pReqQuotQryField);

        public delegate IntPtr DeleReqUserMDPasswordUpdate(IntPtr api, DFITCSECReqMDPasswordUpdateField pReqMDPasswordUpdate);

        #endregion
        #region REQ函数

        private int nRequestID = 0;

        public IntPtr Release()
        {
            return (Invoke(_handle, "Release", typeof(DeleRelease)) as DeleRelease)(_api);
        }

        public IntPtr Init(string pszSvrAddr)
        {
            return (Invoke(_handle, "Init", typeof(DeleInit)) as DeleInit)(_api, pszSvrAddr, _spi);
        }

        public IntPtr SubscribeStockMarketData(IntPtr ppInstrumentID, int nCount, int nRequestID)
        {
            return (Invoke(_handle, "SubscribeStockMarketData", typeof(DeleSubscribeStockMarketData)) as DeleSubscribeStockMarketData)(_api, ppInstrumentID,nCount,nRequestID);
        }

        public IntPtr UnSubscribeStockMarketData(IntPtr ppInstrumentID, int nCount, int nRequestID)
        {
            return (Invoke(_handle, "UnSubscribeStockMarketData", typeof(DeleUnSubscribeStockMarketData)) as DeleUnSubscribeStockMarketData)(_api, ppInstrumentID, nCount, nRequestID);
        }

        public IntPtr SubscribeSOPMarketData(IntPtr ppInstrumentID, int nCount, int nRequestID)
        {
            return (Invoke(_handle, "SubscribeSOPMarketData", typeof(DeleSubscribeSOPMarketData)) as DeleSubscribeSOPMarketData)(_api, ppInstrumentID, nCount, nRequestID);
        }

        public IntPtr UnSubscribeSOPMarketData(IntPtr ppInstrumentID, int nCount, int nRequestID)
        {
            return (Invoke(_handle, "UnSubscribeSOPMarketData", typeof(DeleUnSubscribeSOPMarketData)) as DeleUnSubscribeSOPMarketData)(_api, ppInstrumentID, nCount, nRequestID);
        }

        public IntPtr ReqStockUserLogin(DFITCSECReqUserLoginField pReqUserLoginField)
        {
            return (Invoke(_handle, "ReqStockUserLogin", typeof(DeleReqStockUserLogin)) as DeleReqStockUserLogin)(_api, pReqUserLoginField);
        }


        public IntPtr ReqStockUserLogout(DFITCSECReqUserLogoutField pReqUserLogoutField)
        {
            return (Invoke(_handle, "ReqStockUserLogout", typeof(DeleReqStockUserLogout)) as DeleReqStockUserLogout)(_api, pReqUserLogoutField);
        }

        public IntPtr ReqSOPUserLogin(DFITCSECReqUserLoginField pReqUserLoginField)
        {
            return (Invoke(_handle, "ReqSOPUserLogin", typeof(DeleReqSOPUserLogin)) as DeleReqSOPUserLogin)(_api, pReqUserLoginField);
        }

        public IntPtr ReqSOPUserLogout(DFITCSECReqUserLogoutField pReqUserLogoutField)
        {
            return (Invoke(_handle, "ReqSOPUserLogout", typeof(DeleReqSOPUserLogout)) as DeleReqSOPUserLogout)(_api, pReqUserLogoutField);
        }

        public IntPtr ReqFASLUserLogin(DFITCSECReqUserLoginField pReqUserLoginField)
        {
            return (Invoke(_handle, "ReqFASLUserLogin", typeof(DeleReqFASLUserLogin)) as DeleReqFASLUserLogin)(_api, pReqUserLoginField);
        }

        public IntPtr ReqFASLUserLogout(DFITCSECReqUserLogoutField pReqUserLogoutField)
        {
            return (Invoke(_handle, "ReqFASLUserLogout", typeof(DeleReqFASLUserLogout)) as DeleReqFASLUserLogout)(_api, pReqUserLogoutField);
        }

        public IntPtr ReqStockAvailableQuotQry(DFITCReqQuotQryField pReqQuotQryField)
        {
            return (Invoke(_handle, "ReqStockAvailableQuotQry", typeof(DeleReqStockAvailableQuotQry)) as DeleReqStockAvailableQuotQry)(_api, pReqQuotQryField);
        }
        public IntPtr ReqSopAvailableQuotQry(DFITCReqQuotQryField pReqQuotQryField)
        {
            return (Invoke(_handle, "ReqSopAvailableQuotQry", typeof(DeleReqSopAvailableQuotQry)) as DeleReqSopAvailableQuotQry)(_api, pReqQuotQryField);
        }


        public IntPtr ReqUserMDPasswordUpdate(DFITCSECReqMDPasswordUpdateField pReqMDPasswordUpdate)
        {
            return (Invoke(_handle, "ReqUserMDPasswordUpdate", typeof(DeleReqUserMDPasswordUpdate)) as DeleReqUserMDPasswordUpdate)(_api, pReqMDPasswordUpdate);
        }


        #endregion
        delegate void DeleSet(IntPtr spi, Delegate func);


        public delegate void DeleOnFrontConnected();
        public void SetOnFrontConnected(DeleOnFrontConnected func) { (Invoke(_handle, "SetOnFrontConnected", typeof(DeleSet)) as DeleSet)(_spi, func); }

        public delegate void DeleOnFrontDisconnected(int nReason);
        public void SetOnFrontDisconnected(DeleOnFrontDisconnected func) { (Invoke(_handle, "SetOnFrontDisconnected", typeof(DeleSet)) as DeleSet)(_spi, func); }

        /// <summary>
        /// ERR-错误应答,pRspInfo:若请求失败，返回错误信息地址
        /// </summary>
        public delegate void DeleOnRspError(ref DFITCSECRspInfoField pRspInfo);
        public void SetOnRspError(DeleOnRspError func) { (Invoke(_handle, "SetOnRspError", typeof(DeleSet)) as DeleSet)(_spi, func); }
  

        
         ///
        ///SEC-消息通知
        ///
        public delegate void DeleOnRtnNotice(ref DFITCSECRspNoticeField pNotice);
        public void SetOnRtnNotice(DeleOnRtnNotice func) { (Invoke(_handle, "SetOnRtnNotice", typeof(DeleSet)) as DeleSet)(_spi, func); }

          /// 登录响应
          ///@param pRspUserLogin:指针若非空,返回用户登录响应信息结构地址,表明登录请求成功
          ///@param pRspInfo::指针若非空，返回错误信息地址，表明登录请求失败
        public delegate void DeleOnRspStockUserLogin(ref DFITCSECRspUserLoginField pRspUserLogin, ref DFITCSECRspInfoField  pRspInfo);
        public void SetOnRspStockUserLogin(DeleOnRspStockUserLogin func) { (Invoke(_handle, "SetOnRspStockUserLogin", typeof(DeleSet)) as DeleSet)(_spi, func); }
        ///
        //  STOCK-登出响应
        //  @param pRspUsrLogout:指针若非空,返回用户登出响应信息结构地址,表明登出请求成功
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明登出请求失败
        // /
        public delegate void DeleOnRspStockUserLogout(ref DFITCSECRspUserLogoutField  pRspUsrLogout, ref DFITCSECRspInfoField  pRspInfo) ;
        public void SetOnRspStockUserLogout(DeleOnRspStockUserLogout func) { (Invoke(_handle, "SetOnRspStockUserLogout", typeof(DeleSet)) as DeleSet)(_spi, func); }
        ///
        //  SOP-登录响应
        //  @param pRspUserLogin:指针若非空,返回用户登录响应信息结构地址,表明登录请求成功
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明登录请求失败
        // /
        public delegate void DeleOnRspSOPUserLogin(ref DFITCSECRspUserLoginField  pRspUserLogin, ref DFITCSECRspInfoField  pRspInfo);
        public void SetOnRspSOPUserLogin(DeleOnRspSOPUserLogin func) { (Invoke(_handle, "SetOnRspSOPUserLogin", typeof(DeleSet)) as DeleSet)(_spi, func); }
        ///
        //  SOP-登出响应
        //  @param pRspUsrLogout:指针若非空,返回用户登出响应信息结构地址,表明登出请求成功
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明登出请求失败
        // /
       public delegate void DeleOnRspSOPUserLogout(ref DFITCSECRspUserLogoutField  pRspUsrLogout, ref DFITCSECRspInfoField  pRspInfo) ;
       public void SetOnRspSOPUserLogout(DeleOnRspSOPUserLogout func) { (Invoke(_handle, "SetOnRspSOPUserLogout", typeof(DeleSet)) as DeleSet)(_spi, func); }
        ///
        //  FASL-登录响应
        //  @param pRspUserLogin:指针若非空,返回用户登录响应信息结构地址,表明登录请求成功
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明登录请求失败
        // /
        public delegate void DeleOnRspFASLUserLogin(ref DFITCSECRspUserLoginField  pRspUserLogin, ref DFITCSECRspInfoField  pRspInfo) ;
        public void SetOnRspFASLUserLogin(DeleOnRspFASLUserLogin func) { (Invoke(_handle, "SetOnRspFASLUserLogin", typeof(DeleSet)) as DeleSet)(_spi, func); }
        ///
        //  FASL-登出响应
        //  @param pRspUsrLogout:指针若非空,返回用户登出响应信息结构地址,表明登出请求成功
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明登出请求失败
        // /
        public delegate void DeleOnRspFASLUserLogout(ref DFITCSECRspUserLogoutField  pRspUsrLogout, ref DFITCSECRspInfoField  pRspInfo) ;
        public void SetOnRspFASLUserLogout(DeleOnRspFASLUserLogout func) { (Invoke(_handle, "SetOnRspFASLUserLogout", typeof(DeleSet)) as DeleSet)(_spi, func); }
       
        ///
        //  STOCK-行情订阅响应
        //  @param pSpecificInstrument:指针若非空,返回用户指定合约行情订阅响应结构地址,表明指定合约行情订阅成功
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明指定合约行情订阅失败
        // /
        public delegate void DeleOnRspStockSubMarketData(ref DFITCSECSpecificInstrumentField  pSpecificInstrument, ref DFITCSECRspInfoField  pRspInfo) ;
        public void SetOnRspStockSubMarketData(DeleOnRspStockSubMarketData func) { (Invoke(_handle, "SetOnRspStockSubMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
        ///
        //  STOCK-取消订阅行情响应
        //  @param pSpecificInstrument:指针若非空,返回用户指定合约行情取消订阅响应结构地址,表明指定合约行情取消订阅成功
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明指定合约行情取消订阅失败
        // /
        public delegate void DeleOnRspStockUnSubMarketData(ref DFITCSECSpecificInstrumentField  pSpecificInstrument, ref DFITCSECRspInfoField  pRspInfo);
        public void SetOnRspStockUnSubMarketData(DeleOnRspStockUnSubMarketData func) { (Invoke(_handle, "SetOnRspStockUnSubMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
        ///
        //  SOP-行情订阅响应
        //  @param pSpecificInstrument:指针若非空,返回用户指定合约行情订阅响应结构地址,表明指定合约行情订阅成功
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明指定合约行情订阅失败
        // /
        public delegate void DeleOnRspSOPSubMarketData(ref DFITCSECSpecificInstrumentField  pSpecificInstrument, ref DFITCSECRspInfoField  pRspInfo);
        public void SetOnRspSOPSubMarketData(DeleOnRspSOPSubMarketData func) { (Invoke(_handle, "SetOnRspSOPSubMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
        ///
        //  SOP-取消订阅行情响应
        //  @param pSpecificInstrument:指针若非空,返回用户指定合约行情取消订阅响应结构地址,表明指定合约行情取消订阅成功
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明指定合约行情取消订阅失败
        // /
        public delegate void DeleOnRspSOPUnSubMarketData(ref DFITCSECSpecificInstrumentField  pSpecificInstrument, ref DFITCSECRspInfoField  pRspInfo) ;
        public void SetOnRspSOPUnSubMarketData(DeleOnRspSOPUnSubMarketData func) { (Invoke(_handle, "SetOnRspSOPUnSubMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }

        ///
        //  STOCK-行情推送响应
        //  @param pMarketDataField:指针若非空,返回行情推送响应结构地址
        // /
        public delegate void DeleOnStockMarketData(ref DFITCStockDepthMarketDataField  pMarketDataField) ;
        public void SetOnStockMarketData(DeleOnStockMarketData func) { (Invoke(_handle, "SetOnStockMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }
        ///
        //  SOP-行情推送响应
        //  @param pMarketDataField:指针若非空,返回行情推送响应结构地址
        // /
        public delegate void DeleOnSOPMarketData(ref DFITCSOPDepthMarketDataField  pMarketDataField) ;
        public void SetOnSOPMarketData(DeleOnSOPMarketData func) { (Invoke(_handle, "SetOnSOPMarketData", typeof(DeleSet)) as DeleSet)(_spi, func); }

        ///
        //  STOCK-可用行情响应
        //  @param pAvailableQuotInfo:指针若非空,返回可用的行情信息
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明指定合约行情取消订阅失败
        //  @param flag  为真是标示最后一条，为假时表示还有后续。
        // /
        public delegate void DeleOnRspStockAvailableQuot(ref DFITCRspQuotQryField  pAvailableQuotInfo, ref DFITCSECRspInfoField  pRspInfo,bool flag) ;
        public void SetOnRspStockAvailableQuot(DeleOnRspStockAvailableQuot func) { (Invoke(_handle, "SetOnRspStockAvailableQuot", typeof(DeleSet)) as DeleSet)(_spi, func); }

        ///
        //  SOP-可用行情响应
        //  @param pAvailableQuotInfo:指针若非空,返回可用的行情信息
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明指定合约行情取消订阅失败
        //  @param flag  为真是标示最后一条，为假时表示还有后续。
        // /
        public delegate void DeleOnRspSopAvailableQuot(ref DFITCRspQuotQryField  pAvailableQuotInfo, ref DFITCSECRspInfoField  pRspInfo,bool flag) ;
        public void SetOnRspSopAvailableQuot(DeleOnRspSopAvailableQuot func) { (Invoke(_handle, "SetOnRspSopAvailableQuot", typeof(DeleSet)) as DeleSet)(_spi, func); }
        ///
        //  密码更新请求响应
        //  @param pMDPasswordUpdate:指针若非空,返回用户行情密码响应信息结构地址,表明密码修改成功。
        //  @param pRspInfo:指针若非空，返回错误信息地址，表明密码修改失败。
        // /
        public delegate void DeleOnRspUserMDPasswordUpdate(ref DFITCSECRspMDPasswordUpdateField pMDPasswordUpdate,ref DFITCSECRspInfoField  pRspInfo);
        public void SetOnRspUserMDPasswordUpdate(DeleOnRspUserMDPasswordUpdate func) { (Invoke(_handle, "SetOnRspUserMDPasswordUpdate", typeof(DeleSet)) as DeleSet)(_spi, func); }
    }
}
