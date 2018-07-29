using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.UI
{
    public class GameUIController : MonoBehaviour
    {
        public enum View
        {
            MainMenu,
            CreateGame
        }

        public static GameUIController instance = null;

        [SerializeField]
        RectTransform[] menu;

        void Awake()
        {
            if (instance == null) {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            HideAllMenu();
            Show(View.MainMenu);
        }

        public void Show(View view) {
            menu[(int)view].gameObject.SetActive(true);
        }

        public void HideAllMenu()
        {
            foreach (RectTransform rect in menu) {
                rect.gameObject.SetActive(false);
            }
        }
    }
}
