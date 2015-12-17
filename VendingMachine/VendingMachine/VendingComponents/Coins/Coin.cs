namespace VendingMachine.VendingComponents.Coins
{
    public class Coin
    {
        public Coin(int price)
        {
            Price = price;
        }

        public int Price { get; set; }
    }
}