using System.Collections.ObjectModel;
using System.Windows.Input;

namespace VendingMachine.VendingComponents.ProductStore
{
    public interface IStore
    {
        ObservableCollection<ProductGroup> ProductsGroup { get; set; }
        void BuyProduct(ProductGroup productGroup);
    }
}