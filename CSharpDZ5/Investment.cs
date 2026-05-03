using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDZ5
{
    public class Investement
    {
        public string Name { get; set; }

        public double InvestmentSum { get; set; }

        public static double Growth { get; set; }

        public Investement(string name, double investmentSum)
        {
            Name = name;
            InvestmentSum = investmentSum;
        }

        public static Investement operator ++(Investement a)
        {
            return new Investement(a.Name, a.InvestmentSum * Growth);
        }


    }
}