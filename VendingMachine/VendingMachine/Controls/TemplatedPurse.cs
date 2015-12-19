using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VendingMachine.VendingComponents.Coins;
using VendingMachine.Views;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace VendingMachine.Controls
{
    public sealed class TemplatedPurse : Control
    {
        public static readonly DependencyProperty CoinGroupsProperty = DependencyProperty.Register(
            "CoinGroups", typeof (ObservableCollection<CoinGroup>), typeof (TemplatedPurse), new PropertyMetadata(default(ObservableCollection<CoinGroup>)));

        public ObservableCollection<CoinGroup> CoinGroups
        {
            get { return (ObservableCollection<CoinGroup>) GetValue(CoinGroupsProperty); }
            set { SetValue(CoinGroupsProperty, value); }
        }

        public TemplatedPurse()
        {
            DefaultStyleKey = typeof (TemplatedPurse);
        }
    }
}