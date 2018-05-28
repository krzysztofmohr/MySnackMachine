using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddInPractice.Logic
{
    public sealed class SnackPile : ValueObject<SnackPile>
    {
        public Snack Snack { get; }
        public int Quantity { get; }
        public int Position { get; }

        private SnackPile() {}

        public SnackPile(Snack snack, int quantity, int position) : this()
        {
            Snack = snack;
            Quantity = quantity;
            Position = position;
        }
         
        protected override bool EqualsCore(SnackPile other)
        {
            return Snack == other.Snack
                   && Quantity == other.Quantity
                   && Position == other.Position;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashcode = Snack.GetHashCode();
                hashcode = (hashcode * 397) ^ Quantity;
                hashcode = (hashcode * 397) ^ Position;
                return hashcode;
            }
        }
    }
}
