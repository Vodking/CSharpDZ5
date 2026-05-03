using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDZ5
{
    public class Loan
    {
        public string Name { get; set; }

        public double LoanSum { get; set; }

        public static double LoanPercentage { get; set; }

        public Loan(string name, double loanSum)
        {
            Name = name;
            LoanSum = loanSum;
        }

        public static Loan operator --(Loan loan)
        {
            return new Loan(loan.Name, loan.LoanSum * LoanPercentage);
        }

    }
}
