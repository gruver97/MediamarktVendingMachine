using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using VendingMachine.VendingComponents.ProductStore;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VendingMachine.Views
{
    public sealed partial class ProductsUserControl : UserControl
    {
        public static readonly DependencyProperty ProductsSourceProperty = DependencyProperty.Register(
            "ProductsSource", typeof (ObservableCollection<ProductGroup>), typeof (ProductsUserControl),
            new PropertyMetadata(default(ObservableCollection<ProductGroup>)));

        public static readonly DependencyProperty BuyProductCommandProperty = DependencyProperty.Register(
            "BuyProductCommand", typeof (ICommand), typeof (ProductsUserControl), new PropertyMetadata(default(ICommand)));

        public ProductsUserControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<ProductGroup> ProductsSource
        {
            get { return (ObservableCollection<ProductGroup>) GetValue(ProductsSourceProperty); }
            set { SetValue(ProductsSourceProperty, value); }
        }

        public ICommand BuyProductCommand
        {
            get { return (ICommand) GetValue(BuyProductCommandProperty); }
            set { SetValue(BuyProductCommandProperty, value); }
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            BuyProductCommand.Execute((sender as Grid).DataContext as ProductGroup);
        }
    }
}