using System;

namespace Homework
{
    /// <summary>
    /// Classe base (pai) Assignment.
    /// Representa uma tarefa genérica de um aluno.
    /// </summary>
    public class Assignment
    {
        // Encapsulamento: variáveis privadas
        private string _studentName;
        private string _topic;

        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        public string GetStudentName()
        {
            return _studentName;
        }

        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }
    }
}
