using Model.Base.Config;
using Model.Network;
using System.Net;

namespace Model.Component.Config
{
    public class InnerConfig : AConfigComponent
    {
        public IPEndPoint IPEndPoint { get; private set; }

        public string Address { get; set; }

        public override void EndInit()
        {
            this.IPEndPoint = NetworkHelper.ToIPEndPoint(this.Address);
        }
    }
}
