using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank;

public class InterestEarningAccount : BankAccount
{
    // <DerivedConstructor>
    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }
    // </DerivedConstructor>

    // <ApplyMonthendInterest>
    public override void PerformMonthEndTransactions()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.05m;
            MakeDeposit(interest, DateTime.Now, "apply monthly interest");
        }
    }
    // </ApplyMonthendInterest>
}