using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;

namespace VendingMachine.VendingComponents.ProductStore
{
    public class ProductGroup : INotifyPropertyChanged
    {
        private int _count;
        private string _image;
        private string _name;
        private int _price;

        public ProductGroup(string name, int price, int count, string image)
        {
            Price = price;
            Count = count;
            _name = name;
            _image = image;
            Products = new Stack<Product>();
            FillGroup();
        }

        public Stack<Product> Products { get; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Price
        {
            get { return _price; }
            set
            {
                if (value == _price) return;
                _price = value;
                OnPropertyChanged();
            }
        }

        public int Count
        {
            get { return _count; }
            set
            {
                if (value == _count) return;
                _count = value;
                OnPropertyChanged();
            }
        }

        public string ImageGroup
        {
            get { return _image; }
            private set
            {
                if (value == _image) return;
                _image = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FillGroup()
        {
            for (var i = 0; i < _count; i++)
            {
                Products.Push(new Product(_name, _price, _image));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}