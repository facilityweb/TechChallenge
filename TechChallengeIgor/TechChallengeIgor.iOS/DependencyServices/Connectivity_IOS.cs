using Plugin.Connectivity;
using System;
using TechChallengeIgor.Domain.Interfaces;

namespace TechChallengeIgor.iOS.DependencyServices
{
    public class Connectivity_IOS : IConnectivityInfomation
    {
        /// <summary>
        /// Use Plugin.Connectivity to check Connection Network
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}