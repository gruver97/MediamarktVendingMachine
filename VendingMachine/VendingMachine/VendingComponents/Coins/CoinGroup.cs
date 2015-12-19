using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;

namespace VendingMachine.VendingComponents.Coins
{
    public class CoinGroup : INotifyPropertyChanged
    {
        public CoinGroup(int price)
        {
            Price = price;
            Coins = new Stack<Coin>();
            TotalGroup = 0;
        }

        public Stack<Coin> Coins { get; set; }

        public int Price { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Coin GetCoin()
        {
            if (Coins.Any())
            {
                var coin = Coins.Pop();
                OnPropertyChanged(nameof(Coins));
                TotalGroup -= coin.Price;
                return coin;
            }
            return null;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddCoin(Coin coin)
        {
            Coins.Push(coin);
            TotalGroup += coin.Price;
            OnPropertyChanged(nameof(Coins));
        }

        public int TotalGroup { get; private set; }
    }
}