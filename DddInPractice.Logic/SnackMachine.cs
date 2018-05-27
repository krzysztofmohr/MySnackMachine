using System;
using System.Collections.Generic;
using System.Linq;

using static DddInPractice.Logic.Money;

namespace DddInPractice.Logic
{
    public class SnackMachine : AggregateRoot
    {
        public virtual Money MoneyInside { get; protected set; } = None;
        public virtual Money MoneyInTransaction { get; protected set; } = None;
        protected virtual IList<Slot> Slots { get; set; }

        public SnackMachine()
        {
            Slots = new List<Slot>
            {
                new Slot(this, null, 0, 0, 1),
                new Slot(this, null, 0, 0, 2),
                new Slot(this, null, 0, 0, 3)
            };
        }


        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
            {
                Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
            };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public virtual void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public virtual void BuySnack(int position)
        {
            var slot = Slots.Single(x => x.Position == position);
            slot.Quantity--;

            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }

        public virtual void LoadSnacks(Snack snack, int position, int quantity, decimal price)
        {
            var slot = Slots.Single(x => x.Position == position);
            slot.Snack = snack; 
            slot.Position = position;
            slot.Quantity = quantity;
            slot.Price = price;
        }        
    }
}
