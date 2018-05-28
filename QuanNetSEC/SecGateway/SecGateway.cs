using QuanNetCommon;
using QuanNetCommon.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetSEC.SecGateway
{
    public enum ConnectionStatus : byte
    {
        Disconnected = 0,
        Connecting = 1,
        Connected = 2,
        Logining = 3,
        Logined = 4,
        Logout = 5,
    }


    public class SecGateway:BaseGateway<SecMdApi, SecTdApi>
    {

        public SecGateway() 
        {
        }

        public override string gatewayName
        {
            get 
            {
                return "SEC";
            }
        }

        public override void Connect(string userID)
        {
            this.md.Connect();

        }

        public override void QryAccount()
        {
            this.td.QryAccount();
        }

        public override void SendOrder(OrderReq req)
        {
            this.td.SendOrder(req);
        }

        public override void QryPosition()
        {
            this.td.QryPosition();
        }

        public override int Subscribe(params string[] pInstrument)
        {
            return this.md.Subscribe(pInstrument);
        }

        public override void CancelOrder(CancelOrderReq req)
        {
            this.td.CancelOrder(req);
        }
    }
}

