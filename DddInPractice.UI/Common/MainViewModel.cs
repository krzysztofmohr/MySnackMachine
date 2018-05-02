using DddInPractice.Logic;
using NHibernate;

namespace DddInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            SnackMachine machine;

            using (ISession session = SessionFactory.OpenSession())
            {
                machine = session.Get<SnackMachine>(1L);
            }

            var viewModel = new SnackMachineViewModel(machine);
            _dialogService.ShowDialog(viewModel);
        }
    }
}
