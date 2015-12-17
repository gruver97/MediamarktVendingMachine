using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                    Coins = new Stack<Coin>()
                };
                CoinGroups.Add(coinGroup);
            }
        }

        public ObservableCollection<CoinGroup> CoinGroups { get; private set; }

        public void AddCoin(Coin coin)
        {
            var groupIndex = GetCoinGroupIndex(coin.Price);
            CoinGroups[groupIndex].Coins.Push(coin);
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
                default: throw new ArgumentOutOfRangeException();
            }
        }
        public Coin GetCoin(int price)
        {
            var groupIndex = GetCoinGroupIndex(price);
            if (CoinGroups[groupIndex].Coins.Any())
            {
                return CoinGroups[groupIndex].Coins.Pop();
            }
            else return null;
        }
    }
}