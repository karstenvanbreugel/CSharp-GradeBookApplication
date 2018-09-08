using System;
using System.Collections.Generic;
using GradeBook.GradeBooks;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            base.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException("Ranked grading requires at least 5 students.");

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            int higherCount = 0;

            foreach (Student student in base.Students)
                {
                if (student.AverageGrade > averageGrade) higherCount += 1;
                }

            if (higherCount < threshold) return 'A';
            else if (higherCount >= threshold) return 'B';
            else if (higherCount >= 2*threshold) return 'C';
            else if (higherCount >= 3*threshold) return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else base.CalculateStudentStatistics(name);
        }
    }
}
