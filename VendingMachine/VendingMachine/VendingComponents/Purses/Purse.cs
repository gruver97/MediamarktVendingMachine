using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;
using VendingMachine.VendingComponents.Coins;

namespace VendingMachine.VendingComponents.Purses
{
    public class Purse : IPurse, INotifyPropertyChanged
    {
        private readonly int[] _coinPrices = {1, 2, 5, 10};
        private int _total;
        private int _maximumAmount;
        private int _total1;

        public Purse(int maximunAmount)
        {
            _total = 0;
            MaximumAmount = maximunAmount;
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
            CoinGroups[groupIndex].AddCoin(coin);
            Total = UpdateTotal();
        }

        public Coin GetCoin(int price)
        {
            var groupIndex = GetCoinGroupIndex(price);
            var coin = CoinGroups[groupIndex].GetCoin();
            Total = UpdateTotal();
            return coin;
        }

        public int Total
        {
            get { return _total; }
            set
            {
                if (value == _total) return;
                _total = value;
                OnPropertyChanged();
            }
        }

        private int UpdateTotal()
        {
            return CoinGroups.Sum(coinGroup => coinGroup.TotalGroup);
        }

        public int MaximumAmount
        {
            get { return _maximumAmount; }
            private set
            {
                if (value == _maximumAmount) return;
                _maximumAmount = value;
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