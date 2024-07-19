namespace CasinoGame
{
    public interface IBuilderSupporter
    {
        public void BuildService<T>(T service) where T : ISaveLoadService<string>;
        public void BuildCustom<U>(U games) where U : CasinoGameBase;
    }
}
