using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace MVP.UI
{
    public class GameUIController : MonoBehaviour
    {
        public enum View
        {
            MainMenu,
            CreateGame,
            InGameMenu
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

            _SubscribeEvents();
        }

        void Update()
        {
            if (Input.GetButtonDown("Cancel")) {
                Toggle(View.InGameMenu);
            }
        }

        void OnDestroy()
        {
            _UnsubscribeEvents();
        }

        void Start()
        {
            HideAllMenu();
            Show(View.MainMenu);
        }

        void _SubscribeEvents()
        {
            GameController.OnGameStart += _OnGameStart;
            GameController.OnGameStop += _OnGameStop;
        }

        void _UnsubscribeEvents()
        {
            GameController.OnGameStart -= _OnGameStart;
            GameController.OnGameStop -= _OnGameStop;
        }

        void _OnGameStart()
        {
            HideAllMenu();
        }

        void _OnGameStop()
        {
            HideAllMenu();
            Show(View.MainMenu);
        }

        public void Show(View view)
        {
            menu[(int)view].gameObject.SetActive(true);
        }

        public void Hide(View view)
        {
            menu[(int)view].gameObject.SetActive(false);
        }

        public void Toggle(View view)
        {
            var isActive = menu[(int)view].gameObject.activeSelf;
            isActive = !isActive;

            if (isActive) {
                Show(view);
            }
            else {
                Hide(view);
            }
        }

        public void HideAllMenu()
        {
            foreach (RectTransform rect in menu) {
                rect.gameObject.SetActive(false);
            }
        }
    }
}
