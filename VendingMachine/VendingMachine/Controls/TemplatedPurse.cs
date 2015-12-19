using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using VendingMachine.VendingComponents.Coins;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace VendingMachine.Controls
{
    public sealed class TemplatedPurse : Control
    {
        public static readonly DependencyProperty CoinGroupsProperty = DependencyProperty.Register(
            "CoinGroups", typeof (ObservableCollection<CoinGroup>), typeof (TemplatedPurse),
            new PropertyMetadata(default(ObservableCollection<CoinGroup>)));

        public static readonly DependencyProperty PressCoinCommandProperty = DependencyProperty.Register(
            "PressCoinCommand", typeof (ICommand), typeof (TemplatedPurse), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
            "Maximum", typeof (int), typeof (TemplatedPurse), new PropertyMetadata(default(int)));

        public static readonly DependencyProperty IsButtonsEnabledProperty = DependencyProperty.Register(
            "IsButtonsEnabled", typeof (bool), typeof (TemplatedPurse), new PropertyMetadata(default(bool)));

        public TemplatedPurse()
        {
            DefaultStyleKey = typeof (TemplatedPurse);
        }

        public ObservableCollection<CoinGroup> CoinGroups
        {
            get { return (ObservableCollection<CoinGroup>) GetValue(CoinGroupsProperty); }
            set { SetValue(CoinGroupsProperty, value); }
        }

        public ICommand PressCoinCommand
        {
            get { return (ICommand) GetValue(PressCoinCommandProperty); }
            set { SetValue(PressCoinCommandProperty, value); }
        }

        public int Maximum
        {
            get { return (int) GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public bool IsButtonsEnabled
        {
            get { return (bool) GetValue(IsButtonsEnabledProperty); }
            set { SetValue(IsButtonsEnabledProperty, value); }
        }
    }
}