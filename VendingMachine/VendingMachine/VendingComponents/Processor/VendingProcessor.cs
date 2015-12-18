using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;
using VendingMachine.VendingComponents.Coins;
using VendingMachine.VendingComponents.Purses;

namespace VendingMachine.VendingComponents.Processor
{
    public class VendingProcessor : IProcessor, INotifyPropertyChanged
    {
        const int MaximumAmount = 1000;
        private readonly IPurse _bufferPurse = new Purse(MaximumAmount);
        private int _depositAmount;

        public VendingProcessor()
        {
            InitializeMachinePurse();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int DepositAmount
        {
            get { return _depositAmount; }
            set
            {
                if (value == _depositAmount) return;
                _depositAmount = value;
                OnPropertyChanged();
            }
        }

        public IPurse MachinePurse { get; private set; } = new Purse(MaximumAmount);

        public void AddToLoader(Coin coin)
        {
            _bufferPurse.AddCoin(coin);
            DepositAmount = _bufferPurse.Total;
        }

        public bool CommitPurchase(int price)
        {
            DepositAmount -= price;
            foreach (var coinGroup in _bufferPurse.CoinGroups)
            {
                var stackCopy = coinGroup.GetAllCoins();
                foreach (var coin in stackCopy)
                {
                    MachinePurse.AddCoin(coin);
                }
            }
            return DepositAmount > 0;
        }

        private void InitializeMachinePurse()
        {
            const int defaultAmount = 100;
            for (var i = 0; i < defaultAmount; i++)
            {
                MachinePurse.AddCoin(new Coin(1));
                MachinePurse.AddCoin(new Coin(2));
                MachinePurse.AddCoin(new Coin(5));
                MachinePurse.AddCoin(new Coin(10));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}