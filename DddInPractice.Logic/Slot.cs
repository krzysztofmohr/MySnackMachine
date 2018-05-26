namespace DddInPractice.Logic
{
    public class Slot : Entity
    {
        public virtual Snack Snack { get; set; }
        public virtual SnackMachine SnackMachine { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int Position { get; set; }

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
