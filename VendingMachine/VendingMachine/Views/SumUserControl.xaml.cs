using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VendingMachine.Annotations;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VendingMachine.Views
{
    public sealed partial class SumUserControl : UserControl, INotifyPropertyChanged
    {
        
        public SumUserControl()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static readonly DependencyProperty DepositProperty = DependencyProperty.Register(
            "Deposit", typeof (int), typeof (SumUserControl), new PropertyMetadata(default(int)));

        public int Deposit
        {
            get { return (int) GetValue(DepositProperty); }
            set { SetValue(DepositProperty, value); }
        }
    }
}