namespace VendingMachine.VendingComponents.Purse
{
    public interface IPurse
    {
        void AddCoin(Coin coin);
        Coin GetCoin(int coinValue);
    }
}