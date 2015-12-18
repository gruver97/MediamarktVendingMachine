using System;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VendingMachine.VendingComponents.Coins;
using VendingMachine.VendingComponents.Processor;
using VendingMachine.VendingComponents.ProductStore;
using VendingMachine.VendingComponents.Purses;

namespace VendingMachine.ViewModel
{
    public class VendingMachineViewModel : ViewModelBase
    {
        private IStore _productStore;
        private IProcessor _vendingProcessor;

        public VendingMachineViewModel()
        {
            VendingProcessor = new VendingProcessor();
            ProductStore = new ProductStore();
            InitializeClientPurse();
            ClientCoinExtract = new RelayCommand<int>(MoveClientCoin);
            BuyProduct = new RelayCommand<ProductGroup>(OnBuyProduct);
            CalculateRentingCommand = new RelayCommand(OnCalculateRentingCommand);
        }

        private void OnCalculateRentingCommand()
        {
            var coins = VendingProcessor.ReturnRenting();
            foreach (var coin in coins)
            {
                ClientPurse.AddCoin(coin);
            }
        }

        public IPurse ClientPurse { get; set; }

        public ICommand ClientCoinExtract { get; private set; }
        public ICommand BuyProduct { get; private set; }

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

        private async void OnBuyProduct(ProductGroup productGroup)
        {
            if (productGroup.Count == 0)
            {
                await new MessageDialog($"{productGroup.Name} законился.").ShowAsync();
                return;
            }
            if (productGroup.Price <= VendingProcessor.DepositAmount)
            {
                ProductStore.BuyProduct(productGroup);
                VendingProcessor.CommitPurchase(productGroup.Price);
                await new MessageDialog("Спасибо!").ShowAsync();
            }
            else
            {
                await new MessageDialog("Недостаточно средств.").ShowAsync();
            }
        }

        public ICommand CalculateRentingCommand { get; private set; }

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

        private void InitializeClientPurse()
        {
            const int maximumAmount = 100;
            ClientPurse = new Purse(maximumAmount);
            for (var i = 0; i < 10; i++)
            {
                ClientPurse.AddCoin(new Coin(1));
            }
            for (var i = 0; i < 30; i++)
            {
                ClientPurse.AddCoin(new Coin(2));
            }
            for (var i = 0; i < 20; i++)
            {
                ClientPurse.AddCoin(new Coin(5));
            }
            for (var i = 0; i < 15; i++)
            {
                ClientPurse.AddCoin(new Coin(10));
            }
        }
    }
}