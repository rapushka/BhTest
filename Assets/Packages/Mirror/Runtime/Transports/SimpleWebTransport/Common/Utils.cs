using System.Threading;

namespace Packages.Mirror.Runtime.Transports.SimpleWebTransport.Common
{
    internal static class Utils
    {
        public static void CheckForInterupt()
        {
            // sleep in order to check for ThreadInterruptedException
            Thread.Sleep(1);
        }
    }
}
