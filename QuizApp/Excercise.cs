using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    [System.Serializable]
    internal class Excercise
    {
        public int numberOfQuestion = 0;
        public string question = "None:";
        public List<Answer> answers = new List<Answer>(4);
        public int questionAnswerNumber = 0;
    }
}
