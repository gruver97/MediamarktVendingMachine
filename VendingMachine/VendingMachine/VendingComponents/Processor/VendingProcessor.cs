using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;
using VendingMachine.VendingComponents.Coins;
using VendingMachine.VendingComponents.Purses;

namespace VendingMachine.VendingComponents.Processor
{
    public class VendingProcessor : IProcessor, INotifyPropertyChanged
    {
        private const int MaximumAmount = 1000;
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

        public IPurse MachinePurse { get; } = new Purse(MaximumAmount);

        public void AddToLoader(Coin coin)
        {
            _bufferPurse.AddCoin(coin);
            DepositAmount = _bufferPurse.Total;
        }

        public void CommitPurchase(int price)
        {
            DepositAmount -= price;
            MoveCoins(_bufferPurse, MachinePurse);
            if (DepositAmount > 0) MoveCoins(MachinePurse, _bufferPurse, DepositAmount);
        }

        private void MoveCoins(IPurse source, IPurse target, int amount)
        {
            foreach (var coinGroup in source.CoinGroups.OrderByDescending(sourceCoinGroup => sourceCoinGroup.Price))
            {
                int solidPart = amount/ coinGroup.Price;
                if (solidPart == 0) continue;
                for (int i = solidPart; i >0; i--)
                {
                    if (!coinGroup.Coins.Any()) break;
                    var coin = coinGroup.GetCoin();
                    target.AddCoin(coin);
                    amount -= coin.Price;
                }
            }
        }

        private void MoveCoins(IPurse source, IPurse target)
        {
            //Перенос всей суммы
            foreach (var coinGroup in source.CoinGroups)
            {
                while (coinGroup.Coins.Any())
                {
                    var coin = source.GetCoin(coinGroup.Price);
                    target.AddCoin(coin);
                }
            }
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