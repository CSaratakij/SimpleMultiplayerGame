
namespace MVP
{
    public static class GameController
    {
        public delegate void _Func();
        public static event _Func OnGameStart; 
        public static event _Func OnGameStop; 

        public static bool IsGameStart { get; private set; }

        public static void GameStart()
        {
            if (IsGameStart) { return; }
            IsGameStart = true;

            if (OnGameStart != null) {
                OnGameStart();
            }
        }

        public static void GameStop()
        {
            if (!IsGameStart) { return; }
            IsGameStart = false;

            if (OnGameStop != null) {
                OnGameStop();
            }
        }
    }
}

