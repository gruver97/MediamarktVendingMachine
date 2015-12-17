using System.ComponentModel;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;
using VendingMachine.VendingComponents.Coins;
using VendingMachine.VendingComponents.Purse;

namespace VendingMachine.VendingComponents.Processor
{
    public class VendingProcessor : IProcessor, INotifyPropertyChanged
    {
        private int _depositAmount;

        public VendingProcessor()
        {
            InitializePurse();
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

        public IPurse MachinePurse { get; private set; }

        private void InitializePurse()
        {
            const int defaultCount = 100;
            MachinePurse = new Purse.Purse();
            for (var i = 0; i < defaultCount; i++)
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