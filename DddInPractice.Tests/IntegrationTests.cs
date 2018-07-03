using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DddInPractice.Logic;
using NHibernate;
using Xunit;

namespace DddInPractice.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void Test()
        {
            SessionFactory.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=True");
            var repository = new SnackMachineRepository();
            var snackMachine = repository.GetById(1);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.BuySnack(1);
            repository.Save(snackMachine);
        }
    }
}
