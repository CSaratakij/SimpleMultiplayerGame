using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace MVP
{
    public class MyNetworkDiscovery : NetworkDiscovery
    {
        void Awake()
        {
            GameController.OnGameStart += _OnGameStart;
            GameController.OnGameStop += _OnGameStop;
        }

        void OnDestroy()
        {
            GameController.OnGameStart -= _OnGameStart;
            GameController.OnGameStop -= _OnGameStop;
        }

        void _OnGameStart()
        {
            if (running) { return; }
            if (Initialize()) {
                StartAsServer();
            }
        }

        void _OnGameStop()
        {
            if (running) {
                StopBroadcast();
            }
        }

        public void FindLocalHost()
        {
            if (running) { return; }
            StartAsClient();
        }

        public override void OnReceivedBroadcast(string fromAddress, string data)
        {
            NetworkManager.singleton.networkAddress = fromAddress;
            NetworkManager.singleton.StartClient();
        }
    }
}
