using GalaSoft.MvvmLight;
using VendingMachine.VendingComponents.Processor;
using VendingMachine.VendingComponents.ProductStore;

namespace VendingMachine.ViewModel
{
    public class VendingMachineViewModel : ViewModelBase
    {
        private IProcessor _vendingProcessor;
        private IStore _productStore;

        public VendingMachineViewModel()
        {
            VendingProcessor = new VendingProcessor();
            ProductStore = new ProductStore();
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