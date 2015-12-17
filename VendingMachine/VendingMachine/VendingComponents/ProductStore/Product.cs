using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;

namespace VendingMachine.VendingComponents.ProductStore
{
    public class Product:INotifyPropertyChanged
    {
        private int _count;

        public Product(string name, int price, int count, string imageSource)
        {
            Name = name;
            Price = price;
            Count = count;
            ImageSourceUri = imageSource;
        }

        public string ImageSourceUri { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}