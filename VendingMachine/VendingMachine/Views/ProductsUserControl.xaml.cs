using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VendingMachine.VendingComponents.ProductStore;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VendingMachine.Views
{
    public sealed partial class ProductsUserControl : UserControl
    {
        public ProductsUserControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ProductsSourceProperty = DependencyProperty.Register(
            "ProductsSource", typeof (ObservableCollection<Product>), typeof (ProductsUserControl), new PropertyMetadata(default(ObservableCollection<Product>)));

        public ObservableCollection<Product> ProductsSource
        {
            get { return (ObservableCollection<Product>) GetValue(ProductsSourceProperty); }
            set { SetValue(ProductsSourceProperty, value); }
        }
    }
}