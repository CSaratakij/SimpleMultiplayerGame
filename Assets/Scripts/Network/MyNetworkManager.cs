using UnityEngine;
using UnityEngine.Networking;

namespace MVP
{
    public class MyNetworkManager : NetworkManager
    {
        public override void OnClientConnect(NetworkConnection connection)
        {
        }

        public override void OnClientDisconnect(NetworkConnection connection)
        {
            GameController.GameStop();
        }
    }
}
