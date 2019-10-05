using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(i => i.AverageGrade).Select(i => i.AverageGrade).ToList();
            if (grades[threshold-1] < averageGrade)
            {
                return 'A';
            }
            else if (grades[threshold *2- 1] < averageGrade)
            {
                return 'B';
            }
            else if (grades[threshold*3 - 1] < averageGrade)
            {
                return 'C';
            }
            else if (grades[threshold*4 - 1] < averageGrade)
            {
                return 'D';
            }
            return 'F';
        }
    }
}
