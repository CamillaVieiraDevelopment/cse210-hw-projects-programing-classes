using System;

namespace Homework
{
    /// <summary>
    /// Classe derivada (filha) WritingAssignment.
    /// Herda de Assignment.
    /// </summary>
    public class WritingAssignment : Assignment
    {
        private string _title;

        public WritingAssignment(string studentName, string topic, string title)
            : base(studentName, topic)
        {
            _title = title;
        }

        public string GetWritingInformation()
        {
            // Usa o método GetStudentName() da classe pai
            return $"{_title} by {GetStudentName()}";
        }
    }
}
