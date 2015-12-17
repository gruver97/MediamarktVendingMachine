using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace VendingMachine.VendingComponents.ProductStore
{
    public class ProductStore : IStore
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>
        {
            new Product("Чай", 13, 10, "ms-appx:///Assets/Products/Tea.jpg"),
            new Product("Кофе", 18, 20, "ms-appx:///Assets/Products/Coffee.jpg"),
            new Product("Кофе с молоком", 21, 20, "ms-appx:///Assets/Products/MilkCoffee.jpg"),
            new Product("Сок", 35, 15, "ms-appx:///Assets/Products/Juice.jpg")
        };

        public ICommand BuyProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}