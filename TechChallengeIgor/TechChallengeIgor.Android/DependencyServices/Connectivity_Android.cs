using Android.Content;
using Android.Net;
using TechChallengeIgor.Domain.Interfaces;

namespace TechChallengeIgor.Droid.DependencyServices
{
    public class Connectivity_Android : IConnectivityInfomation
    {
        public bool CheckConnection()
        {
            var connectivityManager = (ConnectivityManager)MainActivity.Instance.GetSystemService(Context.ConnectivityService);

            NetworkInfo netWorkInfo = connectivityManager.ActiveNetworkInfo;
            return (netWorkInfo != null) && netWorkInfo.IsConnected;
        }
    }
}