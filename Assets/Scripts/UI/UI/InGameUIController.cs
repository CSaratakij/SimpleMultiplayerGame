using UnityEngine;
using UnityEngine.Networking;

namespace MVP.UI
{
    public class InGameUIController : MonoBehaviour
    {
        public void StopConnection()
        {
            StopHost();
        }

        public void StopHost()
        {
            NetworkManager.singleton.StopHost();
            _ReturnToCreateServerMenu();
        }

        public void StopLanServer()
        {
            NetworkManager.singleton.StopServer();
            _ReturnToCreateServerMenu();
        }

        public void StopClient()
        {
            NetworkManager.singleton.StopClient();
            _ReturnToCreateServerMenu();
        }

        void _StopBroadcast()
        {
            MyNetworkDiscovery.singleton.StopFindLocalServer();
        }

        void _ReturnToCreateServerMenu()
        {
            _StopBroadcast();
            GameController.GameStop();
        }
    }
}
