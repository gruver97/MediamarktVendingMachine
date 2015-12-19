using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VendingMachine.VendingComponents.Coins;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace VendingMachine.Controls
{
    public sealed class TemplatedPurse : Control
    {
        public static readonly DependencyProperty PressCoinCommandProperty = DependencyProperty.Register(
            "PressCoinCommand", typeof (ICommand), typeof (TemplatedPurse), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty IsButtonsEnabledProperty = DependencyProperty.Register(
            "IsButtonsEnabled", typeof (bool), typeof (TemplatedPurse), new PropertyMetadata(default(bool)));

        public TemplatedPurse()
        {
            DefaultStyleKey = typeof (TemplatedPurse);
        }

        public ICommand PressCoinCommand
        {
            get { return (ICommand) GetValue(PressCoinCommandProperty); }
            set { SetValue(PressCoinCommandProperty, value); }
        }

        public bool IsButtonsEnabled
        {
            get { return (bool) GetValue(IsButtonsEnabledProperty); }
            set { SetValue(IsButtonsEnabledProperty, value); }
        }

        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
            "Count", typeof (int), typeof (TemplatedPurse), new PropertyMetadata(default(int)));

        public int Count
        {
            get { return (int) GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }
    }
}