using CasinoGame;

public static class Builder
{
    public static IBuilderSupporter BuildGame(int userInput)
    {
        switch (userInput)
        {
            case 1:
                var game = new BlackJack(52);
                return (IBuilderSupporter)game;
            case 2:
                var selectedGame = new DiceGame(2, 1, 6);
                return (IBuilderSupporter)selectedGame;
            default:
                return null;
        }
    }
}
