using System;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VendingMachine.Common;
using VendingMachine.VendingComponents.Coins;
using VendingMachine.VendingComponents.Processor;
using VendingMachine.VendingComponents.ProductStore;
using VendingMachine.VendingComponents.Purses;

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
            ClientCoinExtract = new RelayCommand<int>(MoveClientCoin);
            BuyProduct = new RelayCommand<ProductGroup>(OnBuyProduct);
        }

        private void OnBuyProduct(ProductGroup productGroup)
        {
            
        }

        private async void MoveClientCoin(int price)
        {
            var coin = ClientPurse.GetCoin(price);
            if (coin == null)
            {
                await new MessageDialog($"Монеты в {price} руб. закончились").ShowAsync();
                return;
            }
            VendingProcessor.AddToLoader(coin);
        }

        public ICommand ClientCoinExtract { get; private set; }
        public ICommand BuyProduct { get; private set; }
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