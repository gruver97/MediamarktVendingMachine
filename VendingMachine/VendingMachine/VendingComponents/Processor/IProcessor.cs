using VendingMachine.VendingComponents.Coins;
using VendingMachine.VendingComponents.Purses;

namespace VendingMachine.VendingComponents.Processor
{
    public interface IProcessor
    {
        int DepositAmount { get; }

        IPurse MachinePurse { get; }

        void AddToLoader(Coin coin);
    }
}