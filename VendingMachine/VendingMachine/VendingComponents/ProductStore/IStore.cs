using System.Collections.ObjectModel;
using System.Windows.Input;

namespace VendingMachine.VendingComponents.ProductStore
{
    public interface IStore
    {
        ObservableCollection<Product> Products { get; set; }
        ICommand BuyProduct(Product product);
    }
}