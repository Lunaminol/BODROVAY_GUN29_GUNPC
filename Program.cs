namespace CasinoGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var casino = new Casino();
            var saveLoadService = new FileSystemSaveLoadService("D:\\");
            casino.BuildService(saveLoadService);
            casino.StartGame();
        }
    }
}
