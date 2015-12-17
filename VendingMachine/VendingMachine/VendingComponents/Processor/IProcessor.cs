using VendingMachine.VendingComponents.Purse;

namespace VendingMachine.VendingComponents.Processor
{
    public interface IProcessor
    {
        int DepositAmount { get; set; }

        IPurse MachinePurse { get; }
    }
}