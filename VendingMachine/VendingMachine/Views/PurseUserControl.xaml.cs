using System.Collections.ObjectModel;
using System.Windows.Input;
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

        public static readonly DependencyProperty PurseStyleProperty = DependencyProperty.Register(
            "PurseStyle", typeof (Style), typeof (PurseUserControl), new PropertyMetadata(default(Style)));

        public Style PurseStyle
        {
            get { return (Style) GetValue(PurseStyleProperty); }
            set { SetValue(PurseStyleProperty, value); }
        }

        public static readonly DependencyProperty CoinGroupsProperty = DependencyProperty.Register(
            "CoinGroups", typeof (ObservableCollection<CoinGroup>), typeof (PurseUserControl), new PropertyMetadata(default(ObservableCollection<CoinGroup>)));

        public ObservableCollection<CoinGroup> CoinGroups
        {
            get { return (ObservableCollection<CoinGroup>) GetValue(CoinGroupsProperty); }
            set { SetValue(CoinGroupsProperty, value); }
        }

        public static readonly DependencyProperty PressCoinCommandProperty = DependencyProperty.Register(
            "PressCoinCommand", typeof (ICommand), typeof (PurseUserControl), new PropertyMetadata(default(ICommand)));

        public ICommand PressCoinCommand
        {
            get { return (ICommand) GetValue(PressCoinCommandProperty); }
            set { SetValue(PressCoinCommandProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
            "Maximum", typeof (int), typeof (PurseUserControl), new PropertyMetadata(default(int)));

        public int Maximum
        {
            get { return (int) GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
    }
}