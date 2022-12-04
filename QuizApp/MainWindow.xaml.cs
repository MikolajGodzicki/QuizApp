using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace QuizApp {
    public partial class MainWindow : Window {
        ExcerciseLoader excerciseLoader;
        private int currentQuestionIdx;
        private int maxQuestionIdx;
        List<Excercise>? excercises;

        public static int score;
        public static int maxScore;
        public bool IsValidFile;

        private int currentCorrectAnswerNumber = 0;

        public MainWindow(string filePath) {
            excerciseLoader = new ExcerciseLoader();
            excercises = excerciseLoader.Load(filePath);
            if (excercises == null) {
                IsValidFile = false;
                return;
            }
            IsValidFile = true;
            currentQuestionIdx = 0;
            maxQuestionIdx = excercises.Count;

            score = 0;
            maxScore = excercises.Count;

            InitializeComponent();
            UpdateExcercise();
        }

        private void nextQuestionBtn_Click(object sender, RoutedEventArgs e) {
            if (answerList.SelectedIndex == -1) {
                MessageBox.Show("Proszę wybrać odpowiedź!");
                return;
            }

            Check();

            currentQuestionIdx++;
            UpdateExcercise();
        }

        private void UpdateExcercise() {
            if (currentQuestionIdx == maxQuestionIdx) {
                ScoreWindow scoreWindow = new ScoreWindow();
                scoreWindow.Show();
                this.Close();
                return;
            }

            answerList.Items.Clear();

            if (excercises != null) {
                Excercise curExcercise = excercises[currentQuestionIdx];

                // Question
                QuestionLabel.Text = $"({currentQuestionIdx + 1}/{maxQuestionIdx}) {curExcercise.question}";
                // Question

                // Answers
                List<Answer> answers = curExcercise.answers;

                foreach (Answer answer in answers) {
                    ListBoxItem listBoxItem = new ListBoxItem();
                    listBoxItem.Content = $"{answer.Number}: {answer.Text}";

                    answerList.Items.Add(listBoxItem);
                }
                // Answers

                currentCorrectAnswerNumber = curExcercise.questionAnswerNumber - 1;
            }
        }

        private void Check() {
            if (answerList.SelectedIndex == currentCorrectAnswerNumber) {
                score++;
            }
        }
    }
}
