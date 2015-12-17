using System.Windows.Input;
using VendingMachine.VendingComponents.ProductStore;

namespace VendingMachine.VendingComponents.Processor
{
    public interface IProcessor
    {
        int DepositAmount { get; set; }
    }
}