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
    public class TemporaryTests
    {
        [Fact]
        public void Test()
        {
            SessionFactory.Init(@"Server=.;Database=DDDInPractice;Trusted_Connection=True");

            using (var session = SessionFactory.OpenSession())
            {
                long id = 1;
                var snackMachine = session.Get<SnackMachine>(id);
            }
        }
    }

}
