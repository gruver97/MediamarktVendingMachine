namespace VendingMachine.VendingComponents.CoinLoader
{
    public interface ICoinLoader
    {
        void InsertCoin(Coin coin);
        Coin[] ReturnCoins();
    }
}