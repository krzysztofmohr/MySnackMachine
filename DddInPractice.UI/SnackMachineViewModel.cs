using DddInPractice.Logic;
using DddInPractice.UI.Common;
using NHibernate;

namespace DddInPractice.UI
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachine _snackMachine;
        public override string Caption => "Snack Machine";
        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.Amount.ToString();

        public Command InsertCentCommand { get; private set; }
        public Command InsertTenCentCommand { get; private set; }
        public Command InsertQuarterCommand { get; private set; }
        public Command InsertDollarCommand { get; private set; }
        public Command InsertFiveDollarCommand { get; private set; }
        public Command InsertTwentyDollarCommand { get; private set; }

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;

            InsertCentCommand = new Command(() => InsertMoney(Money.Cent));
            InsertTenCentCommand = new Command(() => InsertMoney(Money.TenCent));
            InsertQuarterCommand = new Command(() => InsertMoney(Money.Quarter));
            InsertDollarCommand = new Command(() => InsertMoney(Money.Dollar));
            InsertFiveDollarCommand = new Command(() => InsertMoney(Money.FiveDollar));
            InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TwentyDollar));
        }

        private void InsertMoney(Money money)
        {
            _snackMachine.InsertMoney(money);
            Notify("MoneyInTransaction");
        }
    }
}
