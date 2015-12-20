using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace VendingMachine.Controls
{
    public sealed class TemplatedPurse : Control
    {
        public static readonly DependencyProperty PressCoinCommandProperty = DependencyProperty.Register(
            "PressCoinCommand", typeof (ICommand), typeof (TemplatedPurse), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty IsButtonsEnabledProperty = DependencyProperty.Register(
            "IsButtonsEnabled", typeof (bool), typeof (TemplatedPurse), new PropertyMetadata(default(bool)));


        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
            "Maximum", typeof (int), typeof (TemplatedPurse), new PropertyMetadata(default(int)));

        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
            "Count", typeof (int), typeof (TemplatedPurse), new PropertyMetadata(default(int)));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof (string), typeof (TemplatedPurse), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public TemplatedPurse()
        {
            DefaultStyleKey = typeof (TemplatedPurse);
        }

        public int Maximum
        {
            get { return (int) GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
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

        public int Count
        {
            get { return (int) GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }
    }
}