using System;
using FinalTask;


namespace FinalTask.Casino.CasinoGames
{
    public abstract class CasinoGameBase
    {
        public event Action OnWin;
        public event Action OnLose;
        public event Action OnDraw;

        public abstract void PlayGame();
        protected abstract void FactoryMethod();
       
        protected void OnWinInvoke() => OnWin?.Invoke();
        protected void OnLoseInvoke() => OnLose?.Invoke();
        protected void OnDrawInvoke() => OnDraw?.Invoke();

    }
}