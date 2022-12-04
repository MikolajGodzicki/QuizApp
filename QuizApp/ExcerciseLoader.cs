//#define _TEST_

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizApp {
    internal class ExcerciseLoader {
        public List<Excercise>? Load(string filePath) {
            List<Excercise>? excersises;

            string fileContent = File.ReadAllText(filePath);
            excersises = JsonConvert.DeserializeObject<List<Excercise>>(fileContent);

            return excersises;
        }

#if _TEST_
        public void Save(string filePath) {
            List<Excercise> excersises = new List<Excercise>() {
                new Excercise() {
                    numberOfQuestion = 1,
                    question = "Podaj zmienną o typie liczbowym: ",
                    answers = {
                        new Answer(1, "int a;"),
                        new Answer(2, "integer b = 1;"),
                        new Answer(3, "liczba a = 25;"),
                        new Answer(4, "string a = 2;")
                    },
                    questionAnswerNumber = 1
                },
                new Excercise() {
                    numberOfQuestion = 2,
                    question = "Podaj zmienną o typie napisowym: ",
                    answers = {
                        new Answer(1, "int b;"),
                        new Answer(2, "nazwa b = marek;"),
                        new Answer(3, "napis a = 25;"),
                        new Answer(4, "string a = \"2\"")
                    },
                    questionAnswerNumber = 4
                },
            };

            string content = JsonConvert.SerializeObject(excersises);
            File.WriteAllText(filePath, content);
        }
#endif
    }
}
