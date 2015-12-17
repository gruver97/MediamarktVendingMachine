using System.Collections.ObjectModel;
using VendingMachine.VendingComponents.Coins;

namespace VendingMachine.VendingComponents.Purses
{
    public interface IPurse
    {
        ObservableCollection<CoinGroup> CoinGroups { get; }
        void AddCoin(Coin coin);
        Coin GetCoin(int price);
        int Total { get; }
    }
}