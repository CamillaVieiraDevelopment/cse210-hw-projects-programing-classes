using System;

namespace Homework
{
    /// <summary>
    /// Classe derivada (filha) MathAssignment.
    /// Herda de Assignment usando ": Assignment".
    /// </summary>
    public class MathAssignment : Assignment
    {
        private string _textbookSection;
        private string _problems;

        public MathAssignment(string studentName, string topic, string textbookSection, string problems)
            : base(studentName, topic) // chama construtor da classe pai
        {
            _textbookSection = textbookSection;
            _problems = problems;
        }

        public string GetHomeworkList()
        {
            return $"Section {_textbookSection} Problems {_problems}";
        }
    }
}
