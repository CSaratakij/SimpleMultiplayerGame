using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace MVP
{
    public class ServerNetworkDiscovery : NetworkDiscovery
    {
        void Start()
        {
            if (running) { return; }
            Initialize();
            StartAsServer();
        }
    }
}
