using System.Collections.ObjectModel;
using VendingMachine.VendingComponents.Coins;

namespace VendingMachine.VendingComponents.Purse
{
    public class Purse : IPurse
    {
        private readonly int[] _coinPrices = {1, 2, 5, 10};

        public Purse()
        {
            CoinGroups = new ObservableCollection<CoinGroup>();
            for (var i = 0; i < 4; i++)
            {
                var coinGroup = new CoinGroup(_coinPrices[i])
                {
                    Price = _coinPrices[i],
                    Coins = new ObservableCollection<Coin>()
                };
                CoinGroups.Add(coinGroup);
            }
        }

        public ObservableCollection<CoinGroup> CoinGroups { get; set; }

        public void AddCoin(Coin coin)
        {
            switch (coin.Price)
            {
                case 1:
                {
                    CoinGroups[0].Coins.Add(coin);
                    break;
                }
                case 2:
                {
                    CoinGroups[1].Coins.Add(coin);
                    break;
                }
                case 5:
                {
                    CoinGroups[2].Coins.Add(coin);
                    break;
                }
                case 10:
                {
                    CoinGroups[3].Coins.Add(coin);
                    break;
                }
            }
        }
    }
}