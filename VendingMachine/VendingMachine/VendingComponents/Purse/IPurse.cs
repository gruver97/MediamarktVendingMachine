using System.Collections.ObjectModel;
using VendingMachine.VendingComponents.Coins;

namespace VendingMachine.VendingComponents.Purse
{
    public interface IPurse
    {
        ObservableCollection<CoinGroup> CoinGroups { get; set; }
        void AddCoin(Coin coin);
    }
}