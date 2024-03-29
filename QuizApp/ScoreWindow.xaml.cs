﻿using System;
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
using System.Windows.Shapes;

namespace QuizApp {
    public partial class ScoreWindow : Window {
        public ScoreWindow() {
            InitializeComponent();
            Init();
        }

        private void Init() {
            scoreText.Text = $"{MainWindow.score}/{MainWindow.maxScore} ({CalculatePercent()})";
        }

        private string CalculatePercent() => ((decimal)MainWindow.score / MainWindow.maxScore).ToString("0.00%");
    }
}
