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
            if (averageGrade >= grades[threshold-1])
            {
                return 'A';
            }
            else if (averageGrade >= grades[threshold *2- 1])
            {
                return 'B';
            }
            else if (averageGrade >= grades[threshold*3 - 1])
            {
                return 'C';
            }
            else if (averageGrade >= grades[threshold*4 - 1])
            {
                return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
               
            }
            base.CalculateStatistics();
        }
    }
}
