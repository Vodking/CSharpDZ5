using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDZ5
{
    public static class Checker
    {
        private static double _grade = 4.5;

        public static bool Prohod(Abiturient student)
        {
            return student.averageGradeAtestat >= _grade;
        }
    }
}
