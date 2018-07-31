using UnityEngine;

namespace MVP.UI
{
    public class UILogic : MonoBehaviour
    {
        public static UILogic singleton = null;

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

        public void FindLocalServer()
        {
            MyNetworkDiscovery.singleton.FindLocalServer();
        }
    }
}
