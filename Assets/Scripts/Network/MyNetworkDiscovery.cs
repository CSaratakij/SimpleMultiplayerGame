using UnityEngine;
using UnityEngine.Networking;

namespace MVP
{
    public class MyNetworkDiscovery : NetworkDiscovery
    {
        public static MyNetworkDiscovery singleton = null;

        void Awake()
        {
            if (singleton == null) {
                singleton = this;
                DontDestroyOnLoad(gameObject);
            }
            else {
                Destroy(gameObject);
            }
        }

        public override void OnReceivedBroadcast(string fromAddress, string data)
        {
            StopFindLocalServer();
            NetworkManager.singleton.networkAddress = fromAddress;
            NetworkManager.singleton.StartClient();
            GameController.GameStart();
        }

        public void BroadcastAsServer()
        {
            StopFindLocalServer();
            Initialize();
            StartAsServer();
        }

        public void FindLocalServer()
        {
            StopFindLocalServer();
            Initialize();
            StartAsClient();
        }

        public void StopFindLocalServer()
        {
            if (running) {
                StopBroadcast();
            }
        }
    }
}
