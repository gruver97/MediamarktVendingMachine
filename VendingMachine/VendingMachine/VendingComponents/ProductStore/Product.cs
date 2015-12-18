using System.ComponentModel;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;

namespace VendingMachine.VendingComponents.ProductStore
{
    public class Product : INotifyPropertyChanged
    {
        private string _imageSourceUri;

        public Product(string name, int price, string imageSource)
        {
            Name = name;
            Price = price;
            ImageSourceUri = imageSource;
        }

        public string ImageSourceUri
        {
            get { return _imageSourceUri; }
            private set
            {
                if (value == _imageSourceUri) return;
                _imageSourceUri = value;
                OnPropertyChanged();
            }
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}