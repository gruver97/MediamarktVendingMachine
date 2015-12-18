using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using VendingMachine.Annotations;
using VendingMachine.VendingComponents.Coins;
using VendingMachine.VendingComponents.Purses;

namespace VendingMachine.VendingComponents.Processor
{
    public class VendingProcessor : IProcessor, INotifyPropertyChanged
    {
        private const int MaximumAmount = 1000;
        private readonly IPurse _bufferPurse = new Purse(MaximumAmount);
        private int _depositAmount;

        public VendingProcessor()
        {
            InitializeMachinePurse();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int DepositAmount
        {
            get { return _depositAmount; }
            set
            {
                if (value == _depositAmount) return;
                _depositAmount = value;
                OnPropertyChanged();
            }
        }

        public IPurse MachinePurse { get; } = new Purse(MaximumAmount);

        public void AddToLoader(Coin coin)
        {
            _bufferPurse.AddCoin(coin);
            DepositAmount = _bufferPurse.Total;
        }

        public void CommitPurchase(int price)
        {
            DepositAmount -= price;
            MoveCoins(_bufferPurse, MachinePurse);
            if (DepositAmount > 0) MoveCoins(MachinePurse, coin => _bufferPurse.AddCoin(coin), DepositAmount, false);
        }

        public IEnumerable<Coin> ReturnRenting()
        {
            var returnedCoins = new List<Coin>();
            MoveCoins(_bufferPurse, coin => returnedCoins.Add(coin), DepositAmount, true);
            DepositAmount -= _bufferPurse.Total;
            if (_bufferPurse.Total > 0) MoveCoins(_bufferPurse, MachinePurse);
            return returnedCoins;
        }

        private void MoveCoins(IPurse source, Action<Coin> addToTargetAction, int amount, bool useVendingMachinePurse)
        {
            var machineSource =
                MachinePurse.CoinGroups.OrderByDescending(sourceCoinGroup => sourceCoinGroup.Price).ToArray();
            var orderedSource = source.CoinGroups.OrderByDescending(sourceCoinGroup => sourceCoinGroup.Price).ToArray();
            for (var index = 0; index < orderedSource.Count(); index++)
            {
                var solidPart = amount/orderedSource[index].Price;
                var partial = amount% orderedSource[index].Price;
                if (solidPart == 0)
                {
                    if (useVendingMachinePurse && amount > orderedSource[index].Price)
                    {
                        amount -= ChangeCoins(solidPart, machineSource[index], addToTargetAction);
                    }
                    continue;
                }
                if (solidPart == 1  && partial == 0 && useVendingMachinePurse)
                {
                    ChangeCoins(solidPart, machineSource[index], addToTargetAction);
                    return;
                }
                amount -= ChangeCoins(solidPart, orderedSource[index], addToTargetAction);
            }
        }

        private int ChangeCoins(int changesCount, CoinGroup sourceCoinGroup, Action<Coin> addToTargetAction)
        {
            var changedAmount = 0;
            for (var i = changesCount; i > 0; i--)
            {
                if (!sourceCoinGroup.Coins.Any()) break;
                var coin = sourceCoinGroup.GetCoin();
                addToTargetAction(coin);
                changedAmount += coin.Price;
            }
            return changedAmount;
        }

        private void MoveCoins(IPurse source, IPurse target)
        {
            //Перенос всей суммы
            foreach (var coinGroup in source.CoinGroups)
            {
                while (coinGroup.Coins.Any())
                {
                    var coin = source.GetCoin(coinGroup.Price);
                    target.AddCoin(coin);
                }
            }
        }

        private void InitializeMachinePurse()
        {
            const int defaultAmount = 100;
            for (var i = 0; i < defaultAmount; i++)
            {
                MachinePurse.AddCoin(new Coin(1));
                MachinePurse.AddCoin(new Coin(2));
                MachinePurse.AddCoin(new Coin(5));
                MachinePurse.AddCoin(new Coin(10));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}