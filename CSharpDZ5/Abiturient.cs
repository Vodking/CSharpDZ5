using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDZ5
{
    public class Abiturient
    {
        public string name { get; set; }

        public double averageGradeAtestat { get; set; }
        public double achievementGrade { get; set; }

        public Abiturient(string name, double averageGA, double achievements) 
        {
            this.name = name;
            averageGradeAtestat = averageGA;
            achievementGrade = achievements;
        }

        public static bool operator <(Abiturient a, Abiturient b)
        {
            if (a.averageGradeAtestat == b.averageGradeAtestat)
            {
                return a.achievementGrade < b.achievementGrade;
            }
            else
            {
                return a.averageGradeAtestat < b.averageGradeAtestat;
            }
        }

        public static bool operator >(Abiturient a, Abiturient b)
        {
            if (a.averageGradeAtestat == b.averageGradeAtestat)
            {
                return a.achievementGrade > b.achievementGrade;
            }
            else
            {
                return a.averageGradeAtestat > b.averageGradeAtestat;
            }
        }


        
    }
}
