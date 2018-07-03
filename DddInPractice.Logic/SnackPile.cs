﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddInPractice.Logic
{
    public sealed class SnackPile : ValueObject<SnackPile>
    {
        public static readonly SnackPile Empty = new SnackPile(Snack.None, 0, 0);
        public Snack Snack { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        private SnackPile() {}

        public SnackPile(Snack snack, int quantity, decimal price) : this()
        {
            if(quantity < 0)
                throw new InvalidOperationException();

            if (price < 0)
                throw new InvalidOperationException();

            Snack = snack;
            Quantity = quantity;
            Price = price;
        }

        public SnackPile SubtractOne()
        {
            return new SnackPile(Snack, Quantity - 1, Price);
        }

        protected override bool EqualsCore(SnackPile other)
        {
            return Snack == other.Snack
                   && Quantity == other.Quantity
                   && Price == other.Price;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashcode = Snack.GetHashCode();
                hashcode = (hashcode * 397) ^ Quantity;
                hashcode = (hashcode * 397) ^ Price.GetHashCode();
                return hashcode;
            }
        }
    }
}
