using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VendingMachine.VendingComponents.Coins;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VendingMachine.Views
{
    public sealed partial class PurseUserControl : UserControl
    {
        public PurseUserControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CoinGroupsProperty = DependencyProperty.Register(
            "CoinGroups", typeof (ObservableCollection<CoinGroup>), typeof (PurseUserControl), new PropertyMetadata(default(ObservableCollection<CoinGroup>)));

        public ObservableCollection<CoinGroup> CoinGroups
        {
            get { return (ObservableCollection<CoinGroup>) GetValue(CoinGroupsProperty); }
            set { SetValue(CoinGroupsProperty, value); }
        }

        public static readonly DependencyProperty IsButtonsEnabledProperty = DependencyProperty.Register(
            "IsButtonsEnabled", typeof (bool), typeof (PurseUserControl), new PropertyMetadata(default(bool)));

        public bool IsButtonsEnabled
        {
            get { return (bool) GetValue(IsButtonsEnabledProperty); }
            set { SetValue(IsButtonsEnabledProperty, value); }
        }
    }
}