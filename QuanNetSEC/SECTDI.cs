using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetSEC
{
    public class SECTDI
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
        public SECTDI(string pFile)
        {
            string curPath = Environment.CurrentDirectory;
            Environment.CurrentDirectory = new FileInfo(pFile).DirectoryName;
            _handle = LoadLibrary(pFile);// Environment.CurrentDirectory + "\" + pFile);
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


    public delegate IntPtr DeleInit(IntPtr api, string pszFrontAddress, IntPtr pSpi);

    public delegate IntPtr DeleSubscribePrivateTopic(IntPtr api, RESUME_TYPE nResumeType);

	 ///
     ///STOCK-登录请求
     ///@param p:指向用户登录请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///

    public IntPtr ReqStockUserLogin(DFITCSECReqUserLoginField p)
    {
        return (Invoke(_handle, "ReqStockUserLogin", typeof(DeleReqStockUserLogin)) as DeleReqStockUserLogin)(_api, p);
    }
     public delegate IntPtr DeleReqStockUserLogin(IntPtr api,DFITCSECReqUserLoginField p) ;    
     ///
     ///STOCK-登出请求
     ///@param p:指向用户登出请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockUserLogout(DFITCSECReqUserLogoutField p)
     {
         return (Invoke(_handle, "ReqStockUserLogout", typeof(DeleReqStockUserLogout)) as DeleReqStockUserLogout)(_api, p);
     }
     public delegate IntPtr DeleReqStockUserLogout(IntPtr api,DFITCSECReqUserLogoutField p) ;
     ///
     ///STOCK-密码更新请求
     ///@param p:指向用户密码更新请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockUserPasswordUpdate(DFITCSECReqPasswordUpdateField p)
     {
         return (Invoke(_handle, "ReqStockUserPasswordUpdate", typeof(DeleReqStockUserPasswordUpdate)) as DeleReqStockUserPasswordUpdate)(_api, p);
     }
     public delegate IntPtr DeleReqStockUserPasswordUpdate(IntPtr api,DFITCSECReqPasswordUpdateField p) ;
     ///
     ///STOCK-委托请求
     ///@param p:指向用户委托请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockEntrustOrder(DFITCStockReqEntrustOrderField p)
     {
         return (Invoke(_handle, "ReqStockEntrustOrder", typeof(DeleReqStockEntrustOrder)) as DeleReqStockEntrustOrder)(_api, p);
     }
     public delegate IntPtr DeleReqStockEntrustOrder(IntPtr api,DFITCStockReqEntrustOrderField p) ;
     ///
     ///STOCK-撤单请求
     ///@param p:指向用户撤单请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockWithdrawOrder(DFITCSECReqWithdrawOrderField p)
     {
         return (Invoke(_handle, "ReqStockWithdrawOrder", typeof(DeleReqStockWithdrawOrder)) as DeleReqStockWithdrawOrder)(_api, p);
     }
     public delegate IntPtr DeleReqStockWithdrawOrder(IntPtr api,DFITCSECReqWithdrawOrderField p) ;
     ///
     ///STOCK-委托查询请求
     ///@param p:指向用户委托查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryEntrustOrder(DFITCStockReqQryEntrustOrderField p)
     {
         return (Invoke(_handle, "ReqStockQryEntrustOrder", typeof(DeleReqStockQryEntrustOrder)) as DeleReqStockQryEntrustOrder)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryEntrustOrder(IntPtr api,DFITCStockReqQryEntrustOrderField p) ;
     ///
     ///STOCK-实时成交查询请求
     ///@param p:指向用户实时成交查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryRealTimeTrade(DFITCStockReqQryRealTimeTradeField p)
     {
         return (Invoke(_handle, "ReqStockQryRealTimeTrade", typeof(DeleReqStockQryRealTimeTrade)) as DeleReqStockQryRealTimeTrade)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryRealTimeTrade(IntPtr api,DFITCStockReqQryRealTimeTradeField p) ;
     ///
     ///STOCK-分笔成交查询请求
     ///@param p:指向用户分笔成交查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQrySerialTrade(DFITCStockReqQrySerialTradeField p)
     {
         return (Invoke(_handle, "ReqStockQrySerialTrade", typeof(DeleReqStockQrySerialTrade)) as DeleReqStockQrySerialTrade)(_api, p);
     }
     public delegate IntPtr DeleReqStockQrySerialTrade(IntPtr api,DFITCStockReqQrySerialTradeField p) ;
     ///
     ///STOCK-持仓查询请求
     ///@param p:指向用户持仓查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryPosition(DFITCStockReqQryPositionField p)
     {
         return (Invoke(_handle, "ReqStockQryPosition", typeof(DeleReqStockQryPosition)) as DeleReqStockQryPosition)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryPosition(IntPtr api,DFITCStockReqQryPositionField p) ;
     ///
     ///STOCK-资金账户查询请求
     ///@param p:指向用户资金账户查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryCapitalAccountInfo(DFITCStockReqQryCapitalAccountField p)
     {
         return (Invoke(_handle, "ReqStockQryCapitalAccountInfo", typeof(DeleReqStockQryCapitalAccountInfo)) as DeleReqStockQryCapitalAccountInfo)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryCapitalAccountInfo(IntPtr api,DFITCStockReqQryCapitalAccountField p) ;
     ///
     ///STOCK-账户查询请求
     ///@param p:指向用户账户查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryAccountInfo(DFITCStockReqQryAccountField p)
     {
         return (Invoke(_handle, "ReqStockQryAccountInfo", typeof(DeleReqStockQryAccountInfo)) as DeleReqStockQryAccountInfo)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryAccountInfo(IntPtr api,DFITCStockReqQryAccountField p) ;
     ///
     ///STOCK-股东查询请求
     ///@param p:指向用户股东查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryShareholderInfo(DFITCStockReqQryShareholderField p)
     {
         return (Invoke(_handle, "ReqStockQryShareholderInfo", typeof(DeleReqStockQryShareholderInfo)) as DeleReqStockQryShareholderInfo)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryShareholderInfo(IntPtr api,DFITCStockReqQryShareholderField p) ;
     ///
     ///STOCK-调拨资金请求
     ///@param p:指向用户调拨资金请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockTransferFunds(DFITCStockReqTransferFundsField p)
     {
         return (Invoke(_handle, "ReqStockTransferFunds", typeof(DeleReqStockTransferFunds)) as DeleReqStockTransferFunds)(_api, p);
     }
     public delegate IntPtr DeleReqStockTransferFunds(IntPtr api,DFITCStockReqTransferFundsField p) ;
     ///
     ///STOCK-批量委托请求
     ///@param p:指向用户批量委托请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockEntrustBatchOrder(DFITCStockReqEntrustBatchOrderField p)
     {
         return (Invoke(_handle, "ReqStockEntrustBatchOrder", typeof(DeleReqStockEntrustBatchOrder)) as DeleReqStockEntrustBatchOrder)(_api, p);
     }
     public delegate IntPtr DeleReqStockEntrustBatchOrder(IntPtr api,DFITCStockReqEntrustBatchOrderField p) ;
     ///
     ///STOCK-批量撤单请求
     ///@param p:指向用户批量撤单请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockWithdrawBatchOrder(DFITCStockReqWithdrawBatchOrderField p)
     {
         return (Invoke(_handle, "ReqStockWithdrawBatchOrder", typeof(DeleReqStockWithdrawBatchOrder)) as DeleReqStockWithdrawBatchOrder)(_api, p);
     }
     public delegate IntPtr DeleReqStockWithdrawBatchOrder(IntPtr api,DFITCStockReqWithdrawBatchOrderField p) ;
     ///
     ///STOCK-计算可委托数量请求
     ///@param p:指向用户计算可委托数量请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockCalcAbleEntrustQty(DFITCStockReqCalcAbleEntrustQtyField p)
     {
         return (Invoke(_handle, "ReqStockCalcAbleEntrustQty", typeof(DeleReqStockCalcAbleEntrustQty)) as DeleReqStockCalcAbleEntrustQty)(_api, p);
     }
     public delegate IntPtr DeleReqStockCalcAbleEntrustQty(IntPtr api,DFITCStockReqCalcAbleEntrustQtyField p) ;
     ///
     ///STOCK-计算可申购ETF篮子数请求
     ///@param p:指向用户计算可申购ETF篮子数请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockCalcAblePurchaseETFQty(DFITCStockReqCalcAblePurchaseETFQtyField p)
     {
         return (Invoke(_handle, "ReqStockCalcAblePurchaseETFQty", typeof(DeleReqStockCalcAblePurchaseETFQty)) as DeleReqStockCalcAblePurchaseETFQty)(_api, p);
     }
     public delegate IntPtr DeleReqStockCalcAblePurchaseETFQty(IntPtr api,DFITCStockReqCalcAblePurchaseETFQtyField p) ;
     ///
     ///STOCK-冻结资金明细查询请求
     ///@param p:指向用户冻结资金明细查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryFreezeFundsDetail(DFITCStockReqQryFreezeFundsDetailField p)
     {
         return (Invoke(_handle, "ReqStockQryFreezeFundsDetail", typeof(DeleReqStockQryFreezeFundsDetail)) as DeleReqStockQryFreezeFundsDetail)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryFreezeFundsDetail(IntPtr api,DFITCStockReqQryFreezeFundsDetailField p) ;
     ///
     ///STOCK-冻结证券明细查询
     ///@param p:指向用户冻结证券明细查询结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryFreezeStockDetail(DFITCStockReqQryFreezeStockDetailField p)
     {
         return (Invoke(_handle, "ReqStockQryFreezeStockDetail", typeof(DeleReqStockQryFreezeStockDetail)) as DeleReqStockQryFreezeStockDetail)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryFreezeStockDetail(IntPtr api,DFITCStockReqQryFreezeStockDetailField p) ;
     ///
     ///STOCK-调拨资金明细查询请求
     ///@param p:指向用户调拨资金明细查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryTransferFundsDetail(DFITCStockReqQryTransferFundsDetailField p)
     {
         return (Invoke(_handle, "ReqStockQryTransferFundsDetail", typeof(DeleReqStockQryTransferFundsDetail)) as DeleReqStockQryTransferFundsDetail)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryTransferFundsDetail(IntPtr api,DFITCStockReqQryTransferFundsDetailField p) ;
     ///
     ///STOCK-调拨证券明细查询请求
     ///@param p:指向用户调拨证券明细查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryTransferStockDetail(DFITCStockReqQryTransferStockDetailField p)
     {
         return (Invoke(_handle, "ReqStockQryTransferStockDetail", typeof(DeleReqStockQryTransferStockDetail)) as DeleReqStockQryTransferStockDetail)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryTransferStockDetail(IntPtr api,DFITCStockReqQryTransferStockDetailField p) ; 
     ///
     ///STOCK-股票查询请求
     ///@param p:指向用户股票查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryStockInfo(DFITCStockReqQryStockField p)
     {
         return (Invoke(_handle, "ReqStockQryStockInfo", typeof(DeleReqStockQryStockInfo)) as DeleReqStockQryStockInfo)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryStockInfo(IntPtr api,DFITCStockReqQryStockField p) ;
     ///
     ///STOCK-股票静态信息查询请求
     ///@param p:指向用户股票静态信息查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryStockStaticInfo(DFITCStockReqQryStockStaticField p)
     {
         return (Invoke(_handle, "ReqStockQryStockStaticInfo", typeof(DeleReqStockQryStockStaticInfo)) as DeleReqStockQryStockStaticInfo)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryStockStaticInfo(IntPtr api,DFITCStockReqQryStockStaticField p) ;
     ///
     ///STOCK-交易时间查询请求
     ///@param p:指向用户交易时间查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqStockQryTradeTime(DFITCStockReqQryTradeTimeField p)
     {
         return (Invoke(_handle, "ReqStockQryTradeTime", typeof(DeleReqStockQryTradeTime)) as DeleReqStockQryTradeTime)(_api, p);
     }
     public delegate IntPtr DeleReqStockQryTradeTime(IntPtr api,DFITCStockReqQryTradeTimeField p) ;
     ///
     ///SOP-登录请求
     ///@param p:指向用户登录请求结构的地址
     ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
      ///
     public IntPtr ReqSOPUserLogin(DFITCSECReqUserLoginField p)
     {
         return (Invoke(_handle, "ReqSOPUserLogin", typeof(DeleReqSOPUserLogin)) as DeleReqSOPUserLogin)(_api, p);
     }
     public delegate IntPtr DeleReqSOPUserLogin(IntPtr api,DFITCSECReqUserLoginField p) ;
     ///
     ///SOP-登出请求
     ///@param p:指向用户登出请求结构的地址
     ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
      ///
     public IntPtr ReqSOPUserLogout(DFITCSECReqUserLogoutField p)
     {
         return (Invoke(_handle, "ReqSOPUserLogout", typeof(DeleReqSOPUserLogout)) as DeleReqSOPUserLogout)(_api, p);
     }
     public delegate IntPtr DeleReqSOPUserLogout(IntPtr api,DFITCSECReqUserLogoutField p) ;
     ///
     ///SOP-交易密码更新请求
     ///@param p:指向用户密码更新请求结构的地址
     ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
      ///
     public IntPtr ReqSOPUserPasswordUpdate(DFITCSECReqPasswordUpdateField p)
     {
         return (Invoke(_handle, "ReqSOPUserPasswordUpdate", typeof(DeleReqSOPUserPasswordUpdate)) as DeleReqSOPUserPasswordUpdate)(_api, p);
     }
     public delegate IntPtr DeleReqSOPUserPasswordUpdate(IntPtr api,DFITCSECReqPasswordUpdateField p) ;
     ///
      /// SOP-报单请求
      ///@param p:指向用户报单请求结构的地址
      ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
      public IntPtr ReqSOPEntrustOrder(DFITCSOPReqEntrustOrderField p)
      {
          return (Invoke(_handle, "ReqSOPEntrustOrder", typeof(DeleReqSOPEntrustOrder)) as DeleReqSOPEntrustOrder)(_api, p);
      }
     public delegate IntPtr DeleReqSOPEntrustOrder(IntPtr api,DFITCSOPReqEntrustOrderField p) ;    
     ///
     /// SOP-持仓组合拆分委托请求
      /// @param p:指向用户交易所持仓组合拆分委托请求结构的地址
      /// @return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
     ///
     public IntPtr ReqSOPGroupSplit(DFITCSOPReqGroupSplitField p)
    {
        return (Invoke(_handle, "ReqSOPGroupSplit", typeof(DeleReqSOPGroupSplit)) as DeleReqSOPGroupSplit)(_api, p);
    }
    public delegate IntPtr DeleReqSOPGroupSplit(IntPtr api,DFITCSOPReqGroupSplitField p) ;
    ///
    ///SOP-查询客户组合持仓明细请求
    ///@param p:指向用户查询客户组合持仓明细请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml
     ///
    public IntPtr ReqSOPQryGroupPosition(DFITCSOPReqQryGroupPositionField p)
    {
        return (Invoke(_handle, "ReqSOPQryGroupPosition", typeof(DeleReqSOPQryGroupPosition)) as DeleReqSOPQryGroupPosition)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryGroupPosition(IntPtr api,DFITCSOPReqQryGroupPositionField p) ;
    ///
    ///SOP-证券锁定解锁请求
    ///@param p:指向用户证券锁定解锁请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPLockOUnLockStock(DFITCSOPReqLockOUnLockStockField p)
    {
        return (Invoke(_handle, "ReqSOPLockOUnLockStock", typeof(DeleReqSOPLockOUnLockStock)) as DeleReqSOPLockOUnLockStock)(_api, p);
    }
    public delegate IntPtr DeleReqSOPLockOUnLockStock(IntPtr api,DFITCSOPReqLockOUnLockStockField p) ;
    ///
    ///SOP-撤单请求
    ///@param p:指向用户撤单请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPWithdrawOrder(DFITCSECReqWithdrawOrderField p)
    {
        return (Invoke(_handle, "ReqSOPWithdrawOrder", typeof(DeleReqSOPWithdrawOrder)) as DeleReqSOPWithdrawOrder)(_api, p);
    }
    public delegate IntPtr DeleReqSOPWithdrawOrder(IntPtr api,DFITCSECReqWithdrawOrderField p) ;
    ///
    ///SOP-当日委托查询请求
    ///@param p:指向用户当日委托查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryEntrustOrder(DFITCSOPReqQryEntrustOrderField p)
    {
        return (Invoke(_handle, "ReqSOPQryEntrustOrder", typeof(DeleReqSOPQryEntrustOrder)) as DeleReqSOPQryEntrustOrder)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryEntrustOrder(IntPtr api,DFITCSOPReqQryEntrustOrderField p) ;
    ///
    ///SOP-分笔成交查询请求
    ///@param p:指向用户分笔成交查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQrySerialTrade(DFITCSOPReqQrySerialTradeField p)
    {
        return (Invoke(_handle, "ReqSOPQrySerialTrade", typeof(DeleReqSOPQrySerialTrade)) as DeleReqSOPQrySerialTrade)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQrySerialTrade(IntPtr api,DFITCSOPReqQrySerialTradeField p) ;
    ///
    ///SOP-持仓查询请求
    ///@param p:指向用户持仓查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryPosition(DFITCSOPReqQryPositionField p)
    {
        return (Invoke(_handle, "ReqSOPQryPosition", typeof(DeleReqSOPQryPosition)) as DeleReqSOPQryPosition)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryPosition(IntPtr api,DFITCSOPReqQryPositionField p) ;
    ///
    ///SOP-担保物持仓查询请求
    ///@param p:指向用户担保物持仓查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryCollateralPosition(DFITCSOPReqQryCollateralPositionField p)
    {
        return (Invoke(_handle, "ReqSOPQryCollateralPosition", typeof(DeleReqSOPQryCollateralPosition)) as DeleReqSOPQryCollateralPosition)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryCollateralPosition(IntPtr api,DFITCSOPReqQryCollateralPositionField p) ;
    ///
    ///SOP-资金信息查询请求
    ///@param p:指向用户资金信息查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryCapitalAccountInfo(DFITCSOPReqQryCapitalAccountField p)
    {
        return (Invoke(_handle, "ReqSOPQryCapitalAccountInfo", typeof(DeleReqSOPQryCapitalAccountInfo)) as DeleReqSOPQryCapitalAccountInfo)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryCapitalAccountInfo(IntPtr api,DFITCSOPReqQryCapitalAccountField p) ;
    ///
    ///SOP-客户信息查询请求
    ///@param p:指向用户客户信息查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryAccountInfo(DFITCSOPReqQryAccountField p)
    {
        return (Invoke(_handle, "ReqSOPQryAccountInfo", typeof(DeleReqSOPQryAccountInfo)) as DeleReqSOPQryAccountInfo)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryAccountInfo(IntPtr api,DFITCSOPReqQryAccountField p) ;
    ///
    ///SOP-股东信息查询请求
    ///@param p:指向用户股东信息查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryShareholderInfo(DFITCSOPReqQryShareholderField p)
    {
        return (Invoke(_handle, "ReqSOPQryShareholderInfo", typeof(DeleReqSOPQryShareholderInfo)) as DeleReqSOPQryShareholderInfo)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryShareholderInfo(IntPtr api,DFITCSOPReqQryShareholderField p) ;
    ///
    ///SOP-可委托数量计算请求
    ///@param p:指向用户可委托数量计算请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPCalcAbleEntrustQty(DFITCSOPReqCalcAbleEntrustQtyField p)
    {
        return (Invoke(_handle, "ReqSOPCalcAbleEntrustQty", typeof(DeleReqSOPCalcAbleEntrustQty)) as DeleReqSOPCalcAbleEntrustQty)(_api, p);
    }
    public delegate IntPtr DeleReqSOPCalcAbleEntrustQty(IntPtr api,DFITCSOPReqCalcAbleEntrustQtyField p) ;
    ///
    ///SOP-可锁定证券数量查询请求
    ///@param p:指向用户可锁定证券数量查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryAbleLockStock(DFITCSOPReqQryAbleLockStockField p)
    {
        return (Invoke(_handle, "ReqSOPQryAbleLockStock", typeof(DeleReqSOPQryAbleLockStock)) as DeleReqSOPQryAbleLockStock)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryAbleLockStock(IntPtr api,DFITCSOPReqQryAbleLockStockField p) ;
    ///
    ///SOP-期权合约代码查询请求
    ///@param p:指向用户期权合约代码查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryContactInfo(DFITCSOPReqQryContactField p)
    {
        return (Invoke(_handle, "ReqSOPQryContactInfo", typeof(DeleReqSOPQryContactInfo)) as DeleReqSOPQryContactInfo)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryContactInfo(IntPtr api,DFITCSOPReqQryContactField p) ;
    ///
    ///SOP-行权委托请求
    ///@param p:指向用户行权委托请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPExectueOrder(DFITCSOPReqExectueOrderField p)
    {
        return (Invoke(_handle, "ReqSOPExectueOrder", typeof(DeleReqSOPExectueOrder)) as DeleReqSOPExectueOrder)(_api, p);
    }
    public delegate IntPtr DeleReqSOPExectueOrder(IntPtr api,DFITCSOPReqExectueOrderField p) ;
    ///
    ///SOP-行权指派信息查询请求
    ///@param p:指向用户行权指派信息查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryExecAssiInfo(DFITCSOPReqQryExecAssiInfoField p)
    {
        return (Invoke(_handle, "ReqSOPQryExecAssiInfo", typeof(DeleReqSOPQryExecAssiInfo)) as DeleReqSOPQryExecAssiInfo)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryExecAssiInfo(IntPtr api,DFITCSOPReqQryExecAssiInfoField p) ;
    ///
    ///SOP-交易时间查询请求
    ///@param p:指向用户交易时间查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryTradeTime(DFITCSOPReqQryTradeTimeField p)
    {
        return (Invoke(_handle, "ReqSOPQryTradeTime", typeof(DeleReqSOPQryTradeTime)) as DeleReqSOPQryTradeTime)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryTradeTime(IntPtr api,DFITCSOPReqQryTradeTimeField p) ;
    ///
    ///SOP-交易所信息查询请求
    ///@param p:指向用户交易所信息查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryExchangeInfo(DFITCSOPReqQryExchangeInfoField p)
    {
        return (Invoke(_handle, "ReqSOPQryExchangeInfo", typeof(DeleReqSOPQryExchangeInfo)) as DeleReqSOPQryExchangeInfo)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryExchangeInfo(IntPtr api,DFITCSOPReqQryExchangeInfoField p) ;
    ///
    ///SOP-手续费查询请求
    ///@param p:指向用户手续费查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryCommission(DFITCSOPReqQryCommissionField p)
    {
        return (Invoke(_handle, "ReqSOPQryCommission", typeof(DeleReqSOPQryCommission)) as DeleReqSOPQryCommission)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryCommission(IntPtr api,DFITCSOPReqQryCommissionField p) ;
    ///
    ///SOP-保证金查询请求
    ///@param p:指向用户保证金查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryDeposit(DFITCSOPReqQryDepositField p)
    {
        return (Invoke(_handle, "ReqSOPQryDeposit", typeof(DeleReqSOPQryDeposit)) as DeleReqSOPQryDeposit)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryDeposit(IntPtr api,DFITCSOPReqQryDepositField p) ;
    ///
    ///SOP-标的信息查询请求
    ///@param p:指向用户标的信息查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqSOPQryContractObjectInfo(DFITCSOPReqQryContractObjectField p)
    {
        return (Invoke(_handle, "ReqSOPQryContractObjectInfo", typeof(DeleReqSOPQryContractObjectInfo)) as DeleReqSOPQryContractObjectInfo)(_api, p);
    }
    public delegate IntPtr DeleReqSOPQryContractObjectInfo(IntPtr api,DFITCSOPReqQryContractObjectField p) ;
    ///
    ///FASL-登录请求
    ///@param p:指向用户登录请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLUserLogin(DFITCSECReqUserLoginField p)
    {
        return (Invoke(_handle, "ReqFASLUserLogin", typeof(DeleReqFASLUserLogin)) as DeleReqFASLUserLogin)(_api, p);
    }
    public delegate IntPtr DeleReqFASLUserLogin(IntPtr api,DFITCSECReqUserLoginField p) ;
    ///
    ///FASL-登出请求
    ///@param p:指向用户登出请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLUserLogout(DFITCSECReqUserLogoutField p)
    {
        return (Invoke(_handle, "ReqFASLUserLogout", typeof(DeleReqFASLUserLogout)) as DeleReqFASLUserLogout)(_api, p);
    }
    public delegate IntPtr DeleReqFASLUserLogout(IntPtr api,DFITCSECReqUserLogoutField p) ;
    ///
    ///FASL-客户可融资信息请求
    ///@param p:指向用户客户可融资信息请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryAbleFinInfo(DFITCFASLReqAbleFinInfoField p)
    {
        return (Invoke(_handle, "ReqFASLQryAbleFinInfo", typeof(DeleReqFASLQryAbleFinInfo)) as DeleReqFASLQryAbleFinInfo)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryAbleFinInfo(IntPtr api,DFITCFASLReqAbleFinInfoField p) ;
    ///
    ///FASL-客户可融券信息请求
    ///@param p:指向用户客户可融券信息请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryAbleSloInfo(DFITCFASLReqAbleSloInfoField p)
    {
        return (Invoke(_handle, "ReqFASLQryAbleSloInfo", typeof(DeleReqFASLQryAbleSloInfo)) as DeleReqFASLQryAbleSloInfo)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryAbleSloInfo(IntPtr api,DFITCFASLReqAbleSloInfoField p) ;
    ///
    ///FASL-担保物划转请求
    ///@param p:指向用户担保物划转请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLTransferCollateral(DFITCFASLReqTransferCollateralField p)
    {
        return (Invoke(_handle, "ReqFASLTransferCollateral", typeof(DeleReqFASLTransferCollateral)) as DeleReqFASLTransferCollateral)(_api, p);
    }
    public delegate IntPtr DeleReqFASLTransferCollateral(IntPtr api,DFITCFASLReqTransferCollateralField p) ;
    ///
    ///FASL-直接还款请求
    ///@param p:指向用户直接还款请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLDirectRepayment(DFITCFASLReqDirectRepaymentField p)
    {
        return (Invoke(_handle, "ReqFASLDirectRepayment", typeof(DeleReqFASLDirectRepayment)) as DeleReqFASLDirectRepayment)(_api, p);
    }
    public delegate IntPtr DeleReqFASLDirectRepayment(IntPtr api,DFITCFASLReqDirectRepaymentField p) ;
    ///
    ///FASL-还券划转请求
    ///@param p:指向用户还券划转请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLRepayStockTransfer(DFITCFASLReqRepayStockTransferField p)
    {
        return (Invoke(_handle, "ReqFASLRepayStockTransfer", typeof(DeleReqFASLRepayStockTransfer)) as DeleReqFASLRepayStockTransfer)(_api, p);
    }
    public delegate IntPtr DeleReqFASLRepayStockTransfer(IntPtr api,DFITCFASLReqRepayStockTransferField p) ;
    ///
    ///FASL-信用交易请求
    ///@param p:指向用户信用交易请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLEntrustCrdtOrder(DFITCFASLReqEntrustCrdtOrderField p)
    {
        return (Invoke(_handle, "ReqFASLEntrustCrdtOrder", typeof(DeleReqFASLEntrustCrdtOrder)) as DeleReqFASLEntrustCrdtOrder)(_api, p);
    }
    public delegate IntPtr DeleReqFASLEntrustCrdtOrder(IntPtr api,DFITCFASLReqEntrustCrdtOrderField p) ;
    ///
    ///FASL-融资融券交易请求
    ///@param p:指向用户融资融券交易请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLEntrsuctOrder(DFITCFASLReqEntrustOrderField p)
    {
        return (Invoke(_handle, "ReqFASLEntrsuctOrder", typeof(DeleReqFASLEntrsuctOrder)) as DeleReqFASLEntrsuctOrder)(_api, p);
    }
    public delegate IntPtr DeleReqFASLEntrsuctOrder(IntPtr api,DFITCFASLReqEntrustOrderField p) ;
    ///
    ///FASL-撤单请求
    ///@param p:指向用户撤单请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLWithdrawOrder(DFITCFASLReqWithdrawOrderField p)
    {
        return (Invoke(_handle, "ReqFASLWithdrawOrder", typeof(DeleReqFASLWithdrawOrder)) as DeleReqFASLWithdrawOrder)(_api, p);
    }
    public delegate IntPtr DeleReqFASLWithdrawOrder(IntPtr api,DFITCFASLReqWithdrawOrderField p) ;
    ///
    ///FASL-信用可委托数量查询请求
    ///@param p:指向用户信用可委托数量查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLCalcAbleEntrustCrdtQty(DFITCFASLReqCalcAbleEntrustCrdtQtyField p)
    {
        return (Invoke(_handle, "ReqFASLCalcAbleEntrustCrdtQty", typeof(DeleReqFASLCalcAbleEntrustCrdtQty)) as DeleReqFASLCalcAbleEntrustCrdtQty)(_api, p);
    }
    public delegate IntPtr DeleReqFASLCalcAbleEntrustCrdtQty(IntPtr api,DFITCFASLReqCalcAbleEntrustCrdtQtyField p) ;
    ///
    ///FASL-查询信用资金请求
    ///@param p:指向用户查询信用资金请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryCrdtFunds(DFITCFASLReqQryCrdtFundsField p)
    {
        return (Invoke(_handle, "ReqFASLQryCrdtFunds", typeof(DeleReqFASLQryCrdtFunds)) as DeleReqFASLQryCrdtFunds)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryCrdtFunds(IntPtr api,DFITCFASLReqQryCrdtFundsField p) ;
    ///
    ///FASL-信用合约信息请求
    ///@param p:指向用户信用合约信息请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryCrdtContract(DFITCFASLReqQryCrdtContractField p)
    {
        return (Invoke(_handle, "ReqFASLQryCrdtContract", typeof(DeleReqFASLQryCrdtContract)) as DeleReqFASLQryCrdtContract)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryCrdtContract(IntPtr api,DFITCFASLReqQryCrdtContractField p) ;
    ///
    ///FASL-信用合约变动信息查询请求
    ///@param p:指向用户信用合约变动信息查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryCrdtConChangeInfo(DFITCFASLReqQryCrdtConChangeInfoField p)
    {
        return (Invoke(_handle, "ReqFASLQryCrdtConChangeInfo", typeof(DeleReqFASLQryCrdtConChangeInfo)) as DeleReqFASLQryCrdtConChangeInfo)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryCrdtConChangeInfo(IntPtr api,DFITCFASLReqQryCrdtConChangeInfoField p) ;
    ///
    ///FASL-资金调转请求
    ///@param p:指向用户资金调转请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLTransferFunds(DFITCStockReqTransferFundsField p)
    {
        return (Invoke(_handle, "ReqFASLTransferFunds", typeof(DeleReqFASLTransferFunds)) as DeleReqFASLTransferFunds)(_api, p);
    }
    public delegate IntPtr DeleReqFASLTransferFunds(IntPtr api,DFITCStockReqTransferFundsField p) ;
    ///
    ///FASL-客户信息查询请求
    ///@param p:指向用户客户信息查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryAccountInfo(DFITCStockReqQryAccountField p)
    {
        return (Invoke(_handle, "ReqFASLQryAccountInfo", typeof(DeleReqFASLQryAccountInfo)) as DeleReqFASLQryAccountInfo)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryAccountInfo(IntPtr api,DFITCStockReqQryAccountField p) ;
    ///
    ///FASL-客户资金查询请求
    ///@param p:指向用户客户资金查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryCapitalAccountInfo(DFITCStockReqQryCapitalAccountField p)
    {
        return (Invoke(_handle, "ReqFASLQryCapitalAccountInfo", typeof(DeleReqFASLQryCapitalAccountInfo)) as DeleReqFASLQryCapitalAccountInfo)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryCapitalAccountInfo(IntPtr api,DFITCStockReqQryCapitalAccountField p) ;
    ///
    ///FASL-股东信息查询请求
    ///@param p:指向用户股东信息查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryShareholderInfo(DFITCStockReqQryShareholderField p)
    {
        return (Invoke(_handle, "ReqFASLQryShareholderInfo", typeof(DeleReqFASLQryShareholderInfo)) as DeleReqFASLQryShareholderInfo)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryShareholderInfo(IntPtr api,DFITCStockReqQryShareholderField p) ;
    ///
    ///FASL-持仓查询请求
    ///@param p:指向用户持仓查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryPosition(DFITCStockReqQryPositionField p)
    {
        return (Invoke(_handle, "ReqFASLQryPosition", typeof(DeleReqFASLQryPosition)) as DeleReqFASLQryPosition)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryPosition(IntPtr api,DFITCStockReqQryPositionField p) ;
    ///
    ///FASL-委托查询请求
    ///@param p:指向用户委托查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryEntrustOrder(DFITCStockReqQryEntrustOrderField p)
    {
        return (Invoke(_handle, "ReqFASLQryEntrustOrder", typeof(DeleReqFASLQryEntrustOrder)) as DeleReqFASLQryEntrustOrder)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryEntrustOrder(IntPtr api,DFITCStockReqQryEntrustOrderField p) ;
    ///
    ///FASL-分笔成交查询请求
    ///@param p:指向用户分笔成交查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQrySerialTrade(DFITCStockReqQrySerialTradeField p)
    {
        return (Invoke(_handle, "ReqFASLQrySerialTrade", typeof(DeleReqFASLQrySerialTrade)) as DeleReqFASLQrySerialTrade)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQrySerialTrade(IntPtr api,DFITCStockReqQrySerialTradeField p) ;
    ///
    ///FASL-实时成交查询请求
    ///@param p:指向用户实时成交查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryRealTimeTrade(DFITCStockReqQryRealTimeTradeField p)
    {
        return (Invoke(_handle, "ReqFASLQryRealTimeTrade", typeof(DeleReqFASLQryRealTimeTrade)) as DeleReqFASLQryRealTimeTrade)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryRealTimeTrade(IntPtr api,DFITCStockReqQryRealTimeTradeField p) ;
    ///
    ///FASL-资金冻结明细查询请求
    ///@param p:指向用户资金冻结明细查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryFreezeFundsDetail(DFITCStockReqQryFreezeFundsDetailField p)
    {
        return (Invoke(_handle, "ReqFASLQryFreezeFundsDetail", typeof(DeleReqFASLQryFreezeFundsDetail)) as DeleReqFASLQryFreezeFundsDetail)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryFreezeFundsDetail(IntPtr api,DFITCStockReqQryFreezeFundsDetailField p) ;
    ///
    ///FASL-证券冻结明细查询请求
    ///@param p:指向用户证券冻结明细查询请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryFreezeStockDetail(DFITCStockReqQryFreezeStockDetailField p)
    {
        return (Invoke(_handle, "ReqFASLQryFreezeStockDetail", typeof(DeleReqFASLQryFreezeStockDetail)) as DeleReqFASLQryFreezeStockDetail)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryFreezeStockDetail(IntPtr api,DFITCStockReqQryFreezeStockDetailField p) ;
    ///
    ///FASL-查询资金调拨明细请求
    ///@param p:指向用户查询资金调拨明细请求结构的地址
    ///@return 0表示请求发送成功，其他值表示请求发送失败，具体错误请对照error.xml  
     ///
    public IntPtr ReqFASLQryTransferFundsDetail(DFITCStockReqQryTransferFundsDetailField p)
    {
        return (Invoke(_handle, "ReqFASLQryTransferFundsDetail", typeof(DeleReqFASLQryTransferFundsDetail)) as DeleReqFASLQryTransferFundsDetail)(_api, p);
    }
    public delegate IntPtr DeleReqFASLQryTransferFundsDetail(IntPtr api,DFITCStockReqQryTransferFundsDetailField p) ;
    ///
     ///FASL-当前系统时间查询请求
     ///@param p:指向用户交易时间查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
    public IntPtr ReqFASLQrySystemTime(DFITCFASLReqQryTradeTimeField p)
    {
        return (Invoke(_handle, "ReqFASLQrySystemTime", typeof(DeleReqFASLQrySystemTime)) as DeleReqFASLQrySystemTime)(_api, p);
    }
     public delegate IntPtr DeleReqFASLQrySystemTime(IntPtr api,DFITCFASLReqQryTradeTimeField p) ;
    ///
     ///FASL-可转入担保证券查询请求
     ///@param p:指向可转入担保证券查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqFASLQryTransferredContract(DFITCFASLReqQryTransferredContractField p)
     {
         return (Invoke(_handle, "ReqFASLQryTransferredContract", typeof(DeleReqFASLQryTransferredContract)) as DeleReqFASLQryTransferredContract)(_api, p);
     }
     public delegate IntPtr DeleReqFASLQryTransferredContract(IntPtr api,DFITCFASLReqQryTransferredContractField p) ;
    ///
     ///FASL-客户可取资金调出请求
     ///@param p:指向客户可取资金调出请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqFASLDesirableFundsOut(DFITCFASLReqDesirableFundsOutField p)
     {
         return (Invoke(_handle, "ReqFASLDesirableFundsOut", typeof(DeleReqFASLDesirableFundsOut)) as DeleReqFASLDesirableFundsOut)(_api, p);
     }
     public delegate IntPtr DeleReqFASLDesirableFundsOut(IntPtr api,DFITCFASLReqDesirableFundsOutField p) ;
    ///
     ///FASL-担保证券查询请求
     ///@param p:指向担保证券查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqFASLQryGuaranteedContract(DFITCFASLReqQryGuaranteedContractField p)
     {
         return (Invoke(_handle, "ReqFASLQryGuaranteedContract", typeof(DeleReqFASLQryGuaranteedContract)) as DeleReqFASLQryGuaranteedContract)(_api, p);
     }
     public delegate IntPtr DeleReqFASLQryGuaranteedContract(IntPtr api,DFITCFASLReqQryGuaranteedContractField p) ;
    ///
     ///FASL-标的证券查询请求
     ///@param p:指向标的证券查询请求结构体的地址
     ///@return : 0 表示请求发送成功，非 0 表示请求发送失败，具体错误请参考error.xml
      ///
     public IntPtr ReqFASLQryUnderlyingContract(DFITCFASLReqQryUnderlyingContractField p)
     {
         return (Invoke(_handle, "ReqFASLQryUnderlyingContract", typeof(DeleReqFASLQryUnderlyingContract)) as DeleReqFASLQryUnderlyingContract)(_api, p);
     }
     public delegate IntPtr DeleReqFASLQryUnderlyingContract(IntPtr api,DFITCFASLReqQryUnderlyingContractField p) ;


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

        public IntPtr SubscribePrivateTopic( RESUME_TYPE nResumeType)
        { 
            return (Invoke(_handle, "SubscribePrivateTopic", typeof(DeleSubscribePrivateTopic)) as DeleSubscribePrivateTopic)(_api,nResumeType);
        }
    


        #endregion
        delegate void DeleSet(IntPtr spi, Delegate func);

  

        
     // /
     // SEC-网络连接正常响应
     ///
    public delegate void DeleOnFrontConnected();
        public void SetOnFrontConnected(DeleOnFrontConnected func) { (Invoke(_handle, "SetOnFrontConnected", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    //  SEC-网络连接不正常响应
    // /
    public delegate void DeleOnFrontDisconnected(int nReason) ;
        public void SetOnFrontDisconnected(DeleOnFrontDisconnected func) { (Invoke(_handle, "SetOnFrontDisconnected", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    //  SEC-消息通知
    // /
    public delegate void DeleOnRtnNotice(ref DFITCSECRspNoticeField pNotice) ;
    public void SetOnRtnNotice(DeleOnRtnNotice func) { (Invoke(_handle, "SetOnRtnNotice", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // ERR-错误应答
    // @param pRspInfo:指针若非空，返回错误信息结构地址
    ///
    public delegate void DeleOnRspError(ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspError(DeleOnRspError func) { (Invoke(_handle, "SetOnRspError", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-登录响应
    // @param pData:指针若非空,返回用户登录响应信息结构体的地址,表明登录请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明登录请求失败
    ///
    public delegate void DeleOnRspStockUserLogin(ref DFITCSECRspUserLoginField pData, ref DFITCSECRspInfoField pRspInfo) ;
        public void SetOnRspStockUserLogin(DeleOnRspStockUserLogin func) { (Invoke(_handle, "SetOnRspStockUserLogin", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-登出响应
    // @param pData:指针若非空,返回用户登出响应信息结构体的地址,表明登出请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明登出请求失败
    ///
    public delegate void DeleOnRspStockUserLogout(ref DFITCSECRspUserLogoutField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspStockUserLogout(DeleOnRspStockUserLogout func) { (Invoke(_handle, "SetOnRspStockUserLogout", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-密码更新响应
    // @param pData:指针若非空,返回用户密码更新响应信息结构体的地址,表明密码更新请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明密码更新请求失败
    ///
    public delegate void DeleOnRspStockUserPasswordUpdate(ref DFITCSECRspPasswordUpdateField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspStockUserPasswordUpdate(DeleOnRspStockUserPasswordUpdate func) { (Invoke(_handle, "SetOnRspStockUserPasswordUpdate", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-委托报单响应
    // @param pData:指针若非空,返回用户委托报单响应信息结构体的地址,表明报单请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明委托报单请求失败
    ///
    public delegate void DeleOnRspStockEntrustOrder(ref DFITCStockRspEntrustOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
        public void SetOnRspStockEntrustOrder(DeleOnRspStockEntrustOrder func) { (Invoke(_handle, "SetOnRspStockEntrustOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-委托撤单响应
    // @param pData:指针若非空,返回用户委托撤单响应信息结构体的地址,表明撤单请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明委托撤单请求失败
    ///
    public delegate void DeleOnRspStockWithdrawOrder(ref DFITCSECRspWithdrawOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
        public void SetOnRspStockWithdrawOrder(DeleOnRspStockWithdrawOrder func) { (Invoke(_handle, "SetOnRspStockWithdrawOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-委托查询响应
    // @param pData:指针若非空,返回用户委托查询响应信息结构体的地址,表明查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明委托查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQryEntrustOrder(ref DFITCStockRspQryEntrustOrderField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspStockQryEntrustOrder(DeleOnRspStockQryEntrustOrder func) { (Invoke(_handle, "SetOnRspStockQryEntrustOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-实时成交查询响应
    // @param pData:指针若非空,返回用户实时成交查询响应信息结构体的地址,表明实时成交查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明实时成交查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQryRealTimeTrade(ref DFITCStockRspQryRealTimeTradeField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspStockQryRealTimeTrade(DeleOnRspStockQryRealTimeTrade func) { (Invoke(_handle, "SetOnRspStockQryRealTimeTrade", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-分笔成交查询响应
    // @param pData:指针若非空,返回用户分笔成交查询响应信息结构体的地址,表明分笔成交查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明分笔成交查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQrySerialTrade(ref DFITCStockRspQrySerialTradeField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspStockQrySerialTrade(DeleOnRspStockQrySerialTrade func) { (Invoke(_handle, "SetOnRspStockQrySerialTrade", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-持仓查询响应
    // @param pData:指针若非空,返回用户持仓查询响应信息结构体的地址,表明持仓查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明持仓查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
         public delegate void DeleOnRspStockQryPosition(ref DFITCStockRspQryPositionField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast);
         public void SetOnRspStockQryPosition(DeleOnRspStockQryPosition func) { (Invoke(_handle, "SetOnRspStockQryPosition", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-资金账号查询响应
    // @param pData:指针若非空,返回用户资金账号查询响应信息结构体的地址,表明资金账号查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明资金账号查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQryCapitalAccountInfo(ref DFITCStockRspQryCapitalAccountField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspStockQryCapitalAccountInfo(DeleOnRspStockQryCapitalAccountInfo func) { (Invoke(_handle, "SetOnRspStockQryCapitalAccountInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-交易账号查询响应
    // @param pData:指针若非空,返回用户交易账号查询响应信息结构体的地址,表明交易账号查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明交易账号查询请求失败
    ///
    public delegate void DeleOnRspStockQryAccountInfo(ref DFITCStockRspQryAccountField pData, ref DFITCSECRspInfoField pRspInfo) ; 
         public void SetOnRspStockQryAccountInfo(DeleOnRspStockQryAccountInfo func) { (Invoke(_handle, "SetOnRspStockQryAccountInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-股东号查询响应
    // @param pData:指针若非空,返回用户股东号查询响应信息结构体的地址,表明股东号查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明股东号查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQryShareholderInfo(ref DFITCStockRspQryShareholderField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ; 
          public void SetOnRspStockQryShareholderInfo(DeleOnRspStockQryShareholderInfo func) { (Invoke(_handle, "SetOnRspStockQryShareholderInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-资金调拨响应
    // @param pData:指针若非空,返回用户资金调拨响应信息结构体的地址,表明股资金调拨请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明资金调拨请求失败
    ///
    public delegate void DeleOnRspStockTransferFunds(ref DFITCStockRspTransferFundsField pData,ref DFITCSECRspInfoField pRspInfo) ;
        public void SetOnRspStockTransferFunds(DeleOnRspStockTransferFunds func) { (Invoke(_handle, "SetOnRspStockTransferFunds", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-批量委托响应
    // @param pData:指针若非空,返回用户批量委托响应信息结构体的地址,表明批量委托请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明批量委托请求失败
    ///
    public delegate void DeleOnRspStockEntrustBatchOrder(ref DFITCStockRspEntrustBatchOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspStockEntrustBatchOrder(DeleOnRspStockEntrustBatchOrder func) { (Invoke(_handle, "SetOnRspStockEntrustBatchOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // STOCK-批量撤单响应
    // @param pData:指针若非空,返回用户批量撤单响应信息结构体的地址,表明批量撤单请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明批量撤单请求失败
    ///
    public delegate void DeleOnRspStockWithdrawBatchOrder(ref DFITCStockRspWithdrawBatchOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspStockWithdrawBatchOrder(DeleOnRspStockWithdrawBatchOrder func) { (Invoke(_handle, "SetOnRspStockWithdrawBatchOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-计算可委托数量响应
    // @param pData:指针若非空,返回用户计算可委托数量响应信息结构体的地址,表明计算可委托数量请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明计算可委托数量请求失败
    ///
    public delegate void DeleOnRspStockCalcAbleEntrustQty(ref DFITCStockRspCalcAbleEntrustQtyField pData, ref DFITCSECRspInfoField pRspInfo) ; 
          public void SetOnRspStockCalcAbleEntrustQty(DeleOnRspStockCalcAbleEntrustQty func) { (Invoke(_handle, "SetOnRspStockCalcAbleEntrustQty", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-计算申购ETF数量响应
    // @param pData:指针若非空,返回用户计算申购ETF数量响应信息结构体的地址,表明计算申购ETF数量请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明计算申购ETF数量请求失败
    ///
    public delegate void DeleOnRspStockCalcAblePurchaseETFQty(ref DFITCStockRspCalcAblePurchaseETFQtyField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspStockCalcAblePurchaseETFQty(DeleOnRspStockCalcAblePurchaseETFQty func) { (Invoke(_handle, "SetOnRspStockCalcAblePurchaseETFQty", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-冻结资金明细查询响应
    // @param pData:指针若非空,返回用户冻结资金明细查询响应信息结构体的地址,表明冻结资金明细查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明冻结资金明细查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQryFreezeFundsDetail(ref DFITCStockRspQryFreezeFundsDetailField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ; 
          public void SetOnRspStockQryFreezeFundsDetail(DeleOnRspStockQryFreezeFundsDetail func) { (Invoke(_handle, "SetOnRspStockQryFreezeFundsDetail", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-冻结证券明细查询响应
    // @param pData:指针若非空,返回用户冻结证券明细查询响应信息结构体的地址,表明冻结证券明细查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明冻结证券明细查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQryFreezeStockDetail(ref DFITCStockRspQryFreezeStockDetailField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspStockQryFreezeStockDetail(DeleOnRspStockQryFreezeStockDetail func) { (Invoke(_handle, "SetOnRspStockQryFreezeStockDetail", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-调拨证券明细查询响应
    // @param pData:指针若非空,返回用户调拨证券明细查询响应信息结构体的地址,表明调拨证券明细查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明调拨证券明细查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQryTransferStockDetail(ref DFITCStockRspQryTransferStockDetailField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspStockQryTransferStockDetail(DeleOnRspStockQryTransferStockDetail func) { (Invoke(_handle, "SetOnRspStockQryTransferStockDetail", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-调拨资金明细查询响应
    // @param pData:指针若非空,返回用户调拨资金明细查询响应信息结构体的地址,表明调拨资金明细查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明调拨资金明细查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQryTransferFundsDetail(ref DFITCStockRspQryTransferFundsDetailField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspStockQryTransferFundsDetail(DeleOnRspStockQryTransferFundsDetail func) { (Invoke(_handle, "SetOnRspStockQryTransferFundsDetail", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-证券信息查询响应
    // @param pData:指针若非空,返回用户证券信息查询响应信息结构体的地址,表明证券信息查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明证券信息查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQryStockInfo(ref DFITCStockRspQryStockField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspStockQryStockInfo(DeleOnRspStockQryStockInfo func) { (Invoke(_handle, "SetOnRspStockQryStockInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-证券静态信息查询响应
    // @param pData:指针若非空,返回用户证券静态信息查询响应信息结构体的地址,表明证券静态信息查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明证券静态信息查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspStockQryStockStaticInfo(ref DFITCStockRspQryStockStaticField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspStockQryStockStaticInfo(DeleOnRspStockQryStockStaticInfo func) { (Invoke(_handle, "SetOnRspStockQryStockStaticInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-交易时间查询响应
    // @param pData:指针若非空,返回用户交易时间查询响应信息结构体的地址,表明交易时间查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息结构体的地址，表明交易时间查询请求失败
    ///
    public delegate void DeleOnRspStockQryTradeTime(ref DFITCStockRspQryTradeTimeField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspStockQryTradeTime(DeleOnRspStockQryTradeTime func) { (Invoke(_handle, "SetOnRspStockQryTradeTime", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-委托回报响应
    // @param pData:返回委托回报结构体的地址
    ///
    public delegate void DeleOnStockEntrustOrderRtn(ref DFITCStockEntrustOrderRtnField  pData);
          public void SetOnStockEntrustOrderRtn(DeleOnStockEntrustOrderRtn func) { (Invoke(_handle, "SetOnStockEntrustOrderRtn", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-成交回报响应
    // @param pData:返回成交回报结构体的地址
    ///
    public delegate void DeleOnStockTradeRtn(ref DFITCStockTradeRtnField  pData);
          public void SetOnStockTradeRtn(DeleOnStockTradeRtn func) { (Invoke(_handle, "SetOnStockTradeRtn", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // STOCK-撤单回报响应
    // @param pData:返回撤单回报结构体的地址
    ///
    public delegate void DeleOnStockWithdrawOrderRtn(ref DFITCStockWithdrawOrderRtnField  pData);
          public void SetOnStockWithdrawOrderRtn(DeleOnStockWithdrawOrderRtn func) { (Invoke(_handle, "SetOnStockWithdrawOrderRtn", typeof(DeleSet)) as DeleSet)(_spi, func); }

    
    ///
    // SOP-登录响应
    // @param pRspUserLogin:指针若非空,返回用户登录响应信息结构地址,表明登录请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明登录请求失败
    ///
    public delegate void DeleOnRspSOPUserLogin(ref DFITCSECRspUserLoginField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspSOPUserLogin(DeleOnRspSOPUserLogin func) { (Invoke(_handle, "SetOnRspSOPUserLogin", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    //  SOP-登出响应
    //  @param pData:指针若非空,返回用户登出响应信息结构地址,表明登出请求成功
    //  @param pRspInfo:指针若非空，返回错误信息地址，表明登出请求失败
    // /
    public delegate void DeleOnRspSOPUserLogout(ref DFITCSECRspUserLogoutField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspSOPUserLogout(DeleOnRspSOPUserLogout func) { (Invoke(_handle, "SetOnRspSOPUserLogout", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // SOP-用户口令更新响应
    // @param pData:指针若非空,返回用户口令更新响应信息结构地址,表明用户口令更新请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明用户口令更新请求失败
    ///
    public delegate void DeleOnRspSOPUserPasswordUpdate(ref DFITCSECRspPasswordUpdateField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspSOPUserPasswordUpdate(DeleOnRspSOPUserPasswordUpdate func) { (Invoke(_handle, "SetOnRspSOPUserPasswordUpdate", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // SOP-报单响应
    // @param pData:指针若非空,返回用户报单响应信息结构地址,表明报单请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明报单请求失败
    ///
    public delegate void DeleOnRspSOPEntrustOrder(ref DFITCSOPRspEntrustOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspSOPEntrustOrder(DeleOnRspSOPEntrustOrder func) { (Invoke(_handle, "SetOnRspSOPEntrustOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }
    ///
    // SOP-组合拆分委托响应
    // @param pData:指针若非空,返回用户响应信息结构地址,表明组合拆分委托请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明组合拆分委托请求失败
    ///
    public delegate void DeleOnRspSOPGroupSplit(ref DFITCSOPRspEntrustOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
    public void SetOnRspSOPGroupSplit(DeleOnRspSOPGroupSplit func) { (Invoke(_handle, "SetOnRspSOPGroupSplit", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // SOP-查询客户组合持仓明细响应
    // @param pData:指针若非空,返回用户查询客户组合持仓明细响应结构地址,表明查询客户组合持仓明细请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明查询客户组合持仓明细请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspSOPQryGroupPosition(ref DFITCSOPRspQryGroupPositionField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspSOPQryGroupPosition(DeleOnRspSOPQryGroupPosition func) { (Invoke(_handle, "SetOnRspSOPQryGroupPosition", typeof(DeleSet)) as DeleSet)(_spi, func); }

    
    /// SOP-证券锁定解锁响应
    /// @param pData:指针若非空,返回用户证券锁定解锁响应信息结构地址,表明证券锁定解锁请求成功
    /// @param pRspInfo:指针若非空，返回错误信息地址，表明证券锁定解锁请求失败
    /// @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspSOPLockOUnLockStock(ref DFITCSOPRspLockOUnLockStockField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspSOPLockOUnLockStock(DeleOnRspSOPLockOUnLockStock func) { (Invoke(_handle, "SetOnRspSOPLockOUnLockStock", typeof(DeleSet)) as DeleSet)(_spi, func); }
 
    ///
    // SOP-撤单响应
    // @param pData:指针若非空,返回用户撤单响应信息结构地址,表明撤单请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明撤单请求失败
    public delegate void DeleOnRspSOPWithdrawOrder(ref DFITCSECRspWithdrawOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspSOPWithdrawOrder(DeleOnRspSOPWithdrawOrder func) { (Invoke(_handle, "SetOnRspSOPWithdrawOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // SOP-委托查询响应
    // @param pData:指针若非空,返回用户委托查询响应信息结构地址,表明委托查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明委托查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspSOPQryEntrustOrder(ref DFITCSOPRspQryEntrustOrderField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspSOPQryEntrustOrder(DeleOnRspSOPQryEntrustOrder func) { (Invoke(_handle, "SetOnRspSOPQryEntrustOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // SOP-分笔成交查询响应
    // @param pData:指针若非空,返回用户分笔成交查询响应信息结构地址,表明分笔成交查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明分笔成交查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspSOPQrySerialTrade(ref DFITCSOPRspQrySerialTradeField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspSOPQrySerialTrade(DeleOnRspSOPQrySerialTrade func) { (Invoke(_handle, "SetOnRspSOPQrySerialTrade", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // SOP-持仓查询响应
    // @param pData:指针若非空,返回用户持仓查询响应信息结构地址,表明持仓查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明持仓查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspSOPQryPosition(ref DFITCSOPRspQryPositionField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspSOPQryPosition(DeleOnRspSOPQryPosition func) { (Invoke(_handle, "SetOnRspSOPQryPosition", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // SOP-客户担保持仓查询响应
    // @param pData:指针若非空,返回用户客户担保持仓查询响应信息结构地址,表明客户担保持仓查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明客户担保持仓查询请求失败
    // @param bIsLast:返回值表明是否是最后一笔响应信息(0-否,1-是)
    ///
    public delegate void DeleOnRspSOPQryCollateralPosition(ref DFITCSOPRspQryCollateralPositionField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
          public void SetOnRspSOPQryCollateralPosition(DeleOnRspSOPQryCollateralPosition func) { (Invoke(_handle, "SetOnRspSOPQryCollateralPosition", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // SOP-客户资金查询响应
    // @param pData:指针若非空,返回用户客户资金查询响应信息结构地址,表明客户客户资金查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明客户客户资金查询请求失败
    ///
    public delegate void DeleOnRspSOPQryCapitalAccountInfo(ref DFITCSOPRspQryCapitalAccountField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspSOPQryCapitalAccountInfo(DeleOnRspSOPQryCapitalAccountInfo func) { (Invoke(_handle, "SetOnRspSOPQryCapitalAccountInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // SOP-客户信息查询响应
    // @param pData:指针若非空,返回用户客户信息查询响应信息结构地址,表明客户客户信息查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明客户客户信息查询请求失败
    ///
    public delegate void DeleOnRspSOPQryAccountInfo(ref DFITCSOPRspQryAccountField pData, ref DFITCSECRspInfoField pRspInfo) ;
          public void SetOnRspSOPQryAccountInfo(DeleOnRspSOPQryAccountInfo func) { (Invoke(_handle, "SetOnRspSOPQryAccountInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    ///
    // SOP-股东信息查询响应
    // @param pData:指针若非空,返回用户股东信息查询响应信息结构地址,表明客户股东信息查询请求成功
    // @param pRspInfo:指针若非空，返回错误信息地址，表明客户股东信息查询请求失败
    ///
    public delegate void DeleOnRspSOPQryShareholderInfo(ref DFITCSOPRspQryShareholderField pData, ref DFITCSECRspInfoField pRspInfo) ; 
         public void SetOnRspSOPQryShareholderInfo(DeleOnRspSOPQryShareholderInfo func) { (Invoke(_handle, "SetOnRspSOPQryShareholderInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }
 
    public delegate void DeleOnRspSOPCalcAbleEntrustQty(ref DFITCSOPRspCalcAbleEntrustQtyField pData, ref DFITCSECRspInfoField pRspInfo) ;
                public void SetOnRspSOPCalcAbleEntrustQty(DeleOnRspSOPCalcAbleEntrustQty func) { (Invoke(_handle, "SetOnRspSOPCalcAbleEntrustQty", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspSOPQryAbleLockStock(ref DFITCSOPRspQryAbleLockStockField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ; 
                public void SetOnRspSOPQryAbleLockStock(DeleOnRspSOPQryAbleLockStock func) { (Invoke(_handle, "SetOnRspSOPQryAbleLockStock", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspSOPQryContactInfo(ref DFITCSOPRspQryContactField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ; 
                public void SetOnRspSOPQryContactInfo(DeleOnRspSOPQryContactInfo func) { (Invoke(_handle, "SetOnRspSOPQryContactInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspSOPExectueOrder(ref DFITCSOPRspExectueOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
                public void SetOnRspSOPExectueOrder(DeleOnRspSOPExectueOrder func) { (Invoke(_handle, "SetOnRspSOPExectueOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspSOPQryExecAssiInfo(ref DFITCSOPRspQryExecAssiInfoField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
                public void SetOnRspSOPQryExecAssiInfo(DeleOnRspSOPQryExecAssiInfo func) { (Invoke(_handle, "SetOnRspSOPQryExecAssiInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspSOPQryTradeTime(ref DFITCSOPRspQryTradeTimeField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
                public void SetOnRspSOPQryTradeTime(DeleOnRspSOPQryTradeTime func) { (Invoke(_handle, "SetOnRspSOPQryTradeTime", typeof(DeleSet)) as DeleSet)(_spi, func); }


    public delegate void DeleOnRspSOPQryExchangeInfo(ref DFITCSOPRspQryExchangeInfoField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
                public void SetOnRspSOPQryExchangeInfo(DeleOnRspSOPQryExchangeInfo func) { (Invoke(_handle, "SetOnRspSOPQryExchangeInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspSOPQryCommission(ref DFITCSOPRspQryCommissionField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
                public void SetOnRspSOPQryCommission(DeleOnRspSOPQryCommission func) { (Invoke(_handle, "SetOnRspSOPQryCommission", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspSOPQryDeposit(ref DFITCSOPRspQryDepositField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
                public void SetOnRspSOPQryDeposit(DeleOnRspSOPQryDeposit func) { (Invoke(_handle, "SetOnRspSOPQryDeposit", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspSOPQryContractObjectInfo(ref DFITCSOPRspQryContractObjectField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
                public void SetOnRspSOPQryContractObjectInfo(DeleOnRspSOPQryContractObjectInfo func) { (Invoke(_handle, "SetOnRspSOPQryContractObjectInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnSOPEntrustOrderRtn(ref DFITCSOPEntrustOrderRtnField  pData);
                public void SetOnSOPEntrustOrderRtn(DeleOnSOPEntrustOrderRtn func) { (Invoke(_handle, "SetOnSOPEntrustOrderRtn", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnSOPTradeRtn(ref DFITCSOPTradeRtnField  pData);
                public void SetOnSOPTradeRtn(DeleOnSOPTradeRtn func) { (Invoke(_handle, "SetOnSOPTradeRtn", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnSOPWithdrawOrderRtn(ref DFITCSOPWithdrawOrderRtnField  pData);

                public void SetOnSOPWithdrawOrderRtn(DeleOnSOPWithdrawOrderRtn func) { (Invoke(_handle, "SetOnSOPWithdrawOrderRtn", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLUserLogin(ref DFITCSECRspUserLoginField pData, ref DFITCSECRspInfoField pRspInfo) ;
             public void SetOnRspFASLUserLogin(DeleOnRspFASLUserLogin func) { (Invoke(_handle, "SetOnRspFASLUserLogin", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLUserLogout(ref DFITCSECRspUserLogoutField pData, ref DFITCSECRspInfoField pRspInfo) ;
                 public void SetOnRspFASLUserLogout(DeleOnRspFASLUserLogout func) { (Invoke(_handle, "SetOnRspFASLUserLogout", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryAbleFinInfo(ref DFITCFASLRspAbleFinInfoField pData, ref DFITCSECRspInfoField pRspInfo) ;
             public void SetOnRspFASLQryAbleFinInfo(DeleOnRspFASLQryAbleFinInfo func) { (Invoke(_handle, "SetOnRspFASLQryAbleFinInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryAbleSloInfo(ref DFITCFASLRspAbleSloInfoField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
             public void SetOnRspFASLQryAbleSloInfo(DeleOnRspFASLQryAbleSloInfo func) { (Invoke(_handle, "SetOnRspFASLQryAbleSloInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLTransferCollateral(ref DFITCFASLRspTransferCollateralField pData, ref DFITCSECRspInfoField pRspInfo) ;
             public void SetOnRspFASLTransferCollateral(DeleOnRspFASLTransferCollateral func) { (Invoke(_handle, "SetOnRspFASLTransferCollateral", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLDirectRepayment(ref DFITCFASLRspDirectRepaymentField pData, ref DFITCSECRspInfoField pRspInfo) ;
             public void SetOnRspFASLDirectRepayment(DeleOnRspFASLDirectRepayment func) { (Invoke(_handle, "SetOnRspFASLDirectRepayment", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLRepayStockTransfer(ref DFITCFASLRspRepayStockTransferField pData, ref DFITCSECRspInfoField pRspInfo) ;
           public void SetOnRspFASLRepayStockTransfer(DeleOnRspFASLRepayStockTransfer func) { (Invoke(_handle, "SetOnRspFASLRepayStockTransfer", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLEntrustCrdtOrder(ref DFITCFASLRspEntrustCrdtOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspFASLEntrustCrdtOrder(DeleOnRspFASLEntrustCrdtOrder func) { (Invoke(_handle, "SetOnRspFASLEntrustCrdtOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLEntrustOrder(ref DFITCFASLRspEntrustOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspFASLEntrustOrder(DeleOnRspFASLEntrustOrder func) { (Invoke(_handle, "SetOnRspFASLEntrustOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLCalcAbleEntrustCrdtQty(ref DFITCFASLRspCalcAbleEntrustCrdtQtyField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspFASLCalcAbleEntrustCrdtQty(DeleOnRspFASLCalcAbleEntrustCrdtQty func) { (Invoke(_handle, "SetOnRspFASLCalcAbleEntrustCrdtQty", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryCrdtFunds(ref DFITCFASLRspQryCrdtFundsField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspFASLQryCrdtFunds(DeleOnRspFASLQryCrdtFunds func) { (Invoke(_handle, "SetOnRspFASLQryCrdtFunds", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryCrdtContract(ref DFITCFASLRspQryCrdtContractField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLat) ;
         public void SetOnRspFASLQryCrdtContract(DeleOnRspFASLQryCrdtContract func) { (Invoke(_handle, "SetOnRspFASLQryCrdtContract", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryCrdtConChangeInfo(ref DFITCFASLRspQryCrdtConChangeInfoField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQryCrdtConChangeInfo(DeleOnRspFASLQryCrdtConChangeInfo func) { (Invoke(_handle, "SetOnRspFASLQryCrdtConChangeInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLTransferFunds(ref DFITCStockRspTransferFundsField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspFASLTransferFunds(DeleOnRspFASLTransferFunds func) { (Invoke(_handle, "SetOnRspFASLTransferFunds", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryAccountInfo(ref DFITCStockRspQryAccountField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspFASLQryAccountInfo(DeleOnRspFASLQryAccountInfo func) { (Invoke(_handle, "SetOnRspFASLQryAccountInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryCapitalAccountInfo(ref DFITCStockRspQryCapitalAccountField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQryCapitalAccountInfo(DeleOnRspFASLQryCapitalAccountInfo func) { (Invoke(_handle, "SetOnRspFASLQryCapitalAccountInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryShareholderInfo(ref DFITCStockRspQryShareholderField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQryShareholderInfo(DeleOnRspFASLQryShareholderInfo func) { (Invoke(_handle, "SetOnRspFASLQryShareholderInfo", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryPosition(ref DFITCStockRspQryPositionField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQryPosition(DeleOnRspFASLQryPosition func) { (Invoke(_handle, "SetOnRspFASLQryPosition", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryEntrustOrder(ref DFITCStockRspQryEntrustOrderField  pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQryEntrustOrder(DeleOnRspFASLQryEntrustOrder func) { (Invoke(_handle, "SetOnRspFASLQryEntrustOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQrySerialTrade(ref DFITCStockRspQrySerialTradeField  pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQrySerialTrade(DeleOnRspFASLQrySerialTrade func) { (Invoke(_handle, "SetOnRspFASLQrySerialTrade", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryRealTimeTrade(ref DFITCStockRspQryRealTimeTradeField  pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQryRealTimeTrade(DeleOnRspFASLQryRealTimeTrade func) { (Invoke(_handle, "SetOnRspFASLQryRealTimeTrade", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryFreezeFundsDetail(ref DFITCStockRspQryFreezeFundsDetailField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQryFreezeFundsDetail(DeleOnRspFASLQryFreezeFundsDetail func) { (Invoke(_handle, "SetOnRspFASLQryFreezeFundsDetail", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryFreezeStockDetail(ref DFITCStockRspQryFreezeStockDetailField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQryFreezeStockDetail(DeleOnRspFASLQryFreezeStockDetail func) { (Invoke(_handle, "SetOnRspFASLQryFreezeStockDetail", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryTransferFundsDetail(ref DFITCStockRspQryTransferFundsDetailField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQryTransferFundsDetail(DeleOnRspFASLQryTransferFundsDetail func) { (Invoke(_handle, "SetOnRspFASLQryTransferFundsDetail", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLWithdrawOrder(ref DFITCFASLRspWithdrawOrderField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspFASLWithdrawOrder(DeleOnRspFASLWithdrawOrder func) { (Invoke(_handle, "SetOnRspFASLWithdrawOrder", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQrySystemTime(ref DFITCFASLRspQryTradeTimeField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspFASLQrySystemTime(DeleOnRspFASLQrySystemTime func) { (Invoke(_handle, "SetOnRspFASLQrySystemTime", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryTransferredContract(ref DFITCFASLRspQryTransferredContractField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
         public void SetOnRspFASLQryTransferredContract(DeleOnRspFASLQryTransferredContract func) { (Invoke(_handle, "SetOnRspFASLQryTransferredContract", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLDesirableFundsOut(ref DFITCFASLRspDesirableFundsOutField pData, ref DFITCSECRspInfoField pRspInfo) ;
         public void SetOnRspFASLDesirableFundsOut(DeleOnRspFASLDesirableFundsOut func) { (Invoke(_handle, "SetOnRspFASLDesirableFundsOut", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryGuaranteedContract(ref DFITCFASLRspQryGuaranteedContractField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
                    public void SetOnRspFASLQryGuaranteedContract(DeleOnRspFASLQryGuaranteedContract func) { (Invoke(_handle, "SetOnRspFASLQryGuaranteedContract", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnRspFASLQryUnderlyingContract(ref DFITCFASLRspQryUnderlyingContractField pData, ref DFITCSECRspInfoField pRspInfo, bool bIsLast) ;
                public void SetOnRspFASLQryUnderlyingContract(DeleOnRspFASLQryUnderlyingContract func) { (Invoke(_handle, "SetOnRspFASLQryUnderlyingContract", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnFASLEntrustOrderRtn(ref DFITCStockEntrustOrderRtnField pData);
             public void SetOnFASLEntrustOrderRtn(DeleOnFASLEntrustOrderRtn func) { (Invoke(_handle, "SetOnFASLEntrustOrderRtn", typeof(DeleSet)) as DeleSet)(_spi, func); }

    public delegate void DeleOnFASLTradeRtn(ref DFITCStockTradeRtnField pData);
         public void SetOnFASLTradeRtn(DeleOnFASLTradeRtn func) { (Invoke(_handle, "SetOnFASLTradeRtn", typeof(DeleSet)) as DeleSet)(_spi, func); }
 
    public delegate void DeleOnFASLWithdrawOrderRtn(ref DFITCStockWithdrawOrderRtnField pData);
         public void SetOnFASLWithdrawOrderRtn(DeleOnFASLWithdrawOrderRtn func) { (Invoke(_handle, "SetOnFASLWithdrawOrderRtn", typeof(DeleSet)) as DeleSet)(_spi, func); }












    }
}

