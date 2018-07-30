using System.Collections;
using System.Collections.Generic;
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
            NetworkManager.singleton.networkAddress = input.text;
            NetworkManager.singleton.StartClient();
        }
    }
}
