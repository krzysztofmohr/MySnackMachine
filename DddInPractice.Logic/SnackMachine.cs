using System;
using System.Collections.Generic;
using System.Linq;

using static DddInPractice.Logic.Money;

namespace DddInPractice.Logic
{
    public class SnackMachine : AggregateRoot
    {
        public virtual Money MoneyInside { get; protected set; } = None;
        public virtual decimal MoneyInTransaction { get; protected set; }
        protected virtual IList<Slot> Slots { get; set; }

        public SnackMachine()
        {
            Slots = new List<Slot>
            {
                new Slot(this, 1),
                new Slot(this, 2),
                new Slot(this, 3)
            };
        }

        public SnackPile GetSnackPile(int position)
        {
            return Slots.Single(s => s.Position == position).SnackPile;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }

        public virtual void InsertMoney(Money money)
        {
            Money[] coinsAndNotes =
            {
                Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar
            };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money.Amount;
            MoneyInside += money;
        }

        public virtual void ReturnMoney()
        {
            MoneyInTransaction = 0;
        }

        public virtual void BuySnack(int position)
        {
            var slot = Slots.Single(x => x.Position == position);
            if(slot.SnackPile.Price > MoneyInTransaction) throw new InvalidOperationException();

            slot.SnackPile = slot.SnackPile.SubtractOne();
            
            MoneyInTransaction = 0;
        }

        public virtual void LoadSnacks(int position, SnackPile snackPile)
        {
            var slot = Slots.Single(x => x.Position == position);
            slot.SnackPile = snackPile;
        }        
    }
}
