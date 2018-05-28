namespace DddInPractice.Logic
{
    public class Slot : Entity
    {
        public virtual SnackPile SnackPile { get; protected set; }
        public virtual SnackMachine SnackMachine { get; protected set; }
        public virtual int Position { get; protected set; }

        protected Slot() {}

        public Slot(SnackMachine snackMachine, Snack snack, decimal price, int quantity, int position) : this()
        {
            SnackMachine = snackMachine;
            Snack = snack;
            Price = price;
            Quantity = quantity;
            Position = position;
        }
    }
}
