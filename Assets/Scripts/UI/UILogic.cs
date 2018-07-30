using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace MVP.UI
{
    public class UILogic : MonoBehaviour
    {
        public void GameStart()
        {
            GameController.GameStart();
        }

        public void GameStop()
        {
            GameController.GameStop();
        }

        public void StartHost()
        {
            NetworkManager.singleton.networkAddress = "0.0.0.0";
            NetworkManager.singleton.StartHost();
        }

        public void StopHost()
        {
            NetworkManager.singleton.StopHost();
        }
    }
}
