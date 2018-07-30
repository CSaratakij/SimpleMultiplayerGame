using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace MVP
{
    public class ClientNetworkDiscovery : NetworkDiscovery
    {
        public override void OnReceivedBroadcast(string fromAddress, string data)
        {
            NetworkManager.singleton.networkAddress = fromAddress;
            NetworkManager.singleton.StartClient();
            GameController.GameStart();
        }

        public void FindLocalServer()
        {
            if (running) { return; }
            Initialize();
            StartAsClient();
        }
    }
}
