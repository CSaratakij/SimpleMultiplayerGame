using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace MVP.UI
{
    public class LanUIController : MonoBehaviour
    {
        [SerializeField]
        InputField input;

        public void JoinLanServer()
        {
            var isNoAddress = string.IsNullOrEmpty(input.text);
            if (isNoAddress) { return; }

            NetworkManager.singleton.networkAddress = input.text;
            NetworkManager.singleton.StartClient();

            GameController.GameStart();
        }

        public void CreateLanServer()
        {
            NetworkManager.singleton.networkAddress = "0.0.0.0";
            NetworkManager.singleton.StartHost();

            GameController.GameStart();
            MyNetworkDiscovery.singleton.BroadcastAsServer();
        }
    }
}
