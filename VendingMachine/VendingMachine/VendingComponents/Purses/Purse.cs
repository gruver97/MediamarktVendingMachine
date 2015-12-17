using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;
using VendingMachine.VendingComponents.Coins;

namespace VendingMachine.VendingComponents.Purses
{
    public class Purse : IPurse, INotifyPropertyChanged
    {
        private readonly int[] _coinPrices = {1, 2, 5, 10};
        private int _total;

        public Purse()
        {
            CoinGroups = new ObservableCollection<CoinGroup>();
            for (var i = 0; i < 4; i++)
            {
                var coinGroup = new CoinGroup(_coinPrices[i])
                {
                    Price = _coinPrices[i]
                };
                CoinGroups.Add(coinGroup);
            }
        }

        public ObservableCollection<CoinGroup> CoinGroups { get; }

        public void AddCoin(Coin coin)
        {
            var groupIndex = GetCoinGroupIndex(coin.Price);
            CoinGroups[groupIndex].Coins.Push(coin);
            Total += coin.Price;
        }

        public Coin GetCoin(int price)
        {
            var groupIndex = GetCoinGroupIndex(price);
            var coin = CoinGroups[groupIndex].GetCoin();
            Total = Total - coin?.Price ?? Total;
            return coin;
        }

        public int Total
        {
            get { return _total; }
            private set
            {
                if (value == _total) return;
                _total = value;
                OnPropertyChanged();
            }
        }

        private int GetCoinGroupIndex(int price)
        {
            switch (price)
            {
                case 1:
                {
                    return 0;
                }
                case 2:
                {
                    return 1;
                }
                case 5:
                {
                    return 2;
                }
                case 10:
                {
                    return 3;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}