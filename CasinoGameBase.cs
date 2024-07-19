namespace CasinoGame
{
    public abstract class CasinoGameBase
    {
        public int PlayerBet { get; set; }
        public int ComputerBet { get; set; }

        public event EventHandler OnWin;
        public event EventHandler OnLoose;
        public event EventHandler OnDraw;
        public abstract void PlayGame();

        public virtual void PlaceBet(int bet)
        {
            PlayerBet = bet;
        }

        public virtual void ComputerPlaceBet(int bet)
        {
            ComputerBet = bet;
        }

        protected void OnWinInvoke()
        {
            OnWin?.Invoke(this, EventArgs.Empty);
        }

        protected void OnLooseInvoke()
        {
            OnLoose?.Invoke(this, EventArgs.Empty);
        }

        protected void OnDrawInvoke()
        {
            OnDraw?.Invoke(this, EventArgs.Empty);
        }
        
        protected abstract void FactoryMethod();

        protected CasinoGameBase()
        {
            FactoryMethod();
        }
    }
}
