using TechChallengeIgor.Domain.Interfaces;

namespace TechChallengeIgor.Test
{
    public class ConnectivityInfomationTest : IConnectivityInfomation
    {
        /// <summary>
        /// MOCK object
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            return true;
        }
    }
}
