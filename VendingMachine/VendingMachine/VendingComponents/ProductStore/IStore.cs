using System.Collections.ObjectModel;

namespace VendingMachine.VendingComponents.ProductStore
{
    public interface IStore
    {
        ObservableCollection<Product> Products { get; set; }
    }
}