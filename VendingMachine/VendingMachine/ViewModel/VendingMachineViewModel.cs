using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VendingMachine.VendingComponents.Coins;
using VendingMachine.VendingComponents.Processor;
using VendingMachine.VendingComponents.ProductStore;
using VendingMachine.VendingComponents.Purse;

namespace VendingMachine.ViewModel
{
    public class VendingMachineViewModel : ViewModelBase
    {
        private IProcessor _vendingProcessor;
        private IStore _productStore;
        public IPurse ClientPurse { get; set; }
        public VendingMachineViewModel()
        {
            VendingProcessor = new VendingProcessor();
            ProductStore = new ProductStore();
            InitializeClientPurse();
            ClientCoinExtract = new RelayCommand(MoveClientCoin);
        }

        private void MoveClientCoin()
        {
            
        }

        public ICommand ClientCoinExtract { get; private set; }

        private void InitializeClientPurse()
        {
            ClientPurse = new Purse();
            for (int i = 0; i < 10; i++)
            {
                ClientPurse.AddCoin(new Coin(1));
            }
            for (int i = 0; i < 30; i++)
            {
                ClientPurse.AddCoin(new Coin(2));
            }
            for (int i = 0; i < 20; i++)
            {
                ClientPurse.AddCoin(new Coin(5));
            }
            for (int i = 0; i < 15; i++)
            {
                ClientPurse.AddCoin(new Coin(10));
            }
        }

        public IProcessor VendingProcessor
        {
            get { return _vendingProcessor; }
            set
            {
                _vendingProcessor = value;
                RaisePropertyChanged(nameof(VendingProcessor));
            }
        }

        public IStore ProductStore
        {
            get { return _productStore; }
            set
            {
                _productStore = value;
                RaisePropertyChanged(nameof(ProductStore));
            }
        }
    }
}