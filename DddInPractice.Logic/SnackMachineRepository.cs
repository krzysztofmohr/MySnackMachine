using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddInPractice.Logic
{
    public class SnackMachineRepository : Repository<SnackMachine>
    {
        public IReadOnlyList<SnackMachine> GetAllWithSnack(Snack snack) { throw new NotImplementedException(); }
        public IReadOnlyList<SnackMachine> GetAllWithMoneyInside(Money money) { throw new NotImplementedException(); }
    }
}
