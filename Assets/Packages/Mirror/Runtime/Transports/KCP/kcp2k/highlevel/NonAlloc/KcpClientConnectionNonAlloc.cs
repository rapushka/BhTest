// where-allocation version of KcpClientConnection.
// may not be wanted on all platforms, so it's an extra optional class.
using System.Net;
using Packages.Mirror.Runtime.Transports.KCP.kcp2k.where_allocation.Scripts;

namespace Packages.Mirror.Runtime.Transports.KCP.kcp2k.highlevel.NonAlloc
{
    public class KcpClientConnectionNonAlloc : KcpClientConnection
    {
        IPEndPointNonAlloc reusableEP;

        protected override void CreateRemoteEndPoint(IPAddress[] addresses, ushort port)
        {
            // create reusableEP with same address family as remoteEndPoint.
            // otherwise ReceiveFrom_NonAlloc couldn't use it.
            reusableEP = new IPEndPointNonAlloc(addresses[0], port);
            base.CreateRemoteEndPoint(addresses, port);
        }

        // where-allocation nonalloc recv
        protected override int ReceiveFrom(byte[] buffer) =>
            socket.ReceiveFrom_NonAlloc(buffer, reusableEP);
    }
}