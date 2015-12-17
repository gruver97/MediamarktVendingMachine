using System.ComponentModel;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;

namespace VendingMachine.VendingComponents.Processor
{
    public class VendingProcessor : IProcessor, INotifyPropertyChanged
    {
        private int _depositAmount;

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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}