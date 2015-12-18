using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace VendingMachine.VendingComponents.ProductStore
{
    public class ProductStore : IStore
    {
        public ProductStore()
        {
            ProductsGroup = new ObservableCollection<ProductGroup>();
            FillProducts();
        }

        public ObservableCollection<ProductGroup> ProductsGroup { get; set; }

        public ICommand BuyProduct(Product product)
        {
            throw new NotImplementedException();
        }

        private void FillProducts()
        {
            var initialData = new[]
            {
                new
                {
                    Name = "Чай",
                    Price = 13,
                    Count = 10,
                    Image = "ms-appx:///Assets/Products/Tea.jpg"
                },
                new
                {
                    Name = "Кофе",
                    Price = 18,
                    Count = 20,
                    Image = "ms-appx:///Assets/Products/Coffee.jpg"
                },
                new
                {
                    Name = "Кофе с молоком",
                    Price = 21,
                    Count = 20,
                    Image = "ms-appx:///Assets/Products/MilkCoffee.jpg"
                },
                new
                {
                    Name = "Сок",
                    Price = 35,
                    Count = 15,
                    Image = "ms-appx:///Assets/Products/Juice.jpg"
                }
            };
            foreach (
                var productGroup in
                    initialData.Select(
                        initialGroupItem =>
                            new ProductGroup(initialGroupItem.Name, initialGroupItem.Price, initialGroupItem.Count,
                                initialGroupItem.Image)))
            {
                ProductsGroup.Add(productGroup);
            }
        }
    }
}