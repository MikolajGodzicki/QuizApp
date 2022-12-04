using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    [System.Serializable]
    internal class Answer
    {
        public int Number;
        public string Text;

        public Answer(int number, string text)
        {
            Number = number;
            Text = text;
        }
    }
}
