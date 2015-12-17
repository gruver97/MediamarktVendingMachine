using GalaSoft.MvvmLight;
using VendingMachine.VendingComponents.Processor;

namespace VendingMachine.ViewModel
{
    public class VendingMachineViewModel : ViewModelBase
    {
        private IProcessor _vendingProcessor;

        public VendingMachineViewModel()
        {
            VendingProcessor = new VendingProcessor();
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
    }
}