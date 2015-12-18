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
            "ProductsSource", typeof (ObservableCollection<ProductGroup>), typeof (ProductsUserControl), new PropertyMetadata(default(ObservableCollection<ProductGroup>)));

        public ObservableCollection<ProductGroup> ProductsSource
        {
            get { return (ObservableCollection<ProductGroup>) GetValue(ProductsSourceProperty); }
            set { SetValue(ProductsSourceProperty, value); }
        }
    }
}